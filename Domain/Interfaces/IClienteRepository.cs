using Domain.Commands;

namespace Domain
{
    public interface IClienteRepository
    {
       Task<string> PostAsync(ClienteCommand command);
    }
}

