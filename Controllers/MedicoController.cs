﻿using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;




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


        [HttpPut("api/medicos")]
        public ActionResult<List<MedicoGetDto>> Put([FromQuery] string EstadoSistema = "Ativo")
        {
            var listaMedicoModel = bancoDadosContext.Medico.AsQueryable();
            List<MedicoGetDto> listaGetDto = new List<MedicoGetDto>();
            if (!string.IsNullOrEmpty(EstadoSistema))
            {
                // Filtrar os pacientes pelo status de atendimento
                listaMedicoModel = listaMedicoModel.Where(m => m.EstadoSistema == EstadoSistema);
            }
            foreach (var item in listaMedicoModel)
            {
                var medicoGetDto = new MedicoGetDto();
                medicoGetDto.Id = medicoGetDto.Id;
                medicoGetDto.NomeCompleto = medicoGetDto.NomeCompleto;
                medicoGetDto.InstituicaoEnsinoFormacao = medicoGetDto.InstituicaoEnsinoFormacao;
                medicoGetDto.CadastroCrm = medicoGetDto.CadastroCrm;
                medicoGetDto.Especializacao = medicoGetDto.Especializacao;
                medicoGetDto.EstadoSistemaEnum = medicoGetDto.EstadoSistemaEnum;
                medicoGetDto.TotalAtendimentosRealizados = medicoGetDto.TotalAtendimentosRealizados;


                listaGetDto.Add(medicoGetDto);
            }




            return Ok(listaGetDto);
        }



    [HttpGet("api/medicos/{id}")]
        public ActionResult<MedicoGetDto> Get([FromRoute] int id)
        {
            //var medicoModel = bancoDadosContext.Medico.Find(id);
            var medicoModel = bancoDadosContext.Medico.Where(w => w.Id == id).FirstOrDefault();
            if (medicoModel == null)
            {
                return NotFound("Dados não encontrados no banco de dados");
            }
            var medicoGetDto = new MedicoGetDto();
            medicoGetDto.Id = medicoGetDto.Id;
            medicoGetDto.NomeCompleto = medicoGetDto.NomeCompleto;
            medicoGetDto.InstituicaoEnsinoFormacao = medicoGetDto.InstituicaoEnsinoFormacao;
            medicoGetDto.CadastroCrm = medicoGetDto.CadastroCrm;
            medicoGetDto.Especializacao = medicoGetDto.Especializacao;
            medicoGetDto.EstadoSistemaEnum = medicoGetDto.EstadoSistemaEnum;
            medicoGetDto.TotalAtendimentosRealizados = medicoGetDto.TotalAtendimentosRealizados;

            return Ok(medicoGetDto);
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

