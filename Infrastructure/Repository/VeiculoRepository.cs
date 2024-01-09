using Domain.Entidades;
using Domain.Interfaces;
using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Infrastructure.Repository
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private string stringconnection = @"Insert Into Veiculo(Placa, AnoFabricacao, TipoVeiculoID, Estado, MontadoraId)
Values (@Placa, @AnoFabricacao, @TipoVeiculoID, @Estado, @MontadoraId)";
        public async Task<string> PostAsync(Veiculo command)
        {
            string queryinsert = "";
            using (var conn = new SqlConnection())
            {
                conn.Execute(queryinsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoID = command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraID = command.Montadora,
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
    }
}
