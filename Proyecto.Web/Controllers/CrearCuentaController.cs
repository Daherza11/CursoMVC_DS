using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Web.Controllers
{
    public class CrearCuentaController
    {
        public string setCrearCuentaController(Logica.Models.clsUsuarios obclsUsuarios, int inOpcion)
        {
            try
            {
                Logica.BL.clsUsuarios obclsUsuario = new Logica.BL.clsUsuarios();
                return obclsUsuario.setCrearCuenta(obclsUsuarios, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}