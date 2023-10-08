using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain
{
    public partial class sale_purchase_datagridview : DataGridView
    {
        private SqlConnection con;
        private SqlDataAdapter da;
        private DataTable dt, dt2;
        private DataSet dataSet;
        private DataView dataView;
        public sale_purchase_datagridview()
        {
           // this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Sizing the column header's 
            this.BackgroundColor = Color.FromArgb(250, 243, 198);
            this.RowsDefaultCellStyle.BackColor = Color.FromArgb(250, 243, 198);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 201, 170); // full row select color 
            this.RowHeadersVisible = false;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.ScrollBars = ScrollBars.None;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.RowTemplate.Height = 30;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold); // HEADER FONT BOLD 

            // var column = this.Columns.GetLastColumn(DataGridViewElementStates.Visible,
            //                    DataGridViewElementStates.None);
            //  column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InitializeComponent();
           
        }
        protected override void OnEnter(EventArgs e)
        {           
            this.CurrentCell = this.Rows[0].Cells[0];
            this.BeginEdit(true);  
            base.OnEnter(e);
        }

        // MY 5th column should always be readonly
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            //if (e.Column.Index == 5)
            //{
            //    e.Column.ReadOnly = true;
            //}
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {

            e.CellStyle.BackColor = Color.FromArgb(0, 0, 0); // change cell color to black 
            e.CellStyle.ForeColor = Color.FromArgb(255, 255, 255); // change cell color to white  
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic);

            //    e.Control.KeyPress -= new KeyPressEventHandler(textbox_keypress);
            //    e.Control.TextChanged -= new EventHandler(TextBox_TextChanged);
            //    e.Control.KeyDown -= new KeyEventHandler(TextBox_KeyDown);
            //    e.Control.Enter -= new EventHandler(TextBox_Enter);
            //    if (this.CurrentCell.ColumnIndex == 1 || this.CurrentCell.ColumnIndex == 2) // Assuming the first column has an index of 0
            //    {
            //        TextBox textBox = e.Control as TextBox;
            //        if (textBox != null)
            //        {
            //            textBox.KeyPress += new KeyPressEventHandler(textbox_keypress);
            //        }
            //    }

            //    else if (this.CurrentCell.ColumnIndex == 0) // Assuming the first column has an index of 0
            //    {
            //        TextBox textBox = e.Control as TextBox;
            //        if (textBox != null)
            //        {
            //            textBox.TextChanged += TextBox_TextChanged; // Attach TextChanged event handler
            //            textBox.KeyDown += TextBox_KeyDown; // Attach KeyDown event handler
            //            textBox.Enter += TextBox_Enter;
            //        }
            //    }
            base.OnEditingControlShowing(e);
        }

        //private void TextBox_Enter(object sender, EventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //   if (this.CurrentCell.ColumnIndex > 0)
        //        return;

        //    dataGridView1.Visible = true;
        //    dataGridView1.Datasource = something 
        //    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        //}
        //private void textbox_keypress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void TextBox_TextChanged(object sender, EventArgs e)
        //{

        //    if (this.CurrentCell.ColumnIndex == 0) // Assuming the first column has an index of 0
        //    {
        //        TextBox textBox = (TextBox)sender;
        //        string searchText = textBox.Text.Trim();
        //        dataView = dataSet.Tables[0].DefaultView;

        //        if (searchText.Length > 0) // strings
        //        {
        //            dataView.RowFilter = $"name LIKE '%{searchText}%'";
        //            if (dataView.Count == 0) // check if no rows match the filter
        //            {
        //                searchText = searchText.Substring(0, searchText.Length - 1);
        //                textBox.Text = searchText;
        //            }
        //            else
        //            {


        //            }
        //        }
        //        else
        //        {

        //            dataView.RowFilter = null;
        //        }
        //        textBox.Select(textBox.Text.Length, 0); // Set cursor at the end
        //    }
        //}



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //MessageBox.Show("ProcessCmdKey");
            //if((keyData==(Keys.Control | Keys.S)))
            //{
            //    // save data
            //}

            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            //MessageBox.Show("ProcessDataGridViewKey");
            //switch (e.KeyCode)
            //{
            //    case Keys.Tab:
            //    case Keys.Right:
            //    case Keys.Enter:
            //        {
            //            return base.ProcessTabKey(e.KeyData);
            //        }
            //    case Keys.Up:
            //        {
            //            return base.ProcessUpKey(e.KeyData);
            //        }
            //    case Keys.Down:
            //        {
            //            return base.ProcessDownKey(e.KeyData);
            //        }
             
            //    case Keys.Left:
            //        {
            //            return base.ProcessLeftKey(e.KeyData);
            //        }
             
            
            //    case Keys.Delete:
            //        {
            //            return base.ProcessDeleteKey(e.KeyData);
            //        }
               
            //    case Keys.Escape:
            //        {
            //            return base.ProcessEscapeKey(e.KeyData);
            //        }
               
            //}


            return base.ProcessDataGridViewKey(e);
        }

        private void sale_purchase_datagridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle r = e.CellBounds;
                r.X -= 2;

                // Check if it's the first column
                if (e.ColumnIndex == 0)
                { // Adjust the padding for the first column
                    r.X += 4;

                    // Align the text to the right for the first column
                    TextRenderer.DrawText(e.Graphics, this.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, r, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    // Align the text to the left for other columns
                    TextRenderer.DrawText(e.Graphics, this.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, r, e.CellStyle.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }

                // Draw top double border
                int topBorderThickness = 3; // Set the thickness of the top border
                int bottomBorderThickness = 1; // Set the thickness of the bottom border
                int x = e.CellBounds.Left;
                int yTop = e.CellBounds.Top;
                int yBottom = e.CellBounds.Bottom - bottomBorderThickness;
                int width = e.CellBounds.Width;
                using (Pen topBorderPen = new Pen(Color.Black, topBorderThickness))
                using (Pen bottomBorderPen = new Pen(Color.Black, bottomBorderThickness))
                {
                    // Draw top border
                    e.Graphics.DrawLine(topBorderPen, x, yTop, x + width, yTop);

                    // Draw bottom border
                    e.Graphics.DrawLine(bottomBorderPen, x, yBottom, x + width, yBottom);
                }

                //    // 


                e.Handled = true;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

    }
}
