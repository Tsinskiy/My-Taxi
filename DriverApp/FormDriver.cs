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
using System.Configuration;
using DataAcessLayer;
using System.Threading;

namespace DriverApp
{
    public partial class FormDriver : Form
    {
        Cars ActiveCar;
        Users ActiveUser;
        public int ActiveOrderId = 0;
        Orders ActiveOrder = null;

        public FormDriver()
        {
            InitializeComponent();
        }

        private void FormDriver_Load(object sender, EventArgs e)
        {
            ActiveUser = null;
            Thread.Sleep(2000);
            ActiveCar = DBManager.Instance().DB.Cars.Find(1);

            if (ActiveCar == null)
            {
                FormAddNewCar frm = new FormAddNewCar();
                frm.ShowDialog();
                if (frm.IsOk && !String.IsNullOrEmpty(frm.NumberCar))
                {
                    foreach (Cars c in DBManager.Instance().DB.Cars)
                    {
                        if (c.Number == frm.NumberCar)
                        {
                            ActiveCar = c;
                            UserInfo.Text = ActiveCar.Name + " " + ActiveCar.Number;
                            return;
                        }
                    }
                }
                Close();
            }
            else
            {
                UserInfo.Text = ActiveCar.Name + " " + ActiveCar.Number;
            }

            //timerCheckOrders.Start();
            grid1.DataSource = FullDataManager.GetAvailableOrders();

        }

        private void timerCheckOrders_Tick(object sender, EventArgs e)
        {
            grid1.DataSource = FullDataManager.GetAvailableOrders();
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grid1.DataSource = FullDataManager.GetAvailableOrders();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            

            if (grid1.SelectedCells.Count > 0)
            {
                int selectedrowindex = grid1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = grid1.Rows[selectedrowindex];

                ActiveOrderId = Convert.ToInt32(selectedRow.Cells["Id"].Value);


            }
            if (ActiveOrderId != 0)
            {
                Orders order = DBManager.Instance().DB.Orders.Find(ActiveOrderId);
                order.CarId = ActiveCar.Id;
                DBManager.Instance().DB.SaveChanges();

                btnAccept.Enabled = false;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (ActiveOrder != null)
            {
                ActiveOrder.FinishTime = DateTime.Now;
                ActiveOrder.Finish = true;
                MessageBox.Show("The ride is over");
            }
        }
    }
}
