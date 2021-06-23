using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace perpusId
{
    public partial class daftarAkun : Form
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; uid = root; database = tugasakhir");

        public daftarAkun()
        {
            InitializeComponent();
        }
        private void daftarAkun_Load(object sender, EventArgs e)
        {

        }
        public void ValidasiRegister()
        {

        }
        public void setNull()
        {
            inputLibId.Text = "";
            inputEmail.Text = "";
            inputNama.Text = "";
            inputNohp.Text = "";
            inputPass.Text = "";
            tglLahir.Text = "";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO member(libraryId,nama,noHp,email,tgl_lahir,password) VALUE(@libId,@nama,@noHp,@email,@tgllhr,@pass)";
                cmd.Parameters.AddWithValue("@libId", inputLibId.Text);
                cmd.Parameters.AddWithValue("@nama", inputNama.Text);
                cmd.Parameters.AddWithValue("@noHp", inputNohp.Text);
                cmd.Parameters.AddWithValue("@email", inputEmail.Text);
                cmd.Parameters.AddWithValue("@tgllhr", tglLahir.Value);
                cmd.Parameters.AddWithValue("@pass", inputPass.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Membuat Akun");
                setNull();
                connection.Close();

            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }
        }
    }
}
