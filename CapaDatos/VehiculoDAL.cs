using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public  class VehiculoDAL
    {
        public DataTable Selectall()
        {
            DataTable datos = new DataTable();

            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string consulta = "Select * from vehiculo";

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
        public int Insert(VehiculoEL vehiculo)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "INSERT INTO Vehiculo(placa, marca, modelo, Nmotor)VALUES(@placa, @marca, @modelo, @Nmotor)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@placa", vehiculo.Placa);
                    cmd.Parameters.AddWithValue("@marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@Nmotor", vehiculo.NMotor);
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
        public int Update(VehiculoEL vehiculo)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "UPDATE Vehiculo SET placa=@placa,marca=@marca,modelo=@modelo,Nmotor=@Nmotor WHERE plcaca=@placa";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@placa", vehiculo.Placa);
                    cmd.Parameters.AddWithValue("@marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@Nmotor", vehiculo.NMotor);
                    cmd.Parameters.AddWithValue("@placa", vehiculo.Placa);
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
        public int Delete(VehiculoEL vehiculo)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "DELETE Vehiculo  WHERE placa=@placa";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@placa", vehiculo.Placa);
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
