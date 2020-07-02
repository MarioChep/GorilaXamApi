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
    public class CiudadesController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los Ciudad
        public IActionResult GetAllCiudades()
        {
            var ciudades = _unitOfWork.Ciudades.Get();
            if (ciudades != null)
            {
                return Ok(ciudades);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar ciudades por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ciudad ciudades = _unitOfWork.Ciudades.GetById(id);
            if (ciudades != null)
            {
                return Ok(ciudades);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado una ciudad con este ID");
            }
        }

        //Update de ciudad
        [HttpPut]
        public IActionResult UpdateCiudad([FromBody] Ciudad ciudad)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Ciudades.Update(ciudad);
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
        
        //Delete Ciudad
        [HttpDelete]
        public IActionResult DeleteCiudad([FromHeader] int id)
        {
            if(id != 0)
            {
                _unitOfWork.Ciudades.Delete(id);
                _unitOfWork.Save();
                return Ok("Ciudad Eliminada");
            }
            else
            {
                return BadRequest("Ciudad con id Invalida");
            }
        }

        //Crear Usuario
        [HttpPost]
        public IActionResult Create([FromBody] Ciudad ciudad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Ciudades.Insert(ciudad);
                    _unitOfWork.Save();
                    return Created("GorilaDemo/Create", ciudad);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(ciudad);
        }

        #endregion


    }
}
