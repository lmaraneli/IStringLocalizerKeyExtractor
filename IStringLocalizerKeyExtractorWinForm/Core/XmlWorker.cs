using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core
{
    public class XmlWorker
    {
        List<string> ResourceFileNames;
        List<Task> tasks = new List<Task>();
        Dictionary<string, Dictionary<string, string>> resources = new Dictionary<string, Dictionary<string, string>>();

        public XmlWorker(List<string> resourceFileNames)
        {
            ResourceFileNames = resourceFileNames;
        }

        public void BeginReadAllResourceFiles()
        {
            foreach (var filename in ResourceFileNames)
            {
                var task = Task.Run(() => { ParseFile(filename); });
                tasks.Add(task);
            }
        }

        public void EndReadAllResourceFilesAsync()
        {
            Task.WaitAll(tasks.ToArray());
            tasks.Clear();
        }

        private async Task ParseFile(string FileName)
        {
            var file = File.ReadAllText(FileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(file);

            XmlNodeList dataNodes = doc.GetElementsByTagName("data");
            var dictionary = new Dictionary<string, string>();
            foreach (XmlNode n in dataNodes)
            {
                var key = n.Attributes["name"].Value;
                var value = n.SelectNodes("value").Item(0).InnerText;
                dictionary.Add(key, value);
            }

            object obj = new object();
            lock (obj)
            {
                if (!resources.ContainsKey(FileName))
                    resources.Add(FileName, dictionary);
            }
        }

        public void BeginPutKeysInFiles(List<string> keys, string saveLocation)
        {
            foreach (var f in ResourceFileNames)
            {
                var task = Task.Run(() => PutKeysInFiles(f, keys, saveLocation));
                tasks.Add(task);
            }
        }

        public void EndPutKeysInFiles()
        {
            Task.WaitAll(tasks.ToArray());
            return;
        }

        public async Task PutKeysInFiles(string filename, List<string> keys, string saveLocation)
        {
            Dictionary<string, string> dict = null;
            if (resources.ContainsKey(filename))
                dict = resources[filename];

            if (dict == null)
                return;

            var xml = File.ReadAllText(filename);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            foreach (var key in keys)
            {
                if (!dict.ContainsKey(key))
                {
                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "data", "");

                    var attr = doc.CreateAttribute("name");
                    attr.Value = key;
                    n.Attributes.Append(attr);

                    var space = doc.CreateAttribute("xml:space");
                    space.Value = "preserve";
                    n.Attributes.Append(space);

                    n.InnerXml = "<value></value>";

                    doc.DocumentElement.AppendChild(n);
                }
            }

            var fileName = filename.Substring(filename.LastIndexOf('\\') + 1);

            doc.Save(saveLocation + "\\" + fileName);
        }
    }
}
