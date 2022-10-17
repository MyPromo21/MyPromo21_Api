using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPromo21_Api.Repositories;
using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ProdutoViewModel;

namespace MyPromo21_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpPost]
        public IActionResult CreateProduto(ProdutoViewModel produto)
        {
            if (produto.Produto == null) return Ok("Parâmetros informados incorretamente!");

            var result = _produtoRepository.CreateProduto(produto.Produto);

            if (result) return Ok("Produto cadastrado com sucesso!");

            return Ok("Não foi possível cadastrar o produto!");
        }

        [HttpGet]
        public IActionResult GetProduto(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao)) return Ok("Parâmetro inválido!");

            var produto = _produtoRepository.BuscarPorDescricao(descricao);

            if (produto != null) return Ok(produto);

            return Ok("Produto não encontrada!");
        }

        [HttpGet]
        public IActionResult GetProdutoByID(int id)
        {

            var produto = _produtoRepository.BuscarPorID(id);

            if (produto != null) return Ok(produto);

            return Ok("Produto não encontrada!");
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var resultado = _produtoRepository.GetAll();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult ListaDeProdutoPorId(int id)
        {

            var produto = _produtoRepository.ProdutoPorIdRetornandoLista(id);

            if (produto != null) return Ok(produto);

            return Ok("Produto não encontrado!");
        }

        //[HttpPut]
        //public IActionResult UpdateProduto(UpdateProdutoViewlModel produto)
        //{
        //    if (produto.Produto == null) return Ok("Parâmetros informados incorretamente!");

        //    var result = _produtoRepository.UpdateProduto(produto.Produto);

        //    if (result) return Ok("Produto atualizado com sucesso!");

        //    return Ok("Não foi possível atualizar o produto!");

        //}
        //[HttpDelete]
        //public IActionResult DeleteProduto(ProdutoDeleteViewModel deleteProdutoViewModel)
        //{
        //    if (deleteProdutoViewModel.Id == 0) return Ok("Id do produto inválido!");

        //    var result = _produtoRepository.DeleteProduto(deleteProdutoViewModel);

        //    if (result) return Ok("Produto excluído com sucesso!");

        //    return Ok("Não foi possível excluir o produto!");
        //}
        //[HttpGet]
        //public IActionResult GetProduto(string descricao)
        //{
        //    if (string.IsNullOrWhiteSpace(descricao)) return Ok("Parâmetro inválido!");

        //    var produto = _produtoRepository.GetProduto(descricao);

        //    if (produto != null) return Ok(produto);

        //    return Ok("Produto não encontrado!");
        //}

    }
}
