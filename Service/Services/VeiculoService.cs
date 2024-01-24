using CreditCardValidator;
using Domain.Commands;
using Domain.Entidades;
using Domain.Enum;
using Domain.Interfaces;
using Domain.ViewModel;

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
               && command.TipoVeiculo != ETipoVeiculo.Hatch
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

        public Task<IEnumerable<VeiculoCommand>> GetSimalu()
        {
            throw new NotImplementedException();
        }

        public Task<VeiculoPreco> GetPrecoDiaria(ETipoVeiculo tipoveiculo)
        {
            throw new NotImplementedException();
        }
        public async Task<SimularVeiculoAluguelViewModel> SimularVeiculoAlguel(int totalDiasSimulado, ETipoVeiculo tipoVeiculo)
        {
            var veiculoPreco = await _repository.GetPrecoDIaria(tipoVeiculo);
            double taxaEstadual = 10.50;
            double taxaFederal = 3.5;
            double taxamunicipal = 13.5;

            var simulacao = new SimularVeiculoAluguelViewModel();
            if (tipoVeiculo == ETipoVeiculo.SUV && totalDiasSimulado > 45)
            {
                return null;
            }
            if (tipoVeiculo == ETipoVeiculo.Sedan && totalDiasSimulado > 30)
            {
                return null;
            }
            if (tipoVeiculo == ETipoVeiculo.Hatch && totalDiasSimulado > 20)
            {
                return null;
            }
            if (tipoVeiculo == ETipoVeiculo.Utilitario && totalDiasSimulado > 40)
            {
                return null;
            }
            simulacao.TotalDiasSimulado = totalDiasSimulado;
            simulacao.Taxas = (decimal)(taxamunicipal + taxaEstadual + taxaFederal);
            simulacao.TipoVeiculo = tipoVeiculo;
            simulacao.ValorDiaria = veiculoPreco.Preco;
            simulacao.ValorTotal = (totalDiasSimulado * veiculoPreco.Preco) + simulacao.Taxas;
            
          return simulacao;
        }

        public async Task AlugarVeiculo(AlugarVeiculoViewModelInput input)
        {
            var veiculoAlugado = await VeiculoAlugado(input.PlacaVeiculo);
            if (veiculoAlugado)
            {
                // "Este Veículo não está mais disponível para alugar";
            }
            CreditCardDetector detector = new CreditCardDetector(Convert.ToString(input.Cartao.Numero));
            var bandeira = detector.CardNumber; // => 4012888888881881

            if (!detector.IsValid())
            {
                //"Cartão Invalido";
            } 

            var valiData = await ValiData(input.DataRetirada, input.DataDevolucao);
            if (valiData)
            {
                // "Data Incorreta"
            }
        }
        private Task<bool> VeiculoAlugado(string placaVeiculo)
        {
            return _repository.VeiculoAlugado(placaVeiculo);
        }
        private Task<bool> ValiData(DateTime dataRetirada, DateTime dataDevolucao)
        {
            return _repository.ValiData( dataRetirada, dataDevolucao);
        }
    }
}
