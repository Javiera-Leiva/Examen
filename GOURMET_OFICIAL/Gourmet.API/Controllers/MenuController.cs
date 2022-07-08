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
    public class MenuController : ControllerBase
    {

        public MenuUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            MenuRepository repository = new MenuRepository(db);
            MenuUseCase service = new MenuUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Menu>> Get()
        {
            MenuUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Menu> Get(Guid id)
        {
            MenuUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Menu> Post([FromBody] Menu menu)
        {
            MenuUseCase service = CreateService();
            var result = service.Create(menu);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Menu menu)
        {
            MenuUseCase service = CreateService();
            menu.Id_Menu = id;
            service.Update(menu);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            MenuUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}