
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            return Ok();
        }
        [HttpPost]
        //public ActionResult<> Post([FromBody] )//Nome classe DTO + classe dto
        //{
           
        //    // Lógica para cadastrar o novo paciente

        //    return Ok();
        //}

       





        [HttpPut]
        //public ActionResult Put([FromBody])//dentro do parenteses Classe MOdel + Classe model
        //{
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
           
            return Ok();
        }
       
        
        
        }
}
