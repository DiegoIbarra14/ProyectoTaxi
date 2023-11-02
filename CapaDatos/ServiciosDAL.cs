using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ServiciosDAL
    {
        public DataTable Selectall()
        {
            DataTable datos = new DataTable();

            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string consulta = "Select * from Servicios";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);

                try
                {
                    con.Open();
                    adapter.Fill(datos);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }


            }
            return datos;


        }
        public int Insert(ServiciosEL servicio)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "INSERT INTO chofer(fecha_Servicio,idHospital,dni)VALUES(@fecha_Servicio,@idHospital,@dni)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fecha_Servicio",servicio.FechaServicio);
                    cmd.Parameters.AddWithValue("@idHospital", servicio.IdHospital);
                    cmd.Parameters.AddWithValue("@dni", servicio.Dni);
                   
                    try
                    {
                        con.Open();
                        request = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            return request;

        }
        public int Update(ServiciosEL servicio)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "UPDATE Servicios SET Fecha_Servicio=@Fecha_Servicio,IdHospital=@IdHospital,dni=@dni WHERE idServicio=@idServicio";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fecha_Servicio", servicio.FechaServicio);
                    cmd.Parameters.AddWithValue("@idHospital", servicio.IdHospital);
                    cmd.Parameters.AddWithValue("@dni", servicio.Dni);
                    cmd.Parameters.AddWithValue("idServicio", servicio.Id);

                    try
                    {
                        con.Open();
                        request = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            return request;

        }
        public int Delete(ServiciosEL servicio)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "DELETE Servicios WHERE idServicio=@idServicio";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idServicio", servicio.Id);
                    try
                    {
                        con.Open();
                        request = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            return request;
        }
    }
}
