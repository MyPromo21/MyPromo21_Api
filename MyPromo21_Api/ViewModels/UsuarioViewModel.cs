using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;

namespace MyPromo21_Api.ViewModels
{
    public class UsuarioViewModel
    {
        public class CreateUsuarioViewModel
        {
            public UsuarioModel usuarioModel { get; set; }
        }

        public class DeleteUsuarioViewModel
        {
            public int Id { get; set; }
        }

        public class UpdateUsuarioViewModel
        {
            public UsuarioDto usuario { get; set; }
            public int Id { get; set; }
        }

    }
}
