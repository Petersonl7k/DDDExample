using Domain.Commands;

namespace Domain.Interfaces
{
    public interface IVeiculoService
    {

        Task<string> PostAsync(VeiculoCommand command);
        void PostAsync();
        void GetAsync();
        Task<IEnumerable<VeiculoCommand>> GetAlugado();
        Task<IEnumerable<VeiculoCommand>> GetDisponivel();
        //Task<string> GetDisponivel(VeiculoCommand command);
        //Task<string> GetAlugado(VeiculoCommand command);
    }
}
