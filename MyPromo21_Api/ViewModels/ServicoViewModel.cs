using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.ViewModels
{
    public class ServicoViewModel
    {
        public class CreateServicoViewModel
        {
            public Servico Servico { get; set; }
        }

        public class DeleteServicoViewModel
        {
            public int Id { get; set; }
        }
        public class UpdateServicoViewModel
        {
            public ServicoDto Servico { get; set; }
        }
    }
}
