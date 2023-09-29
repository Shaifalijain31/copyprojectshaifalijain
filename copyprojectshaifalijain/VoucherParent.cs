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
    public partial class VoucherParent : blackborder_lightform
    {
        public VoucherParent()
        {
            InitializeComponent();
        }

        private void VoucherForm_Load(object sender, EventArgs e)
        {

            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.CurrentForm.Text = "Accounting Voucher Creation";
            //if ()
            //{
            //    this.BackColor = Color.FromArgb(227,220,192);
            //    this.VoucherType.Text = "Sales";
            //    this.label1.Text = "Reference no.:";
            //    label2.Hide();
            //    textBox2.Hide();

            //}
            //else if ()
            //{
            //    this.BackColor = Color.FromArgb(250,43,198);
            //    this.VoucherType.Text = "Purchase";
            //    this.label1.Text = "Supplier Invoice no.:";
            //    label2.Show();
            //    textBox2.Show();

            //}



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
