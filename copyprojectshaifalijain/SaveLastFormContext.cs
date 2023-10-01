using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyprojectshaifalijain
{
    class SaveLastFormContext : ApplicationContext
    {
        public SaveLastFormContext(Form firstForm) : base(firstForm) { }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.TopLevel && !form.InvokeRequired)
                {
                    MainForm = form;
                    return;
                }
            }
            // Save LastForm TypeName
            var settings = copyprojectshaifalijain.Properties.Settings.Default;
            settings.Lastform = MainForm.GetType().Name;
            settings.Save();
            base.OnMainFormClosed(sender, e);
        }
    }
}
  
