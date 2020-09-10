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
        public string Entrada { get; set; }
        public string Validade { get; set; }
        public string Saida { get; set; }
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


        public void cadastrar2(CardexDAL cadastrar2)
        {
            DateTime sem;
            string nada;
            nada = "1/1/1900";
            sem = Convert.ToDateTime(nada);


            SqlCommand cmd = new SqlCommand("insert into Cardex values (@IdProduto, @Produto, @Quantidade, @Entrada, @Validade, @saida)", conn);

          //  SqlCommand cmd = new SqlCommand("insert into Cardex values (@IdProduto, @Produto, @Quantidade, @Entrada, @Validade)", conn);

            cmd.Parameters.AddWithValue("@IdProduto", IdProduto);
            cmd.Parameters.AddWithValue("Produto", Produto);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            cmd.Parameters.AddWithValue("@Entrada", Entrada);
            cmd.Parameters.AddWithValue("@validade", Validade);
            cmd.Parameters.AddWithValue("@saida", nada);


            cmd.ExecuteNonQuery();



        }

        public List<CardexDAL> Pesquisar()
        {
            SqlCommand cmd = new SqlCommand("select *from Cardex", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<CardexDAL> listacardex = new List<CardexDAL>();

            while (dr.Read())
            {
                CardexDAL objlista = new CardexDAL();

                objlista.IdCardex = Convert.ToInt32(dr["IdCardex"]);
                objlista.IdProduto = Convert.ToInt32(dr["IdProduto"]);
               
               
                objlista.Quantidade = Convert.ToInt16(dr["Quantidade"]);
                objlista.Validade = Convert.ToString(dr["Validade"]);
                objlista.Produto = Convert.ToString(dr["Produto"]);

                objlista.Entrada = Convert.ToString(dr["entrada"]);

                 objlista.Saida =Convert.ToString(dr["saida"]);
                

                  if ( objlista.Saida == "1/1/1900") 
                      //(Convert.ToString(dr["saida"]) == "1/1/1900")
                  { 

                      objlista.Saida = null;
                  }
                  else
                  {
                      objlista.Saida = Convert.ToString(dr["saida"]);
                  }


                listacardex.Add(objlista);


            }
            return listacardex;
        }





















    }
}
