using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.PromocaoViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoRepository _promocaoRepository;

        public PromocaoController()
        {
            _promocaoRepository = new PromocaoRepository();
        }
        [HttpGet]
        public IActionResult CarregarInicio()
        {
            var promocoes = _promocaoRepository.CarregarInicio();

            if (promocoes != null) return Ok(promocoes);

            return Ok("Não há dados a serem carregados!");
        }
        [HttpPost]
        public IActionResult CreatePromocao(PromocaoViewModel promocao)
        {
            if (promocao == null) return Ok("Parâmetros informados incorretamente!");

            var result = _promocaoRepository.CreatePromocao(promocao.Promocao);

            if (result) return Ok("Promoção cadastrada com sucesso!");

            return Ok("Não foi possível cadastrar a promoção!");
        }
        //[HttpPut]
        //public IActionResult UpdatePromocao(UpdatePromocaoViewlModel promocao)
        //{
        //    if (promocao.Promocao == null) return Ok("Parâmetros informados incorretamente!");

        //    var result = _promocaoRepository.UpdatePromocao(promocao.Promocao);

        //    if (result) return Ok("Promoção atualizada com sucesso!");

        //    return Ok("Não foi possível atualizar a promoção!");
        //}
        [HttpDelete]
        public IActionResult DeletePromocao(DeletePromocaoViewModel id)
        {
            if (id.Id_Promocao == 0) return Ok("Id da promoção inválido!");

            var result = _promocaoRepository.DeletePromocao(id);

            if (result) return Ok("Promoção excluída com sucesso!");

            return Ok("Não foi possível excluir a promoção!");
        }

        [HttpGet]
        public IActionResult GetPromocao(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return Ok("Parâmetro inválido!");

            var promocao = _promocaoRepository.BuscarPorToken(token);

            if (promocao != null) return Ok(promocao);

            return Ok("Promocao não encontrada!");
        }

        [HttpGet]
        public IActionResult GetPromocaoByID(int id)
        {

            var promocao = _promocaoRepository.BuscarPorID(id);

            if (promocao != null) return Ok(promocao);

            return Ok("Promocao não encontrada!");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _promocaoRepository.GetAll();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

    }
}
