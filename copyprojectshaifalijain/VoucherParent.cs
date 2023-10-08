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
using copyprojectshaifalijain.helperclasses;

namespace copyprojectshaifalijain
{
    public partial class VoucherParent : blackborder_lightform
    {

        int rpos, cpos;
        private DataTable dt; 
        private DataView dataView;
        public VoucherParent()
        {
            InitializeComponent();
        }

        private void VoucherForm_Load(object sender, EventArgs e)
        {
         

            textBox3.TabStop = false;

            this.ActiveControl = textBox1; // working but reserved for later 
            textBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy", new CultureInfo("en-us"));          
            mainmaster master = (mainmaster)this.Parent.FindForm();
            master.CurrentForm.Text = "Accounting Voucher Creation";

 
            var settings = copyprojectshaifalijain.Properties.Settings.Default;
            string lastForm = settings.Lastform; 
           
            switch (lastForm)
            {
                case "Sales":
                    this.BackColor = Color.FromArgb(227, 220, 192);
                    this.VoucherType.Text = "Sales";
                    this.label1.Text = "Reference no.:";
                    label2.Hide();
                    textBox2.Hide();
                    break;
                default:
                    this.BackColor = Color.FromArgb(250, 243, 198);
                    this.VoucherType.Text = "Purchase";
                    this.label1.Text = "Supplier Invoice no.:";
                    label2.Show();
                    textBox2.Show();
                    break;
            }
            dt = new DataTable();
            dataGridView1.DataSource = dt = connectionlogics.FillDataGridView($"SELECT * FROM ledgernames").Tables[0];
           // dataGridView1.ExpandColumns();
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false; // needed to remove last default row
            dataGridView1.ReadOnly = true;
            dataGridView1.BackgroundColor = Color.FromArgb(211, 241, 213);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(211, 241, 213);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128,128,128);
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["opening_balance"].Visible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.TabStop = false;
            //  rpos = dataGridView1.CurrentCell.RowIndex;
            //   cpos = dataGridView1.CurrentCell.ColumnIndex;
            dataGridView1.Visible = false;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void VoucherParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = copyprojectshaifalijain.Properties.Settings.Default;
            settings.Lastform = VoucherType.Text;
            settings.Save();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox4.Text.Trim();
            dataView = dt.DefaultView;

            if (searchText.Length > 0) // strings
            {
                dataView.RowFilter = $"name LIKE '%{searchText}%'";
                if (dataView.Count == 0) // check if no rows match the filter
                {
                    searchText = searchText.Substring(0, searchText.Length - 1);
                    textBox4.Text = searchText;
                }
                else
                {

                  //  dataGridView1.DataSource = dataView;
                }
            }
            else if(searchText.Length == 0)
            {
                dataView.RowFilter = null;
               // dataGridView1.DataSource = dt.DefaultView;
            }
            textBox4.Select(textBox4.Text.Length, 0); // Set cursor at the end
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            dataGridView1.Visible = true; 
           dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.Rows[e.RowIndex].Selected)
            {
                // use both italic and bold
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic);

                // edit: to change the background color:
                //e.CellStyle.SelectionBackColor = Color.Coral;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //code for results up and down in popup datagridview
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            else
            {
                rpos = dataGridView1.CurrentCell.RowIndex;
                cpos = dataGridView1.CurrentCell.ColumnIndex;

                switch (e.KeyCode)
                {
                    case Keys.Up:

                        rpos--;
                        if (rpos >= 0) dataGridView1.CurrentCell = dataGridView1.Rows[rpos].Cells[cpos];
                        e.Handled = true;
                        break;
                    case Keys.Down:

                        rpos++;
                        if (rpos < dataGridView1.Rows.Count) dataGridView1.CurrentCell = dataGridView1.Rows[rpos].Cells[cpos];
                        e.Handled = true;
                        break;
                    case Keys.Enter:
                        {
                            if (dataGridView1.Rows.Count > 0)
                            {
                                dataGridView1.Visible = false;
                                textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                                sale_purchase_datagridview1.Focus();

                            
                                // below 2 lines i already add in OnEnter method of customcontrol
                                // customControl11.CurrentCell = customControl11.Rows[0].Cells[0]; // Select the first cell                                
                                //  customControl11.BeginEdit(true);
                                dataView.RowFilter = ""; // resets the filter to its starting state 
                            }
                            e.Handled = e.SuppressKeyPress = true;
                            break;
                        }
                }
            }
        }
    }
}
