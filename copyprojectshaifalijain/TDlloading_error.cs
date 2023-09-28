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
            Form formBackground = new Form();
            Panel P = this.Parent as Panel;
            if (keyData == (Keys.Escape))
            {
                // try to create blur form 
                //formBackground.StartPosition = FormStartPosition.Manual;
                //formBackground.FormBorderStyle = FormBorderStyle.None;
                //formBackground.Opacity = .50d;
                //formBackground.BackColor = Color.Black;
                //formBackground.WindowState = FormWindowState.Maximized;
                //formBackground.TopMost = true;
                //formBackground.Location = this.Location;
                //formBackground.ShowInTaskbar = false;
                //formBackground.Show();
                //MainExitForm mx = new MainExitForm();
                //mx.Owner = formBackground;
                //mx.ShowDialog();

                //formBackground.Dispose();
                ////this.Close();
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
            //Panel P = this.Parent as Panel;

            //if (P != null)
            //{
            //    foreach (Form oldForm in P.Controls.OfType<Form>().ToArray())
            //    {
            //        using (oldForm)
            //        {
            //            oldForm.Close();
            //            P.Controls.Remove(oldForm);
            //        }
            //    }

            //    var newForm = new T
            //    {
            //        TopLevel = false,
            //       // Visible = true 
            //    };
            //    // Calculate the X and Y coordinates for centering the form
            //    int x = (P.Width - newForm.Width) / 2;
            //    int y = (P.Height - newForm.Height) / 2;
            //    // Set the location of the form
            //    newForm.Location = new Point(x, y);
            //    newForm.FormBorderStyle = FormBorderStyle.None;
            //    newForm.StartPosition = FormStartPosition.CenterParent;
            //    newForm.Anchor = AnchorStyles.None;
            //    newForm.ControlBox = false;
            //    newForm.ShowInTaskbar = false;
            //    //  newForm.BringToFront(); // no need as there is no previous form left to overlap the current form 
            //     P.Controls.Add(newForm);
            //    newForm.Show();
            //    newForm.Focus();

            //}

        }
        private void TDlloading_error_Load(object sender, EventArgs e)
        {

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
    }
}
