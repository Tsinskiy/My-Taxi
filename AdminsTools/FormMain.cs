using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace AdminsTools
{

    public enum GridTables {Users = 1, Cards, Cars, Orders, FavouriteAddress }
    public partial class FormMain : Form
    {
       

        GridTables ActiveTable = GridTables.Users;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnUsers_Click(object sender, EventArgs e)
        {
            
            ActiveTable = GridTables.Users;
            grid.DataSource = DBManager.Instance().DB.Users.ToList();
            ActivateButton((Button)sender);
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            
            ActiveTable = GridTables.Cars;
            grid.DataSource = DBManager.Instance().DB.Cars.ToList();
            ActivateButton((Button)sender);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           

            switch (ActiveTable)
            {
                case GridTables.Users:
                    FormAddNewUser frmU = new FormAddNewUser();
                    frmU.ShowDialog();
                    grid.DataSource = DBManager.Instance().DB.Users.ToList();//Обновление Данных на Экране после добавления запии в табл
                    break;
                case GridTables.Cars:
                    FormAddNewCar frmC = new FormAddNewCar();
                    frmC.ShowDialog();
                    grid.DataSource = DBManager.Instance().DB.Cars.ToList(); //Обновление Данных на Экране после добавления запии в табл
                    break;
                case GridTables.Cards:
                    FormAddNewUCard frmP = new FormAddNewUCard();
                    frmP.ShowDialog();
                    grid.DataSource = FullDataManager.GetUsersCards();
                    break;


            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUsersCards_Click(object sender, EventArgs e)
        {
            
            ActiveTable = GridTables.Cards;
            grid.DataSource = FullDataManager.GetUsersCards();
            ActivateButton((Button)sender);

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            
            ActiveTable = GridTables.Orders;
            grid.DataSource = DBManager.Instance().DB.Orders.ToList();
            ActivateButton((Button)sender);
        }

        private void btnFavAddress_Click(object sender, EventArgs e)
        {
           
            ActiveTable = GridTables.FavouriteAddress;
            grid.DataSource = DBManager.Instance().DB.FavouriteAddress.ToList();
            ActivateButton((Button)sender);
        }

        void ActivateButton(Button aButton)
        {
            foreach(Button b in pMenu.Controls)
            {
                b.BackColor = System.Drawing.SystemColors.Highlight;
                aButton.BackColor = Color.DarkGreen;
            }
            btnAdd.Enabled = ActiveTable == GridTables.Users ||
               ActiveTable == GridTables.Cars ||
               ActiveTable == GridTables.Cards;

            btnDelete.Enabled = btnAdd.Enabled;
            btnEdit.Enabled = btnAdd.Enabled;
        }
    }
}
