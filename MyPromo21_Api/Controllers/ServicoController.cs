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
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var servicos = new GetAllServicoViewModel();

        //    servicos.Servicos = _servicoRepository.GetAll();

        //    return Ok(servicos.Servicos);
        //}
    }
}
