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
    internal class Multa
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");
        string cadenaSql = @"SELECT *
                               FROM multas 
                              ORDER BY id_multa;";

        public string id_multa { get; set; }
        public string codigo { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string cantidad { get; set; }
        public string matricula { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }

        public void agregarMulta(Multa multa)
        {
            string cadena = @"IF NOT EXISTS(SELECT codigo_multa, dia, hora, cantidad, matricula 
                                          FROM multas 
                                         WHERE codigo_multa = @codigo_multa
                                           AND dia = @dia              
                                           AND hora = @hora         
                                           AND cantidad = @cantidad
                                           AND matricula = @matricula)                                               
                                 BEGIN
                                    INSERT INTO multas (codigo_multa, dia, hora, cantidad, matricula) 
                                                VALUES (@codigo_multa, @dia, @hora, @cantidad, @matricula)
                                 END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            if(multa.codigo != "" || multa.dia != "" || multa.hora != "" || multa.cantidad != "" || multa.matricula != "")
            {
                agregar.Parameters.AddWithValue("@codigo_multa", multa.codigo);
                agregar.Parameters.AddWithValue("@dia", multa.dia);
                agregar.Parameters.AddWithValue("@hora", multa.hora);
                agregar.Parameters.AddWithValue("@cantidad", multa.cantidad);
                agregar.Parameters.AddWithValue("@matricula", multa.matricula);
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

        public void modificarMulta(Multa multa)
        {
            string cadena = @"IF EXISTS(SELECT matricula FROM vehiculos WHERE matricula = @matricula)
                                BEGIN
                                    UPDATE multas
                                       SET codigo_multa = @codigo_multa,
                                           dia = @dia,
                                           hora = @hora,
                                           cantidad = @cantidad,
                                           matricula = @matricula
                                     WHERE id_multa = @id_multa
                                END;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_multa", multa.id_multa);
            modificar.Parameters.AddWithValue("@codigo_multa", multa.codigo);
            modificar.Parameters.AddWithValue("@dia", multa.dia);
            modificar.Parameters.AddWithValue("@hora", multa.hora);
            modificar.Parameters.AddWithValue("@cantidad", multa.cantidad);
            modificar.Parameters.AddWithValue("@matricula", multa.matricula);
        
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

        public void eliminarMulta(Multa multa)
        {
            string cadena = @"DELETE FROM multas
                               WHERE id_multa = @id_multa;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_multa", multa.id_multa);
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
