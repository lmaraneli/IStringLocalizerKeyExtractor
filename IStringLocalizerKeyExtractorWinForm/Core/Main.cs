using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Main
    {
        readonly string Path;
        readonly string ResourcePath;
        readonly string[] Variables;
        readonly string SaveLocation;

        List<string> FileNames = new List<string>();
        List<string> ResouceFileNames = new List<string>();

        public Main(string path, string resourcePath, string saveLocation, params string[] variables)
        {
            this.Path = path; this.ResourcePath = resourcePath; Variables = variables;
            SaveLocation = saveLocation;
        }

        public int ProcessFiles()
        {
            var task1 = Task.Run(() => { GetAllFileNames(); });
            var task2 = Task.Run(() => { GetAllResourceFilesNames(); });

            Task.WaitAll(task2);

            var xmlWorker = new XmlWorker(ResouceFileNames);
            xmlWorker.BeginReadAllResourceFiles();

            Task.WaitAll(task1);

            var fileParser = new CSFileParser(FileNames, Variables);
            fileParser.BeginParseAllFilesAndGetKeys();

            xmlWorker.EndReadAllResourceFilesAsync();

            var keys = fileParser.EndParseAllFilesAndGetKeys();

            xmlWorker.BeginPutKeysInFiles(keys, SaveLocation);

            xmlWorker.EndPutKeysInFiles();

            return 1;
        }

        private async Task GetAllFileNames()
        {
            DirectoryInfo d = new DirectoryInfo(Path);
            FileInfo[] files = d.GetFiles("*.cs").Concat(d.GetFiles("*.cshtml")).ToArray();
            foreach (var f in files)
            {
                FileNames.Add(f.FullName);
            }

            var subDirectories = d.GetDirectories();

            foreach (var dir in subDirectories)
                GetFileNamesWithinDirectory(dir);
        }

        private void GetFileNamesWithinDirectory(DirectoryInfo d)
        {
            FileInfo[] files = d.GetFiles("*.cs").Concat(d.GetFiles("*.cshtml")).ToArray(); ;
            foreach (var f in files)
            {
                FileNames.Add(f.FullName);
            }

            var subDirectories = d.GetDirectories();

            foreach (var dir in subDirectories)
                GetFileNamesWithinDirectory(dir);
        }

        private async Task GetAllResourceFilesNames()
        {
            DirectoryInfo d = new DirectoryInfo(ResourcePath);
            FileInfo[] files = d.GetFiles("*.resx");
            foreach (var f in files)
            {
                ResouceFileNames.Add(f.FullName);
            }
        }
    }
}
