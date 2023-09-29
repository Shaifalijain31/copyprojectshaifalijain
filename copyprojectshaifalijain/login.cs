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

        private void login_Load(object sender, EventArgs e)
        {
            // Access the parent form
           // Form parent = (Form)this.Owner;
         //  Label label = this.Parent.Labels["Label1"];
            parent.CurrentForm.Text = "";
            label1.Text += "Dummy";
            this.ActiveControl = textBox1;
        }
    }
}
