
//using LABMedicine.DTO;
//using LABMedicine.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;







//namespace LABMedicine.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class AtendimentoController : ControllerBase
//    {
//        private readonly BancoDadosContext bancoDadosContext;

//        public AtendimentoController(BancoDadosContext bancoDadosContext)
//        {
//            this.bancoDadosContext = bancoDadosContext;
//        }

//        [HttpPut("{idPaciente}/{idMedico}")]
//        public ActionResult<AtendimentoModel> Put(int idPaciente, int idMedico, [FromBody] AtendimentoDto atendimentoDto)
//        {
//            var pacienteModel = bancoDadosContext.Paciente.Find(idPaciente);

//            if (pacienteModel == null)
//            {
//                return NotFound($"Paciente com Id {idPaciente} não encontrado.");
//            }

//            var medicoModel = bancoDadosContext.Medico.Find(idMedico);

//            if (medicoModel == null)
//            {
//                return NotFound($"Médico com Id {idMedico} não encontrado.");
//            }

//            var atendimentoModel = bancoDadosContext.Atendimento.FirstOrDefault(a => a.IdPaciente == idPaciente && a.IdMedico == idMedico);

//            if (atendimentoModel == null)
//            {
//                return NotFound($"Atendimento com paciente Id {idPaciente} e médico Id {idMedico} não encontrado.");
//            }

//            atendimentoModel.Descricao = atendimentoDto.Descricao;
//            bancoDadosContext.Entry(atendimentoModel).State = EntityState.Modified;
//            bancoDadosContext.SaveChanges();

//            // atualiza o registro do paciente
//            pacienteModel.StatusAtendimento = atendimentoDto.Paciente.StatusAtendimento;
//            pacienteModel.TotalAtendimentos = atendimentoDto.Paciente.TotalAtendimentos;

//            bancoDadosContext.Entry(pacienteModel).State = EntityState.Modified;
//            bancoDadosContext.SaveChanges();

//            // atualiza o registro do médico
//            medicoModel.TotalAtendimentosRealizados = atendimentoDto.Medico.TotalAtendimentosRealizados;

//            bancoDadosContext.Entry(medicoModel).State = EntityState.Modified;
//            bancoDadosContext.SaveChanges();

//            return Ok(atendimentoDto);
//        }
//    }
//}

