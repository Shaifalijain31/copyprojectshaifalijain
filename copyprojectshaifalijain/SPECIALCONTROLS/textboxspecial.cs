using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain.SPECIALCONTROLS
{
    public partial class textboxspecial : TextBox
    {
        public textboxspecial()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public const int WM_PASTE = 0x0302;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
       
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPY || m.Msg == WM_CUT || m.Msg== WM_PASTE)
            {
                // DO NOTHING 
            }           
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            const int VK_V = 0x56;
            const int VK_MENU = 0x12;

            if ((msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN) && keyData == (Keys.V | Keys.Alt | Keys.Control))
            {
                // Custom paste logic here
               // string customClipboardText = "This is custom clipboard text";
                SelectedText = Clipboard.GetText();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // BELOW IS SUGGESTED BY CASTORIX BUT MINE ABOVE IS ALSO WORKING 
        // SO I HAVE NOT TRIED BELOW 
        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (e.KeyCode == Keys.V
        //        && (Control.ModifierKeys & Keys.Control) == Keys.Control
        //        && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
        //    {
        //        this.Paste(Clipboard.GetText());
        //    }
        //}
    }
}
