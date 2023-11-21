using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen.Clases;

namespace Examen.Paginas
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind(); 
                        }
                    }

                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void botonAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Clase_Usuario.AgregarUsuario(Convert.ToInt32(txtIdUsuario.Text), txtnombre.Text, txtCorreo.Text, txttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario Agregado Exitosamente");
                txtIdUsuario.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Usuario");

            }

        }

        protected void botonConsultar_Click(object sender, EventArgs e)
        {
            
            int codigo = int.Parse(txtIdUsuario.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TIPO WHERE ID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        protected void botonModificar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Clase_Usuario.ModificarUsuario(Convert.ToInt32(txtIdUsuario.Text), txtnombre.Text, txtCorreo.Text, txttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario Modificado Exitosamente");
                txtIdUsuario.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Usuario");

            }

        }

        protected void botonEliminar_Click(object sender, EventArgs e)
        {
                int resultado = Clases.Clase_Usuario.EliminarUsuario(int.Parse(txtIdUsuario.Text));

                if (resultado > 0)
                {
                    alertas("Usuario Eliminado con exito");
                    txtIdUsuario.Text = string.Empty;
                    LlenarGrid();
                }
                else
                {
                    alertas("Error al eliminar Usuario");

                }
            }
        }




      
}