<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="Examen.Paginas.Tecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<div class="container text-center">
    <h1>Tecnicos </h1>
    <p>&nbsp;</p>
</div>
<div>
    <br />
    <br />
    <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

    <br />
    <br />
    <br />


        <div class="Columnas">
            <table class="auto-style6" align="left">
                <tr>
                    <td class="auto-style2"><strong>ID Tecnico:  </strong></td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtIdtecnico" runat="server" Height="30px"  Width="249px"></asp:TextBox>
                    </td>
                </tr>
       <tr>
    <td class="auto-style2"><strong>Nombre :</strong></td>
    <td class="auto-style2">
        <asp:TextBox ID="txtnombre" runat="server" Height="30px" Width="249px"></asp:TextBox>
    </td>
</tr>
                <tr>
                    <td class="auto-style2"><strong>Especialidad:  </strong></td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtespecialidad" runat="server" Height="30px" Width="249px"></asp:TextBox>
                    </td>
                </tr>
               
            </table>
        </div>
    <div class="container text-center">
        <div class="Botones">
            <br />
            <br />
            <asp:Button ID="botonAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="botonAgregar_Click"   />
            <asp:Button ID="botonConsultar" class="btn btn-info" runat="server" Text="Consultar" OnClick="botonConsultar_Click"  />
            <asp:Button ID="botonModificar" class="btn btn-warning" runat="server" Text="Modificar" OnClick="botonModificar_Click"  />
            <asp:Button ID="botonEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="botonEliminar_Click" />
            <br />
            <br />
        </div>
    </div>
      </div>
</asp:Content>
