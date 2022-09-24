using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Dtos
{
    public class ClienteDto
    {
		public int Id_Cliente { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime Data_Nascimento { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public DateTime Data_Cadastro { get; set; }
	}
}
