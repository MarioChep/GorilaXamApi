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
    public class ProductosController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los productos
        public IActionResult GetAllProductos()
        {
            var productos = _unitOfWork.Productos.Get();
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar productos por ID
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Producto productos = _unitOfWork.Productos.GetById(id);
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado un producto con este ID");
            }
        }

        //Update de producto
        [HttpPut]
        public IActionResult UpdateProducto([FromBody] Producto producto)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Productos.Update(producto);
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
        
        //Delete Producto
        [HttpDelete("id")]
        public IActionResult DeleteProducto(int id)
        {
            if(id != 0)
            {
                _unitOfWork.Productos.Delete(id);
                _unitOfWork.Save();
                return Ok("Producto Eliminada");
            }
            else
            {
                return BadRequest("Producto con id Invalida");
            }
        }
        
        #endregion


    }
}
