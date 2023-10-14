using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain.helperclasses
{
  public static  class datagridviewcommonproperties
    {
        public static void SetCommon(this DataGridView sender)
        {
            sender.CellBorderStyle = DataGridViewCellBorderStyle.None;
            sender.ScrollBars = ScrollBars.None;
            sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sender.MultiSelect = false;
            sender.AllowUserToResizeColumns = false;
            sender.RowHeadersVisible = false;
            sender.AllowUserToResizeRows = false;
        }
    }
}
