using ContractorsApp.Forms;
using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ContractorsApp
{
    public partial class Form1 : Form
    {
     


        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void btnClose_Click(object sender, EventArgs e) // Zamyka aplikacje
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) // przycisk login odpowiadajacy za logowanie do systemu
        {
            if(isFormValid())
            { 
                if(checklogin())
                {
                    using (FormDashboard fd = new FormDashboard())
                    {
                        fd.ShowDialog();
                    }
                }
            }

        }

        private bool checklogin() // sprawdzenie poprawnosci danych do logowania
        {
            string username = db.getSingleValue("select Login from tbLogin where Login = '" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "'", out username, 0);
            if (username == null) 
            {
                MessageBox.Show("Nieprawidłowy Login lub Hasło", "Nieprawidlowe dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormValid() // powiadomienie gdy nie wpiszemy login lub hasla a bedziemy chcieli sie zalogowac
        {
            if (txtUserName.Text.ToString().Trim() == string.Empty || txtPassword.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Pole jest puste","Wypełnij pole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            
        }

        
    }
}
