
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LABMedicine.DTO;
using LABMedicine.Enumerator;
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
        [HttpGet("pacientes/status")]
        public ActionResult<List<PacienteGetDto>> Get([FromQuery] string StatusAtendimento = null)//Ver se realmente se não é passado null para statusAtendimento
        {
                var listaPacienteModel = bancoDadosContext.Paciente.AsQueryable();//AsQueryable permitindo a utilização do método Where() sem gerar o erro de conversão.
                //var listaPacienteModel = bancoDadosContext.Paciente;
                List<PacienteGetDto> listaGetDto = new List<PacienteGetDto>();

            if (!string.IsNullOrEmpty(StatusAtendimento))
            {
                // Filtrar os pacientes pelo status de atendimento
                listaPacienteModel = listaPacienteModel.Where(p => p.StatusAtendimento == StatusAtendimento);
            }

            foreach (var item in listaPacienteModel)
            {
                var pacienteGetDto = new PacienteGetDto();
                pacienteGetDto.Id = pacienteGetDto.Id;
                pacienteGetDto.NomeCompleto = pacienteGetDto.NomeCompleto;
                pacienteGetDto.ContatoDeEmergencia = pacienteGetDto.ContatoDeEmergencia;
                pacienteGetDto.Convenio = pacienteGetDto.Convenio;
                pacienteGetDto.StatusAtendimentoEnum = pacienteGetDto.StatusAtendimentoEnum;
                pacienteGetDto.Alergias = pacienteGetDto.Alergias;
                pacienteGetDto.CuidadosEspecificos = pacienteGetDto.CuidadosEspecificos;


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
                return NotFound("Dados não encontrados");
            }

                var pacienteGetDto = new PacienteGetDto();
                pacienteGetDto.Id = pacienteGetDto.Id;
                pacienteGetDto.NomeCompleto = pacienteGetDto.NomeCompleto;
                pacienteGetDto.ContatoDeEmergencia = pacienteGetDto.ContatoDeEmergencia;
                pacienteGetDto.Convenio = pacienteGetDto.Convenio;
                pacienteGetDto.StatusAtendimentoEnum  = pacienteGetDto.StatusAtendimentoEnum ;
                pacienteGetDto.Alergias = pacienteGetDto.Alergias;
                pacienteGetDto.CuidadosEspecificos = pacienteGetDto.CuidadosEspecificos;
          

                return Ok(pacienteGetDto);
        }
       
        [HttpPost("paciente")]
        //  public ActionResult<PacienteGetDto> Post ([FromBody] PacienteCreateDto pacienteCreateDto)
        //{
        //    return Ok();
        //}



        //    [HttpPut("api/pacientes/Status? = ATENDIDO")]
        //  public ActionResult<PacienteGetDto> Put ([FromBody] PacienteGetDto pacienteGetDto)
        //{
        //    return Ok();
        //}






        [HttpPut("pacientes/{id}")]
        public ActionResult<PacienteUpdateDto> Put(int id,[FromBody]PacienteUpdateDto pacienteUpdateDto)
        {
            if (id != pacienteUpdateDto.Id)
            {
                      return BadRequest("Requisição com dados inválidos.");
            }
            //Buscar por id no banco de dados
            var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == pacienteUpdateDto.Id).FirstOrDefault();
            if (pacienteModel != null)
            {
                      pacienteModel.Id = pacienteUpdateDto.Id;
                      pacienteModel.NomeCompleto = pacienteUpdateDto.NomeCompleto;
                      pacienteModel.ContatoDeEmergencia = pacienteUpdateDto.ContatoDeEmergencia;
                      pacienteModel.Convenio = pacienteUpdateDto.Convenio;
                      pacienteModel.StatusAtendimento = pacienteUpdateDto.StatusAtendimento;
                      pacienteModel.Alergias = pacienteUpdateDto.Alergias;
                      pacienteModel.CuidadosEspecificos = pacienteUpdateDto.CuidadosEspecificos;
                     
                     
                      bancoDadosContext.Paciente.Update(pacienteModel);
                      bancoDadosContext.Paciente.Attach(pacienteModel);

                      bancoDadosContext.SaveChanges();
                     
                

                      return Ok(pacienteUpdateDto);
            }
            else
            {
                     return NotFound("Não foi possível encontrar registro informado.");

            }

           
        }

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
           



        }
           
               
    }

        
        
}

