using Microsoft.AspNetCore.Mvc;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using Gourmet.Core.Aplication.UseCases;
using Gourmet.Core.Infraestructura.Repository.Concrete;
using Gourmet.Core.Domain.Models;

using System.Collections.Generic;

using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gourmet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public UsuarioUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioUseCase service = new UsuarioUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            UsuarioUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            UsuarioUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            var result = service.Create(usuario);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            usuario.Id_Usuario = id;
            service.Update(usuario);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UsuarioUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}
