using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class CSFileParser
    {
        List<string> FileNames = new List<string>();
        List<List<string>> Keys = new List<List<string>>();

        List<Task> tasks = new List<Task>();
        string[] Variables;

        public CSFileParser(List<string> fileNames, string[] variables)
        {
            FileNames = fileNames;
            Variables = variables;
        }

        public void BeginParseAllFilesAndGetKeys()
        {
            foreach (var f in FileNames)
            {
                var t = Task.Run(() => ParseFile(f, Variables));
                tasks.Add(t);
            }
        }

        public List<string> EndParseAllFilesAndGetKeys()
        {
            Task.WaitAll(tasks.ToArray());

            var lst = new List<string>();
            Keys.ForEach(x => lst = lst.Concat(x ?? new List<string>()).ToList());

            return lst.Distinct().ToList();
        }

        private async Task ParseFile(string fileName, string[] variables)
        {
            string file = File.ReadAllText(fileName);
            var list = new List<string>();
            foreach (var v in variables)
            {
                var regex = new Regex(v + "\\[\"(.*)\"\\]");
                var coll = regex.Matches(file);
                for (var i = 0; i < coll.Count; i++)
                    list.Add(coll[i].Groups[1].Value);
            }

            object obj = new object();
            lock (obj)
            {
                Keys.Add(list);
            }
        }
    }
}
