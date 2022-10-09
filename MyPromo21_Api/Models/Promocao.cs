using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Models
{
    public class Promocao
    {
		public int Id { get; set; }
		public string Token { get; set; }
		public DateTime ValidadePromo { get; set; }
		public string Motivo { get; set; }
		public int IdEndereco { get; set; }
		public int IdEstabelecimento { get; set; }

	}
}


