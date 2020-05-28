using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Mostrar usuarios dentro del comboBox
        private void Form1_Load(object sender, EventArgs e)
        {
            var users = ConnectionDB.ExecuteQuery($"SELECT username FROM appuser");
            var usersCombo = new List<string>();

            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource = usersCombo;
        }
        //Iniciar sesión
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var verifySesion = ConnectionDB.ExecuteQuery($"SELECT * FROM appuser WHERE " +
                                                             $"username = '" + comboBox1.Text +
                                                             $"' AND password = '" + textBox1.Text + "';");
                

                if (verifySesion.Rows.Count > 0)
                {
                    if ((bool) verifySesion.Rows[0][4])
                    {
                        AdminView vistaA = new AdminView();
                        vistaA.Show();
                    }
                    else
                    {
                        int id = Convert.ToInt32(verifySesion.Rows[0][0]);
                        UserView vistaU = new UserView(id);
                        vistaU.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.");
            }
        }

        //Dirigir hacia ventana ChangePassword
        private void button2_Click(object sender, EventArgs e)
        {
            ChangePassword cambio = new ChangePassword();
            cambio.Show();
        }

        //Dirigir hacia ventana Register
        private void button3_Click(object sender, EventArgs e)
        {
            Register registrarse = new Register();
            registrarse.Show();
            //Cargando otra vezz los usuarios del comboBox
            var users = ConnectionDB.ExecuteQuery($"SELECT username FROM appuser");
            var usersCombo = new List<string>();

            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource = usersCombo;
        }
    }
}