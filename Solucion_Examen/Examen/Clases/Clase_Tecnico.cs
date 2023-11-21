using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen.Clases
{
    public class Clase_Tecnico
    {
            public int tecnicoid { get; set; }
            public string nombre { get; set; }
            public string especialidad { get; set; }

            public Clase_Tecnico() { }

            public Clase_Tecnico(int tecnicoid, string nombre, string especialidad)
            {
                this.tecnicoid = tecnicoid;
                this.nombre = nombre;
                this.especialidad = especialidad;
            }

            public static int AgregarTecnico(int tecnicoid, String nombre, string especialidad)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConex.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("AgregarTecnico", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                    cmd.Parameters.Add(new SqlParameter("@TecnicoID", tecnicoid));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                        cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));

                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }
                return retorno;
            }

            public static int ModificarTecnico(int tecnicoid, String nombre, String especialidad)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConex.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("ModificarTecnico", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@TecnicoID", tecnicoid));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                        cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));
                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }
                return retorno;
            }

            public static int EliminarTecnico(int tecnicoid)
            {
                int retorno = 0;
                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConex.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("EliminarTecnico", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@TecnicoID", tecnicoid));

                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }
                return retorno;
            }
            public static List<Clase_Tecnico> ConsultarTecnico(int tecnicoid)
            {
                int retorno = 0;
                SqlConnection Conn = new SqlConnection();
                List<Clase_Tecnico> List = new List<Clase_Tecnico>();
                try
                {
                    using (Conn = DBConex.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("ConsultarTecnico", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@TecnicoID", tecnicoid));
                        retorno = cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            Clase_Tecnico Tecnico = new Clase_Tecnico(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));  
                                List.Add(Tecnico);
                            }
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return List;
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }
                return List;
            }
        }
    }
