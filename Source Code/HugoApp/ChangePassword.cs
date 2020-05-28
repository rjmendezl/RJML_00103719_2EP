using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            var users = ConnectionDB.ExecuteQuery($"SELECT username FROM appuser");
            var usersCombo = new List<string>();

            foreach (DataRow dr in users.Rows)
            {
                usersCombo.Add(dr[0].ToString());
            }
            comboBox1.DataSource = usersCombo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var verifySesion = ConnectionDB.ExecuteQuery($"SELECT * FROM appuser WHERE " +
                                                             $"username = '" + comboBox1.Text +
                                                             $"' AND password = '" + textBox1.Text + "';");

                if (verifySesion.Rows.Count > 0)
                {
                    ConnectionDB.ExecuteNonQuery($"UPDATE appuser SET password = " +
                                                 $"'{textBox2.Text}' WHERE username = " +
                                                 $"'{comboBox1.Text}'");
                    MessageBox.Show("La contaseña se ha actualizado correctamente.");
                    this.Close();
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
    }
}