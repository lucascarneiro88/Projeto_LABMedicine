using LABMedicine.Enumerator;
using LABMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly BancoDadosContext bancoDadoscontext;

        //Construtor com parametro (Injetado)
        public AtendimentoController(BancoDadosContext bancoDadoscontext)
        {
            this.bancoDadoscontext = bancoDadoscontext;
        }

        [HttpPut("{idPaciente}/{idMedico}")]
        public ActionResult Put(int idPaciente, int idMedico)
        {
            var pacienteModel = bancoDadoscontext.Paciente.Find(idPaciente);
            if (pacienteModel == null)
            {
                return NotFound($"Paciente com Id {idPaciente} não encontrado.");
            }

            var medicoModel = bancoDadoscontext.Medico.Find(idMedico);
            if (medicoModel == null)
            {
                return NotFound($"Médico com Id {idMedico} não encontrado.");
            }

            try
            {
                var atendimentoModel = new AtendimentoModel
                {
                    IdPaciente = idPaciente,
                    IdMedico = idMedico
                };

                bancoDadoscontext.Atendimento.Add(atendimentoModel);
                bancoDadoscontext.SaveChanges();

                //UPDATE na tabela Pacientes
                pacienteModel.StatusAtendimento = StatusAtendimentoEnum.Atendido;
                pacienteModel.TotalAtendimentos++;

                bancoDadoscontext.Entry(pacienteModel).State = EntityState.Modified;
                bancoDadoscontext.SaveChanges();

                return Ok(atendimentoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

