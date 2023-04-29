using LABMedicine.DTO;
using LABMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using static LABMedicine.CustomValidation.CustomValidation;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeiroController : ControllerBase
    {
            private readonly BancoDadosContext bancoDadosContext;

            //Construtor com parametro (Injetado)
        public EnfermeiroController(BancoDadosContext bancoDadosContext)
        {
            this.bancoDadosContext = bancoDadosContext;
        }

        [HttpPost]
        public ActionResult<EnfermeiroDto> Post([FromBody] EnfermeiroDto enfermeiroDto)
        {

            
            if (!new checkCPF().IsValid(enfermeiroDto.CPF))
            {
                return BadRequest($"CPF inválido");
            }
            var enfermeiroModel = bancoDadosContext.Enfermeiro.FirstOrDefault(e => e.CPF == enfermeiroDto.CPF);
            if (enfermeiroModel != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Já existe cadastrado esse CPF {enfermeiroDto.CPF}.");
            }

                enfermeiroModel  = new EnfermeiroModel();

            {
                enfermeiroModel.NomeCompleto = enfermeiroDto.NomeCompleto;
                enfermeiroModel.CPF = enfermeiroDto.CPF;
                enfermeiroModel.InstituicaoEnsinoFormacao = enfermeiroDto.InstituicaoEnsinoFormacao;
                enfermeiroModel.CadastroCOFEN = enfermeiroDto.CadastroCOFEN;
                enfermeiroModel.Telefone = enfermeiroDto.Telefone;
                enfermeiroModel.DataDeNascimento = enfermeiroDto.DataDeNascimento;
                enfermeiroModel.Genero = enfermeiroDto.Genero;
            }

               bancoDadosContext.Enfermeiro.Add(enfermeiroModel);
               bancoDadosContext.SaveChanges();
               enfermeiroDto.Id = enfermeiroModel.Id;

               return StatusCode(201, enfermeiroDto);
        }

        [HttpGet]
        public ActionResult<List<EnfermeiroDto>> Get()
        {
            var listaEnfermeiroModel = bancoDadosContext.Enfermeiro;
            List<EnfermeiroDto> listaGetDto = new List<EnfermeiroDto>();

            foreach (var item in listaEnfermeiroModel)
            {
                var enfermeiroDto = new EnfermeiroDto();
                enfermeiroDto.Id = item.Id;
                enfermeiroDto.CPF = item.CPF;
                enfermeiroDto.NomeCompleto = item.NomeCompleto;
                enfermeiroDto.Genero = item.Genero;
                enfermeiroDto.Telefone = item.Telefone;
                enfermeiroDto.DataDeNascimento = item.DataDeNascimento;
                enfermeiroDto.CadastroCOFEN = item.CadastroCOFEN;
                enfermeiroDto.InstituicaoEnsinoFormacao = item.InstituicaoEnsinoFormacao;


                listaGetDto.Add(enfermeiroDto);
            }

                return Ok(listaGetDto);

        }

        [HttpGet("{id}")]
        public ActionResult<EnfermeiroDto> Get([FromRoute] int id)
        {
            //Buscar o registro no banco de dados por >>>ID<<<
            var enfermeiroModel = bancoDadosContext.Enfermeiro.Find(id);
            // var enfermeiroMoldel = bancoDadosContext.Enfermeiro.Where(w => w.Id == id).FirstOrDefault();

             if (enfermeiroModel == null)
             {
                 return NotFound("Dados não encontrados no banco de dados");
             }

             EnfermeiroDto enfermeiroDto = new EnfermeiroDto();
             enfermeiroDto.Id = enfermeiroModel.Id;
            enfermeiroDto.CPF = enfermeiroModel.CPF;
            enfermeiroDto.NomeCompleto = enfermeiroModel.NomeCompleto;
             enfermeiroDto.Genero = enfermeiroModel.Genero;
             enfermeiroDto.Telefone = enfermeiroModel.Telefone;
             enfermeiroDto.DataDeNascimento = enfermeiroModel.DataDeNascimento;
             enfermeiroDto.CadastroCOFEN = enfermeiroModel.CadastroCOFEN;
             enfermeiroDto.InstituicaoEnsinoFormacao = enfermeiroModel.InstituicaoEnsinoFormacao;

             return Ok(enfermeiroDto);
        }

        [HttpPut("{id}")]
        public ActionResult<EnfermeiroDto> Put(int id, [FromBody] EnfermeiroDto enfermeiroDto)
        {

            
          
            // Buscar por id no banco de dados
            var enfermeiroModel = bancoDadosContext.Enfermeiro.SingleOrDefault(e => e.Id == id);

             if (enfermeiroModel == null)
             {
                return NotFound("Não foi possível encontrar registro informado.");
             }

            // Atualizar informações do enfermeiro
            enfermeiroModel.NomeCompleto = enfermeiroDto.NomeCompleto;
            enfermeiroModel.InstituicaoEnsinoFormacao = enfermeiroDto.InstituicaoEnsinoFormacao;
            enfermeiroModel.CadastroCOFEN = enfermeiroDto.CadastroCOFEN;
            enfermeiroModel.Genero = enfermeiroDto.Genero;
            enfermeiroModel.DataDeNascimento = enfermeiroDto.DataDeNascimento;
            enfermeiroModel.Telefone = enfermeiroDto.Telefone;
            enfermeiroModel.CPF = enfermeiroDto.CPF;

            bancoDadosContext.Enfermeiro.Attach(enfermeiroModel);
            bancoDadosContext.SaveChanges();

            return Ok(enfermeiroDto);
        }
        

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var enfermeiroModel = bancoDadosContext.Enfermeiro.Find(id);

            //Verificar se o registro est� diferente de null
           if (enfermeiroModel != null)
           {
                //Deletar o regitro no banco de dados

                bancoDadosContext.Enfermeiro.Remove(enfermeiroModel);
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
  






