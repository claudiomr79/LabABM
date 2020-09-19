 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Negocio;


namespace LabABM
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        int idUsuario;
        bool estadoAlta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDiasCalendario();
               
            }
                     
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            estadoAlta = !PaginaEnEstadoEdicion();

            if (estadoAlta)
            {
                lblAccion.Text = "Agregar Nuevo Usuario";

            }
            else
            {
                idUsuario = Convert.ToInt32(Request.QueryString["id"]);
                lblAccion.Text = "Editar Usuario " + idUsuario.ToString();
                CargarDatosUsuario(idUsuario);
            }

        }
private bool PaginaEnEstadoEdicion()
        {
            if (Request.QueryString["id"] != null)
            {
                return true;//en edicion
            }
            else
            {
                return false;//alta
            }
        }

        private void cargarDiasCalendario()
        {
            for (int i = 1; i <= 31; i++)
            {
                ListItem num = new ListItem(i.ToString(), i.ToString());
                ddlDiaFechaNacimiento.Items.Add(num);
            }
        }
        private void CargarDatosUsuario(int idUsuario)
        {
            // 1 - Obtener los datos del usuario en cuestión
            // 2 - Cargar en los controles de la tabla los datos del usuario obtenido
            
            ManagerUsuarios manager = new ManagerUsuarios();
            Usuario usuarioActual = new Usuario();
            usuarioActual = manager.GetUsuario(idUsuario);
            txtApellido.Text = usuarioActual.Apellido;
            txtNombre.Text = usuarioActual.Nombre;
            rblTipoDocumento.SelectedIndex = usuarioActual.TipoDoc.Value -1;
            txtNroDocumento.Text = usuarioActual.NroDoc.ToString();
            //ddlDiaFechaNacimiento.SelectedValue= usuarioActual.FechaNac.
            //ddlMesFechaNacimiento.SelectedValue= usuarioActual.FechaNac.
            txtDirección.Text = usuarioActual.Direccion;
            txtTelefono.Text = usuarioActual.Telefono;
            txtEmail.Text = usuarioActual.Email;
            txtCelular.Text = usuarioActual.Celular;
            txtNombreUsuario.Text = usuarioActual.NombreUsuario;
           //txtClave.Text = usuarioActual.Clave;
            //txtConfirmarClave.Text = usuarioActual.Clave;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usr = new Usuario();
            if (Page.IsPostBack)
            {
               
                usr.Id = idUsuario;
                usr.Apellido = txtApellido.Text;
                usr.Nombre = txtNombre.Text;
                usr.Direccion = txtDirección.Text;
                usr.Telefono = txtTelefono.Text;
                usr.Email = txtEmail.Text;
                usr.Celular = txtCelular.Text;
                usr.NombreUsuario = txtNombreUsuario.Text;
                usr.Clave = txtClave.Text;
                usr.TipoDoc = Int32.Parse(rblTipoDocumento.SelectedValue);
                if (txtNroDocumento != null)
                    usr.NroDoc = Int32.Parse(txtNroDocumento.Text);
                usr.FechaNac = ddlDiaFechaNacimiento.SelectedItem.ToString() + "/" + ((ddlMesFechaNacimiento.SelectedIndex) +1).ToString() + "/" + txtAnioFechaNacimiento.Text; 
            }
           
            if (estadoAlta)
            {
                ManagerUsuarios manager = new ManagerUsuarios();
                manager.AgregarUsuario(usr);
                grdUsuarios.DataBind();
            }
            else
            {
                ManagerUsuarios manager = new ManagerUsuarios();
                manager.ActualizarUsuario(usr);
                grdUsuarios.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListaUsuarios.aspx");
        }
    }
}