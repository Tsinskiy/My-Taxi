using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcessLayer.Models;
using DataAcessLayer;

namespace AdminsTools
{
    public partial class FormAddNewCar : Form
    {
        public FormAddNewCar()
        {
            InitializeComponent();
        }

     

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cars newCar = new Cars();
            newCar.Number = tbCarNumber.Text;
            newCar.Description = tbCarDescription.Text;
            newCar.Name = tbDriverName.Text;
            newCar.Busy = false;
            DBManager.Instance().DB.Cars.Add(newCar);
            DBManager.Instance().DB.SaveChanges();
            Close();
        }

        private void tbCarNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }

        private void tbDriverName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }

        private void tbCarDescription_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}

