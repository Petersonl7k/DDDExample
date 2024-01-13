using Dapper;
using Domain;
using Domain.Commands;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";

        public async Task<string> PostAsync(ClienteCommand command)
        {
            string querycdst = @"Insert Into Clientes (primeiroNome, nomeMeio, ultimoNome, nascimento, habilitacao, estado, cpf, contato)
            Values (@primeiroNome, @nomeMeio, @ultimoNome, @nascimento, @habilitacao, @estado, @cpf, @contato)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(querycdst, new
                {
                    primeiroNome = command.primeiroNome,
                    nomeMeio = command.nomeMeio,
                    ultimoNome = command.ultimoNome,
                    nascimento = command.nascimento,
                    habilitacao = command.habilitacao,
                    estado = command.estado,
                    cpf = command.cpf,
                    contato = command.contato
                });
                return "Cliente cadastrado com sucesso _|_";
            }
        }
    }
}
