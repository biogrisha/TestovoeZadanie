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
    public partial class EditBinaryValue : Form
    {
        private List<byte> ByteArray;
        RegistryKey Key;
        string ParamName;
        public EditBinaryValue(RegistryKey key, string Param, List<byte> byteArray)
        {
            InitializeComponent();
            ByteArray = byteArray;
            Key = key;
            ParamName = Param;
        }

        private void EditBinaryValue_Load(object sender, EventArgs e)
        {
            PopulateTextBox();
        }

        private void PopulateTextBox()
        {
            string Bytes = string.Empty;
            foreach (byte bt in ByteArray)
            {
                Bytes += bt.ToString();
            }
            textBox1.Text = Bytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var charBytes = textBox1.Text.ToCharArray();
            ByteArray.Clear();
            foreach (char bt in charBytes)
            {
                ByteArray.Add(Convert.ToByte(bt));
            }
            try
            {
                Key.SetValue(ParamName, ByteArray.ToArray(), RegistryValueKind.Binary);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Dispose();
        }
    }
}
