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
    public class CTPlatoController : ControllerBase
    {

        public CategoriaPUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            CtPlatoRepository repository = new CtPlatoRepository(db);
            CategoriaPUseCase service = new CategoriaPUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria_Plato>> Get()
        {
            CategoriaPUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria_Plato> Get(Guid id)
        {
            CategoriaPUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Categoria_Plato> Post([FromBody] Categoria_Plato categoria_Plato)
        {
            CategoriaPUseCase service = CreateService();
            var result = service.Create(categoria_Plato);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categoria_Plato categoria_Plato)
        {
            CategoriaPUseCase service = CreateService();
            categoria_Plato.Id_CategoriaPlato = id;
            service.Update(categoria_Plato);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaPUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}