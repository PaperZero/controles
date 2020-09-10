using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controle.DAL;

namespace controle1.View
{
    public partial class Conversa : System.Web.UI.Page
    {
        public string nome { get; set; }
       // string senha;
        //string cpf;
        //string cargo;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }

            atualiza();

            controle.DAL.DALfuncionario objpri = new DALfuncionario();


            objpri.IDfuncionario = Convert.ToInt32(Session["usuario"]);

            if (!IsPostBack)
            {
                objpri = objpri.PesquisaID(objpri);

               // objpri.login = nome;

                lblNome.Text = objpri.login;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            controle.DAL.ConversaDAL objla = new ConversaDAL();

            objla.texto = txtconv.Text;
            objla.autor = lblNome.Text;

            objla.enviar(objla);

            atualiza();

        }

        public void atualiza()
        {
            controle.DAL.ConversaDAL objpri = new ConversaDAL();
            List<controle.DAL.ConversaDAL> lconversa = new List<ConversaDAL>();
            lconversa = objpri.Pesquisar();
            gcon.DataSource = lconversa;
            gcon.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            atualiza();
        }
    }
}