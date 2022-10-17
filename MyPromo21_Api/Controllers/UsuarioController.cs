using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Repositories;
using MyPromo21_Api.ViewModels;
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
        public IActionResult Create(UsuarioViewModel usuario)
        {
            if (usuario.Usuario == null)
                return Ok("Dados não preenchidos.");

            var result = _usuarioRepository.CreateUsuario(usuario.Usuario);

            if (result) return Ok("Usuario cadastrado com sucesso!");

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

        [HttpGet]
        public IActionResult GetUsuario(string login)
        {
            if (string.IsNullOrWhiteSpace(login)) return Ok("Parâmetro inválido!");

            var usuario = _usuarioRepository.BuscarPorLogin(login);

            if (usuario != null) return Ok(usuario);

            return Ok("Usuario não encontrado!");
        }

        [HttpGet]
        public IActionResult GetUsuarioByID(int id)
        {            

            var usuario = _usuarioRepository.BuscarPorID(id);

            if (usuario != null) return Ok(usuario);

            return Ok("Usuario não encontrado!");
        }

        [HttpPut]
        public IActionResult Update(UsuarioViewModel updateUsuarioViewModel)
        {

            var resultado = _usuarioRepository.UpdateUsuario(updateUsuarioViewModel.UsuarioDto);

            if (resultado) return Ok(new
            {
                sucesso = true,
                mensagem = "Usuario atualizado com sucesso. "
            }
                );;
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o usuario."
            });
        }

        //[HttpDelete]
        //public IActionResult Delete(DeleteUsuarioViewModel deleteUsuarioViewModel)
        //{
        //    var resultado = _usuarioRepository.DeleteUsuario(deleteUsuarioViewModel.Id);

        //    if (resultado) return Ok("Usuario removido com sucesso.");

        //    return Ok("Erro ao deletar o usuario.");
        //}
    }
}
