using Dapper;
using Domain.Commands;
using Domain.Entidades;
using Domain.Enum;
using Domain.Interfaces;
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

      

        public async Task<VeiculoPrecoCommand> GetPrecoDIaria(ETipoVeiculo tipoveiculo)
        {
            string queryGetPrecoDiaria = @"Select * From VeiculoPreco Where TipoVeiculo = @TipoVeiculo";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<VeiculoPrecoCommand>(queryGetPrecoDiaria, new
                {
                    TipoVeiculo = tipoveiculo
                }).Result.FirstOrDefault();
            }
        }
        public async Task<bool> VeiculoAlugado(string placaVeiculo)
        {
            string queryDisponibilidadeVeiculo = @" Select Alugado FROM Veiculo Where Placa = @Placa";
            using(SqlConnection conn = new SqlConnection(conexao))
            {

                return conn.Query<bool>(queryDisponibilidadeVeiculo, new
                {
                    Placa = placaVeiculo
                }).FirstOrDefault();
                
            }
        }
        public async Task<bool> ValiData(DateTime dataRetirada, DateTime dataDevolucao)
        {
            return await 
        }
    }
}

