using SerraLinhasAereas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Interfaces
{
    public interface IClienteRepository
    {
        void RegistrarCliente(Cliente cpfCliente);
        Cliente BuscarClientePorCPF(long cpfCliente);
        void AtualizarCliente(Cliente cpfCliente);
        void DeletarCliente(int cliente);
        List<Cliente> BuscarTodosClientes();
    }
}
