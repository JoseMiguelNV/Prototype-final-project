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
    internal class Proyecto
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");
        string cadenaSql = @"SELECT * FROM proyectos ORDER BY id_proyecto;";

        public string id_proyecto { get; set; }
        public string contrata { get; set; }
        public string descripcion { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }

        public void agregarProyecto(Proyecto proyecto)
        {
            string cadena = @"IF NOT EXISTS(SELECT contrata, descripcion_proyecto FROM proyectos WHERE contrata = @contrata AND descripcion_proyecto = @descripcion_proyecto)
                                BEGIN
                                    INSERT INTO proyectos (contrata, descripcion_proyecto) 
                                                   VALUES (@contrata, @descripcion_proyecto)
                                END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            if(proyecto.contrata != "" && proyecto.descripcion != "")
            {
                agregar.Parameters.AddWithValue("@contrata", proyecto.contrata);
                agregar.Parameters.AddWithValue("@descripcion_proyecto", proyecto.descripcion);
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

        public void modificarProyecto(Proyecto proyecto)
        {
            string cadena = @"UPDATE proyectos
                                 SET contrata = @contrata,
                                     descripcion_proyecto = @descripcion_proyecto
                               WHERE id_proyecto = @id_proyecto;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_proyecto", proyecto.id_proyecto);
            modificar.Parameters.AddWithValue("@contrata", proyecto.contrata);
            modificar.Parameters.AddWithValue("@descripcion_proyecto", proyecto.descripcion);
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

        public void eliminarProyecto(Proyecto proyecto)
        {
            string cadena = @"DELETE FROM proyectos
                               WHERE id_proyecto = @id_proyecto;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_proyecto", proyecto.id_proyecto);
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
