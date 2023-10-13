using copyprojectshaifalijain.helperclasses;
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
        // suggested by gezza 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public DataGridView LinkDataGridView { get; set; }

        private DataTable  dt2;        
        private DataView dataView;
        DataGridView dgv;
        int rpos, cpos;
         
        public sale_purchase_datagridview()
        {
            // this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Sizing the column header's 
            //   this.BackgroundColor = Color.FromArgb(250, 243, 198);
            //   this.RowsDefaultCellStyle.BackColor = Color.FromArgb(250, 243, 198);
            //   this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 201, 170); // full row select color 
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            this.RowHeadersVisible = false;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.ScrollBars = ScrollBars.None;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.RowTemplate.Height = 30;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold); // HEADER FONT BOLD 
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //var column = this.Columns.GetLastColumn(DataGridViewElementStates.Visible,
            //                   DataGridViewElementStates.None);
            // column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dt2 = new DataTable();
            
            InitializeComponent();
           
        }

      

        //PREVENT EATING OF ARROW KEYS BY TEXTBOX INSIDE DATAGRIDVIEW 
        // important method
        protected override bool ProcessKeyPreview(ref Message m)
        {
            MessageBox.Show("ProcessKeyPreview");
            KeyEventArgs args1 = new KeyEventArgs(((Keys)((int)m.WParam)) | Control.ModifierKeys);
            switch (args1.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                
               
                    return false;
            }
            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            MessageBox.Show("processdialogkey");
            if (keyData == Keys.Enter)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.EndEdit();

                int row = this.CurrentCell.RowIndex;
                int col = this.CurrentCell.ColumnIndex;
                if (col == 0 && string.IsNullOrEmpty(this.CurrentCell.Value?.ToString()))
                {
                    this.SelectNextControl(this, true, true, true, true);
                    return true;
                }
                else if (col == this.ColumnCount - 1) // CHECK IF I AM AT LAST COLUMN 
                {
                    if (row == this.RowCount - 1)// CHECK IF I AM AT LAST ROW  
                    {
                        this.Rows.Add();
                        this.CurrentCell = this[0, row + 1];
                        this.BeginEdit(true);
                        return base.ProcessDialogKey(keyData);
                    }
                    else
                    {
                        this.CurrentCell = this[0, row + 1];
                        this.BeginEdit(true);
                    }
                }
                else // not at last column 
                {
                    this.CurrentCell = this[col + 1, row]; // change column
                    this.BeginEdit(true);
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);

        }


        protected override void OnEnter(EventArgs e)
        {
            dgv = Application.OpenForms["VoucherParent"].Controls["dataGridView1"] as DataGridView;
            this.CurrentCell = this.Rows[0].Cells[0]; // invokes cell enter 
            this.BeginEdit(true); 
            
            base.OnEnter(e);
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            if (this.CurrentCell.ColumnIndex == 0)
            {
                if (dgv.Rows.Count > 0)
                {
                    this.CurrentCell.Value = dgv.SelectedRows[0].Cells[1].Value.ToString();
                      dgv.Visible = false;
                }
            }
            if ((this.CurrentCell.ColumnIndex == 2 && this.CurrentRow.Cells[1].Value != null && this.CurrentRow.Cells[2].Value != null))
            {
                for (int i = 0; i < this.Rows.Count - 1; i++)
                {
                    decimal a = Convert.ToDecimal(this.Rows[i].Cells[1].Value);
                    decimal b = Convert.ToDecimal(this.Rows[i].Cells[2].Value);

                    decimal c = a * b;

                    this.Rows[i].Cells[3].Value = c.ToString();
                }
            }



          //  dataView.RowFilter = ""; // resets the filter to its starting state 
            
            base.OnCellEndEdit(e);


        }

        // changing the styles part starts
        private int previousRowIndex = -1;
        private int previousColumnIndex = -1;
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (e.RowIndex != previousRowIndex || e.ColumnIndex != previousColumnIndex))
            {
                RestorePreviousCellStyles();
                SetCurrentCellStyles(e.RowIndex, e.ColumnIndex);
                UpdatePreviousIndices(e.RowIndex, e.ColumnIndex);
              //  HighlightCurrentRow(e.RowIndex);
            }
        }

        private void SetCurrentCellStyles(int rowIndex, int columnIndex)
        {
            this.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.Black;
            this.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.White;
            this.Rows[rowIndex].DefaultCellStyle.Font = new Font(this.DefaultCellStyle.Font, FontStyle.Bold);
        }

        //private void HighlightCurrentRow(int rowIndex)
        //{
        //    for (int colIndex = 0; colIndex < this.Columns.Count; colIndex++)
        //    {
        //        if (colIndex != previousColumnIndex)
        //        {
        //            this.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.Yellow;
        //        }
        //    }
        //}

        protected override void OnCellLeave(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                RestoreCellStyles(e.RowIndex, e.ColumnIndex);
            }
        }
        private void RestoreCellStyles(int rowIndex, int columnIndex)
        {
             //this.Rows[rowIndex].Cells[columnIndex].Style.BackColor = this.Parent.BackColor;
            // this.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = this.DefaultCellStyle.ForeColor;

           //  this.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.;
             this.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.Black ;
        }
        private void RestorePreviousCellStyles()
        {
            if (previousRowIndex >= 0 && previousColumnIndex >= 0)
            {
                for (int colIndex = 0; colIndex < this.Columns.Count; colIndex++)
                {
                    this.Rows[previousRowIndex].Cells[colIndex].Style.BackColor = this.Parent.BackColor;
                }
            }
        }

        private void UpdatePreviousIndices(int rowIndex, int columnIndex)
        {
            previousRowIndex = rowIndex;
            previousColumnIndex = columnIndex;
        }
        // changingthe styles finish



        //protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        //{
        //    var cell = this.CurrentCell;
        //    cell.Style = new DataGridViewCellStyle()
        //    {
        //        BackColor = Color.FromArgb(255, 255, 255),
        //        ForeColor = Color.FromArgb(0, 0, 0) };


        //    base.OnCellValueChanged(e);
        //}
        // MY 6th column should always be readonly
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            if (e.Column.Index == 5)
            {
                e.Column.ReadOnly = true;
            }
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {

            //e.CellStyle.BackColor = Color.FromArgb(0, 0, 0); // change cell color to black 
            //e.CellStyle.ForeColor = Color.FromArgb(255, 255, 255); // change cell color to white  
            //e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic);

            e.Control.KeyPress -= new KeyPressEventHandler(textbox_keypress);
            e.Control.TextChanged -= new EventHandler(TextBox_TextChanged);
            e.Control.KeyDown -= new KeyEventHandler(TextBox_KeyDown);
            e.Control.Enter -= new EventHandler(TextBox_Enter);
            if (this.CurrentCell.ColumnIndex == 1 || this.CurrentCell.ColumnIndex == 2) // Assuming the first column has an index of 0
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(textbox_keypress);
                }
            }

            else if (this.CurrentCell.ColumnIndex == 0) // Assuming the first column has an index of 0
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.TextChanged += TextBox_TextChanged; // Attach TextChanged event handler
                    textBox.KeyDown += TextBox_KeyDown; // Attach KeyDown event handler
                    textBox.Enter += TextBox_Enter;
                }
            }
            base.OnEditingControlShowing(e);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (this.CurrentCell.ColumnIndex > 0)
                return;

                      
            dgv.Visible = true;
            dgv.DataSource = dt2 = connectionlogics.FillDataGridView($"SELECT * FROM [productnames]").Tables[0];
            dgv.CurrentCell = dgv.Rows[0].Cells[1];
        }
        private void textbox_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

            if (this.CurrentCell.ColumnIndex == 0) // Assuming the first column has an index of 0
            {
                TextBox textBox = (TextBox)sender;
                string searchText = textBox.Text.Trim();
                dataView = dt2.DefaultView;

                if (searchText.Length > 0) // strings
                {
                    dataView.RowFilter = $"[Productname] LIKE '%{searchText}%'";
                    if (dataView.Count == 0) // check if no rows match the filter
                    {
                        searchText = searchText.Substring(0, searchText.Length - 1);
                        textBox.Text = searchText;
                    }
                    else
                    {


                    }
                }
                else if (searchText.Length == 0)
                {
                    dataView.RowFilter = null;
                    // dataGridView1.DataSource = dt.DefaultView;
                }
                textBox.Select(textBox.Text.Length, 0); // Set cursor at the end
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.CurrentCell.ColumnIndex == 0) // Assuming the first column has an index of 0
            {
                TextBox textBox = (TextBox)sender;

                //code for results up and down in popup datagridview

                if (dgv.CurrentCell == null)
                {
                    return;
                }
                else
                {
                    rpos = dgv.CurrentCell.RowIndex;
                    cpos = dgv.CurrentCell.ColumnIndex;
                    switch (e.KeyCode)
                    {
                        case Keys.Up:

                            rpos--;
                            if (rpos >= 0) dgv.CurrentCell = dgv.Rows[rpos].Cells[cpos];
                            e.Handled = true;
                            break;
                        case Keys.Down:

                            rpos++;
                            if (rpos < dgv.Rows.Count) dgv.CurrentCell = dgv.Rows[rpos].Cells[cpos];
                            e.Handled = true;
                            break;
                        case Keys.Enter://
                            {//
                                //if (dataGridView1.Rows.Count > 0)//
                                //{//
                                //    dataGridView1.Visible = false;//
                                //    customtextbox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//
                                //    customControl11.Focus(); //
                                //                             // below 2 lines i already add in OnEnter method of customcontrol
                                //                             // customControl11.CurrentCell = customControl11.Rows[0].Cells[0]; // Select the first cell                                
                                //                             //  customControl11.BeginEdit(true);
                                //    dataView.RowFilter = ""; // resets the filter to its starting state 
                                //}
                                e.Handled = e.SuppressKeyPress = true; //
                                break;//
                            }

                    }
                }
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
                MessageBox.Show("ProcessCmdKey");
            //    if ((keyData == (Keys.Control | Keys.S)))
            //    {
            //        // save data
            //    }
            //    if ((keyData == (Keys.Enter)))
            //    {
            //        if (dgv.Rows.Count > 0)
            //        {
            //            dgv.Visible = false;
            //        }
            //        dataView.RowFilter = ""; // resets the filter to its starting state 
            //    }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            MessageBox.Show("ProcessDataGridViewKey");
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

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}

    }
}
