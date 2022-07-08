using Microsoft.AspNetCore.Mvc;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using Gourmet.Core.Aplication.UseCases;
using Gourmet.Core.Domain.Models;

using System.Collections.Generic;

using System;
using Gourmet.Core.Infraestructura.Repository.Concrete;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gourmet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {

        public BebidaUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            BebidaRepository repository = new BebidaRepository(db);
            BebidaUseCase service = new BebidaUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Plato>> Get()
        {
            BebidaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Plato> Get(Guid id)
        {
            BebidaUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Plato> Post([FromBody] Bebida bebida)
        {
            BebidaUseCase service = CreateService();
            var result = service.Create(bebida);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Bebida bebida)
        {
            BebidaUseCase service = CreateService();
            bebida.Id_Bebida = id;
            service.Update(bebida);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            BebidaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}