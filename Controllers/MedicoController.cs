using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using static LABMedicine.CustomValidation.CustomValidation;
using Microsoft.IdentityModel.Tokens;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly BancoDadosContext bancoDadosContext;

        //Construtor com parametro (Injetado)
        public MedicoController(BancoDadosContext bancoDadosContext)
        {
            this.bancoDadosContext = bancoDadosContext;
        }

        [HttpPost("medicos")]
        public ActionResult<MedicoCreateDto> Post([FromBody] MedicoCreateDto medicoCreateDto)
        {

            if (medicoCreateDto.CPF == "cPf")
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF Já cadastrado na base de dados");
            }
            if (!new checkCPF().IsValid(medicoCreateDto.CPF))
            {
                return BadRequest("CPF inválido");
            }



            MedicoModel model = new MedicoModel();

            {
                model.NomeCompleto = medicoCreateDto.NomeCompleto;
                model.CPF = medicoCreateDto.CPF;
                model.InstituicaoEnsinoFormacao = medicoCreateDto.InstituicaoEnsinoFormacao;
                model.Especializacao = medicoCreateDto.Especializacao;
                model.Telefone = medicoCreateDto.Telefone;
                model.DataDeNascimento = medicoCreateDto.DataDeNascimento;
                model.Genero = medicoCreateDto.Genero;
                model.TotalAtendimentosRealizados = medicoCreateDto.TotalAtendimentosRealizados;
                model.CadastroCrm = medicoCreateDto.CadastroCrm;

             

            }


            bancoDadosContext.Medico.Add(model);


            bancoDadosContext.SaveChanges();

            medicoCreateDto.Id = model.Id;

            return StatusCode(201, medicoCreateDto);
        }

        [HttpGet("medicos/{id}")]
        public ActionResult<MedicoGetDto> Get([FromRoute] int id)
        {
            //var medicoModel = bancoDadosContext.Medico.Find(id);
                var medicoModel = bancoDadosContext.Medico.Where(w => w.Id == id).FirstOrDefault();
            if (medicoModel == null)
            {
                return NotFound("Dados não encontrados no banco de dados");
            }
                var medicoGetDto = new MedicoGetDto();
                medicoGetDto.Id = medicoModel.Id;
                medicoGetDto.NomeCompleto = medicoModel.NomeCompleto;
                medicoGetDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
                medicoGetDto.CadastroCrm = medicoModel.CadastroCrm;
                medicoGetDto.Especializacao = medicoModel.Especializacao;
                medicoGetDto.EstadoSistemaEnum = medicoModel.EstadoSistemaEnum;
                medicoGetDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados;

            return Ok(medicoGetDto);
        }

        [HttpGet("medicos")]
        public ActionResult<List<MedicoGetDto>> Get()
        {
                var listaMedicoModel = bancoDadosContext.Medico;

                List<MedicoGetDto> listaGetDto = new List<MedicoGetDto>();

            foreach (var medicoModel in listaMedicoModel)
            {
                var medicoGetDto = new MedicoGetDto();
                medicoGetDto.Id = medicoModel.Id;
                medicoGetDto.NomeCompleto = medicoModel.NomeCompleto;
                medicoGetDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
                medicoGetDto.CadastroCrm = medicoModel.CadastroCrm;
                medicoGetDto.Especializacao = medicoModel.Especializacao;
                medicoGetDto.EstadoSistemaEnum = medicoModel.EstadoSistemaEnum;
                medicoGetDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados;



                listaGetDto.Add(medicoGetDto);
            }

            return Ok(listaGetDto);

        }

        [HttpPut("medicos/{id}")]
        public ActionResult<MedicoCreateDto> Put([FromRoute] int id, [FromBody] MedicoCreateDto medicoCreateDto)
        {
                var medicoModel = bancoDadosContext.Medico.SingleOrDefault(m => m.Id == id);

            if (medicoModel == null)
            {
                return NotFound("Não foi possível encontrar o medico informado.");
            }
        
               medicoModel.NomeCompleto = medicoCreateDto.NomeCompleto;
               medicoModel.DataDeNascimento = medicoCreateDto.DataDeNascimento;
               medicoModel.Genero = medicoCreateDto.Genero;
               medicoModel.Telefone = medicoCreateDto.Telefone;
               medicoModel.CPF = medicoCreateDto.CPF;
               medicoModel.InstituicaoEnsinoFormacao = medicoCreateDto.InstituicaoEnsinoFormacao;
               medicoModel.CadastroCrm = medicoCreateDto.CadastroCrm;
               medicoModel.Especializacao = medicoCreateDto.Especializacao;
               medicoModel.EstadoSistemaEnum = medicoCreateDto.EstadoSistemaEnum;
               medicoModel.TotalAtendimentosRealizados = medicoCreateDto.TotalAtendimentosRealizados;
           
     

               bancoDadosContext.SaveChanges();

            return Ok(medicoCreateDto);
        
        }

        //[HttpPut("medicos/{id}/status")]
        //public ActionResult<List<MedicoCreateDto>> put(int id ,[FromQuery] EstadoSistemaEnum estadoSistemaEnum = "ativo")
        //{
        //    var medicomodel = bancodadoscontext.Medico.asqueryable();
        //    List<MedicoCreateDto>ListaCreateDto = new List<medicoCreateDto>();
        //    if (!string.isnullorempty(estadoSistemaEnum))
        //    {
        //        // filtrar os medicos pelo status no sistema
        //      medicomodel = medicomodel.where(m => m.estadosistemaenum == estadosistema);
        //    }
        //    foreach (var item in medicomodel)
        //    {
        //        var medicoCreateDto = new medicoCreateDto();
        //        medicoCreateDto.id = item.id;
        //        medicoCreateDto.nomecompleto = item.nomecompleto;
        //        medicoCreateDto.instituicaoensinoformacao = item.instituicaoensinoformacao;
        //        medicoCreateDto.cadastrocrm = item.cadastrocrm;
        //        medicoCreateDto.especializacao = item.especializacao;
        //        medicoCreateDto.estadosistemaenum = item.estadosistemaenum;
        //        medicoCreateDto.totalatendimentosrealizados = item.totalatendimentosrealizados;


        //        listaCreatedto.add(medicoCreateDto);
        //    }




        //    return ok(listaCreateDto);
        //}

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
               //Verificar se existe registro no banco de dados
               var medicoModel = bancoDadosContext.Medico.Find(id);
               //Verificar se o registro est� diferente de null

            if (medicoModel != null)
            {
                //Deletar o regitro no banco de dados
                bancoDadosContext.Medico.Remove(medicoModel);
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

