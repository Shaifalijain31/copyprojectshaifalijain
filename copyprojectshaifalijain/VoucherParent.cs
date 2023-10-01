using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain
{
    public partial class VoucherParent : blackborder_lightform
    {
        public VoucherParent()
        {
            InitializeComponent();
        }

        private void VoucherForm_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo("en-us"));          
            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.CurrentForm.Text = "Accounting Voucher Creation";


            // @koz6.0 help needed , i have only one form 
            // 
            var settings = copyprojectshaifalijain.Properties.Settings.Default;
            string lastForm = settings.Lastform; 
           
            switch (lastForm)
            {
                case "Sale":
                    this.BackColor = Color.FromArgb(227, 220, 192);
                    this.VoucherType.Text = "Sales";
                    this.label1.Text = "Reference no.:";
                    label2.Hide();
                    textBox2.Hide();
                    break;
                default:
                    this.BackColor = Color.FromArgb(250, 43, 198);
                    this.VoucherType.Text = "Purchase";
                    this.label1.Text = "Supplier Invoice no.:";
                    label2.Show();
                    textBox2.Show();
                    break;
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
