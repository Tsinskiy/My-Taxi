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

namespace DriverApp
{
    public partial class FormAddNewCar : Form
    {
        public bool IsOk = false;
        public string NumberCar = null;

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
            IsOk = true;
            NumberCar = newCar.Number;
            Close();
        }
    }
}

