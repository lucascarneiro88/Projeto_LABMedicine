using LABMedicine.DTO;
using LABMedicine.Models;
using static LABMedicine.CustomValidation.CustomValidation;
using Microsoft.AspNetCore.Mvc;
using LABMedicine.Enumerator;

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

        [HttpPost("pacientes")]
        public ActionResult<PacienteDto> Post([FromBody] PacienteDto pacienteDto)
        {
            if (bancoDadosContext.Enfermeiro.Any(e => e.CPF == pacienteDto.CPF))
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Já existe  cadastrado este CPF {pacienteDto.CPF}.");
            }
            if (!new checkCPF().IsValid(pacienteDto.CPF))
            {
                return BadRequest("CPF inválido");
            }


            PacienteModel model = new PacienteModel();

            {
                model.NomeCompleto = pacienteDto.NomeCompleto;
                model.DataDeNascimento = pacienteDto.DataDeNascimento;
                model.CPF = pacienteDto.CPF;
                model.ContatoDeEmergencia = pacienteDto.ContatoDeEmergencia;
                model.Convenio = pacienteDto.Convenio;
                model.StatusAtendimento = pacienteDto.StatusAtendimento;
                model.Alergias = string.Join("|", pacienteDto.Alergias!);
                model.CuidadosEspecificos = string.Join("|", pacienteDto.CuidadosEspecificos!);
                model.TotalAtendimentos = pacienteDto.TotalAtendimentos;
            }

               bancoDadosContext.Paciente.Add(model);
               bancoDadosContext.SaveChanges();
               pacienteDto.Id = model.Id;

               return StatusCode(201, pacienteDto);
          
        }

        [HttpGet("pacientes/status")]
        public ActionResult<List<PacienteDto>> Get([FromQuery] string StatusAtendimento = "Atendido")
        {
            var listaPacienteModel = bancoDadosContext.Paciente.AsQueryable();
            List<PacienteDto> listaGetDto = new List<PacienteDto>();

            if (!string.IsNullOrEmpty(StatusAtendimento))
            {
                StatusAtendimentoEnum statusEnum = (StatusAtendimentoEnum)Enum.Parse(typeof(StatusAtendimentoEnum), StatusAtendimento, true);
                listaPacienteModel = listaPacienteModel.Where(p => p.StatusAtendimento == statusEnum);
            }

            foreach (var item in listaPacienteModel)
            {
                var pacienteDto = new PacienteDto();
                pacienteDto.Id = item.Id;
                pacienteDto.NomeCompleto = item.NomeCompleto;
                pacienteDto.DataDeNascimento = item.DataDeNascimento;
                pacienteDto.CPF = item.CPF;
                pacienteDto.ContatoDeEmergencia = item.ContatoDeEmergencia;
                pacienteDto.Convenio = item.Convenio;
                pacienteDto.StatusAtendimento = item.StatusAtendimento;
                pacienteDto.Alergias = item.Alergias;
                pacienteDto.CuidadosEspecificos = item.CuidadosEspecificos;
                pacienteDto.TotalAtendimentos = item.TotalAtendimentos;

                listaGetDto.Add(pacienteDto);
            }

                return Ok(listaGetDto);
        }


        [HttpGet("pacientes/{id}")]
        public ActionResult<PacienteDto> Get([FromRoute] int id)
        {
            var pacienteModel = bancoDadosContext.Paciente.Find(id);
            //var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Dados não encontrados");
            }

                PacienteDto pacienteDto = new PacienteDto();
                pacienteDto.Id = pacienteModel.Id;
                pacienteDto.NomeCompleto = pacienteModel.NomeCompleto;
                pacienteDto.DataDeNascimento = pacienteModel.DataDeNascimento;
                pacienteDto.CPF = pacienteModel.CPF;
                pacienteDto.ContatoDeEmergencia = pacienteModel.ContatoDeEmergencia;
                pacienteDto.Convenio = pacienteModel.Convenio;
                pacienteDto.StatusAtendimento  = pacienteModel.StatusAtendimento;
                pacienteDto.Alergias = pacienteModel.Alergias;
                pacienteDto.CuidadosEspecificos = pacienteModel.CuidadosEspecificos;
                pacienteDto.TotalAtendimentos = pacienteModel.TotalAtendimentos;


                return Ok(pacienteDto);
        }


        [HttpPut("pacientes/{id}")]
        public ActionResult<PacienteDto> Put([FromRoute] int id, [FromBody] PacienteDto pacienteDto)
        {

            var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == pacienteDto.Id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Não foi possível encontrar o medico informado.");
            }


            if (pacienteModel != null)
            {
                pacienteModel.Id = pacienteDto.Id;
                pacienteModel.NomeCompleto = pacienteDto.NomeCompleto;
                pacienteModel.DataDeNascimento = pacienteDto.DataDeNascimento;
                pacienteModel.CPF = pacienteDto.CPF;
                pacienteModel.ContatoDeEmergencia = pacienteDto.ContatoDeEmergencia;
                pacienteModel.Convenio = pacienteDto.Convenio;
                pacienteModel.StatusAtendimento = pacienteDto.StatusAtendimento;
                pacienteModel.Alergias = pacienteDto.Alergias;
                pacienteModel.CuidadosEspecificos = pacienteDto.CuidadosEspecificos;
                pacienteModel.TotalAtendimentos = pacienteDto.TotalAtendimentos;


                // bancoDadosContext.Paciente.Update(pacienteModel);
                //bancoDadosContext.Paciente.Attach(pacienteModel);

                bancoDadosContext.SaveChanges();

                return Ok(pacienteDto);
            }
            else
            {
                return NotFound("Dados inválidos.");

            }

        }


        [HttpPut("pacientes/{id}/status")]
        public ActionResult AtualizarStatusAtendimento([FromRoute] int id, [FromBody] StatusAtendimentoEnum statusAtendimento)
        {
            var pacienteModel = bancoDadosContext.Paciente.FirstOrDefault(p => p.Id == id);

            if (pacienteModel == null)
            {
                return NotFound("Não foi possível encontrar registro.");
            }

            if (!Enum.IsDefined(typeof(StatusAtendimentoEnum), statusAtendimento))
            {
                return BadRequest("Status de atendimento inválido.");
            }

            pacienteModel.StatusAtendimento = statusAtendimento;

            bancoDadosContext.Paciente.Attach(pacienteModel);
            bancoDadosContext.SaveChanges();

            return Ok(pacienteModel);
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
                return NotFound("Código não existente ");
            }
           
        }
        
    }

}

