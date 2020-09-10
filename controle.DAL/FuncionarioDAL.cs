using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace controle.DAL
{
    public class DALfuncionario
    {
        public int IDfuncionario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string cargo { get; set; }
        public string CPF { get; set; }
        public List<DALfuncionario> listaFuncionario { get; set; }



        private SqlConnection conn;

        string caminho = "workstation id=controle.mssql.somee.com;packet size=4096;user id=Papel_zero_SQLLogin_1;pwd=k9nni8mvty;data source=controle.mssql.somee.com;persist security info=False;initial catalog=controle";


        public DALfuncionario()
        {
            conn = new SqlConnection(caminho);
            conn.Open();

           
        }
        public void fecha()
        {
            this.conn.Close();

        }




 
        //cadastra itens no banco de dados
        public void Cadastro(DALfuncionario cadastro)
        {
            /*SqlConnection conn = new SqlConnection("workstation id=controle.mssql.somee.com;packet size=4096;user id=Papel_zero_SQLLogin_1;pwd=k9nni8mvty;data source=controle.mssql.somee.com;persist security info=False;initial catalog=controle");
            conn.Open();*/

            SqlCommand cmd = new SqlCommand("insert into funcionario values (@login, @CPF, @cargo, @senha )", conn);

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@Senha", senha);

            cmd.ExecuteNonQuery();

            fecha();


        }


        //pesquisar que vai dar retorno em uma tabela
        public List<DALfuncionario> Pesquisar()
        {
            SqlCommand cmd = new SqlCommand("select *from Funcionario", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<DALfuncionario> listaFuncionario = new List<DALfuncionario>();

            while (dr.Read())
            {
                DALfuncionario objlista = new DALfuncionario();

                objlista.IDfuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                objlista.login = dr["Nome"].ToString();
                objlista.CPF = dr["CPF"].ToString();
                objlista.cargo = dr["Cargo"].ToString();
                objlista.senha = dr["Senha"].ToString();

                listaFuncionario.Add(objlista);

            }


            return listaFuncionario;
        }

        public DALfuncionario PesquisaID(DALfuncionario PesquisaID)
        {
            SqlCommand cmd = new SqlCommand("select *from Funcionario where IdFuncionario =@id", conn);

            cmd.Parameters.AddWithValue("@id", IDfuncionario);

            SqlDataReader dr = cmd.ExecuteReader();

            DALfuncionario objfoi = new DALfuncionario();

            if (dr.Read())
            {
                objfoi.login = dr["Nome"].ToString();
                objfoi.cargo = dr["Cargo"].ToString();
                objfoi.senha = dr["Senha"].ToString();
                objfoi.CPF = dr["CPF"].ToString();

            }

            return objfoi;


        }

        //o codigo esta começando a ficar bagunçado...
         public void tudo(DALfuncionario tudo)
        {

            SqlCommand cmd = new SqlCommand("delete from funcionario", conn);
            cmd.ExecuteNonQuery();
        }
        //tenho que mudar o nome senha e cargo pelo id
        public void editar(DALfuncionario editar)
        {

            SqlCommand cmd = new SqlCommand("update Funcionario set Nome = @nome, Cargo = @cargo, Senha = @senha where IdFuncionario = @id", conn);

            cmd.Parameters.AddWithValue("@id", IDfuncionario);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@Senha", senha);
            cmd.Parameters.AddWithValue("@nome", login);
            cmd.ExecuteNonQuery();

        }

       
        public DALfuncionario logon(DALfuncionario funcionario)
        {

            SqlCommand cmd = new SqlCommand("select *from Funcionario where nome = @login and senha = @senha", conn);

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader dr = cmd.ExecuteReader();

            DALfuncionario objlogon = new DALfuncionario();

            if (dr.Read())
            {
                objlogon.IDfuncionario = Convert.ToInt32(dr["IDfuncionario"]);
                objlogon.login = dr["nome"].ToString();
                objlogon.senha = dr["senha"].ToString();
                objlogon.cargo = dr["cargo"].ToString();
                objlogon.CPF = dr["CPF"].ToString();


            }
            return objlogon;



        }

    }
}
