using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Interfaces
{
    /// <summary>
    /// Interface genérica para definição dos métodos do repositório
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
        where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
