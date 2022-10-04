using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Dtos
{
    public class ProdutoDto
    {
		public int Id { get; set; }
		public int IdEstabelecimento { get; set; }
		public string Descricao { get; set; }
		public float Preco { get; set; }
		public int Quantidade { get; set; }
		public int Perecivel { get; set; }
		public DateTime ValidadeProduto { get; set; }
		public string LinkImagem { get; set; }
	}
}
