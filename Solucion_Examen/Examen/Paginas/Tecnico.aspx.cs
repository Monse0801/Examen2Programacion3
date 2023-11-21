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
    public partial class Tecnico : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos"))
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
            int resultado = Clases.Clase_Tecnico.AgregarTecnico(Convert.ToInt32(txtIdtecnico.Text), txtnombre.Text, txtespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico Agregado Exitosamente");
                txtIdtecnico.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Tecnico");

            }

        }

        protected void botonConsultar_Click(object sender, EventArgs e)
        {

            int codigo = int.Parse(txtIdtecnico.Text);
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
            int resultado = Clases.Clase_Tecnico.ModificarTecnico(Convert.ToInt32(txtIdtecnico.Text), txtnombre.Text, txtespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico Modificado Exitosamente");
                txtIdtecnico.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Tecnico");

            }

        }

        protected void botonEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Clase_Tecnico.EliminarTecnico(int.Parse(txtIdtecnico.Text));

            if (resultado > 0)
            {
                alertas("Tecnico Eliminado con exito");
                txtIdtecnico.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar Tecnico");

            }
        }
    }

}
