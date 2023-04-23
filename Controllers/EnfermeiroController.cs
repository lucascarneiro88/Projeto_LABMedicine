using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessDomainValidationObjects;
using Microsoft.EntityFrameworkCore;
using LABMedicine.validation;

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

        [HttpGet("enfermeiros/{id}")]
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
     

[HttpPost("enfermeiros")]
    public ActionResult<EnfermeiroCreateDto> Post([FromBody] EnfermeiroCreateDto enfermeiroCreateDto)
    {
        // Verifica se o CPF já está cadastrado
        if (bancoDadosContext.Enfermeiro.Any(e => e.CPF == enfermeiroCreateDto.CPF))
        {
            return Conflict("CPF já cadastrado");
        }

        
        if (!new CPF().IsValid(enfermeiroCreateDto.CPF))
        {
            return BadRequest("CPF inválido");
        }

        EnfermeiroModel enfermeiroModel = new EnfermeiroModel
        {
            NomeCompleto = enfermeiroCreateDto.NomeCompleto,
            CPF = enfermeiroCreateDto.CPF,
            InstituicaoEnsinoFormacao = enfermeiroCreateDto.InstituicaoEnsinoFormacao,
            CadastroCOFEN = enfermeiroCreateDto.CadastroCOFEN
        };

       
        bancoDadosContext.Enfermeiro.Add(enfermeiroModel);
        bancoDadosContext.SaveChanges();

        // Retorna o objeto criado como um EnfermeiroCreateDto
        var resultado = new EnfermeiroCreateDto
        {
            NomeCompleto = enfermeiroModel.NomeCompleto,
            CPF = enfermeiroModel.CPF,
            InstituicaoEnsinoFormacao = enfermeiroModel.InstituicaoEnsinoFormacao,
            CadastroCOFEN = enfermeiroModel.CadastroCOFEN
        };
        return Ok(enfermeiroCreateDto);
    }



    [HttpPut("enfermeiros/{id}")]
        public ActionResult<EnfermeiroUpdateDto> Put(int id, [FromBody] EnfermeiroUpdateDto enfermeiroUpdateDto)
        {

            if (id != enfermeiroUpdateDto.Id)
            {
                return NotFound("Não foi possível encontrar o enfermeiro informado.");
            }
           

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

        [HttpDelete("enfermeiros/{id}")]
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
      

    }
}





