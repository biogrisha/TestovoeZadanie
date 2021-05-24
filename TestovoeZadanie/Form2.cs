using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestovoeZadanie
{
    public partial class Form2 : Form
    {
        RegistryKey registryKey;
        public Form2(RegistryKey key)
        {
            InitializeComponent();
            registryKey = key;
        }

        public Form2(RegistryKey key,string Param, string Value)
        {
            InitializeComponent();
            registryKey = key;
            ParamTextBox.Text = Param;
            ValueTextBox.Text = Value;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                registryKey.SetValue(ParamTextBox.Text, ValueTextBox.Text);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Dispose();
            
        }
    }
}
