using System.Data;
using System.Collections.Generic;
using Preparcial.Modelo;
using System;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorUsuario
    {
        public static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>();
            DataTable tableUsuarios = null;

            try
            {
                //Correción de consulta
                tableUsuarios = ConexionBD.EjecutarConsulta($"SELECT * FROM usuario");
            }
            catch(Exception ex)
            {
                //Corrección de la variable ex
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }

            foreach(DataRow dr in tableUsuarios.Rows)
            {
                usuarios.Add(new Usuario
                    (
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        Convert.ToBoolean(dr[3].ToString())
                    )
                );
            }

            return usuarios;
        }

        public static DataTable GetUsuariosTable()
        {
            DataTable tableUsuarios = null;

            try
            {
                //Corrección de consulta
                tableUsuarios = ConexionBD.EjecutarConsulta($"SELECT * FROM USUARIO");
            }
            catch (Exception ex)
            {
                //Corrección de variable ex
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }

            return tableUsuarios;
        }

        public static void ActualizarContrasena(string idUsuario, string nueva)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE USUARIO SET contrasenia = '{nueva}' " +
                    $"WHERE idUsuario = {idUsuario}");

                MessageBox.Show("Se ha actualizado la contrasena");
            }
            catch(Exception ex)
            {
                //Corrección de variable ex
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }
        }

        public static void CrearUsuario(string usuario)
        {
            try
            {
                //Corrección de consulta nombreUsuario = nombre
                ConexionBD.EjecutarComando($"INSERT INTO USUARIO(nombre, contrasenia, tipo)" +
                    $" VALUES('{usuario}', '{usuario}', false)");

                MessageBox.Show("Se ha agregado el nuevo usuario, contrasenia igual al nombre");
            }
            catch(Exception ex)
            {
                //Corrección de variable ex
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }
        }
    }
}
