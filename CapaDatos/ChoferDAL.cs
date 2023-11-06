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
    public class ChoferDAL
    {
        public DataTable Selectall()
        {
            DataTable datos = new DataTable();

            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string procedure = "Mostrar_Chofer";

                SqlCommand cmd = new SqlCommand(procedure,con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        public string Insert(ChoferEL chofer)
        {
            int request = 0;
            string valor = "";
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "INSERT INTO chofer(dni,Nombre,ApellidoP,ApellidoM,FechaIngreso,placa)VALUES(@dni,@Nombre,@ApellidoP,@ApellidoM,@FechaIngreso,@placa)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", chofer.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoP",chofer.ApellidoP);
                    cmd.Parameters.AddWithValue("@ApellidoM", chofer.ApellidoM);
                    cmd.Parameters.AddWithValue("@FechaIngreso", chofer.Ingreso);
                    cmd.Parameters.AddWithValue("@placa", chofer.Placa);
                    try
                    {
                        con.Open();
                        request = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine(ex.Message);
                        valor = ex.Message;
                    }

                }

            }
            return valor;

        }
        public int Update(ChoferEL chofer)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "UPDATE chofer SET dni=@dni,Nombre=@Nombre,ApellidoP=@ApellidoP,ApellidoM=@ApellidoM,FechaIngreso=@FechaIngreso,placa=@placa WHERE dni=@dni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", chofer.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoP", chofer.ApellidoP);
                    cmd.Parameters.AddWithValue("@ApellidoM", chofer.ApellidoM);
                    cmd.Parameters.AddWithValue("@FechaIngreso", chofer.Ingreso);
                    cmd.Parameters.AddWithValue("@placa", chofer.Placa);

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
        public int Delete(ChoferEL chofer)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "DELETE chofer WHERE dni=@dni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", chofer.Dni);
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
