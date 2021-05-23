using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestovoeZadanie.Services;
using TestovoeZadanie.UserControls;

namespace TestovoeZadanie
{
    public partial class Form1 : Form
    {
        FileSystemRepresentation _fileSystemRepreesentation;
        FileLogic _fileLogic;
        TimeWatch _timeWatch;
        public Form1()
        {
            InitializeComponent();
            _fileSystemRepreesentation = new FileSystemRepresentation(@"C:\Users\User\");
            _fileLogic = new FileLogic();
            _timeWatch = new TimeWatch();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureControls();
            SetDirectory();

        }
        private async void ConfigureControls()
        {
            flowLayoutForFiles1.ContextMenuStrip = contextMenuStrip1;

            MenuCreateItem.Click += MenuCreateItem_Click;
            MenuDeleteItem.Click += MenuDeleteItem_Click;
            textBox1.ReadOnly = true;
            textBox1.Text = await Task.Run(() => _timeWatch.timeTicker());

        }

        private void MenuDeleteItem_Click(object sender, EventArgs e)
        {
            var fileInfo = ((FileIconControl)(flowLayoutForFiles1.SelectedControl))?.Info;
            try
            {
                if (fileInfo != null)
                {
                    if (fileInfo is FileInfo)
                    {
                        File.Delete(fileInfo.FullName);
                    }
                    else if (fileInfo is DirectoryInfo)
                    {
                        Directory.Delete(fileInfo.FullName);
                    }

                    flowLayoutForFiles1.Controls.Remove(flowLayoutForFiles1.SelectedControl);
                    flowLayoutForFiles1.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Выберите файл для удаления");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuCreateItem_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(_fileSystemRepreesentation.DirectoryPath + @"New Folder\");
            _fileSystemRepreesentation.Reload();
            SetDirectory();
        }

        private void SetDirectory()
        {
            treeView1.Nodes.Clear();
            _fileSystemRepreesentation.PopulateControlWithFiles(FileSystemRepresentation.FileSystemEntities.Directory, (fileSystemInfo) =>
            {
                treeView1.Nodes.Add(fileSystemInfo.Name, fileSystemInfo.Name, 1, 1);

            });
            flowLayoutForFiles1.Controls.Clear();
            _fileSystemRepreesentation.PopulateControlWithFiles(FileSystemRepresentation.FileSystemEntities.Directory, (fileSystemInfo) =>
            {
                FileIconControl userControl = new FileIconControl() { Info = fileSystemInfo, FileImage = Properties.Resources.folder_invoices__v2 };
                userControl.DoubleClick += UserControl_DoubleClick;
                flowLayoutForFiles1.Controls.Add(userControl);

            });
            _fileSystemRepreesentation.PopulateControlWithFiles(FileSystemRepresentation.FileSystemEntities.File, (fileSystemInfo) =>
            {
                FileIconControl userControl = new FileIconControl() { Info = fileSystemInfo, FileImage = Properties.Resources.iconfinder_file_227587 };
                userControl.DoubleClick += UserControl_DoubleClick;
                flowLayoutForFiles1.Controls.Add(userControl);

            });
            flowLayoutForFiles1.ClearSelection();


        }

        private void UserControl_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                var fileInfo = ((FileIconControl)(flowLayoutForFiles1.SelectedControl)).Info;
                if (fileInfo is FileInfo)
                {
                    Process.Start("C:\\Windows\\System32\\notepad.exe", fileInfo.FullName);
                    return;
                }
                _fileSystemRepreesentation.DirectoryPath = ((FileIconControl)sender).FilePath + @"\";
                SetDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                _fileSystemRepreesentation.DirectoryPath = _fileSystemRepreesentation.DirectoryPath + treeView1.SelectedNode.Text + @"\";
                SetDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            string filePath = _fileSystemRepreesentation.DirectoryPath;
            try
            {
                string tempPath = filePath;
                tempPath = tempPath.Substring(0, tempPath.LastIndexOf(@"\"));
                tempPath = tempPath.Substring(0, tempPath.LastIndexOf(@"\") + 1);
                _fileSystemRepreesentation.DirectoryPath = tempPath;
                SetDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _fileSystemRepreesentation.DirectoryPath = filePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fileLogic.WriteToFile();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = await Task.Run(() => _timeWatch.timeTicker());

        }
    }
}
