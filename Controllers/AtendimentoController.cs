
using LABMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LABMedicine.Enumerator;

namespace LABMedicine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly BancoDadosContext bancoDadosContext;

        //Construtor com parametro (Injetado)
        public AtendimentoController(BancoDadosContext bancoDadosContext)
        {
            this.bancoDadosContext = bancoDadosContext;
        }

        [HttpPut("{idPaciente}/{idMedico}")]
        public ActionResult<AtendimentoModel> Put(int idPaciente, int idMedico,[FromBody] AtendimentoModel atendimento)
        {
            var pacienteModel = bancoDadosContext.Paciente.Find(idPaciente);
            if (pacienteModel == null)
            {
                return NotFound($"Paciente com Id {idPaciente} não encontrado.");
            }

            var medicoModel = bancoDadosContext.Medico.Find(idMedico);
            if (medicoModel == null)
            {
                return NotFound($"Médico com Id {idMedico} não encontrado.");
            }

            var descricao = "Descrição  atendimento";
            var atendimentoModel = new AtendimentoModel();
            {
                atendimentoModel.IdPaciente = idPaciente;
                atendimentoModel.IdMedico = idMedico;
                atendimentoModel.Descricao = descricao;
            }
             bancoDadosContext.Atendimento.Add(atendimentoModel);
             bancoDadosContext.SaveChanges();


            // UPDATE na tabela Paciente
            pacienteModel.StatusAtendimento = StatusAtendimentoEnum.Atendido;
            pacienteModel.TotalAtendimentos++;
            bancoDadosContext.Entry(pacienteModel).State = EntityState.Modified;
            bancoDadosContext.SaveChanges();

            return Ok(atendimentoModel);
        }
    }
}
