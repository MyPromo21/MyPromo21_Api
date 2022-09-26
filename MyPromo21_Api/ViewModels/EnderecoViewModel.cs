using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;

namespace MyPromo21_Api.ViewModels
{
    public class EnderecoViewModel
    {
        public class CreateEnderecoViewModel
        {
            public Endereco endereco { get; set; }
        }

        public class DeleteEnderecoViewModel
        {
            public int Id { get; set; }
        }

        public class UpdateEnderecoViewModel
        {
            public EnderecoDto endereco { get; set; }
        }
    }
}
