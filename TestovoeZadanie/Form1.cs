using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestovoeZadanie.DataModels;
using TestovoeZadanie.Services;

namespace TestovoeZadanie
{
    public partial class Form1 : Form
    {
        FileLogic _fileLogic;
        TimeWatch _timeWatch;
        Regedit _regedit;
        public Form1()
        {
            InitializeComponent();
            _fileLogic = new FileLogic();
            _timeWatch = new TimeWatch();
            _regedit = new Regedit(treeView1, this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureControls();
            _regedit.PopulateWithKeys();
        }
        private void ConfigureControls()
        {
            textBox1.ReadOnly = true;
            new Thread(SampleFunction).Start();

            DeleteMenuItem.Click += DeleteMenuItem_Click;
            AddMenuItem.Click += AddMenuItem_Click;
            EditMenuItem.Click += EditMenuItem_Click;

        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            var Key = (RegistryKey)(treeView1.SelectedNode.Tag);
            if (listBox1.SelectedItem != null)
            {
                if (Key.GetValueKind(listBox1.SelectedItem.ToString()) == RegistryValueKind.Binary)
                {
                    var KeyValue = Key.GetValue(listBox1.SelectedItem.ToString());
                    List<byte> byteArray = new List<byte>((byte[])KeyValue);
                    EditBinaryValue editByteForm = new EditBinaryValue(Key, listBox1.SelectedItem.ToString(), byteArray);
                    editByteForm.Show();
                }
                else if (Key.GetValueKind(listBox1.SelectedItem.ToString()) == RegistryValueKind.MultiString)
                {
                    var KeyValue = Key.GetValue(listBox1.SelectedItem.ToString());
                    EditMultiStringValue form = new EditMultiStringValue(Key, listBox1.SelectedItem.ToString(), new List<string>((string[])KeyValue));
                    form.Show();

                }
                else
                {
                    Form2 form = new Form2(Key, listBox1.SelectedItem.ToString(), (Key.GetValue(listBox1.SelectedItem.ToString()))?.ToString() ?? string.Empty);
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Выберите параметр");
            }

        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            var Key = (RegistryKey)(treeView1.SelectedNode.Tag);
            Form2 form = new Form2(Key);
            form.Show();
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            var Item = (ListViewItemContainer)(listBox1.SelectedItem);
            if (Item != null)
            {
                Item.registryKey.DeleteValue(Item.Name);
            }
            UpdateRegistries(treeView1.SelectedNode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fileLogic.WriteToFile();
        }



        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            UpdateRegistries(e.Node);
        }

        private void UpdateRegistries(TreeNode treeNode)
        {
            listBox1.Items.Clear();
            var Key = (RegistryKey)(treeNode.Tag);
            string[] valueNames = Key?.GetValueNames();
            if (valueNames != null)
            {
                foreach (string name in valueNames)
                {

                    listBox1.Items.Add(new ListViewItemContainer() { Name = name, registryKey = Key });

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRegistries(treeView1.SelectedNode);
        }
        public void SetTime(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetTime), new object[] { value });
                return;
            }
            textBox1.Text = value;
        }

        void SampleFunction()
        {
            // Gets executed on a seperate thread and 
            // doesn't block the UI while sleeping
            while (true)
            {
                SetTime(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

    }
}
