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
    public partial class login : blackborder_lightform
    {
        public login()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Enter) )
            {
               if(textBox1.Text != string.Empty && textBox2.Text !=string.Empty)
                {
                    mainmaster master = (mainmaster)this.Parent.FindForm();
                    master.RecreateCenterForm<VoucherParent>();
                }
                return true;
            }
            else if ( keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void login_Load(object sender, EventArgs e)
        {
          
            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.CurrentForm.Text = "LOGIN";
            label1.Text += "Dummy";
            this.ActiveControl = textBox1;
        }
    }
}
