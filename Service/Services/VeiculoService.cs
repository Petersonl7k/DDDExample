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

        public Task PostAsync(VeiculoCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }
               
            //To do

            //inculuir validação, só podem cadastrar veiculos com até 5 anos de uso

            //To do

            //incluir somente carros do tipo SUV, Sedan e Hatch
            if(command.tipoVeiculo != ETipoVeiculo.SUV
               && command.tipoVeiculo != ETipoVeiculo.hatch
               && command.tipoVeiculo != ETipoVeiculo.Sedan
              )
            {
                Console.WriteLine("Não cadastrou o veiculo");
                throw new ArgumentNullException();
            }
            else
            {
                Console.WriteLine("Cadastrou Veiculo");
            }
            throw new NotImplementedException();
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
