using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public interface IVeiculoRepository 
  {
   Task<string> PostAsync(Veiculo command);
   void PostAsync();
   void GetAsync();
  }
}
