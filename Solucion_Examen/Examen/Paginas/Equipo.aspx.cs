using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen.Paginas
{
    public partial class Equipo : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind(); //Este comando refresca los datos.
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
            int resultado = Clases.Clase_Usuario.AgregarUsuario(Convert.ToInt32(txtIdequipo.Text), txttipoequipo.Text,txtModelo.Text, txtusuarioid.Text);

            if (resultado > 0)
            {
                alertas("Equipo Agregado Exitosamente");
                txtIdequipo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Equipo");

            }

        }

        protected void botonConsultar_Click(object sender, EventArgs e)
        {

            int codigo = int.Parse(txtIdequipo.Text);
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
                        datagrid.DataBind(); 
                    }
                }
            }
        }

        protected void botonModificar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Clase_Equipo.ModificarEquipo(Convert.ToInt32(txtIdequipo.Text), txttipoequipo.Text, txtModelo.Text, Convert.ToInt32(txtusuarioid.Text) );

            if (resultado > 0)
            {
                alertas("Equipo Modificado Exitosamente");
                txtIdequipo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al Modificar Equipo");

            }

        }

        protected void botonEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Clase_Equipo.EliminarEquipo(int.Parse(txtIdequipo.Text));

            if (resultado > 0)
            {
                alertas("Equipo Eliminado con exito");
                txtIdequipo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al Eliminar Equipo");

            }
        }
    }



}
