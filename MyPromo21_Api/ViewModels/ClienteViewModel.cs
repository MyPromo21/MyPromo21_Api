using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.ViewModels
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }

        public class DeleteClienteViewModel
        {
            public int IdCliente { get; set; }
        }

        public class UpdateClienteViewModel
        {
            public ClienteDto Cliente { get; set; }
        }
    }
}
