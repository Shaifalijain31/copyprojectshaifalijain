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
    public partial class MainExitForm : blackborder_lightform
    {

        readonly List<Control> enabledList = new List<Control>();
        /// <summary>
        ///  closing the form slowly be reducing opacity and then making disappear 
        /// </summary>
        public MainExitForm()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
         
            if (keyData == (Keys.Enter) || keyData == (Keys.Y))
            {
                timer1.Start();
                return true;
            }
            else if (keyData == (Keys.N) || keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        protected override void OnShown(EventArgs e)
        {
            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //foreach (Control c in enabledList)
            //{
            //    c.Enabled = false;
            //}
            //base.OnFormClosed(e);
        }
        private void MainExitForm_Load(object sender, EventArgs e)
        {
            button3.Left = -120;
            button1.TabStop = false;
            button2.TabStop = false;
            //base.OnShown(e);
            //if (Owner != null)
            //{
            //    foreach (Control c in Owner.Controls)
            //    {
            //        if (c.Enabled)
            //        {
            //            c.Enabled = true;
            //            enabledList.Add(c);
            //        }
            //    }
            //}
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.07;
            }
            else
            {
                timer1.Stop();
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
