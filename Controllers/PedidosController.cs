using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GorilaXamDemoApi.Entities.Models;
using GorilaXamDemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GorilaXamDemoApi.Controllers
{
    [Route("api/v1/GorilaXamDemoApi/[controller]")]
    public class PedidosController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los Pedidos
        public IActionResult GetAllPedidos()
        {
            var pedidos = _unitOfWork.Pedidos.Get();
            if (pedidos != null)
            {
                return Ok(pedidos);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar pedido por ID
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Pedido pedidos = _unitOfWork.Pedidos.GetById(id);
            if (pedidos != null)
            {
                return Ok(pedidos);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado un pedido con este ID");
            }
        }

        //Update de pedido
        [HttpPut]
        public IActionResult UpdatePedidos([FromBody] Pedido pedido)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Pedidos.Update(pedido);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(DataException ex)
            {
                return BadRequest(ex);
            }
        }
        
        //Delete pedido
        [HttpDelete("id")]
        public IActionResult DeletePedidos(int id)
        {
            if(id != 0)
            {
                _unitOfWork.Pedidos.Delete(id);
                _unitOfWork.Save();
                return Ok("Pedido Eliminada");
            }
            else
            {
                return BadRequest("Pedido con id Invalida");
            }
        }
        
        #endregion


    }
}
