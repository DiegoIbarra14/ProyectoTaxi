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
    public class HospitalDAL
    {
        public DataTable Selectall()
        {
            DataTable datos = new DataTable();

            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string consulta = "Select * from Hospital ";

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
        public int Insert(HospitalEL hospital)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "INSERT INTO Hospital(Nombre,Tipo,Direccion)VALUES(@Nombre,@Tipo,@Direccion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", hospital.Nombre);
                    cmd.Parameters.AddWithValue("@Tipo", hospital.Tipo);
                    cmd.Parameters.AddWithValue("@Direccion", hospital.Direccion);
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
        public int Update(HospitalEL hospital)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "UPDATE chofer SET Nombre=@Nombre,Tipo=@Tipo,Direccion=@Direccion WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", hospital.Nombre);
                    cmd.Parameters.AddWithValue("@Tipo", hospital.Tipo);
                    cmd.Parameters.AddWithValue("@Direccion", hospital.Direccion);
                    cmd.Parameters.AddWithValue("@id", hospital.Id);

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
        public int Delete(HospitalEL hospital)
        {
            int request = 0;
            using (SqlConnection con = ConexionDAL.ConectartoBD())
            {
                string query = "DELETE hospital WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", hospital.Id);
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
