 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace LabABM
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        int idUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool estadoAlta = !PaginaEnEstadoEdicion();
            if (estadoAlta)
                {
                    lblAccion.Text = "Agregar Nuevo Usuario";

                }
                else
                {
                    lblAccion.Text = "Editar Usuario " + idUsuario.ToString();
                    idUsuario = Convert.ToInt32(Request.QueryString["id"]);
                    CargarDatosUsuario(idUsuario);
                }
               
            
            if (!IsPostBack)
            {
               
                cargarDiasCalendario();
               
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
            Usuario usuarioActual;
            ManagerUsuarios manager = new ManagerUsuarios();
            usuarioActual = manager.GetUsuario(idUsuario);
            txtApellido.Text = usuarioActual.Apellido;
            txtNombre.Text = usuarioActual.Nombre;
            rblTipoDocumento.SelectedValue = usuarioActual.TipoDoc.ToString();
            txtNroDocumento.Text = usuarioActual.NroDoc.ToString();
            // ddlDiaFechaNacimiento.SelectedValue= usuarioActual.FechaNac.
            //ddlMesFechaNacimiento.SelectedValue= usuarioActual.FechaNac.
            txtDirección.Text = usuarioActual.Direccion;
            txtTelefono.Text = usuarioActual.Telefono;
            txtEmail.Text = usuarioActual.Email;
            txtCelular.Text = usuarioActual.Celular;
            txtNombreUsuario.Text = usuarioActual.NombreUsuario;
            txtClave.Text = usuarioActual.Clave;
            txtConfirmarClave.Text = usuarioActual.Clave;
        }
    }
}