using Domain.Commands;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommand command);
        void PostAsync();
        void GetAsync();
        Task<IEnumerable<VeiculoCommand>> GetDisponivel();
        Task<IEnumerable<VeiculoCommand>> GetAlugado();
        Task<VeiculoPrecoCommand> GetPrecoDIaria(ETipoVeiculo tipoveiculo);
        Task<bool> VeiculoAlugado(string placaVeiculo);
        Task<bool> ValiData(DateTime DataRetirada, DateTime DataDevolucao);

        
    }
}
