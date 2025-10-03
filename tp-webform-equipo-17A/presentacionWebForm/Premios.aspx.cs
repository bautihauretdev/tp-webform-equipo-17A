using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacionWebForm
{
    public partial class Premios : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            ListaArticulos = artNegocio.Listar();

            rRepetidor.DataSource = ListaArticulos;
            rRepetidor.DataBind();

        }
    }
}