using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LABMedicine.DTO;
using LABMedicine.Enumerator;
using LABMedicine.Models;
using static LABMedicine.CustomValidation.CustomValidation;
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

        [HttpPost("pacientes")]
        public ActionResult<PacienteCreateDto> Post([FromBody] PacienteCreateDto pacienteCreateDto)
        {

            if (pacienteCreateDto.CPF == "cPF")
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF Já cadastrado na base de dados");
            }
            if (!new checkCPF().IsValid(pacienteCreateDto.CPF))
            {
                return BadRequest("CPF inválido");
            }


            PacienteModel model = new PacienteModel();

            {
                model.NomeCompleto = pacienteCreateDto.NomeCompleto;
                model.CPF = pacienteCreateDto.CPF;
                model.ContatoDeEmergencia = pacienteCreateDto.ContatoDeEmergencia;
                model.Convenio = pacienteCreateDto.Convenio;
                model.StatusAtendimento = pacienteCreateDto.StatusAtendimento;
                model.Alergias = string.Join("|", pacienteCreateDto.Alergias!);
                model.CuidadosEspecificos = string.Join("|", pacienteCreateDto.CuidadosEspecificos!);


            }

            bancoDadosContext.Paciente.Add(model);
            bancoDadosContext.SaveChanges();

            return Ok(pacienteCreateDto);
        }


        [HttpGet("pacientes/status")]
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
                pacienteGetDto.ContatoDeEmergencia = item.ContatoDeEmergencia;
                pacienteGetDto.Convenio = item.Convenio;
                pacienteGetDto.StatusAtendimento = item.StatusAtendimento;
                pacienteGetDto.Alergias = item.Alergias;
                pacienteGetDto.CuidadosEspecificos = item.CuidadosEspecificos;


                listaGetDto.Add(pacienteGetDto);
            }
                return Ok(listaGetDto);
        }   
 
        [HttpGet("pacientes/{id}")]
        public ActionResult<PacienteGetDto> Get([FromRoute] int id)
        {
            var pacienteModel = bancoDadosContext.Paciente.Find(id);
            //var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Dados não encontrados");
            }

                PacienteGetDto pacienteGetDto = new PacienteGetDto();
                pacienteGetDto.Id = pacienteModel.Id;
                pacienteGetDto.NomeCompleto = pacienteModel.NomeCompleto;
                pacienteGetDto.ContatoDeEmergencia = pacienteModel.ContatoDeEmergencia;
                pacienteGetDto.Convenio = pacienteModel.Convenio;
                pacienteGetDto.StatusAtendimento  = pacienteModel.StatusAtendimento;
                pacienteGetDto.Alergias = pacienteModel.Alergias;
                pacienteGetDto.CuidadosEspecificos = pacienteModel.CuidadosEspecificos;
          

                return Ok(pacienteGetDto);
        }



        //    //Buscar o registro no banco de dados por >>>ID<<<
        //    var enfermeiroModel = bancoDadosContext.Enfermeiro.Find(id);
        //    // var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Where(w => w.Id == id).FirstOrDefault();

        //    if (enfermeiroModel == null)
        //    {
        //        return NotFound("Dados não encontrados no banco de dados");
        //    }
        //    EnfermeiroGetDto enfermeiroGetDto = new EnfermeiroGetDto();
        //    enfermeiroGetDto.Id = enfermeiroModel.Id;
        //    enfermeiroGetDto.NomeCompleto = enfermeiroModel.NomeCompleto;
        //    enfermeiroGetDto.Genero = enfermeiroModel.Genero;
        //    enfermeiroGetDto.Telefone = enfermeiroModel.Telefone;
        //    enfermeiroGetDto.DataDeNascimento = enfermeiroModel.DataDeNascimento;
        //    enfermeiroGetDto.CPF = enfermeiroModel.CPF;
        //    enfermeiroGetDto.CadastroCOFEN = enfermeiroModel.CadastroCOFEN;
        //    enfermeiroGetDto.InstituicaoEnsinoFormacao = enfermeiroModel.InstituicaoEnsinoFormacao;


        //    return Ok(enfermeiroGetDto);
        //}

        [HttpPut("pacientes/{id}")]
        public ActionResult<PacienteCreateDto> Put([FromRoute] int id, [FromBody] PacienteCreateDto pacienteCreateDto)
        {

            var pacienteModel = bancoDadosContext.Paciente.Where(w => w.Id == pacienteCreateDto.Id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Não foi possível encontrar o medico informado.");
            }


            if (pacienteModel != null)
            {
                pacienteModel.Id = pacienteCreateDto.Id;
                pacienteModel.NomeCompleto = pacienteCreateDto.NomeCompleto;
                pacienteModel.ContatoDeEmergencia = pacienteCreateDto.ContatoDeEmergencia;
                pacienteModel.Convenio = pacienteCreateDto.Convenio;
                pacienteModel.StatusAtendimento = pacienteCreateDto.StatusAtendimento;
                pacienteModel.Alergias = pacienteCreateDto.Alergias;
                pacienteModel.CuidadosEspecificos = pacienteCreateDto.CuidadosEspecificos;


                // bancoDadosContext.Paciente.Update(pacienteModel);
                //bancoDadosContext.Paciente.Attach(pacienteModel);

                bancoDadosContext.SaveChanges();



                return Ok(pacienteCreateDto);
            }
            else
            {
                return NotFound("Dados inválidos.");

            }

        }


            //[HttpPut("api/pacientes/{id}/status")]
            //public ActionResult AtualizarStatusAtendimento([FromRoute] int id, [FromBody] StatusAtendimentoDto statusAtendimentoDto = "")
            //{
            //    var pacienteModel = bancoDadosContext.Paciente.FirstOrDefault(p => p.Id == id);

            //    if (pacienteModel == null)
            //    {
            //        return NotFound("Não foi possível encontrar registro .");
            //    }

            //    // Validar se o campo "StatusAtendimentoEnum" pertence aos valores possíveis
            //    if (!Enum.IsDefined(typeof(StatusAtendimentoEnum), statusAtendimentoDto.Status))
            //    {
            //        return BadRequest("Status de atendimento inválido.");
            //    }

            //    pacienteModel.StatusAtendimento = statusAtendimentoDto.Status;

            //    bancoDadosContext.Paciente.Attach(pacienteModel);
            //    bancoDadosContext.SaveChanges();

            //    return Ok(pacienteModel);
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
           



        }
        



    }



}

