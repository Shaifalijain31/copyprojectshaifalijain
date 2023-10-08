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
        public sale_purchase_datagridview()
        {
            InitializeComponent();
           this.Columns[5].ReadOnly = true;
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
           

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            MessageBox.Show("ProcessCmdKey");
            if((keyData==(Keys.Control | Keys.S)))
            {
                // save data
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            MessageBox.Show("ProcessDataGridViewKey");
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Right:
                case Keys.Enter:
                    {
                        return base.ProcessTabKey(e.KeyData);
                    }
                case Keys.Up:
                    {
                        return base.ProcessUpKey(e.KeyData);
                    }
                case Keys.Down:
                    {
                        return base.ProcessDownKey(e.KeyData);
                    }
             
                case Keys.Left:
                    {
                        return base.ProcessLeftKey(e.KeyData);
                    }
             
            
                case Keys.Delete:
                    {
                        return base.ProcessDeleteKey(e.KeyData);
                    }
               
                case Keys.Escape:
                    {
                        return base.ProcessEscapeKey(e.KeyData);
                    }
               
            }


            return base.ProcessDataGridViewKey(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

    }
}
