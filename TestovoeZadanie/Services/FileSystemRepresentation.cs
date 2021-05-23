using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.Services
{
    class FileSystemRepresentation
    {
        public enum FileSystemEntities
        {
            File,
            Directory
        }

        private string directoryPath;
        List<string> filesInDirectory;
        List<string> directoriesInDirectory;

        public delegate void PopulateControl(FileSystemInfo fileInfo);

        public FileSystemRepresentation(string path)
        {
            DirectoryPath = path;
        }

        public string DirectoryPath
        {
            get
            {
                return directoryPath;
            }
            set
            {
                directoryPath = value;
                SetEntitiesInDirectory();
            }
        }
        public void PopulateControlWithFiles(FileSystemEntities type, PopulateControl populateControl)
        {
            List<string> currentEntity;
            Type fileSystemInfoType;

            switch (type)
            {
                case FileSystemEntities.File:
                    currentEntity = filesInDirectory;
                    fileSystemInfoType = typeof(FileInfo);
                    break;
                case FileSystemEntities.Directory:
                    currentEntity = directoriesInDirectory;
                    fileSystemInfoType = typeof(DirectoryInfo);
                    break;
                default:
                    fileSystemInfoType = null;
                    currentEntity = null;
                    break;

            }

            foreach (string path in currentEntity)
            {
                FileSystemInfo fileSystemInfo = (FileSystemInfo)Activator.CreateInstance(fileSystemInfoType, path);
                populateControl.Invoke(fileSystemInfo);
            }
        }

        internal void Reload()
        {
            SetEntitiesInDirectory();
        }

        private void SetEntitiesInDirectory()
        {
            filesInDirectory = new List<string>(Directory.GetFiles(directoryPath));
            directoriesInDirectory = new List<string>(Directory.GetDirectories(directoryPath));
        }

    }
}
