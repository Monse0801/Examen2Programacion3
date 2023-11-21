using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen.Clases
{
    public class Clase_Equipo
    {
        public int Equiposid { get; set; }
        public string tipoEquipo { get; set; }
        public string modelo { get; set; }
        public int usuarioID { get; set; }

        public Clase_Equipo() { }

        public Clase_Equipo(int Equiposid, string tipoEquipo, string modelo, int usuarioID)
        {
            this.Equiposid = Equiposid;
            this.tipoEquipo = tipoEquipo;
            this.modelo = modelo;
            this.usuarioID = usuarioID;
        }

        public static int AgregarEquipo(String tipoequipo, String modeloequipo, int usuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipoequipo));
                    cmd.Parameters.Add(new SqlParameter("@ModeloEquipo", modeloequipo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioEquipo", usuario));

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

        public static int ModificarEquipo(int Equiposid, String tipoEquipo, String modelo, int usuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", Equiposid));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@ModeloEquipo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioEquipo", usuario));

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

        public static int EliminarEquipo(int Equiposid)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", Equiposid));

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
        public static List<Clase_Equipo> ConsultarEquipo(int Equiposid)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            List<Clase_Equipo> List = new List<Clase_Equipo>();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", Equiposid));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Clase_Equipo Equipo = new Clase_Equipo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));  
                            List.Add(Equipo);
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
