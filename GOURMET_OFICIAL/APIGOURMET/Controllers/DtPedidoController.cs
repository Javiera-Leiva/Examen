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
    public class DtPedidoController : ControllerBase
    {

        public PedidoDUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            DtPedidoRepository repository = new DtPedidoRepository(db);
            PedidoDUseCase service = new PedidoDUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Detalle_Pedido>> Get()
        {
            PedidoDUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Detalle_Pedido> Get(Guid id)
        {
            PedidoDUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Detalle_Pedido> Post([FromBody] Detalle_Pedido detalle_Pedido)

        {
            PedidoDUseCase service = CreateService();
            var result = service.Create(detalle_Pedido);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Detalle_Pedido detalle_Pedido)
        {
            PedidoDUseCase service = CreateService();
            detalle_Pedido.Id_Pedido = id;
            service.Update(detalle_Pedido);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PedidoDUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}