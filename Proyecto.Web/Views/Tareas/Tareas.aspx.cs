using System;
using System.Data;

namespace Proyecto.Web.Views.Tareas
{
    public partial class Tareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Controllers.TareasController obTareasController = new Controllers.TareasController();
                DataSet dsConsultaEstadoTareas = obTareasController.getConsultarEstadoTareasController();
                DataSet dsConsultaPrioridad = obTareasController.getConsultarPrioridadController();

                ddlEstadoTarea.DataSource = dsConsultaEstadoTareas;
                ddlEstadoTarea.DataTextField = "estaDescripcion";
                ddlEstadoTarea.DataValueField = "estaCodigo";
                ddlEstadoTarea.DataBind();

                ddlPrioridad.DataSource = dsConsultaPrioridad;
                ddlPrioridad.DataTextField = "prioDescripcion";
                ddlPrioridad.DataValueField = "prioCodigo";
                ddlPrioridad.DataBind();
            }
        }
    }
}