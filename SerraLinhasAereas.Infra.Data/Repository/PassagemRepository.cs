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
    public class PassagemRepository : IPassagemRepository
    {
        private readonly PassagemDAO _passagemDao;
        public PassagemRepository()
        {
            _passagemDao = new PassagemDAO();
        }

        public void AdicionarPassagem(Passagem passagem)
        {
            _passagemDao.AdicionarPassagem(passagem);
        }

        public void AtualizarPassagem(Passagem passagemCliente)
        {
            _passagemDao.AtualizarPassagem(passagemCliente);
        }

        public void BuscarPorData(DateTime passagemCliente)
        {
            _passagemDao.BuscarPorData(passagemCliente);
        }

        public void BuscarPorDestino(int passagemCliente)
        {
             _passagemDao.BuscarPorDestino(passagemCliente);
        }

        public void BuscarPorOrigem(int passagemCliente)
        {
            _passagemDao.BuscarPorOrigem(passagemCliente);
        }

        public List<Passagem> BuscarTodasPassagens()
        {
            return _passagemDao.BuscarTodasPassagens();
        }
    }
}
