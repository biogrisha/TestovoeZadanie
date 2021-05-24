using Microsoft.Win32;
using System;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace TestovoeZadanie.Services
{
    class Regedit
    {
        TreeView treeView1;
        Control Form;
        TreeNode selectedNode;
        RegistryKey[] RootKeys = new RegistryKey[]
            {
                Registry.CurrentUser,
                Registry.LocalMachine,
                Registry.Users,
                Registry.CurrentConfig,
                Registry.ClassesRoot

            };
        public Regedit(TreeView treeView, Control form)
        {
            treeView1 = treeView;
            treeView1.BeforeExpand += TreeView1_BeforeExpand;

            treeView.HideSelection = true;
            Form = form;
        }



        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            selectedNode = e.Node;
            PopulateNode();
        }
        public void PopulateNode()
        {
            new Thread(AppendNodes).Start();
        }
        public void PopulateWithKeys()
        {
            foreach (var key in RootKeys)
            {
                var node = treeView1.Nodes.Add(key.Name);
                node.Tag = key;
                if (key.SubKeyCount > 0)
                {
                    node.Nodes.Add("empty");
                }
            }


        }

        
        public void AppendNodes()
        {
            if (Form.InvokeRequired)
            {
                Form.Invoke(new Action(AppendNodes));
                return;
            }
            var node = selectedNode;
            if (node.Nodes.Count < 2)
            {
                node.Nodes.Clear();
                var Key = (RegistryKey)(node.Tag);
                var Keys = ((RegistryKey)(node.Tag)).GetSubKeyNames();
                foreach (var keyName in Keys)
                {
                    RegistryKey newKey = null;
                    var newNode = node.Nodes.Add(keyName);
                    try
                    {
                        newKey = Key.OpenSubKey(keyName);
                        newNode.Tag = newKey;

                    }
                    catch (SecurityException ex)
                    {

                    }
                    if (newKey?.SubKeyCount != null && newKey.SubKeyCount > 0)
                    {
                        newNode.Nodes.Add("empty");
                    }

                }
            }
        }


    }
}
