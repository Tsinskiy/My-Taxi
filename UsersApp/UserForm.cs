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

namespace UsersApp
{
    public partial class UserForm : Form
    {
        Cars ActiveCar;
        Users ActiveUser;
        public int ActiveOrderId = 0;
        Orders ActiveOrder;

        public static object ConfigurationManager { get; private set; }

        public UserForm()
        {
            InitializeComponent();
        }


        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshAll();
            ActiveCar = null;
            Thread.Sleep(2000);
            ActiveUser = DBManager.Instance().DB.Users.Find(4);
            ActiveOrder = null;
            if (ActiveUser == null)
            {
                // если юзер не найден то регистрируем в форме регистрации
                FormAddNewUser frm = new FormAddNewUser();
                frm.ShowDialog();
                if (frm.IsOk && !String.IsNullOrEmpty(frm.email))
                {
                    foreach (Users u in DBManager.Instance().DB.Users)
                    {
                        if (u.Email == frm.email)
                        {
                            ActiveUser = u;
                            UserInfo.Text = ActiveUser.Name + " " + ActiveUser.Surname;
                            return;
                        }
                    }
                }
                Close();
            }
            else
            {
                // если найден 
                UserInfo.Text = ActiveUser.Name + " " + ActiveUser.Surname;
                // проверяем нет ли заказов незакрытых

                //!-----------------------------------
                ActiveOrder = DBManager.Instance().DB.Orders.Where(r => r.UserId == ActiveUser.Id)
                    .Where(t => t.StartTime == null).First();

                if (ActiveOrder != null)
                {
                    ActiveOrderId = ActiveOrder.Id;
                    tbFrom.Text = ActiveOrder.AddressFrom;
                    tbTo.Text = ActiveOrder.AddressTo;
                    tbDesc.Text = ActiveOrder.Description;
                    cbPayCash.Checked = (bool)ActiveOrder.PayCash;

                    if (ActiveOrder.CarId == null)
                    {
                        StartFindDriver();
                    }
                    else
                    {
                        CarInfo.Items.Clear();
                        CarInfo.Items.Add("Found an available driver:");

                        ActiveCar = DBManager.Instance().DB.Cars.Find(ActiveOrder.CarId);

                        CarInfo.Items.Add("Driver : " + ActiveCar.Name);
                        CarInfo.Items.Add("Car :" + ActiveCar.Number);
                        CarInfo.Items.Add(ActiveCar.Description);
                        CarInfo.Items.Add("Price:" + 120); ;

                        if (ActiveOrder.StartTime != null)
                        {
                            tbFrom.Enabled = false;
                            tbTo.Enabled = false;
                            tbDesc.Enabled = false;
                            btnAccept.Enabled = false;
                            btnOrder.Enabled = false;
                            CarInfo.Items.Add("The ride is in process");
                        }



                    }
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            ActiveOrder = new Orders();
            ActiveOrder.AddressFrom = tbFrom.Text;
            ActiveOrder.AddressTo = tbTo.Text;
            ActiveOrder.Create = DateTime.Now;
            ActiveOrder.UserId = ActiveUser.Id;

            ActiveOrder.Description = tbDesc.Text;
            ActiveOrder.PayCash = cbPayCash.Checked;

            DBManager.Instance().DB.Orders.Add(ActiveOrder);
            DBManager.Instance().DB.SaveChanges();
            ActiveOrderId = ActiveOrder.Id;

            StartFindDriver();
            //CheckOrderAndShowCarInfo();
        }

        void StartFindDriver()
        {
            btnAccept.Enabled = false;
            timer1.Start();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            // Accept
           if (ActiveOrder!= null)
            {
                ActiveOrder.StartTime = DateTime.Now;
                btnAccept.Enabled = false;
                DBManager.Instance().DB.SaveChanges();
            }

        }

        private void tbTo_TextChanged(object sender, EventArgs e)
        {

        }






        void CheckOrderAndShowCarInfo()
        {
            ActiveCar = null;
            if (!String.IsNullOrEmpty(tbFrom.Text) && !String.IsNullOrEmpty(tbTo.Text))
            {
                foreach (Cars c in DBManager.Instance().DB.Cars)
                {
                    if (c.Busy == false)
                    {
                        CarInfo.Items.Clear();
                        CarInfo.Items.Add("Found an available driver:");


                        CarInfo.Items.Add("Driver : " + c.Name);
                        CarInfo.Items.Add("Car :" + c.Number);
                        CarInfo.Items.Add(c.Description);
                        CarInfo.Items.Add("Price:" + 120); ;

                        ActiveCar = c;
                        break;
                    }
                }

                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;

                CarInfo.Items.Clear();
                CarInfo.Items.Add("Not all data entered correctly");
            }

        }


        private void btnDecline_Click(object sender, EventArgs e)
        {


        }

        private void btnMyCab_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAll();
            ; ActiveOrder = DBManager.Instance().DB.Orders.Where(r => r.Id == ActiveOrder.Id).First();
            if (ActiveOrder.CarId != null)
                ActiveCar = DBManager.Instance().DB.Cars.Find(ActiveOrder.CarId);

            if (CarInfo.BackColor == System.Drawing.SystemColors.Info)
            {
                CarInfo.BackColor = Color.Blue;
            }
            else
            {
                CarInfo.BackColor = System.Drawing.SystemColors.Info;
            }

            if (ActiveCar != null)
            {
                CarInfo.BackColor = System.Drawing.SystemColors.Info;
                CarInfo.Items.Clear();
                CarInfo.Items.Add("Found an available driver:");

                CarInfo.Items.Add("Driver : " + ActiveCar.Name);
                CarInfo.Items.Add("Car :" + ActiveCar.Number);
                CarInfo.Items.Add(ActiveCar.Description);
                CarInfo.Items.Add("Price:" + 120);

                ActiveOrder.CarId = ActiveCar.Id;

                timer1.Stop();
                btnAccept.Enabled = true;

            }
        }
        public void RefreshAll()
        {
            foreach (var entity in DBManager.Instance().DB.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }


    }
}
