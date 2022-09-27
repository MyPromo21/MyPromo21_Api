using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }

        public class ProdutoDeleteViewModel
        {
            public int Id { get; set; }
        }
        public class UpdateProdutoViewlModel
        {
            public ProdutoDto Produto { get; set; }
        }
    }
}
