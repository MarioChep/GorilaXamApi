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
    public class TiendasController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los tianda
        public IActionResult GetAllTienda()
        {
            var tiendas = _unitOfWork.Tiendas.Get();
            if (tiendas != null)
            {
                return Ok(tiendas);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar tienda por ID
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Tienda tiendas = _unitOfWork.Tiendas.GetById(id);
            if (tiendas != null)
            {
                return Ok(tiendas);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado una tienda con este ID");
            }
        }

        //Update de tienda
        [HttpPut]
        public IActionResult UpdateTiendas([FromBody] Tienda tienda)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Tiendas.Update(tienda);
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

        //Delete tiendas
        [HttpDelete("id")]
        public IActionResult DeleteTiendas(int id)
        {
            if(id != 0)
            {
                _unitOfWork.Tiendas.Delete(id);
                _unitOfWork.Save();
                return Ok("Tienda Eliminada");
            }
            else
            {
                return BadRequest("Tienda con id Invalida");
            }
        }
        
        #endregion


    }
}
