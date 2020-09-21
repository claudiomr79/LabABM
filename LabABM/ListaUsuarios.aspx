<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="LabABM.ListaUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="odsUsuarios" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario" />
                    <asp:BoundField DataField="FechaDateTime" HeaderText="FechaNac" SortExpression="FechaDateTime" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ListaUsuarios.aspx?id={0}" Text="Editar" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="odsUsuarios" runat="server" DataObjectTypeName="Negocio.Usuario" DeleteMethod="BorrarUsuario" SelectMethod="GetAll" TypeName="Negocio.ManagerUsuarios"></asp:ObjectDataSource>
        </div>
    <br /><br />
    <table border="1">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblAccion" runat="server" ForeColor="#66CCFF"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Apellido:</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe tener valor"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Nombre:</td>
                
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Tipo de Documento:</td>
                <td>
                    <asp:RadioButtonList ID="rblTipoDocumento" runat="server">
                        <asp:ListItem Value="1">DNI</asp:ListItem>
                        <asp:ListItem Value="2">LC / LE</asp:ListItem>
                        <asp:ListItem Value="3">C&#233;dula Identidad</asp:ListItem>
                        <asp:ListItem Value="4">Pasaporte</asp:ListItem>
                        <asp:ListItem Value="5">Otro</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Nro de Documento:</td>
                <td>
                    <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Fecha de Nacimiento:</td>
                <td>
                    <asp:DropDownList ID="ddlDiaFechaNacimiento" runat="server">
                         </asp:DropDownList>
                    <asp:DropDownList ID="ddlMesFechaNacimiento" runat="server">
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtAnioFechaNacimiento" runat="server" MaxLength="4" Width="50px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Dirección:</td>
                <td>
                    <asp:TextBox ID="txtDirección" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Teléfono:</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Celular:</td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Nombre de Usuario:</td>
                <td>
                    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Clave:</td>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Confirmar Clave:</td>
                <td>
                    <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
                <td align="center">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
