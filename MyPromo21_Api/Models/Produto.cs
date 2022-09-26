﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Models
{
    public class Produto
    {
		public string Descricao { get; set; }
		public decimal Preco { get; set; }
		public int Quantidade { get; set; }
		public bool Perecivel { get; set; }
		public DateTime ValidadeProduto { get; set; }
		public string LinkImagem { get; set; }

	}
}