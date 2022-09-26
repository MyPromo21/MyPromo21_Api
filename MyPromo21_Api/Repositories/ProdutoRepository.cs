using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=ITELABD03\SQLEXPRESS01";
        //private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=Bruno";
        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }

        public bool CreateProduto(ProdutoViewModel produto)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into Produto() values()";
                }
            }
            catch (SqlException e)
            {
                
            }

            return result;
        }
    }
}
