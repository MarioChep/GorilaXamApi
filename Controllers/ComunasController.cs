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
    public class ComunasController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos las Comunas
        public IActionResult GetAllComunas()
        {
            var comunas = _unitOfWork.Comunas.Get();
            if (comunas != null)
            {
                return Ok(comunas);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar comunas por ID
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Comuna comunas = _unitOfWork.Comunas.GetById(id);
            if (comunas != null)
            {
                return Ok(comunas);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado comuna con este ID");
            }
        }

        //Update de comuna
        [HttpPut]
        public IActionResult UpdateComuna([FromBody] Comuna comuna)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Comunas.Update(comuna);
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
        
        //Delete comuna
        [HttpDelete("id")]
        public IActionResult DeleteComuna(int id)
        {
            if(id != 0)
            {
                _unitOfWork.Comunas.Delete(id);
                _unitOfWork.Save();
                return Ok("Comuna Eliminada");
            }
            else
            {
                return BadRequest("Comuna con id Invalida");
            }
        }
        
        #endregion


    }
}
