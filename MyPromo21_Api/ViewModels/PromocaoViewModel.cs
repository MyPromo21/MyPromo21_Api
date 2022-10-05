using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.ViewModels
{
    public class PromocaoViewModel
    {
        public Promocao Promocao { get; set; }

        public class DeletePromocaoViewModel
        {
            public int Id_Promocao { get; set; }
        }
        public class UpdatePromocaoViewlModel
        {
            public PromocaoDto Promocao { get; set; }
        }
        public class GetAllPromocao
        {
            public List<PromocaoDto> Promocoes { get; set; } = new List<PromocaoDto>();
            public List<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
            public List<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
        }

    }
}
