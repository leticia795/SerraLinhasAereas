using SerraLinhasAereas.Domain.Entidade;
using SerraLinhasAereas.Domain.Interfaces;
using SerraLinhasAereas.Infra.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly ViagemDAO _viagemDao;
        public ViagemRepository()
        {
            _viagemDao = new ViagemDAO();
        }

        public List<Viagem> BuscarTodasViagens()
        {
            return _viagemDao.BuscarTodasViagens();
        }

        public void MarcarViagem(Viagem viagem)
        {
            _viagemDao.MarcarViagem(viagem);
        }

        public void RemarcarViagem(Viagem viagem)
        {
            _viagemDao.RemarcarViagem(viagem);
        }
    }
}
