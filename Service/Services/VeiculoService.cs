using Domain;
using Domain.Commands;
using Domain.Enum;
using Domain.Interfaces;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }
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
            if (command.TipoVeiculo != ETipoVeiculo.SUV
               && command.TipoVeiculo != ETipoVeiculo.hatch
               && command.TipoVeiculo != ETipoVeiculo.Sedan
              )
            {
                return "O Tipo de Veiculo não é permitido";
            }
            return await _repository.PostAsync(command);
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<VeiculoCommand>> GetAlugado()
        {
            return await _repository.GetAlugado();
        }

        public async Task<IEnumerable<VeiculoCommand>> GetDisponivel()
        {
            return await _repository.GetDisponivel();
        }
    }
}
