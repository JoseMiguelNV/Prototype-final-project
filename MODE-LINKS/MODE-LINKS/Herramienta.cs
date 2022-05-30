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
    internal class Herramienta
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");
        string cadenaSql = @"SELECT * FROM herramientas ORDER BY id_herramienta;";

        public string id_herramienta { get; set; }
        public string marca { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }

        public void agregarHerramienta(Herramienta herramienta)
        {
            string cadena = @"IF NOT EXISTS(SELECT marca, tipo, codigo 
                                              FROM herramientas 
                                             WHERE marca = @marca 
                                               AND tipo = @tipo 
                                               AND codigo = @codigo)
                                BEGIN
                                    INSERT INTO herramientas (marca, tipo, codigo) 
                                                   VALUES (@marca, @tipo, @codigo)
                                END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            if (herramienta.marca != "" || herramienta.tipo != "" || herramienta.codigo != "")
            {
                agregar.Parameters.AddWithValue("@marca", herramienta.marca);
                agregar.Parameters.AddWithValue("@tipo", herramienta.tipo);
                agregar.Parameters.AddWithValue("@codigo", herramienta.codigo);
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

        public void modificarHerramienta(Herramienta herramienta)
        {
            string cadena = @"UPDATE herramientas
                                 SET marca = @marca,
                                     tipo = @tipo,
                                     codigo = @codigo
                               WHERE id_herramienta = @id_herramienta;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_herramienta", herramienta.id_herramienta);
            modificar.Parameters.AddWithValue("@marca", herramienta.marca);
            modificar.Parameters.AddWithValue("@tipo", herramienta.tipo);
            modificar.Parameters.AddWithValue("@codigo", herramienta.codigo);
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

        public void eliminarHerramienta(Herramienta herramienta)
        {
            string cadena = @"DELETE FROM herramientas
                               WHERE id_herramienta = @id_herramienta;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_herramienta", herramienta.id_herramienta);
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
