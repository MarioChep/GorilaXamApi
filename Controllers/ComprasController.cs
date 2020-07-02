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
    public class ComprasController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los Compra
        public IActionResult GetAllCompras()
        {
            var compras = _unitOfWork.Compras.Get();
            if (compras != null)
            {
                return Ok(compras);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar compras por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Compra compras = _unitOfWork.Compras.GetById(id);
            if (compras != null)
            {
                return Ok(compras);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado compra asociada con este ID");
            }
        }

        //Update de Compras
        [HttpPut]
        public IActionResult UpdateCompras([FromBody] Compra compra)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Compras.Update(compra);
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
        
        //Delete Compra
        [HttpDelete]
        public IActionResult DeleteCompra([FromHeader] int id)
        {
            if(id != 0)
            {
                _unitOfWork.Compras.Delete(id);
                _unitOfWork.Save();
                return Ok("Compra Eliminada");
            }
            else
            {
                return BadRequest("Compra con id Invalida");
            }
        }

        //Crear compras
        [HttpPost]
        public IActionResult Create([FromBody] Compra compra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Compras.Insert(compra);
                    _unitOfWork.Save();
                    return Created("GorilaDemo/Create", compra);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(compra);
        }

        #endregion


    }
}
