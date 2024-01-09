using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Veiculo
    {
        public int VeiculoID { get; set; }
        public string Placa { get; set; }
        public int AnoFabricacao { get; set; }
        public ETipoVeiculo TipoVeiculo { get; set; }
        public string Estado {  get; set; }
        public EMontadora Montadora { get; set; }
        public bool Alugado { get; set; } = false;
    }
}
