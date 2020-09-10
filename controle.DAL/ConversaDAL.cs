using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace controle.DAL
{
    public class ConversaDAL
    {

        public string autor { get; set; }
        public string texto { get; set; }
        public List<ConversaDAL> listaConversa { get; set; }

        private SqlConnection conn;

        string caminho = "workstation id=controle.mssql.somee.com;packet size=4096;user id=Papel_zero_SQLLogin_1;pwd=k9nni8mvty;data source=controle.mssql.somee.com;persist security info=False;initial catalog=controle";


        public ConversaDAL()
        {
            conn = new SqlConnection(caminho);
            conn.Open();


        }
        public void fecha()
        {
            this.conn.Close();

        }


        public void enviar(ConversaDAL enviar)
        {
           

            SqlCommand cmd = new SqlCommand("insert into Comentario values (@autor, @texto)", conn);

            cmd.Parameters.AddWithValue("@autor", autor);
            cmd.Parameters.AddWithValue("@texto", texto);
           

            cmd.ExecuteNonQuery();

            fecha();


        }


        //pesquisar que vai dar retorno em uma tabela
        public List<ConversaDAL> Pesquisar()
        {
            SqlCommand cmd = new SqlCommand("select *from Comentario", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<ConversaDAL> listaConversa = new List<ConversaDAL>();

            while (dr.Read())
            {
                ConversaDAL objlista = new ConversaDAL();

               
                objlista.autor = dr["Autor"].ToString();
                objlista.texto = dr["Texto"].ToString();

                listaConversa.Add(objlista);

            }


            return listaConversa;
        }


    }
}
