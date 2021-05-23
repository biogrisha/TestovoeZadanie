using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestovoeZadanie.UserControls
{
    class FlowLayoutForFiles:FlowLayoutPanel
    {
        UserControl selectedControl = null;
        public FlowLayoutForFiles()
        {
            base.ControlAdded += FlowLayoutForFiles_ControlAdded;
        }

        public UserControl SelectedControl 
        {
            get 
            {
                return selectedControl;
            }
        }
        
        public void ClearSelection()
        {
            selectedControl = null;
        }

        private void FlowLayoutForFiles_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.GotFocus += Control_GotFocus;
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            selectedControl = (UserControl)sender;
        }
    }
}
