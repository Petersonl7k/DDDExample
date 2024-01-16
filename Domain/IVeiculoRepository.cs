using Domain.Commands;

namespace Domain
{
    public interface IVeiculoRepository 
  {
   Task<string> PostAsync(VeiculoCommand command);
   void PostAsync();
   void GetAsync();
   Task<IEnumerable<VeiculoCommand>> GetDisponivel();
   Task<IEnumerable<VeiculoCommand>> GetAlugado();
   Task<IEnumerable<VeiculoCommand>> GetSimalu();
    }
}
