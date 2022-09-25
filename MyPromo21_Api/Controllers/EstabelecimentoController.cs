using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using static MyPromo21_Api.ViewModels.EstabelecimentoViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly EstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoController()
        {
            _estabelecimentoRepository = new EstabelecimentoRepository();
        }

        [HttpPost]
        public IActionResult Create(CreateEstabelecimentoViewModel createEstabelecimentoViewModel)
        {
            if (createEstabelecimentoViewModel.estabelecimento == null)
                return Ok("Dados não preenchidos.");

            var resultado = _estabelecimentoRepository.CreateEstabelecimento(createEstabelecimentoViewModel.estabelecimento);

            if (resultado) return Ok("Estabelecimento cadastrado com sucesso.");

            return Ok("Erro ao cadastrar o estabelecimento.");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _estabelecimentoRepository.ReadAllEstabelecimento();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Update(UpdateEstabelecimentoViewModel updateEstabelecimentoViewModel)
        {

            var resultado = _estabelecimentoRepository.UpdateEstabelecimento(updateEstabelecimentoViewModel.estabelecimento);

            if (resultado) return Ok("Estabelecimento atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o estabelecimento."
            });
        }

        [HttpDelete]
        public IActionResult Delete(DeleteEstabelecimentoViewModel deleteEstabelecimentoViewModel)
        {
            var resultado = _estabelecimentoRepository.DeleteEstabelecimento(deleteEstabelecimentoViewModel.Id);

            if (resultado) return Ok("Estabelecimento removido com sucesso.");

            return Ok("Erro ao deletar o estabelecimento.");
        }
    }
}
