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

namespace UsersApp
{
    public partial class FormAddNewUser : Form
    {
        public bool IsOk = false;
        public string email = null;
        public FormAddNewUser()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Users newUser = new Users();
            newUser.Name = tbName.Text;
            newUser.Surname = tbSurname.Text;
            newUser.Phone = tbPhone.Text;
            newUser.Email = tbEmail.Text;

            DBManager.Instance().DB.Users.Add(newUser);
            DBManager.Instance().DB.SaveChanges();

            IsOk = true;
            email = newUser.Email;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
