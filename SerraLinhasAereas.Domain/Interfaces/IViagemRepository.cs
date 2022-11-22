using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Interfaces
{
    public interface IViagemRepository
    {
        
        void MarcarViagem(Viagem viagem);
        void RemarcarViagem(Viagem viagem);
        List<Viagem> BuscarTodasViagens();
    }
}
