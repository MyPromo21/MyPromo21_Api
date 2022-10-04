using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Models
{
	public class Cliente
	{
		public int IdUsuario { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set;}
		public DateTime DataNascimento { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public DateTime	DataCadastro { get; set; }
	}
}
