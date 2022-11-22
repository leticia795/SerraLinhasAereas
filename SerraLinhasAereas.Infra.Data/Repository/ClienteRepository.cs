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
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDAO _clienteDao;
        public ClienteRepository()
        {
            _clienteDao = new ClienteDAO();
        }

        public void RegistrarCliente(Cliente cpfCliente)
        {
            _clienteDao.RegistrarCliente(cpfCliente);
        }

        public Cliente BuscarClientePorCPF(long cpfCliente)
        {
            return _clienteDao.BuscarClientePorCPF(cpfCliente);
        }

        public List<Cliente> BuscarTodosClientes()
        {
            return _clienteDao.BuscarTodosClientes();
        }

        public void AtualizarCliente(Cliente cpfCliente)
        {
            _clienteDao.AtualizarCliente(cpfCliente);
        }

        public void DeletarCliente(int cliente)
        {
            _clienteDao.DeletarCliente(cliente);
        }

       

    }
}
