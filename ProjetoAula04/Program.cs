using ProjetoAula04.Controllers;
using System;

namespace ProjetoAula04
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteController = new ClienteController();
            clienteController.ManterClientes();
        }
    }
}
