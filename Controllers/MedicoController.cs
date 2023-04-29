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


        [HttpPost]
        public ActionResult<MedicoDto> Post([FromBody] MedicoDto medicoDto)
        {
            

            if (!new checkCPF().IsValid(medicoDto.CPF))
            {
                return BadRequest("CPF inválido");
            }
            var medicoModel = bancoDadosContext.Medico.FirstOrDefault(m => m.CPF == medicoDto.CPF);
            if (medicoModel != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Já existe cadastrado esse CPF {medicoDto.CPF}.");
            }


                medicoModel = new MedicoModel();

            {
                medicoModel.Id = medicoDto.Id;
                medicoModel.NomeCompleto = medicoDto.NomeCompleto;
                medicoModel.Genero = medicoDto.Genero;
                medicoModel.DataDeNascimento = medicoDto.DataDeNascimento;
                medicoModel.Telefone = medicoDto.Telefone;
                medicoModel.CPF = medicoDto.CPF;
                medicoModel.InstituicaoEnsinoFormacao = medicoDto.InstituicaoEnsinoFormacao;
                medicoModel.Especializacao = medicoDto.Especializacao;
                medicoModel.EstadoSistema = medicoDto.EstadoSistema;
                medicoModel.TotalAtendimentosRealizados = medicoDto.TotalAtendimentosRealizados ++;
                medicoModel.CadastroCrm = medicoDto.CadastroCrm;

            }

            bancoDadosContext.Medico.Add(medicoModel);
            bancoDadosContext.SaveChanges();
            medicoDto.Id = medicoModel.Id;

            return StatusCode(201, medicoDto);
        }

    [HttpGet("{id}")]
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
            medicoDto.CPF = medicoModel.CPF;
            medicoDto.NomeCompleto = medicoModel.NomeCompleto;
            medicoDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
            medicoDto.CadastroCrm = medicoModel.CadastroCrm;
            medicoDto.Especializacao = medicoModel.Especializacao;
            medicoDto.EstadoSistema = medicoModel.EstadoSistema;
            medicoDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados ++;

            return Ok(medicoDto);
        }

        [HttpGet]
        public ActionResult<List<MedicoDto>> Get()
        {
            var listaMedicoModel = bancoDadosContext.Medico;

            List<MedicoDto> listaGetDto = new List<MedicoDto>();

            foreach (var medicoModel in listaMedicoModel)
            {
                var medicoDto = new MedicoDto();
                medicoDto.Id = medicoModel.Id;
                medicoDto.CPF = medicoModel.CPF;
                medicoDto.NomeCompleto = medicoModel.NomeCompleto;
                medicoDto.InstituicaoEnsinoFormacao = medicoModel.InstituicaoEnsinoFormacao;
                medicoDto.CadastroCrm = medicoModel.CadastroCrm;
                medicoDto.Especializacao = medicoModel.Especializacao;
                medicoDto.EstadoSistema = medicoModel.EstadoSistema;
                medicoDto.TotalAtendimentosRealizados = medicoModel.TotalAtendimentosRealizados ++;

                listaGetDto.Add(medicoDto);
            }

            return Ok(listaGetDto);

        }

        [HttpPut("{id}")]
        public ActionResult<MedicoDto> Put([FromRoute] int id, [FromBody] MedicoDto medicoDto)
        {
            var medicoModel = bancoDadosContext.Medico.SingleOrDefault(e => e.Id == id);
            medicoModel.TotalAtendimentosRealizados = (medicoDto.TotalAtendimentosRealizados++);

            if (medicoModel == null)
            {
                return NotFound("Não foi possível encontrar o medico informado.");
            }
            medicoModel.Id = medicoDto.Id;
            medicoModel.NomeCompleto = medicoDto.NomeCompleto;
            medicoModel.CPF = medicoDto.CPF;
            medicoModel.DataDeNascimento = medicoDto.DataDeNascimento;
            medicoModel.Genero = medicoDto.Genero;
            medicoModel.Telefone = medicoDto.Telefone;
            medicoModel.InstituicaoEnsinoFormacao = medicoDto.InstituicaoEnsinoFormacao;
            medicoModel.CadastroCrm = medicoDto.CadastroCrm;
            medicoModel.Especializacao = medicoDto.Especializacao;
            medicoModel.EstadoSistema = medicoDto.EstadoSistema;
            medicoModel.TotalAtendimentosRealizados = medicoDto.TotalAtendimentosRealizados ++;

            bancoDadosContext.Medico.Attach(medicoModel);
            bancoDadosContext.SaveChanges();

            return Ok(medicoDto);

        }

        [HttpPut("{id}/status")]
        public ActionResult<MedicoDto> AtualizarEstadoSistema([FromRoute] int id, [FromBody] EstadoSistemaEnum estadoSistema)
        {

            // Verificar se o status informado é válido
            if (!Enum.IsDefined(typeof(EstadoSistemaEnum), estadoSistema))
            {
                return BadRequest($"O status {estadoSistema} não é um valor válido para o campo status.");
            }

            // Verificar se o médico existe
            var medicoModel = bancoDadosContext.Medico.SingleOrDefault(m => m.Id == id);

            if (medicoModel == null)
            {
                return NotFound($"Médico com o identificador {id} não foi encontrado.");
            }
            
            // Atualizar o status do médico
            medicoModel.EstadoSistema = estadoSistema;

            bancoDadosContext.Medico.Attach(medicoModel);
            bancoDadosContext.SaveChanges();

            return Ok(medicoModel);

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





