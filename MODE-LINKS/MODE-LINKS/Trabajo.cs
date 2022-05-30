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
    internal class Trabajo
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");
        string cadenaSql = @"SELECT tr.id_trabajo, tec.id_tecnico, tec.nombre, tec.apellido1, tec.apellido2, v.id_vehiculo, v.marca, v.modelo,
                                    pr.id_proyecto, pr.contrata, tr.descripcion_trabajo
                               FROM trabajos tr, tecnicos tec, vehiculos v, proyectos pr
                              WHERE tr.id_tecnico = tec.id_tecnico AND tec.id_vehiculo = v.id_vehiculo AND tr.id_proyecto = pr.id_proyecto
                              ORDER BY id_trabajo;";

        public string id_trabajo { get; set; }
        public string id_tecnico { get; set; }
        public string id_vehiculo { get; set; }
        public string id_proyecto { get; set; }
        public string descripcion { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }

        public void agregarTrabajo(Trabajo trabajo)
        {
            string cadena = @"IF NOT EXISTS(SELECT id_tecnico, id_vehiculo, id_proyecto, descripcion_trabajo 
                                              FROM trabajos     
                                             WHERE id_tecnico = @id_tecnico 
                                               AND id_vehiculo = @id_vehiculo
                                               AND id_proyecto = @id_proyecto
                                               AND descripcion_trabajo = @descripcion_trabajo)
                                    BEGIN
                                        INSERT INTO trabajos (id_tecnico, id_vehiculo, id_proyecto, descripcion_trabajo) 
                                                      VALUES (@id_tecnico, @id_vehiculo, @id_proyecto, @descripcion_trabajo)
                                    END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            agregar.Parameters.AddWithValue("@id_tecnico", trabajo.id_tecnico);
            agregar.Parameters.AddWithValue("@id_vehiculo", trabajo.id_vehiculo);
            agregar.Parameters.AddWithValue("@id_proyecto", trabajo.id_proyecto);
            agregar.Parameters.AddWithValue("@descripcion_trabajo", trabajo.descripcion);
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

        public void modificarTrabajo(Trabajo trabajo)
        {
            string cadena = @"UPDATE trabajos
                                 SET id_tecnico = @id_tecnico,
                                     id_vehiculo = @id_vehiculo,
                                     id_proyecto = @id_proyecto,
                                     descripcion_trabajo = @descripcion_trabajo
                               WHERE id_trabajo = @id_trabajo;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_trabajo", trabajo.id_trabajo);
            modificar.Parameters.AddWithValue("@id_tecnico", trabajo.id_tecnico);
            modificar.Parameters.AddWithValue("@id_vehiculo", trabajo.id_vehiculo);
            modificar.Parameters.AddWithValue("@id_proyecto", trabajo.id_proyecto);
            modificar.Parameters.AddWithValue("@descripcion_trabajo", trabajo.descripcion);
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

        public void eliminarTrabajo(Trabajo trabajo)
        {
            string cadena = @"DELETE FROM trabajos
                               WHERE id_trabajo = @id_trabajo;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_trabajo", trabajo.id_trabajo);
            try
            {
                conexion.Open();
                eliminar.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }
        }
    }
}
