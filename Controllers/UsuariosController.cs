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
    public class UsuariosController : Controller
    {
        //dependencias inicializadas
        private GorilaDemoContext _context = new GorilaDemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new GorilaDemoContext());


        #region Endpoint
        [HttpGet]
        //Buscar Todos los Usuario
        public IActionResult GetAllUser()
        {
            var usuarios = _unitOfWork.Usuarios.Get();
            if (usuarios != null)
            {
                return Ok(usuarios);
            }
            else
            {
                return Ok();
            }
        }

        //Buscar Usuarios por ID
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Usuario usuario = _unitOfWork.Usuarios.GetById(id);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                //return NoContent("No se ha encontrado un usuario con este ID");
                return BadRequest("No se ha encontrado un usuario con este ID");
            }
        }

        //Update de cliente
        [HttpPut]
        public IActionResult UpdateUser([FromBody] Usuario usuario)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    _unitOfWork.Usuarios.Update(usuario);
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
        
        //Delete Cliente
        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            if(id != 0)
            {
                _unitOfWork.Usuarios.Delete(id);
                _unitOfWork.Save();
                return Ok("Usuario Eliminado");
            }
            else
            {
                return BadRequest("Usuario con id Invalido");
            }
        }
        
        #endregion


    }
}
