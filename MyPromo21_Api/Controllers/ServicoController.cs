using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ServicoViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _servicoRepository;

        public ServicoController()
        {
            _servicoRepository = new ServicoRepository();
        }

        [HttpPost]
        public IActionResult CreateServico(ServicoViewModel servico)
        {
            if (servico.Servico == null) return Ok("Parâmetros informados incorretamente!");

            var result = _servicoRepository.CreateServico(servico.Servico);

            if (result) return Ok("Serviço cadastrado com sucesso!");

            return Ok("Não foi possível efetuar o cadastro do serviço!");
        }

        [HttpGet]
        public IActionResult GetServico(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao)) return Ok("Parâmetro inválido!");

            var servico = _servicoRepository.BuscarPorDescricao(descricao);

            if (servico != null) return Ok(servico);

            return Ok("Servico não encontrado!");
        }

        [HttpGet]
        public IActionResult GetServicoByID(int id)
        {

            var servico = _servicoRepository.BuscarPorID(id);

            if (servico != null) return Ok(servico);

            return Ok("Servico não encontrado!");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _servicoRepository.GetAll();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult ListaDeServicoPorId(int id)
        {

            var servico = _servicoRepository.ServicoPorIdRetornandoLista(id);

            if (servico != null) return Ok(servico);

            return Ok("Servico não encontrado!");
        }

        //[HttpPut]
        //public IActionResult UpdateServico(UpdateServicoViewModel servico)
        //{
        //    if (servico.Servico == null) return Ok("Parâmetros informados incorretamente!");

        //    var result = _servicoRepository.UpdateServico(servico.Servico);

        //    if (result) return Ok("Serviço atualizado com sucesso!");

        //    return Ok("Não foi possível atualizar o cadastro do serviço!");
        //}
        //[HttpGet]
        //public IActionResult GetServico(string descricao)
        //{
        //    if (string.IsNullOrWhiteSpace(descricao)) return Ok("Parâmetro não informado!");

        //    var servico = _servicoRepository.GetServico(descricao);

        //    if (servico != null) return Ok(servico);

        //    return Ok("Serviço não localizado!");
        //}

    }
}
