using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Examen.Paginas;

namespace Examen.Clases
{
    public class Clase_Usuario
    {
        public int usuarioid { get; set; }
        public string nombre { get; set; }
        public string correoelectronico { get; set; }
        public string telefono { get; set; }

        public Clase_Usuario() { }

        public Clase_Usuario(int usuarioid, string nombre, string correoelectronico, string telefono)
        {
            this.usuarioid = usuarioid;
            this.nombre = nombre;
            this.correoelectronico = correoelectronico;
            this.telefono = telefono;
        }

        public static int AgregarUsuario(int usuarioid,String nombre, String correoelectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_USUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioid));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));

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

        public static int ModificarUsuario(int usuarioid, String nombre, String correoelectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioid));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));

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

        public static int EliminarUsuario(int usuarioid)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioid));

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
        public static List<Clase_Usuario> ConsultarUsuario(int usuarioid)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            List<Clase_Usuario> List = new List<Clase_Usuario>();
            try
            {
                using (Conn = DBConex.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioid));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Clase_Usuario Usuario = new Clase_Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  
                            List.Add(Usuario);
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
