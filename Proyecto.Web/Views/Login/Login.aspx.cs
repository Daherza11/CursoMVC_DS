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
            if (!IsPostBack) //La primera vez que carga la página
            {
                if (Request.Cookies["cookieEmail"] != null)
                {
                    txtEmail.Text = Request.Cookies["cookieEmail"].Value.ToString();
                }
            }
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
                    Session["sessionEmail"] = txtEmail.Text;

                    if (chkRecordar.Checked)
                    {
                        //Creo objeto cookie
                        HttpCookie cookie = new HttpCookie("cookieEmail",txtEmail.Text);
                        cookie.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpCookie cookie = new HttpCookie("cookieEmail", txtEmail.Text);
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                    Response.Redirect("../Index/Index.aspx?stEmail="+ txtEmail.Text);
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