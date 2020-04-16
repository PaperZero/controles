using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controle.DAL;

namespace controle1.View
{
    public partial class Produtos : System.Web.UI.Page
    {

        public int IdProduto { get; set; }
        public string Nome_produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public DateTime entrada { get; set; }

        public bool retorno { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            atualiza();
            txtmov.Text = "Pesquise um produto primeiro";
            txtmov.Enabled = false;


        }

        protected void btncad_Click(object sender, EventArgs e)
        {
            controle.DAL.ProdutoDAL objteste = new ProdutoDAL();

            

            objteste.Nome_produto = txtnopro.Text;
            objteste.Preco = Convert.ToDecimal(txtpreco.Text);
            objteste.Quantidade = Convert.ToInt16(txtquan.Text);
            objteste.Validade = Convert.ToDateTime(txtval.Text);
            objteste.entrada = DateTime.Now;

            objteste.cadastrar(objteste);
            atualiza();
        }

        protected void btnpesq_Click(object sender, EventArgs e)
        {
            ValidaID(IdProduto);

            if (retorno == false)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ID não encontrado')", true);

                return;

            }

            controle.DAL.ProdutoDAL objteste = new ProdutoDAL();

            objteste.IdProduto = Convert.ToInt32(txtidpro.Text);

            objteste = objteste.pesquisarID(objteste);
            
            txtnopro.Text = objteste.Nome_produto;
            txtpreco.Text = Convert.ToString(objteste.Preco);
            txtquan.Text = Convert.ToString(objteste.Quantidade);
            txtval.Text = objteste.Validade.ToString("dd/MM/yyyy");
            lblEntrada.Text = objteste.entrada.ToString("dd/MM/yyyy");

            txtquan.Enabled = false;
            txtmov.Enabled = true;

        }
        public void atualiza()
        {

            controle.DAL.ProdutoDAL objpri = new ProdutoDAL();
            List<controle.DAL.ProdutoDAL> lprod = new List<ProdutoDAL>();
            lprod = objpri.Pesquisar();
            gvprod.DataSource = lprod;
            gvprod.DataBind();

        }

        protected void btnmov_Click(object sender, EventArgs e)
        {

            sei();

            controle.DAL.CardexDAL objsei = new CardexDAL();
            controle.DAL.ProdutoDAL objteste = new ProdutoDAL();
            objteste.IdProduto = Convert.ToInt32(txtidpro.Text);

            objsei.IdProduto = Convert.ToInt32(txtidpro.Text);
            objsei.Produto = txtnopro.Text;
            
            objsei.Entrada = Convert.ToDateTime(lblEntrada.Text);
            objsei.Validade = Convert.ToDateTime(txtval.Text);

            


            int movimento;
            int quantidade;
            int depois;

            movimento = Convert.ToInt32(txtmov.Text);
            quantidade = Convert.ToInt32(txtquan.Text);
           
           

            if (rbsoma.Checked)
            {
                depois = quantidade + movimento;
                objteste.Quantidade = depois;
                objteste.movimento(objteste);

                objsei.Quantidade = Convert.ToInt32(txtquan.Text);
                objsei.cadastrar(objsei);

            }
            if (rbtira.Checked)
            {

                depois = quantidade - movimento;
                objteste.Quantidade = depois;
                objteste.movimento(objteste);

                objsei.Saida = DateTime.Today;
                objsei.Quantidade = Convert.ToInt32(txtquan.Text);
                objsei.cadastrar(objsei);

            }


            atualiza();

        }

        //inicio dos metodos de validaçao (ainda vou ver se vai dar certp)

        public void ValidaID(int IdProduto)
        {

            if(!int.TryParse(txtidpro.Text,out IdProduto))
            {
                txtidpro.Text = string.Empty;
              retorno = false ;
                return;
            }
            retorno = true;

           
        }

        public void sei()
        {
            if (txtmov.Text == "teste")
            {
                lblEntrada.Text = "deu certo";
            }

        }
    }
}





/*tenho que pegar a quantidade do movimento
 * ver a quantidade do produto que tem no banco 
 * (a quantidade obrigatoriamente vai estar no txt de quantidade)
 * fazer a subtraçao ou soma
 * atualizar no banco*/