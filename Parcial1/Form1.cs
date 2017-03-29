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

namespace Inicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string user, pass, sql, tipo;
        MySqlConnection cnx = new MySqlConnection("SERVER=216.245.208.162;DATABASE=pcicompa_DBPLACAS;UID=pcicompa_ADMIN;PASSWORD=SXJWo~M#q4id");
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    cnx.Open();
            //    MessageBox.Show("Conexion Realizada");
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            user = txtUsuario.Text;
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            pass = txtContraseña.Text;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(validar()==true){
                if(tipo=="admin"){
                    frmAdmin a = new frmAdmin();
                    a.Show();
                    this.Hide();
                }
                if(tipo=="user"){
                    frmUser a = new frmUser();
                    a.Show();
                    this.Hide();
                }
            }

        }
        private Boolean validar()
        {
            sql = "select TIPO from USUARIOS where NOMBRE=@NOMBRE AND CONTRASEÑA=@CONTRASEÑA";
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@NOMBRE", user);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", pass);
            cnx.Open();
            MySqlDataReader lectura;
            lectura = cmd.ExecuteReader();
            while (lectura.Read())
                tipo = lectura[0].ToString();
            cnx.Close();
            if (tipo != null){
            return true;
            }
        else MessageBox.Show("El Usuario No Existe");
            return false;
        }
    }
}
