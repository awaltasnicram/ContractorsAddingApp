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

namespace ContractorsApp.Forms
{
    public partial class FormDashboard : Form
    {

        DbConnector db;
        public FormDashboard()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        public int Record_Id;

        private void btnClose_Click(object sender, EventArgs e) // klawisz X w lewym gornym rogu w zakladce kontrahenci
        {
            this.Dispose();
        }

        private void btnDodaj_Click(object sender, EventArgs e) // przycisk dodaj, który doda kontrahenta tabeli poniżej
        {
            if (isFormValid())
            {
                DialogResult dialog = MessageBox.Show("Na pewno chcesz dodać kontrahenta?", "Potwierdź", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    db.performCRUD("insert into tbContractors(imie, nazwisko, miejscowosc, adres, telefon, email, RodzajKontrahenta, NIP) values('" + txtImie.Text + "','" + txtNazwisko.Text + "','" + txtMiejscowosc.Text + "','" + txtAdres.Text + "','" + txtTelefon.Text + "','" + txtEmail.Text + "','" + cmbRodzajKontrahenta.Text + "','" + txtNIP.Text + "')");
                    MessageBox.Show("Dodano kontrahenta", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    txtImie.Clear();
                    txtNazwisko.Clear();
                    txtMiejscowosc.Clear();
                    txtAdres.Clear();
                    txtTelefon.Clear();
                    txtEmail.Clear();
                    txtNIP.Clear();
                    this.OnLoad(e);
                }
            }
        }

        private bool isFormValid() // funkcja wykonuje sie dopiero, gdy wprowadzimy wszystkie dane do dodania kontrahenta
        {
            if (txtImie.Text.Trim() == string.Empty ||
               txtNazwisko.Text.Trim() == string.Empty ||
               txtMiejscowosc.Text.Trim() == string.Empty ||
               txtAdres.Text.Trim() == string.Empty ||
               txtTelefon.Text.Trim() == string.Empty ||
               txtEmail.Text.Trim() == string.Empty ||
               cmbRodzajKontrahenta.Text.Trim() == string.Empty ||
               txtNIP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Nie wszystkie pola sa wypełnione", "Wypełnij poozstałe pola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                return true;
            }
        }

        private void FormDashboard_Load(object sender, EventArgs e) // odczyt tabeli tbContractors z bazy danych
        {
            db.fillDataGridView("select * from  tbContractors", dataGridView1);
        }

        private void cmbRodzajKontrahenta_SelectedIndexChanged(object sender, EventArgs e) //funkcja umozliwiajaca wprowadzenie NIP tylko dla Podmiotu gospodarczego
        {
            if (cmbRodzajKontrahenta.Text == "Osoba fizyczna")
            {

                txtNIP.Visible = false;
                txtNIP.Text = "-";



            }
            else if (cmbRodzajKontrahenta.Text == "Podmiot gospodarczy")
            {
                txtNIP.Visible = true;
                txtNIP.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  // po kliknieciu na konkretnego kontrahenta jego dane pojawiaja sie w kazdym oknie do dodawania kontrahenta
        {
            Record_Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtImie.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNazwisko.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMiejscowosc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbRodzajKontrahenta.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtNIP.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

      

        private void btnEdytuj_Click_1(object sender, EventArgs e) //funkcja odpowiadajaca za edytowanie kontrahenta, powyzsza uzupelnia dane z tabeli,
                                                                   //a przycisk edytuj zatwierdza zmieniane przez nas edytowane dane
        {

            db.performCRUD("update tbContractors set imie='" + txtImie.Text + "',nazwisko='" + txtNazwisko.Text + "',miejscowosc='" + txtMiejscowosc.Text + "',adres='" + txtAdres.Text + "',telefon='" + txtTelefon.Text + "',email='" + txtEmail.Text + "',RodzajKontrahenta='" + cmbRodzajKontrahenta.Text + "',NIP='" + txtNIP.Text + "'where id=" + Record_Id);
            MessageBox.Show("Zmieniono dane", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtImie.Clear();
            txtNazwisko.Clear();
            txtMiejscowosc.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtNIP.Clear();
            this.OnLoad(e);

            db.fillDataGridView("select * from  tbContractors", dataGridView1);
        }
    }
}
