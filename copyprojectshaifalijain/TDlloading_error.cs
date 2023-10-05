using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain
{
    public partial class TDlloading_error : blackborder_lightform
    {
        public TDlloading_error()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // if the user presses escape a mainexit form should open asking for exit 
            if (keyData == (Keys.Escape))
            {
               
                formbackground formBackground = new formbackground(this);
                mainmaster main = (mainmaster)this.Parent.FindForm();
                Panel mainmasterpanel = main.Mainmasterpanel;
                Rectangle bounds = mainmasterpanel.Parent.RectangleToScreen(mainmasterpanel.Bounds);
                Point panelLocation = mainmasterpanel.Location;
                Point screenLocation = mainmasterpanel.PointToScreen(panelLocation);            
                formBackground.Location = screenLocation;
                formBackground.Bounds = bounds;            
                formBackground.Show(this);
                using (MainExitForm mx = new MainExitForm())
                {
                    mx.StartPosition = FormStartPosition.CenterParent;
                    mx.ShowInTaskbar = false;
                    mx.ShowDialog(formBackground);
                    if(mx.DialogResult == DialogResult.Cancel)
                    {
                        formBackground.Close();
                    }
                }                
               
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                RecreateCenterForm<login>();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void RecreateCenterForm<T>() where T : Form, new()
        {
            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.RecreateCenterForm<T>();
          
        }       
        private void TDlloading_error_Load(object sender, EventArgs e)
        {
            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.CurrentForm.Text = "TDL Loading Error";
            HideButtonsInParentFormTableLayoutPanel();
        }
        private void HideButtonsInParentFormTableLayoutPanel()
        {
            // Access the parent form
            Form parentForm = this.Parent.FindForm();

            // Check if the parent form exists and contains a TableLayoutPanel
            if (parentForm != null && parentForm.Controls.ContainsKey("tableLayoutPanel1"))
            {
                TableLayoutPanel tableLayoutPanel = parentForm.Controls["tableLayoutPanel1"] as TableLayoutPanel;

                // Hide the buttons in the TableLayoutPanel
                if (tableLayoutPanel != null)
                {
                    foreach (Control control in tableLayoutPanel.Controls)
                    {
                        if (control is Button button)
                        {
                            button.Visible = false;
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
