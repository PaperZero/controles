using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace controle.DAL
{
    public class ProdutoDAL
    {
        public int IdProduto { get; set; }
        public string Nome_produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Validade { get; set; }
        public string entrada { get; set; }
        public List<ProdutoDAL> listaprodutos { get; set; }


        private SqlConnection conn;

        string caminho = "workstation id=controle.mssql.somee.com;packet size=4096;user id=Papel_zero_SQLLogin_1;pwd=k9nni8mvty;data source=controle.mssql.somee.com;persist security info=False;initial catalog=controle";


        public ProdutoDAL()
        {
            conn = new SqlConnection(caminho);
            conn.Open();


        }
        public void fecha()
        {
            this.conn.Close();

        }


        public void cadastrar(ProdutoDAL cadastro)
        {
            SqlCommand cmd = new SqlCommand("set dateformat dMy insert into produto values(@Nome_Produto, @Preco, @Quantidade, @Validade, @entrada)", conn);

            cmd.Parameters.AddWithValue("@Nome_Produto", Nome_produto);
            cmd.Parameters.AddWithValue("@Preco", Preco);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            cmd.Parameters.AddWithValue("@Validade", Validade);
            cmd.Parameters.AddWithValue("@Entrada", entrada);

            cmd.ExecuteNonQuery();
        }

        public ProdutoDAL pesquisarID(ProdutoDAL pesquisarID)
        {

            SqlCommand cmd = new SqlCommand("select *from Produto where IdProduto =@id", conn);

            cmd.Parameters.AddWithValue("@id", IdProduto);

            SqlDataReader dr = cmd.ExecuteReader();

            ProdutoDAL objfoi = new ProdutoDAL();

            if (dr.Read())
            {
                objfoi.Nome_produto = dr["Nome_produto"].ToString();
                objfoi.Preco = Convert.ToDecimal(dr["Preco"]);
                objfoi.Quantidade = Convert.ToInt16(dr["Quantidade"]);
                objfoi.Validade = dr["Validade"].ToString();
                objfoi.entrada = dr["entrada"].ToString();


            }
            return objfoi;

        }

        public List<ProdutoDAL> Pesquisar()
        {
            SqlCommand cmd = new SqlCommand("select *from Produto", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<ProdutoDAL> listaprodutos = new List<ProdutoDAL>();

            while (dr.Read())
            {
                ProdutoDAL objlista = new ProdutoDAL();

                objlista.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                objlista.Nome_produto = dr["Nome_Produto"].ToString();
                objlista.Preco = Convert.ToDecimal(dr["Preco"]);
                objlista.Quantidade = Convert.ToInt16(dr["Quantidade"]);
                objlista.Validade = dr["Validade"].ToString();

               
                objlista.entrada = dr["entrada"].ToString();

                listaprodutos.Add(objlista);
                

            }
            return listaprodutos;
        }

        public void movimento(ProdutoDAL movimento)
        {

            SqlCommand cmd = new SqlCommand("update produto set Quantidade = @Quantidade where IdProduto = @id", conn);

            cmd.Parameters.AddWithValue("@id", IdProduto);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            
            cmd.ExecuteNonQuery();

        }
       


    }

}