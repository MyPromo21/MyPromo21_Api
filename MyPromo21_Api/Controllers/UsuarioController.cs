using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using static MyPromo21_Api.ViewModels.UsuarioViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateUsuarioViewModel createUsuarioViewModel)
        {
            if (createUsuarioViewModel.usuarioModel == null)
                return Ok("Dados não preenchidos.");

            var resultado = _usuarioRepository.CreateUsuario(createUsuarioViewModel.usuarioModel);

            if (resultado) return Ok("Usuario cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o usuario.");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _usuarioRepository.ReadAllUsuario();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateUsuarioViewModel updateUsuarioViewModel)
        {

            var resultado = _usuarioRepository.UpdateUsuario(updateUsuarioViewModel.Usuario, updateUsuarioViewModel.Id);

            if (resultado) return Ok("Usuario atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o usuario."
            });
        }

        [HttpDelete]
        public IActionResult Delete(DeleteUsuarioViewModel deleteUsuarioViewModel)
        {
            var resultado = _usuarioRepository.DeleteUsuario(deleteUsuarioViewModel.Id);

            if (resultado) return Ok("Usuario removido com sucesso.");

            return Ok("Erro ao deletar o usuario.");
        }
    }
}
