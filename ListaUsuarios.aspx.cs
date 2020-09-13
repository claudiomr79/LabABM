 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabABM
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //lblAccion.Text = "Editar Usuario";
                cargarDiasCalendario();
               
            }
            bool estadoAltaOEdicion = !PaginaEnEstadoEdicion();
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
    }
}