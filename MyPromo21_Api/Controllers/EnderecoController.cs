using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using static MyPromo21_Api.ViewModels.EnderecoViewModel;
using MyPromo21_Api.ViewModels;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }



        [HttpPost]
        public IActionResult Create(EnderecoViewModel endereco)
        {

            var resultado = _enderecoRepository.CreateEndereco(endereco.Endereco);
            

            if (resultado) return Ok("Endereco cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o endereco.");
        }


        //[HttpGet]
        //public IActionResult ReadAll()
        //{
        //    var resultado = _enderecoRepository.ReadAllEndereco();

        //    if (resultado == null)
        //        return NotFound();

        //    return Ok(resultado);
        //}

        //[HttpPut]
        //public IActionResult Update(UpdateEnderecoViewModel updateEnderecoViewModel)
        //{

        //    var resultado = _enderecoRepository.UpdateEndereco(updateEnderecoViewModel.endereco);

        //    if (resultado) return Ok("Endereco atualizado com sucesso. ");
        //    return Ok(new
        //    {
        //        sucesso = false,
        //        mensagem = "Erro ao atualizar o endereco."
        //    });
        //}

        //[HttpDelete]
        //public IActionResult Delete(DeleteEnderecoViewModel deleteEnderecoViewModel)
        //{
        //    var resultado = _enderecoRepository.DeleteEndereco(deleteEnderecoViewModel.Id);

        //    if (resultado) return Ok("Endereco removido com sucesso.");

        //    return Ok("Erro ao deletar o endereco.");
        //}
    }
}
