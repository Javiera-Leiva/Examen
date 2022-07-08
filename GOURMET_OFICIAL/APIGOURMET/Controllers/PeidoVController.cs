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
    public class PedidoVController : ControllerBase
    {

        public PedidoVUseCase CreateService()
        {
            PlantillaDB db = new PlantillaDB();
            PedidoVRepository repository = new PedidoVRepository(db);
            PedidoVUseCase service = new PedidoVUseCase(repository);
            return service;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Pedido_Venta>> Get()
        {
            PedidoVUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Pedido_Venta> Get(Guid id)
        {
            PedidoVUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Pedido_Venta> Post([FromBody] Pedido_Venta pedido_Venta)

        {
            PedidoVUseCase service = CreateService();
            var result = service.Create(pedido_Venta);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido_Venta pedido_Venta)
        {
            PedidoVUseCase service = CreateService();
            pedido_Venta.Id_Pedido = id;
            service.Update(pedido_Venta);
            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PedidoVUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado Exitosamente");
        }
    }
}