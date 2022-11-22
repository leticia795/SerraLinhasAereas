using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain.Entidade;
using SerraLinhasAereas.Domain.Interfaces;
using SerraLinhasAereas.Infra.Data.Repository;

namespace SerraLinhasAereasSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemRepository _passagemRepository;
        public PassagemController()
        {
            _passagemRepository = new PassagemRepository();
        }

        [HttpPost]
        public IActionResult AdicionarPassagem(Passagem passagem)
        {
            _passagemRepository.AdicionarPassagem(passagem);

            return Ok(passagem);
        }

        [HttpGet("{Data}")]
        public IActionResult GetBuscarPorData(DateTime passagemCliente)
        {
            _passagemRepository.BuscarPorData(passagemCliente);
            if (_passagemRepository == null)
                return BadRequest(new Resposta(400, "Nenhuma passagem localizada!"));
            return Ok(_passagemRepository);
        }

        [HttpGet("{Origem}")]
        public IActionResult GetBuscarPorOrigem(int passagemCliente)
        {
            _passagemRepository.BuscarPorOrigem(passagemCliente);
            if (_passagemRepository == null)
                return BadRequest(new Resposta(400, "Nenhuma passagem localizada!"));
            return Ok(_passagemRepository);
        }
        [HttpGet("{Destino}")]
        public IActionResult GetBuscarPorDestino(int passagemCliente)
        {
            _passagemRepository.BuscarPorDestino(passagemCliente);
            if (_passagemRepository == null)
                return BadRequest(new Resposta(400, "Nenhuma passagem localizada!"));
            return Ok(_passagemRepository);
        }
        [HttpGet]
        public IActionResult GetBuscarTodasPassagens()
        {
            var passagem = _passagemRepository.BuscarTodasPassagens();
            if (passagem == null)
                return BadRequest(new Resposta(400, "Nenhuma passagem localizada!"));
            return Ok(passagem);
        }
        //[HttpPut("IdPassagem")]
        //public IActionResult AtualizarPassagem(Passagem passagemCliente)
        //{
        //    var passagemBuscado = _passagemRepository.BuscarPorOrigem(passagemCliente.IdPassagem);
        //    if (passagemBuscado == null)
        //        return BadRequest(new Resposta(400, "Nenhum registro encontrado!"));

        //    passagemBuscado.IdPassagem = passagemBuscado.IdPassagem;

        //    return Ok(passagemBuscado);
        //}


    }
}
