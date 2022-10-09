using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Dtos
{
    public class ServicoDto
    {
        public int Id { get; set; }
        public int IdPromocao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string LinkImagem { get; set; }
    }
}
