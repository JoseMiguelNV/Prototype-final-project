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
    internal class Tecnico
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS; Integrated Security = True");
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

        public void agregarTecnico(Tecnico tecnico)
        {
            string cadena = @"IF NOT EXISTS(SELECT dni, nombre, apellido1, apellido2 FROM tecnicos WHERE dni = @dni)
                                BEGIN
                                    INSERT INTO tecnicos (dni, nombre, apellido1, apellido2, telefono, email, contrasenya, tipo_usuario, id_vehiculo, imagen) 
                                                   VALUES (@dni, @nombre, @apellido1, @apellido2, @telefono, @email, @contrasenya, @tipo_usuario, @id_vehiculo, @imagen)
                                END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            if (tecnico.dni != "" || tecnico.nombre != "" || tecnico.apellido1 != "" || tecnico.apellido2 != "")
            {
                agregar.Parameters.AddWithValue("@dni", tecnico.dni);
                agregar.Parameters.AddWithValue("@nombre", tecnico.nombre);
                agregar.Parameters.AddWithValue("@apellido1", tecnico.apellido1);
                agregar.Parameters.AddWithValue("@apellido2", tecnico.apellido2);
                agregar.Parameters.AddWithValue("@telefono", tecnico.telefono);
                agregar.Parameters.AddWithValue("@email", tecnico.email);
                agregar.Parameters.AddWithValue("@contrasenya", tecnico.contrasenya);
                agregar.Parameters.AddWithValue("@tipo_usuario", tecnico.tipo_usuario);
                agregar.Parameters.AddWithValue("@id_vehiculo", tecnico.id_vehiculo);
                agregar.Parameters.AddWithValue("@imagen", tecnico.imagen);
                try
                {
                    conexion.Open();
                    agregar.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conexion.Close();
                }
            }
        }


        public void modificarTecnico(Tecnico tecnico)
        {
            string cadena = @"IF EXISTS(SELECT id_vehiculo FROM vehiculos WHERE id_vehiculo = @id_vehiculo OR @id_vehiculo = 0)
                              UPDATE tecnicos
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
            modificar.Parameters.AddWithValue("@id_tecnico", tecnico.id_tecnico);
            modificar.Parameters.AddWithValue("@dni", tecnico.dni);
            modificar.Parameters.AddWithValue("@nombre", tecnico.nombre);
            modificar.Parameters.AddWithValue("@apellido1", tecnico.apellido1);
            modificar.Parameters.AddWithValue("@apellido2", tecnico.apellido2);
            modificar.Parameters.AddWithValue("@telefono", tecnico.telefono);
            modificar.Parameters.AddWithValue("@email", tecnico.email);
            modificar.Parameters.AddWithValue("@contrasenya", tecnico.contrasenya);
            modificar.Parameters.AddWithValue("@tipo_usuario", tecnico.tipo_usuario);
            modificar.Parameters.AddWithValue("@id_vehiculo", tecnico.id_vehiculo);
            modificar.Parameters.AddWithValue("@imagen", tecnico.imagen);
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

        public void eliminarTecnico(Tecnico tecnico)
        {
            string cadena = @"DELETE FROM tecnicos
                               WHERE id_tecnico = @id_tecnico;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_tecnico", tecnico.id_tecnico);
            try
            {
                conexion.Open();
                eliminar.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
