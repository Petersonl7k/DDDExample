using Domain.Commands;
using Domain.Enum;

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
    }
}
