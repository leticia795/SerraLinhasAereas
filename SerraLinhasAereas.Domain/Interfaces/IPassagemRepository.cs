using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Interfaces
{
    public interface IPassagemRepository
    {
        void AdicionarPassagem(Passagem passagem);
        void BuscarPorData(DateTime passagemCliente);
        void BuscarPorOrigem(int passagemCliente);
        void BuscarPorDestino(int passagemCliente);
        void AtualizarPassagem(Passagem passagemCliente);
        List<Passagem> BuscarTodasPassagens();
        
    }
}
