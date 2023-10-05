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
    public partial class mainmaster : Form
    {
        //code for disabling close button 
        private const int NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public mainmaster()
        {
            InitializeComponent();
        }

        private void mainmaster_Load(object sender, EventArgs e)
        {

            RecreateCenterForm<TDlloading_error>();
        }

        public void RecreateCenterForm<T>() where T : Form, new()
        {
            // suggested by koz6.0
            foreach (Form oldForm in Mainmasterpanel.Controls.OfType<Form>().ToArray())
            {
                using (oldForm)
                {
                    oldForm.Close();
                    Mainmasterpanel.Controls.Remove(oldForm);
                }
            }

            var newForm = new T
            {
                TopLevel = false

            };
            // Calculate the X and Y coordinates for centering the form
            int x = (Mainmasterpanel.Width - newForm.Width) / 2;
            int y = (Mainmasterpanel.Height - newForm.Height) / 2;
            //// Set the location of the form
            newForm.Location = new Point(x, y);
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.StartPosition = FormStartPosition.CenterParent;
            newForm.Anchor = AnchorStyles.None;
            newForm.ControlBox = false;
            newForm.ShowInTaskbar = false;
            //   newForm.BringToFront();

            Mainmasterpanel.Controls.Add(newForm);
            newForm.Show();
            newForm.Focus(); // sets the focus to newly form 

        }

        private void mainmaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent the user from closing the from  directly by taksbar 
            e.Cancel = true;
        }

        private void Mainmasterpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
