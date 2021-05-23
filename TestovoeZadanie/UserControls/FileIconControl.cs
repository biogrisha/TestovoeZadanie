using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestovoeZadanie.UserControls
{
    public partial class FileIconControl : UserControl
    {
        private bool isSelected = false;
        public event EventHandler<EventArgs> WasClicked;
        FileSystemInfo fileInfo;
        public FileIconControl()
        {
            InitializeComponent();
        }
        public bool IsSelected 
        {
            get
            {
                return isSelected;
            }
            set
            {
                if(value == true)
                {
                    this.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    this.BorderStyle = BorderStyle.None;
                }
                isSelected = value;
            }
        }

        public FileSystemInfo Info
        {
            get
            {
                return fileInfo;
            }
            set 
            {
                FileNameLable.Text = value.Name;
                FileRootLable.Text = value.FullName;
                FilePath = value.FullName;
                fileInfo = value;
            }
        }

        public Bitmap FileImage
        {
            set
            {
                FilePic.BackgroundImage = value;
            }
        }

        public string FilePath { get; private set; }

        private void FileIconControl_Enter(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void FileIconControl_Leave(object sender, EventArgs e)
        {
            IsSelected = false;
        }

        private void FireClickEvent()
        {
            var wasClicked = WasClicked;
            if (wasClicked != null)
            {
                WasClicked(this, EventArgs.Empty);
            }
            IsSelected = true;
        }
    }
}
