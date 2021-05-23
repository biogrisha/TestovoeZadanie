using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.Services
{
    class FileLogic
    {
        List<string> filePaths;
        List<Tuple<string, string>> filePathPairs;

        public FileLogic()
        {
            PopulatePathPairs();
        }
        private void PopulatePathPairs()
        {
            filePaths = new List<string>(Directory.GetFiles(@"C:\Windows\System32"));
            filePathPairs = filePaths.Where((path) => path.Substring(path.LastIndexOf(@"\"), path.Length - path.LastIndexOf(@"\")).Contains("e"))
                .Select((path) =>
                {

                    string second = path.Substring(path.LastIndexOf(@"\") + 1, path.Length - path.LastIndexOf(@"\") - 1);
                    string first = second;
                    if (second.Length - 1 - second.IndexOf('e') >= 2)
                    {
                        second = second.Substring(second.IndexOf('e') + 1, 2);
                    }
                    else
                    {
                        second = "Две буквы не помещаются";
                    }

                    return new Tuple<string, string>(first, second);

                }).Reverse().ToList();


        }

        public void WriteToFile()
        {
            using (StreamWriter sw = File.CreateText(@"C:\Users\User\Desktop\NewDocument.txt"))
            {
                foreach (var el in filePathPairs)
                {
                    sw.WriteLine($"{el.Item1} - {el.Item2}");
                }
            }
        }
    }
}
