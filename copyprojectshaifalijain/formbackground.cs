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
    public partial class formbackground : Form
    {
        public formbackground(Form parent)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; 
            this.BackColor = Color.Black;
            this.Opacity = 0.50;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = parent.ClientSize;
            this.Location = parent.PointToScreen(Point.Empty);
            parent.Move += AdjustPosition;
            parent.SizeChanged += AdjustPosition;
        }
        private void AdjustPosition(object sender, EventArgs e)
        {
            Form parent = sender as Form;
            this.Location = parent.PointToScreen(Point.Empty);
            this.ClientSize = parent.ClientSize;
        }
        private void formbackground_Load(object sender, EventArgs e)
        {

        }
    }
}
