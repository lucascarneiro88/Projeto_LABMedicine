using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CPFValidation;
using Microsoft.EntityFrameworkCore;


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


                //listaGetDto.Add(enfermeiroGetDto);
            }

            return Ok(listaGetDto);

        }

        [HttpGet("api/enfermeiros/{id}")]
        public ActionResult<EnfermeiroGetDto> Get([FromRoute] int id)
        {
            //Buscar o registro no banco de dados por >>>ID<<<
            var enfermeiroModel = bancoDadosContext.Enfermeiro.Find(id);
            // var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Where(w => w.Id == id).FirstOrDefault();

            if (enfermeiroModel == null)
            {
                return NotFound("Dados não encontrados no banco de dados");
            }

            var enfermeiroGetDto = new EnfermeiroGetDto();
            enfermeiroGetDto.Id = enfermeiroGetDto.Id;
            enfermeiroGetDto.NomeCompleto = enfermeiroGetDto.NomeCompleto;


            return Ok(enfermeiroGetDto);
        }

        [HttpPut("api/enfermeiros/{id}")]
        public ActionResult<EnfermeiroUpdateDto> Put(int id, [FromBody] EnfermeiroUpdateDto enfermeiroUpdateDto)
        {

            if (id != enfermeiroUpdateDto.Id)
            {
                return NotFound("Não foi possível encontrar o enfermeiro informado.");
            }
            // Verificar se não é null

            //Buscar por id no banco de dados
            var enfermeiroModel = bancoDadosContext.Enfermeiro.Where(w => w.Id == enfermeiroUpdateDto.Id).FirstOrDefault();
            if (enfermeiroModel != null)
            {
                enfermeiroModel.Id = enfermeiroUpdateDto.Id;
                enfermeiroModel.NomeCompleto = enfermeiroUpdateDto.NomeCompleto;
                enfermeiroModel.InstituicaoEnsinoFormacao = enfermeiroUpdateDto.InstituicaoEnsinoFormacao;
                enfermeiroModel.CadastroCOFEN = enfermeiroUpdateDto.CadastroCOFEN;

                bancoDadosContext.Attach(enfermeiroModel);
                bancoDadosContext.Enfermeiro.Update(enfermeiroModel);
                bancoDadosContext.Enfermeiro.Attach(enfermeiroModel);

                bancoDadosContext.SaveChanges();
                return Ok(enfermeiroUpdateDto);
            }
            else
            {
                return BadRequest("Não foi possível encontrar o enfermeiro informado.");

            }
        }

        [HttpDelete("api/enfermeiros/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var enfermeiroModel = bancoDadosContext.Enfermeiro.Find(id);

            //Verificar se o registro est� diferente de null
            if (enfermeiroModel != null)
            {
                //Deletar o regitro no banco de dados

                bancoDadosContext.Enfermeiro.Remove(enfermeiroModel);
                bancoDadosContext.SaveChanges();

                return Ok();
            }
            else
            {
                //se for null retorno um request de erro
                return NotFound("Erro ao apagar o registro");

            }
        }
      // [HttpPost("api/enfermeiros")]
        //public ActionResult<EnfermeiroCreateDto> Post([FromBody] EnfermeiroCreateDto enfermeiroCreateDto)
        //{

        //    return Ok();
        //}
    }
}



 
