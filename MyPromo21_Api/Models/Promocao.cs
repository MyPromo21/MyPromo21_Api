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
		public int Id_Produto { get; set; }
		public DateTime Validade_Promo { get; set; }
		public int Id_Estabelecimento { get; set; }
		public string Motivo { get; set; }

	}
}
