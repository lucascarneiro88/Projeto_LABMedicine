using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessDomainValidationObjects;
using Microsoft.EntityFrameworkCore;
using LABMedicine.CustomValidation;
using static LABMedicine.CustomValidation.CustomValidation;

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
        [HttpPost("enfermeiros")]
        public ActionResult<EnfermeiroCreateDto> Post([FromBody] EnfermeiroCreateDto enfermeiroCreateDto)
        {




            if (enfermeiroCreateDto.CPF == "cPf")
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF Já cadastrado na base de dados");
            }
            if (!new checkCPF().IsValid(enfermeiroCreateDto.CPF))
            {
                return BadRequest("CPF inválido");
            }



            EnfermeiroModel model = new EnfermeiroModel();

            {
                model.NomeCompleto = enfermeiroCreateDto.NomeCompleto;
                model.CPF = enfermeiroCreateDto.CPF;
                model.InstituicaoEnsinoFormacao = enfermeiroCreateDto.InstituicaoEnsinoFormacao;
                model.CadastroCOFEN = enfermeiroCreateDto.CadastroCOFEN;
                model.Telefone = enfermeiroCreateDto.Telefone;
                model.DataDeNascimento = enfermeiroCreateDto.DataDeNascimento;
                model.Genero = enfermeiroCreateDto.Genero;

            }


            bancoDadosContext.Enfermeiro.Add(model);


            bancoDadosContext.SaveChanges();

            enfermeiroCreateDto.Id = model.Id;

            return StatusCode(201, enfermeiroCreateDto);
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
                enfermeiroGetDto.Genero = item.Genero;
                enfermeiroGetDto.Telefone = item.Telefone;
                enfermeiroGetDto.DataDeNascimento = item.DataDeNascimento;
                enfermeiroGetDto.CPF = item.CPF;
                enfermeiroGetDto.CadastroCOFEN = item.CadastroCOFEN;
                enfermeiroGetDto.InstituicaoEnsinoFormacao = item.InstituicaoEnsinoFormacao;


                listaGetDto.Add(enfermeiroGetDto);
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
            EnfermeiroGetDto enfermeiroGetDto = new EnfermeiroGetDto();
            enfermeiroGetDto.Id = enfermeiroModel.Id;
            enfermeiroGetDto.NomeCompleto = enfermeiroModel.NomeCompleto;
            enfermeiroGetDto.Genero = enfermeiroModel.Genero;
            enfermeiroGetDto.Telefone = enfermeiroModel.Telefone;
            enfermeiroGetDto.DataDeNascimento = enfermeiroModel.DataDeNascimento;
            enfermeiroGetDto.CPF = enfermeiroModel.CPF;
            enfermeiroGetDto.CadastroCOFEN = enfermeiroModel.CadastroCOFEN;
            enfermeiroGetDto.InstituicaoEnsinoFormacao = enfermeiroModel.InstituicaoEnsinoFormacao;


            return Ok(enfermeiroGetDto);
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
                enfermeiroModel.Genero = enfermeiroUpdateDto.Genero;
                enfermeiroModel.DataDeNascimento = enfermeiroUpdateDto.DataDeNascimento;
                enfermeiroModel.Telefone = enfermeiroUpdateDto.Telefone;
                enfermeiroModel.CPF = enfermeiroUpdateDto.CPF;
               

               // bancoDadosContext.Attach(enfermeiroModel);
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
  






