using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain.Entidade;
using SerraLinhasAereas.Domain.Interfaces;
using SerraLinhasAereas.Infra.Data.Repository;
using System.ComponentModel;

namespace SerraLinhasAereasSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }
        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteRepository.BuscarTodosClientes();
            if (clientes == null)
                return BadRequest(new Resposta(400, "Nenhuma cliente localizado!"));
            return Ok(clientes);
        }

        [HttpGet("{cpf}")]
        public IActionResult GetClientePorCpf(long cpfCliente)
        {
            var clientesEncontrada = _clienteRepository.BuscarClientePorCPF(cpfCliente);
            if (clientesEncontrada == null)
                return BadRequest(new Resposta(400, "Nenhuma cliente localizado!"));
            return Ok(clientesEncontrada);
        }

        [HttpPost]
        public IActionResult RegistrarCliente(Cliente cpfCliente)
        {
            _clienteRepository.RegistrarCliente(cpfCliente);

            return Ok(cpfCliente);
        }

        [HttpDelete("{CPF}")]
        public IActionResult DeletarCliente(int cliente)
        {
            _clienteRepository.DeletarCliente(cliente);

            return Ok();
        }
        [HttpPut("CPF")]
        public IActionResult AtualizarCliente(Cliente cpfCliente)
        {
            var clienteBuscado = _clienteRepository.BuscarClientePorCPF(cpfCliente.CPF);
            if (clienteBuscado == null)
                return BadRequest(new Resposta(400, "Nenhum registro encontrado!"));

            clienteBuscado.PrimeiroNome = clienteBuscado.PrimeiroNome;
            clienteBuscado.Sobrenome = clienteBuscado.Sobrenome;
            clienteBuscado.Rua = clienteBuscado.Rua;
            clienteBuscado.Cep = clienteBuscado.Cep;
            clienteBuscado.Numero = clienteBuscado.Numero;
            clienteBuscado.Bairro = clienteBuscado.Bairro;
            clienteBuscado.Completo = clienteBuscado.Completo;

            return Ok(clienteBuscado);
        }
    }
}
