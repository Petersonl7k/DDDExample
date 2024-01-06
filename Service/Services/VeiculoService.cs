using Domain.Commands;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        public void GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> PostAsync(VeiculoCommand command)
        {
            if (command == null)
                return "Todos os campos são Obrigatórios";

            int AnoAtual = DateTime.Now.Year;

            //To do
            //inculuir validação, só podem cadastrar veiculos com até 5 anos de uso

            if (AnoAtual - command.AnoFabricacao > 5)
                return "O Ano do veiculo é menor que o permitido";

            //To do
            //incluir somente carros do tipo SUV, Sedan e Hatch
            if (command.tipoVeiculo != ETipoVeiculo.SUV
               && command.tipoVeiculo != ETipoVeiculo.hatch
               && command.tipoVeiculo != ETipoVeiculo.Sedan
              )
            {
                return "O Tipo de Veiculo não é permitido";
            }
            return "Cadastro realizado com sucesso";
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
