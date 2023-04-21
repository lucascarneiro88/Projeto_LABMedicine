
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
        [HttpGet("/api/pacientes")]
        public ActionResult<List<PacienteGetDto>> Get([FromQuery] string StatusAtendimento = "Atendido")//Ver se realmente se não é passado null para statusAtendimento
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
                pacienteGetDto.Id = item.Id;
                pacienteGetDto.NomeCompleto = item.NomeCompleto;
                pacienteGetDto.ContatoDeEmergencia = pacienteGetDto.ContatoDeEmergencia;
                pacienteGetDto.Convenio = pacienteGetDto.Convenio;
                pacienteGetDto.StatusAtendimento = pacienteGetDto.StatusAtendimento;
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
                pacienteGetDto.StatusAtendimento  = pacienteGetDto.StatusAtendimento ;
                pacienteGetDto.Alergias = pacienteGetDto.Alergias;
                pacienteGetDto.CuidadosEspecificos = pacienteGetDto.CuidadosEspecificos;

                return Ok(pacienteGetDto);
        }
       
        [HttpPost("api")]
        //public ActionResult<> Post([FromBody] )//Nome classe DTO + classe dto
        //{

            // Lógica para cadastrar o novo paciente

         //  return Ok();
       // }


        [HttpPut()]//"api/pacientes/{id}/status"

        //public ActionResult<> Put([FromBody] )
        //{
        //        No corpo da request, informar objeto json com o campo status, e seu novo valor; EX: { “Status”:”Atendido”}
        //    O campo deve ser validado como sendo obrigatório e pertencente aos valores possíveis para este campo.
        //    Response:
        //    HTTP Status Code 200 (OK) em caso de sucesso, constando no corpo da resposta os dados atualizados do paciente.
        //    HTTP Status Code 400 (Bad Request) em caso de requisição com dados inválidos, informando mensagem de erro explicativa no corpo do response.
        //    HTTP Status Code 404 (Not Found) em caso de não ser encontrado registro com o código informado, retornando mensagem de erro explicativa no corpo do response.
        //    ‌


        //    return Ok();
        //}




        [HttpPut("{id}")]
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

