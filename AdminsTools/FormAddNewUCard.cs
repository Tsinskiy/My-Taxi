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
    public partial class FormAddNewUCard : Form
    {
        public FormAddNewUCard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAddNewUCard_Load(object sender, EventArgs e)
        {
            cbUser.DataSource = DBManager.Instance().DB.Users.ToList();
            cbUser.DisplayMember = "FullName";
            cbUser.ValueMember = "Id";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cards newCard = new Cards();
            newCard.Number = tbCardNumber.Text;
            newCard.UserId = Convert.ToInt32(cbUser.SelectedValue.ToString());

            DBManager.Instance().DB.Cards.Add(newCard);
            DBManager.Instance().DB.SaveChanges();
            Close();
               
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tbCardNumber_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
