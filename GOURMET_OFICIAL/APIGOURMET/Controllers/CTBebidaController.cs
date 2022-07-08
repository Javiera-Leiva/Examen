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
    public class CTBebidaController : ControllerBase
    {

        public CategoriaBUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            CtBebidaRepository repository = new CtBebidaRepository(db);
            CategoriaBUseCase service = new CategoriaBUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria_Bebida>> Get()
        {
            CategoriaBUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria_Bebida> Get(Guid id)
        {
            CategoriaBUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Categoria_Bebida> Post([FromBody] Categoria_Bebida categoria_Bebida)
        {
            CategoriaBUseCase service = CreateService();
            var result = service.Create(categoria_Bebida);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categoria_Bebida categoria_Bebida)
        {
            CategoriaBUseCase service = CreateService();
            categoria_Bebida.Id_CategoriaBebida = id;
            service.Update(categoria_Bebida);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaBUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}