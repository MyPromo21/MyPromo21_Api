using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Dtos
{
    public class ClienteDto
    {
		public int IdUsuario { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public DateTime DataCadastro { get; set; }

		//nome
	}
}
