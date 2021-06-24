using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamenFinalDS2.Models;
using Microsoft.EntityFrameworkCore;
using ExamenFinalDS2.Models.Datebase;
using ExamenFinalDS2.Context;

namespace ExamenFinalDS2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AppDbContext dbContext;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(dbContext.Usuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetByidus")]
        public ActionResult GetByidus(int id)
        {
            try
            {
                var Usuario = dbContext.Usuarios.FirstOrDefault(Usuario => Usuario.id == id);
                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            try
            {
                dbContext.Usuarios.Add(Usuario);
                dbContext.SaveChanges();
                return CreatedAtRoute("GetByidus", new { Usuario.id }, Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Updates(int id, [FromBody] Usuario Usuario)
        {

            try
            {
                if (Usuario.id == id)
                {
                    dbContext.Entry(Usuario).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return CreatedAtRoute("GetByiddv", new { id = Usuario.id }, Usuario);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Usuario = dbContext.Usuarios.FirstOrDefault(c => c.id == id);
                if (Usuario != null)
                {
                    dbContext.Usuarios.Remove(Usuario);
                    dbContext.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
