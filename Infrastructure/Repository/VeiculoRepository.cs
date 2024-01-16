using Dapper;
using Domain;
using Domain.Commands;
using Domain.Entidades;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository

    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";
        public async Task<IEnumerable<VeiculoCommand>> GetAlugado()
        {
            string querygetalug = @"Select * From Veiculo Where Alugado = 1";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(querygetalug);
            }

        }

        public async Task<IEnumerable<VeiculoCommand>> GetDisponivel()
        {
            string querygetdisp = @"Select * From Veiculo Where Alugado = 0";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(querygetdisp);
            }

        }
        public async Task<string> PostAsync(Veiculocommand command)
        {
            string queryinsert = @"Insert Into Veiculo(Placa, AnoFabricacao, TipoVeiculoID, Estado, MontadoraId, Preco)
            Values (@Placa, @AnoFabricacao, @TipoVeiculoID, @Estado, @MontadoraId, @Preco)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryinsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoID = (int)command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraID = (int)command.Montadora,
                    Preco = command.Preco,
                });
                return "Veiculo cadastrado com sucesso _|_";
            }
        }
        public void PostAsync()
        {

        }
        public void GetAsync()
        {

        }

        public Task<string> PostAsync(VeiculoCommand command)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<VeiculoCommand>> GetSimalu()
        {
            string querysimalug = @"Select Preco From Veiculo Where Alugado = 0";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(querysimalug);
            }
        }
    }
}
