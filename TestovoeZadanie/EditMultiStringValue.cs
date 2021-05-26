using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestovoeZadanie
{
    public partial class EditMultiStringValue : Form
    {
        private List<string> StringArray;
        RegistryKey Key;
        string ParamName;
        public EditMultiStringValue(RegistryKey key, string Param, List<string> stringArray)
        {
            InitializeComponent();
            StringArray = stringArray;
            Key = key;
            ParamName = Param;
        }

        private void EditMultiStringValue_Load(object sender, EventArgs e)
        {
            string Strings = string.Empty;
            foreach (string st in StringArray)
            {
                Strings += st + "\r\n";
            }
            textBox1.Text = Strings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] StrToSave = textBox1.Text.Split(new[] { Environment.NewLine },StringSplitOptions.None);
            StringArray.Clear();
            foreach (string st in StrToSave)
            {
                if (st != string.Empty)
                {
                    StringArray.Add(st);
                }
            }
            try
            {
                Key.SetValue(ParamName, StringArray.ToArray(), RegistryValueKind.MultiString);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Доступа для записи нет");
            }
            this.Dispose();
        }
    }
}
