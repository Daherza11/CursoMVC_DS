using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ctrl + K + C es Comentar
            //Ctrl + K + U es Descomentar
            //if (!IsPostBack)
            //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('¡Buen trabajo!','Se realizó proceso con éxito', 'success')</script>");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese email,";
                if (string.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese contraseña,";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                //Defino objeto con propiedades
                Logica.Models.clsUsuarios obclsUsuarios = new Logica.Models.clsUsuarios
                {
                    stLogin = txtEmail.Text,
                    stPassword = txtPassword.Text
                };

                //Instancio controlador
                Controllers.LoginController obLoginController = new Controllers.LoginController();
                bool blBandera = obLoginController.getValidarUsuarioController(obclsUsuarios);

                if (blBandera)
                {
                    Response.Redirect("../Index/Index.aspx");
                }
                else
                {
                    throw new Exception("Usuario o Password incorrectos");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('¡Error!','" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}