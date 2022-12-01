using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsensoInformato2
{
    public partial class FormDottore : Form
    {
        public FormDottore()
        {
            InitializeComponent();

            if (Common.DoctorList != null)
            {
                foreach(var doctor in Common.DoctorList)
                {
                    var currentItem = lsbDottore.Items.Add(doctor);
                    if (!string.IsNullOrEmpty(Common.Dottore) && doctor == Common.Dottore)
                    {
                        lsbDottore.SelectedIndex = currentItem;
                    }
                }
            }
        }

        private void lsbDottore_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lsbDottore.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selected))
            {
                lblDottore.Text = selected;
                cmdOk.Enabled = true;
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            var selected = lblDottore.Text;
            if (!string.IsNullOrEmpty(selected))
            {
                Common.SetDoctor(selected);
            }
        }
    }
}
