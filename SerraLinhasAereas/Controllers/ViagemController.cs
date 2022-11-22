using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain.Entidade;
using SerraLinhasAereas.Domain.Interfaces;
using SerraLinhasAereas.Infra.Data.Repository;

namespace SerraLinhasAereasSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemRepository _viagemRepository;
        public ViagemController()
        {
            _viagemRepository = new ViagemRepository();
        }

        [HttpGet]
        public IActionResult BuscarTodasViagens()
        {
            var viagem = _viagemRepository.BuscarTodasViagens();
            if (viagem == null)
                return BadRequest(new Resposta(400, "Nenhuma viagem localizado!"));
            return Ok(viagem);
        }

        [HttpPost]
        public IActionResult MarcarViagem(Viagem viagem)
        {
            _viagemRepository.MarcarViagem(viagem);

            return Ok(viagem);
        }
        //[HttpPut("CodigoReserva")]
        //public IActionResult RemarcarViagem(Viagem viagem)
        //{
        //    var viagemBuscado = _viagemRepository.BuscarTodasViagens(viagem.CodigoReserva);
        //    if (viagemBuscado == null)
        //        return BadRequest(new Resposta(400, "Nenhum registro encontrado!"));

        //    viagemBuscado.CodigoReserva = viagemBuscado.CodigoReserva;
           

        //    return Ok(viagemBuscado);
        //}
    }
}
