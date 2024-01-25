using Domain.Commands;
using Domain.Entidades;
using Domain.Enum;
using Domain.ViewModel;

namespace Domain.Interfaces
{
    public interface IVeiculoService
    {

        Task<string> PostAsync(VeiculoCommand command);
        void PostAsync();
        void GetAsync();
        Task<IEnumerable<VeiculoCommand>> GetAlugado();
        Task<IEnumerable<VeiculoCommand>> GetDisponivel();
        Task<IEnumerable<VeiculoCommand>> GetSimalu();
        Task<VeiculoPreco> GetPrecoDiaria(ETipoVeiculo tipoveiculo);
        Task<SimularVeiculoAluguelViewModel> SimularVeiculoAlguel(int TotalDiasSimulado, ETipoVeiculo tipoVeiculo);
        Task AlugarVeiculo(AlugarVeiculoViewModelInput input);
        Task<bool> ValiData(DateTime DataRetirada, DateTime DataDevolucao);

    }
}
