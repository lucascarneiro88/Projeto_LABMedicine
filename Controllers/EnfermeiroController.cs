using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeiroController : ControllerBase
    {
        private readonly BancoDadosContext bancoDadosContext;

        //Construtor com parametro (Injetado)
        public EnfermeiroController(BancoDadosContext bancoDadosContext)
        {
            this.bancoDadosContext = bancoDadosContext;
        }
        [HttpGet]
        public ActionResult<List<EnfermeiroGetDto>> Get()
        {
            var listaEnfermeiroModel = bancoDadosContext.Enfermeiro;
            List<EnfermeiroGetDto> listaGetDto = new List<EnfermeiroGetDto>();


            foreach (var item in listaEnfermeiroModel)
            {
                var enfermeiroGetDto = new EnfermeiroGetDto();
                enfermeiroGetDto.Id = item.Id;
                enfermeiroGetDto.NomeCompleto = item.NomeCompleto;
               

                listaGetDto.Add(enfermeiroGetDto);
            }

            return Ok(listaGetDto);
            
        }
        [HttpGet("{id}")]
        public ActionResult<EnfermeiroGetDto> Get([FromRoute] int id)
        {
            //Buscar o registro no banco de dados por >>>ID<<<
            var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Find(id);
           // var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Where(w => w.Id == id).FirstOrDefault();

              if (enfermeiroMoldel == null)
              {
                   return NotFound("Dados não encontrados no banco de dados");
              }

            var enfermeiroGetDto = new EnfermeiroGetDto();
            enfermeiroGetDto.Id = enfermeiroGetDto.Id;
            enfermeiroGetDto.NomeCompleto = enfermeiroGetDto.NomeCompleto;

            
            return Ok(enfermeiroGetDto);
        }
        [HttpPost]
        //public ActionResult Post([FromBody])//Nome classe DTO + classe dto
        //{
        //    return Ok(true);
        //}
        [HttpPut]
        //public ActionResult Put([FromBody])//dentro do parenteses Classe MOdel + Classe model
        //{
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)//
        {
            return Ok();
        }
    }
}
