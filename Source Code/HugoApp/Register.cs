using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool tipoUsuario = !radioButton1.Checked;
            
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos.");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery("INSERT INTO appuser(fullname, username, password, userType) VALUES(" +
                                                 $"'{textBox1.Text}', " +
                                                 $"'{textBox2.Text}', " +
                                                 $"'{textBox3.Text}', " + 
                                                 $"'{tipoUsuario}')");

                    MessageBox.Show("Los datos del usuario se han registrado correctamente.");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error.");
                }
            }
        }
    }
}