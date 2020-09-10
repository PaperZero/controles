using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controle.DAL;

namespace controle1.View
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualiza();


        }

        protected void btnentrar_Click(object sender, EventArgs e)

        {

            if (txtusu.Text  == null || txtsen.Text == null || txtcar.Text == null || txtcpf == null)
            {
                txtusu.Text = "preencha todos os campos";

                return;
            }
            



            //chama a dal e da os valores em objeto para ela cadastrar
            controle.DAL.DALfuncionario objpri = new DALfuncionario();
            
            objpri.login = txtusu.Text;
            objpri.senha = txtsen.Text;
            objpri.cargo = txtcar.Text;
            objpri.CPF = txtcpf.Text;

            //retorna o objeto para a dal
            objpri.Cadastro(objpri);

            atualiza();
        }

        protected void btnpesquisa_Click(object sender, EventArgs e)
        {
            atualiza();

        }

        protected void btnid_Click(object sender, EventArgs e)
        {

            controle.DAL.DALfuncionario objpri = new DALfuncionario();

            objpri.IDfuncionario = Convert.ToInt32(txtid.Text);

            objpri = objpri.PesquisaID(objpri);
            txtusu.Text = objpri.login;
            txtsen.Text = objpri.senha;
            txtcar.Text = objpri.cargo;
            txtcpf.Text = objpri.CPF;

           txtcpf.Enabled = false;
        }

        //fiz errado e agora nao tem mais como apagar
        protected void btnid_Click1(object sender, EventArgs e)
        {

        }

        protected void btntudo_Click(object sender, EventArgs e)
        {

        //    controle.DAL.DALfuncionario objpri = new DALfuncionario();
        //    objpri.tudo(objpri);

        }

        protected void btnedi_Click(object sender, EventArgs e)
        {

            if (txtusu.Text == null || txtsen.Text == null || txtcar.Text == null || txtcpf == null)
            {
                txtusu.Text = "preencha todos os campos";
                return;
            }

            controle.DAL.DALfuncionario objpri = new DALfuncionario();

            objpri.IDfuncionario = Convert.ToInt32(txtid.Text);
            objpri.login = txtusu.Text;
            objpri.cargo = txtcar.Text;
            objpri.senha = txtsen.Text;


            objpri.editar(objpri);

            txtcpf.Enabled = true;
            txtcpf.Text = string.Empty;
            atualiza();

        }

        public void atualiza()
        {
            controle.DAL.DALfuncionario objpri = new DALfuncionario();
        List<controle.DAL.DALfuncionario> lfuncionarios = new List<DALfuncionario>();
        lfuncionarios = objpri.Pesquisar();
            Gvfun.DataSource = lfuncionarios;
            Gvfun.DataBind();
            

        }
}
}