using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controle.DAL;

namespace controle1.View
{
    public partial class Cardex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualiza();
        }

        protected void btnatu_Click(object sender, EventArgs e)
        {
            atualiza();
        }

        public void atualiza()
        {

            controle.DAL.CardexDAL objpri = new CardexDAL();
            List<controle.DAL.CardexDAL> lprod = new List<CardexDAL>();
            lprod = objpri.Pesquisar();
            gcardex.DataSource = lprod;
            gcardex.DataBind();

            
        }

    }
}