using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace controle.DAL
{
    public class CardexDAL
    {
        public int IdCardex { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Validade { get; set; }
        public DateTime Saida { get; set; }
        public List<CardexDAL> listacardex { get; set; }



        private SqlConnection conn;

        string caminho = "workstation id=controle.mssql.somee.com;packet size=4096;user id=Papel_zero_SQLLogin_1;pwd=k9nni8mvty;data source=controle.mssql.somee.com;persist security info=False;initial catalog=controle";


        public CardexDAL()
        {
            conn = new SqlConnection(caminho);
            conn.Open();


        }
        public void fecha()
        {
            this.conn.Close();

        }




        public void cadastrar(CardexDAL cadastrar)
        {
            SqlCommand cmd = new SqlCommand("insert into Cardex values (@IdProduto, @Produto, @Quantidade, @Entrada, @Validade, @saida )", conn);

            cmd.Parameters.AddWithValue("@IdProduto", IdProduto);
            cmd.Parameters.AddWithValue("Produto", Produto);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            cmd.Parameters.AddWithValue("@Entrada", Entrada);
            cmd.Parameters.AddWithValue("@validade", Validade);
            cmd.Parameters.AddWithValue("@Saida", Saida);

            cmd.ExecuteNonQuery();



        }





















    }
}
