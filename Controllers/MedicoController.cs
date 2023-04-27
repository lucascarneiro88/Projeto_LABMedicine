using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using static LABMedicine.CustomValidation.CustomValidation;
using LABMedicine.Enumerator;


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
        public ActionResult<MedicoDto> Post([FromBody] MedicoDto medicoDto)
        {
            if (bancoDadosContext.Medico.Any(e => e.CPF == medicoDto.CPF))
            {
                return StatusCode(StatusCodes.Status409Conflict,$"Já existe  cadastrado com esse CPF {medicoDto.CPF}.");
            }

            if (!new checkCPF().IsValid(medicoDto.CPF))
            {
               return BadRequest("CPF inválido");
            }

            MedicoModel model = new MedicoModel();
            

            {
                model.NomeCompleto = medicoDto.NomeCompleto;
                model.Genero = medicoDto.Genero;
                model.DataDeNascimento = medicoDto.DataDeNascimento;
                model.Telefone = medicoDto.Telefone;
                model.CPF = medicoDto.CPF;
                model.InstituicaoEnsinoFormacao = medicoDto.InstituicaoEnsinoFormacao;
                model.Especializacao = medicoDto.Especializacao;
                model.EstadoSistema = medicoDto.EstadoSistema;
                model.TotalAtendimentosRealizados = medicoDto.TotalAtendimentosRealizados;
                model.CadastroCrm = medicoDto.CadastroCrm;
            }

               bancoDadosContext.Medico.Add(model);
               bancoDadosContext.SaveChanges();

               medicoDto.Id = model.Id;

              return StatusCode(201, medicoDto);
        }

        [HttpGet("medicos/{id}")]
        public ActionResult<MedicoDto> Get([FromRoute] int id)
        {
            //var medicoModel = bancoDadosContext.Medico.Find(id);
                var medicoModel = bancoDadosContext.Medico.Where(w => w.Id == id).FirstOrDefault();
            if (medicoModel == null)
            {
                return NotFound("Dados não encontrados no banco de dados");
            }
                var medicoDto = new MedicoDto();
                medicoDto.Id = medicoModel.Id;
                medicoDto.NomeCompleto = medicoModel.NomeCompleto;
                medicoDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
                medicoDto.CadastroCrm = medicoModel.CadastroCrm;
                medicoDto.Especializacao = medicoModel.Especializacao;
                medicoDto.EstadoSistema = medicoModel.EstadoSistema;
                medicoDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados;

            return Ok(medicoDto);
        }

        [HttpGet("medicos")]
        public ActionResult<List<MedicoDto>> Get()
        {
                var listaMedicoModel = bancoDadosContext.Medico;

                List<MedicoDto> listaGetDto = new List<MedicoDto>();

            foreach (var medicoModel in listaMedicoModel)
            {
                var medicoDto = new MedicoDto();
                medicoDto.Id = medicoModel.Id;
                medicoDto.NomeCompleto = medicoModel.NomeCompleto;
                medicoDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
                medicoDto.CadastroCrm = medicoModel.CadastroCrm;
                medicoDto.Especializacao = medicoModel.Especializacao;
                medicoDto.EstadoSistema = medicoModel.EstadoSistema;
                medicoDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados;

                listaGetDto.Add(medicoDto);
            }

            return Ok(listaGetDto);

        }

        [HttpPut("medicos/{id}")]
        public ActionResult<MedicoDto> Put([FromRoute] int id, [FromBody] MedicoDto medicoDto)
        {
                var medicoModel = bancoDadosContext.Medico.SingleOrDefault(m => m.Id == id);

            if (medicoModel == null)
            {
                return NotFound("Não foi possível encontrar o medico informado.");
            }
        
               medicoModel.NomeCompleto = medicoDto.NomeCompleto;
               medicoModel.DataDeNascimento = medicoDto.DataDeNascimento;
               medicoModel.Genero = medicoDto.Genero;
               medicoModel.Telefone = medicoDto.Telefone;
               medicoModel.CPF = medicoDto.CPF;
               medicoModel.InstituicaoEnsinoFormacao = medicoDto.InstituicaoEnsinoFormacao;
               medicoModel.CadastroCrm = medicoDto.CadastroCrm;
               medicoModel.Especializacao = medicoDto.Especializacao;
               medicoModel.EstadoSistema = medicoDto.EstadoSistema;
               medicoModel.TotalAtendimentosRealizados = medicoDto.TotalAtendimentosRealizados;
           
               bancoDadosContext.SaveChanges();

               return Ok(medicoDto);
        
        }
        [HttpPut("medicos/{id}/status")]
        public ActionResult<MedicoDto> UpdateMedicoStatus(int id, [FromBody] EstadoSistemaEnum estadoSistema)
        {
            // Verificar se o médico existe
            var medico = bancoDadosContext.Medico.SingleOrDefault(m => m.Id == id);
            if (medico == null)
            {
                return NotFound($"Médico com o identificador {id} não foi encontrado.");
            }

            // Verificar se o status informado é válido
            if (!Enum.IsDefined(typeof(EstadoSistemaEnum), estadoSistema))
            {
                return BadRequest($"O status {estadoSistema} não é um valor válido para o campo status.");
            }

            // Atualizar o status do médico
            medico.EstadoSistema = estadoSistema;
            bancoDadosContext.SaveChanges();

            // Criar e retornar um objeto MedicoDto com os dados atualizados do médico
            var medicoDto = new MedicoDto
            {
                Id = medico.Id,
                NomeCompleto = medico.NomeCompleto,
                InstituicaoEnsinoFormacao = medico.InstituicaoEnsinoFormacao,
                CadastroCrm = medico.CadastroCrm,
                Especializacao = medico.Especializacao,
                EstadoSistema = medico.EstadoSistema,
                TotalAtendimentosRealizados = medico.TotalAtendimentosRealizados
            };

            return medicoDto;
        }



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
                return NotFound("Código não existente ");
            }

        }
    }
}

