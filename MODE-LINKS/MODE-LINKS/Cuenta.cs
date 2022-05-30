using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MODE_LINKS
{
    internal class Cuenta
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");
        string cadenaSql = @"SELECT * FROM tecnicos ORDER BY id_tecnico;";

        public string id_tecnico { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string contrasenya { get; set; }
        public string tipo_usuario { get; set; }
        public string id_vehiculo { get; set; }
        public string imagen { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }
     
        public void modificarCuenta(Cuenta cuenta)
        {
            string cadena = @"UPDATE tecnicos
                                 SET dni = @dni,
                                     nombre = @nombre,
                                     apellido1 = @apellido1,
                                     apellido2 = @apellido2,
                                     telefono = @telefono,
                                     email = @email,
                                     contrasenya = @contrasenya,
                                     tipo_usuario = @tipo_usuario,
                                     id_vehiculo = @id_vehiculo,
                                     imagen = @imagen
                               WHERE id_tecnico = @id_tecnico;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_tecnico", cuenta.id_tecnico);
            modificar.Parameters.AddWithValue("@dni", cuenta.dni);
            modificar.Parameters.AddWithValue("@nombre", cuenta.nombre);
            modificar.Parameters.AddWithValue("@apellido1", cuenta.apellido1);
            modificar.Parameters.AddWithValue("@apellido2", cuenta.apellido2);
            modificar.Parameters.AddWithValue("@telefono", cuenta.telefono);
            modificar.Parameters.AddWithValue("@email", cuenta.email);
            modificar.Parameters.AddWithValue("@contrasenya", cuenta.contrasenya);
            modificar.Parameters.AddWithValue("@tipo_usuario", cuenta.tipo_usuario);
            modificar.Parameters.AddWithValue("@id_vehiculo", cuenta.id_vehiculo);
            modificar.Parameters.AddWithValue("@imagen", cuenta.imagen);
            try
            {
                conexion.Open();
                modificar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
