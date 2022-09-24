using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Repositories;
using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ClienteViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }
        
        [HttpPost]
        public IActionResult CreateCliente(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.Cliente.Nome == "") return Ok("Nome do cliente invalido!");
            if (clienteViewModel.Cliente.Cpf == "") return Ok("Cpf do cliente invalido!");
            if (clienteViewModel.Cliente.Email == "") return Ok("Email do cliente invalido!");
            if (clienteViewModel.Cliente.Telefone == "") return Ok("Telefone do cliente invalido!");
            if (clienteViewModel.Cliente.Data_Nascimento == null) return Ok("Data de nascimento do cliente invalido!");

            var retorno = _clienteRepository.CreateUsuario(clienteViewModel.Cliente);

            if (retorno) return Ok("Cliente cadastrado com sucesso!");

            return Ok("Erro ao cadastrar o cliente!");
        }
        [HttpPut]
        public IActionResult UpdateCliente(UpdateClienteViewModel clienteVielModelUpdate)
        {
            if (clienteVielModelUpdate == null) return Ok("Não foram informados os parâmetros corretamente!");

            var retorno = _clienteRepository.UpdateCliente(clienteVielModelUpdate.Cliente);

            if (retorno) return Ok("Cliente atualizado com sucesso!");

            return Ok("Não foi possível atualizar o cliente!");
        }
        [HttpGet]
        public IActionResult GetCliente(int id_Cliente)
        {
            if (id_Cliente == 0) return Ok("Id do cliente informado incorretamente!");

            var cliente = _clienteRepository.GetCliente(id_Cliente);

            if (cliente != null) return Ok(cliente);

            return Ok("Cliente não localizado!");
        }

    }
}
