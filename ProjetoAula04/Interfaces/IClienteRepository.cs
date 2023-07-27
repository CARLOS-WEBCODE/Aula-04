using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    /// <summary>
    /// Interface para definição dos métodos do repositorio de Cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        List<Cliente> GetByNome(string nome);
    }
}
