
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Mvc;






namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly BancoDadosContext bancoDadosContext;
       //Construtor com parametro (Injetado)
        public PacienteController(BancoDadosContext bancoDadosContext)
        {
            this.bancoDadosContext = bancoDadosContext;
        }
        [HttpGet]
        public ActionResult<List<PacienteGetDto>> Get() 
        {
                var listaPacienteModel = bancoDadosContext.Paciente;
                List<PacienteGetDto> listaGetDto = new List<PacienteGetDto>();

            foreach (var item in listaPacienteModel)
            {
                var pacienteGetDto = new PacienteGetDto();
                pacienteGetDto.Id = item.Id;
                pacienteGetDto.NomeCompleto = item.NomeCompleto;


                listaGetDto.Add(pacienteGetDto);
            }
                return Ok(listaGetDto);
        }   
 
        [HttpGet("{id}")]
        public ActionResult<PacienteGetDto> Get([FromRoute] int id)
        {
            //var pacienteMoldel = bancoDadosContext.Paciente.Find(id);
            var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Dados não encontrados no banco de dados");
            }

                var pacienteGetDto = new PacienteGetDto();
                pacienteGetDto.Id = pacienteGetDto.Id;
                pacienteGetDto.NomeCompleto = pacienteGetDto.NomeCompleto;

                return Ok(pacienteGetDto);
        }
       
        [HttpPost]
        //public ActionResult<> Post([FromBody] )//Nome classe DTO + classe dto
        //{
           
        //    // Lógica para cadastrar o novo paciente

        //    return Ok();
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
            var pacienteModel = bancoDadosContext.Paciente.Find(id);
            //Verificar se o registro est� diferente de null
            if (pacienteModel != null)
            {
                //Deletar o regitro no banco de dados

                bancoDadosContext.Paciente.Remove(pacienteModel);
                bancoDadosContext.SaveChanges();

                return Ok();
            }
            else
            {
                //se for null retorno um request de erro
                return NotFound("Erro ao apagar o registro");
            }
            return Ok();



        }
           
               
    }

        
        
}

