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
    public class AdminController : ControllerBase
    {

        public AdminUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            AdminRepository repository = new AdminRepository(db);
            AdminUseCase service = new AdminUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Administrador>> Get()
        {
            AdminUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Administrador> Get(Guid id)
        {
            AdminUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Administrador> Post([FromBody] Administrador administrador)
        {
            AdminUseCase service = CreateService();
            var result = service.Create(administrador);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Administrador administrador)
        {
            AdminUseCase service = CreateService();
            administrador.Id_Admin = id;
            service.Update(administrador);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            AdminUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}

