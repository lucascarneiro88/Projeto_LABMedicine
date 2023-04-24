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

            }


            bancoDadosContext.Medico.Add(model);


            bancoDadosContext.SaveChanges();

            medicoCreateDto.Id = model.Id;

            return StatusCode(201, medicoCreateDto);
        }



        //[HttpPut("medicos")]
        //public ActionResult<List<MedicoGetDto>> Put([FromQuery] string EstadoSistema = "Ativo")
        //{
        //    var listaMedicoModel = bancoDadosContext.Medico.AsQueryable();
        //    List<MedicoGetDto> listaGetDto = new List<MedicoGetDto>();
        //    if (!string.IsNullOrEmpty(EstadoSistema))
        //    {
        //        // Filtrar os medicos pelo status no sistema
        //        listaMedicoModel = listaMedicoModel.Where(m => m.EstadoSistemaEnum == EstadoSistema);
        //    }
        //    foreach (var item in listaMedicoModel)
        //    {
        //        var medicoGetDto = new MedicoGetDto();
        //        medicoGetDto.Id = item.Id;
        //        medicoGetDto.NomeCompleto = item.NomeCompleto;
        //        medicoGetDto.InstituicaoEnsinoFormacao = item.InstituicaoEnsinoFormacao;
        //        medicoGetDto.CadastroCrm = item.CadastroCrm;
        //        medicoGetDto.Especializacao = item.Especializacao;
        //        medicoGetDto.EstadoSistemaEnum = item.EstadoSistemaEnum;
        //        medicoGetDto.TotalAtendimentosRealizados = item.TotalAtendimentosRealizados;


        //        listaGetDto.Add(medicoGetDto);
        //    }




        //    return Ok(listaGetDto);
        //}



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

       
        
       
        
        
        

        [HttpPut]
        //public ActionResult Put([FromBody])//dentro do parenteses Classe MOdel + Classe model
        //{
        //    return Ok();
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

