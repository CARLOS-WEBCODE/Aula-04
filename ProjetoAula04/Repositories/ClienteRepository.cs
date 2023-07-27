using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    /// <summary>
    /// Classe para implementar o repositorio de Cliente
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        //atributo para armazenar a connectionstring do banco de dados..
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnet Failover=False";
        
        public void Create(Cliente obj)
        {
            //conectando na base de dados atraves da connectionstring
            using (var connection = new SqlConnection(_connectionString))
            {
                //executar a procedure para cadastro do cliente
                connection.Execute("SP_INSERIRCLIENTE", new
                {
                    @NOME = obj.Nome,
                    @CPF = obj.Cpf,
                    @DATANASCIMENTO = obj.DataNascimento
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Update(Cliente obj)
        {
            //conectando na base de dados atraves da connectionstring
            using (var connection = new SqlConnection(_connectionString))
            {
                //executar a procedure para edição do cliente
                connection.Execute("SP_ATUALIZARCLIENTE", new
                {
                    @IDCLIENTE = obj.IdCliente,
                    @NOME = obj.Nome,
                    @CPF = obj.Cpf,
                    @DATANASCIMENTO = obj.DataNascimento
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Delete(Cliente obj)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                //executar a procedure para exclusão do cliente
                connection.Execute("SP_EXCLUIRCLIENTE", new
                {
                    @IDCLIENTE = obj.IdCliente,
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Cliente> GetAll()
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    ORDER BY NOME ASC
                ";

            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(sql) .ToList();
            }
        }

        public Cliente GetById(Guid id)
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    WHERE IDCLIENTE = @PARAM
                ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(sql, new { @PARAM = id }).FirstOrDefault();
            }
        }  

        public List<Cliente> GetByNome(string nome)
        {
            var sql = @"
                    SELECT * FROM CLIENTE
                    WHERE NOME LIKE @PARAM
                    ORDER BY NOME ASC
                ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(sql, new { @PARAM = $"%{nome}%" }).ToList();
            }
        }
    }
}
