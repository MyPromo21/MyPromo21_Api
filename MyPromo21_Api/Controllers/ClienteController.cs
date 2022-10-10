using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
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
        public IActionResult CreateCliente(ClienteViewModel cliente)//ClienteModel cliente)
        {
            if (cliente.Cliente == null) return Ok("Parâmetros informados incorretamente!");
            if (string.IsNullOrWhiteSpace(cliente.Cliente.Nome)) return Ok("Nome do cliente invalido!");
            if (string.IsNullOrWhiteSpace(cliente.Cliente.Cpf)) return Ok("Cpf do cliente invalido!");
            if (string.IsNullOrWhiteSpace(cliente.Cliente.Email)) return Ok("Email do cliente invalido!");
            if (string.IsNullOrWhiteSpace(cliente.Cliente.Telefone)) return Ok("Telefone do cliente invalido!");
            if (cliente.Cliente.DataNascimento == null) return Ok("Data de nascimento do cliente invalido!");
            if (cliente.Cliente.DataCadastro == null) return Ok("Data de cadastro do cliente invalido!");

            var retorno = _clienteRepository.CreateCliente(cliente.Cliente);

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
        //[HttpGet]
        //public IActionResult GetCliente(string cpf)
        //{
        //    if (string.IsNullOrWhiteSpace(cpf)) return Ok("Nome do cliente informado incorretamente!");

        //    var cliente = _clienteRepository.GetCliente(cpf);

        //    if (cliente != null) return Ok(cliente);

        //    return Ok("Cliente não localizado!");
        //}
        [HttpDelete]
        public IActionResult DeleteCliente(DeleteClienteViewModel deleteClienteViewModel)
        {
            if (deleteClienteViewModel.IdCliente == 0) return Ok("Parâmetro inválido!");

            var result = _clienteRepository.DeleteCliente(deleteClienteViewModel);

            if (result) return Ok("Cliente excluido com sucesso!");

            return Ok("Não foi possível excluir o cliente!");
        }

        [HttpGet]
        public IActionResult GetCliente(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return Ok("Parâmetro inválido!");

            var cliente = _clienteRepository.BuscarPorNome(nome);

            if (cliente != null) return Ok(cliente);

            return Ok("Cliente não encontrado!");
        }

        [HttpGet]
        public IActionResult GetClienteByID(int id)
        {

            var cliente = _clienteRepository.BuscarPorID(id);

            if (cliente != null) return Ok(cliente);

            return Ok("Cliente não encontrado!");
        }

    }
}
