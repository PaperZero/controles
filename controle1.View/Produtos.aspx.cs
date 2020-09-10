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
        public string Validade { get; set; }
        public string entrada { get; set; }

        public int retorno { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            atualiza();
           // txtmov.Text = "Pesquise um produto primeiro";
            txtmov.Enabled = false;


        }

        protected void btncad_Click(object sender, EventArgs e)
        {

            if (txtnopro.Text == "" || txtval.Text == null)
            {
                txtnopro.Text = "Dados invalidos";
                return;
            }

           // Valida_data(Validade);
            Valida_preco(Preco);
            Valida_quantidade(Quantidade);

            if (retorno >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ID não encontrado')", true);

                return;

            }

            controle.DAL.ProdutoDAL objteste = new ProdutoDAL();
 

            objteste.Nome_produto = txtnopro.Text;
            objteste.Preco = Convert.ToDecimal(txtpreco.Text);
            objteste.Quantidade = Convert.ToInt16(txtquan.Text);
            //  objteste.Validade = Convert.ToDateTime(txtval.Text);
            objteste.Validade = txtval.Text;

            objteste.entrada = DateTime.Now.ToString("dd/MM/yyyy");


            objteste.cadastrar(objteste);
            atualiza();
        }

        protected void btnpesq_Click(object sender, EventArgs e)
        {
            txtmov.Text = string.Empty;

            ValidaID(IdProduto);

            if (retorno >= 1)
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
            txtval.Text = objteste.Validade;
            lblEntrada.Text = objteste.entrada.ToString();//("dd/MM/yyyy");

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

            ValidaID(IdProduto);
            Valida_quantidade(Quantidade);

            if (retorno >= 1)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ID não encontrado')", true);

                return;

            }

            controle.DAL.CardexDAL objsei = new CardexDAL();
            controle.DAL.ProdutoDAL objteste = new ProdutoDAL();
            controle.DAL.CardexDAL objcad = new CardexDAL();



            objteste.IdProduto = Convert.ToInt32(txtidpro.Text);

            objcad.IdProduto = Convert.ToInt32(txtidpro.Text);
            objcad.Produto = txtnopro.Text;

            objsei.IdProduto = Convert.ToInt32(txtidpro.Text);
            objsei.Produto = txtnopro.Text;

           // DateTime teste;
          //  teste = lblEntrada;
            
         //   objsei.Entrada = Convert.ToDateTime(lblEntrada.Text);
         //   objsei.Validade = Convert.ToDateTime(txtval.Text);
            objsei.Entrada = lblEntrada.Text;
            objsei.Validade = txtval.Text;



           // objcad.Entrada = Convert.ToDateTime(lblEntrada.Text);
           // objcad.Validade = Convert.ToDateTime(txtval.Text);

            objcad.Entrada = lblEntrada.Text;
            objcad.Validade = txtval.Text;


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

                objcad.Quantidade = Convert.ToInt32(txtquan.Text);

                
                objcad.cadastrar2(objcad);


            }
            if (rbtira.Checked)
            {

                depois = quantidade - movimento;
                objteste.Quantidade = depois;
                objteste.movimento(objteste);

                string hoje;
                hoje = DateTime.Now.ToString("dd/MM/yyyy");
                

                objsei.Saida = hoje;
                
                objsei.Quantidade = Convert.ToInt32(txtquan.Text);
                objsei.cadastrar(objsei);

            }


            atualiza();


        }

        //inicio dos metodos de validaçao (ainda vou ver se vai dar certp)

        public void ValidaID(int IdProduto)
        {
           


            if (txtidpro.Text == null || !int.TryParse(txtidpro.Text,out IdProduto))
            {
                txtidpro.Text = "Dados invalidos";
                retorno++;
                return;
            }
    

           
        }
        

        public void Valida_quantidade(int Quantidade)
        {
            if (txtquan.Text == null || !int.TryParse(txtquan.Text, out Quantidade))
            {
                txtquan.Text = "Dados invalidos";
                retorno++;
                return;
            }
           

        }

        public void Valida_preco(decimal Preco)
        {
            if (txtpreco.Text == null || !decimal.TryParse(txtpreco.Text, out Preco)  )
            {
                txtpreco.Text = "Dados invalidos";
                retorno++;
                return;
            }
            

        }

        public void Valida_data(DateTime Validade)
        {
            if (txtval.Text == null || !DateTime.TryParse(txtval.Text, out Validade))
            {
                txtval.Text = "Dados invalidos";
                retorno++;
                return;
            }
           

        }


        public void pega_valores()
        {



            IdProduto = Convert.ToInt16(txtidpro.Text);
            Nome_produto = txtnopro.Text;
            Preco = Convert.ToDecimal(txtpreco.Text);
            Quantidade = Convert.ToInt16(txtquan.Text);
            //Validade = Convert.ToDateTime(txtval.Text);
            

        }
    }
}





/*tenho que pegar a quantidade do movimento
 * ver a quantidade do produto que tem no banco 
 * (a quantidade obrigatoriamente vai estar no txt de quantidade)
 * fazer a subtraçao ou soma
 * atualizar no banco*/