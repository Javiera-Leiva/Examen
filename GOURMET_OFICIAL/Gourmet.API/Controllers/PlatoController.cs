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
    public class PlatoController : ControllerBase
    {

        public PlatoUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            PlatoRepository repository = new PlatoRepository(db);
            PlatoUseCase service = new PlatoUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Plato>> Get()
        {
            PlatoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Plato> Get(Guid id)
        {
            PlatoUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Plato> Post([FromBody] Plato plato)
        {
            PlatoUseCase service = CreateService();
            var result = service.Create(plato);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Plato plato)
        {
            PlatoUseCase service = CreateService();
            plato.Id_Plato = id;
            service.Update(plato);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PlatoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}