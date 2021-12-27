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
    public partial class FormAddNewUser : Form
    {
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

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }

        private void tbSurname_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }

        private void tbPhone_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }

        private void tbEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                SendKeys.Send("{TAB}");
        }
    }
}
