using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;

namespace MyPromo21_Api.ViewModels
{
    public class EstabelecimentoViewModel
    {

        public Estabelecimento Estabelecimento { get; set; }


        public class CreateEstabelecimentoViewModel
        {
            public Estabelecimento estabelecimento { get; set; }
        }

        public class DeleteEstabelecimentoViewModel
        {
            public int Id { get; set; }
        }

        public class UpdateEstabelecimentoViewModel
        {
            public EstabelecimentoDto estabelecimento { get; set; }
        }
    }
}
