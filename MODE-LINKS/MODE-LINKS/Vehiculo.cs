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
    internal class Vehiculo
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS; Integrated Security = True");
        string cadenaSql = @"SELECT *
                               FROM vehiculos
                              ORDER BY id_vehiculo;";

        public string id_vehiculo { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string entrada { get; set; }
        public string salida { get; set; }
        public string id_multa { get; set; }


        public DataTable conexionConLaTabla()
        {
            SqlDataAdapter puenteConLaTabla = new SqlDataAdapter(cadenaSql, conexion);
            DataTable dt = new DataTable();
            puenteConLaTabla.Fill(dt);
            return dt;
        }

        public void agregarVehiculo(Vehiculo vehiculo)
        {
            string cadena = @"IF NOT EXISTS(SELECT matricula, marca, modelo
                                              FROM vehiculos 
                                             WHERE matricula = @matricula
                                               AND marca = @marca
                                               AND modelo = @modelo)
                                BEGIN
                                    INSERT INTO vehiculos (matricula, marca, modelo, fecha_entrada, fecha_salida, id_multa) 
                                                   VALUES (@matricula, @marca, @modelo, @fecha_entrada, @fecha_salida, @id_multa)
                                END;";

            SqlCommand agregar = new SqlCommand(cadena, conexion);
            if(vehiculo.matricula != "" || vehiculo.marca != "" || vehiculo.modelo != "" || vehiculo.entrada != "")
            {
                agregar.Parameters.AddWithValue("@matricula", vehiculo.matricula);
                agregar.Parameters.AddWithValue("@marca", vehiculo.marca);
                agregar.Parameters.AddWithValue("@modelo", vehiculo.modelo);
                agregar.Parameters.AddWithValue("@fecha_entrada", vehiculo.entrada);
                agregar.Parameters.AddWithValue("@fecha_salida", vehiculo.salida);
                agregar.Parameters.AddWithValue("@id_multa", vehiculo.id_multa);
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

        public void modificarVehiculo(Vehiculo vehiculo)
        {
            string cadena = @"IF EXISTS(SELECT id_multa, matricula
                                          FROM multas
                                         WHERE id_multa = @id_multa
                                           AND matricula = @matricula
                                            OR @id_multa = 0)
                                BEGIN
                                     UPDATE vehiculos
                                        SET matricula = @matricula,
                                            marca = @marca,
                                            modelo = @modelo,
                                            fecha_entrada = @fecha_entrada,
                                            fecha_salida = @fecha_salida,
                                            id_multa = @id_multa
                                      WHERE id_vehiculo = @id_vehiculo
                                END;";

            SqlCommand modificar = new SqlCommand(cadena, conexion);
            modificar.Parameters.AddWithValue("@id_vehiculo", vehiculo.id_vehiculo);
            modificar.Parameters.AddWithValue("@matricula", vehiculo.matricula);
            modificar.Parameters.AddWithValue("@marca", vehiculo.marca);
            modificar.Parameters.AddWithValue("@modelo", vehiculo.modelo);
            modificar.Parameters.AddWithValue("@fecha_entrada", vehiculo.entrada);
            modificar.Parameters.AddWithValue("@fecha_salida", vehiculo.salida);
            modificar.Parameters.AddWithValue("@id_multa", vehiculo.id_multa);
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

        public void eliminarVehiculo(Vehiculo vehiculo)
        {
            string cadena = @"DELETE FROM vehiculos
                               WHERE id_vehiculo = @id_vehiculo;";
            SqlCommand eliminar = new SqlCommand(cadena, conexion);
            eliminar.Parameters.AddWithValue("@id_vehiculo", vehiculo.id_vehiculo);
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
