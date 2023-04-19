using Lanche.Models;
using Lanche.Services;
using Microsoft.AspNetCore.Mvc;

namespace LancheWebAPI.Controllers
{
    [ApiController]
    [Route("lanches")]
    public class LancheController : ControllerBase
    {
        //Obter todos os lanches
        [HttpGet]
        public ActionResult<List<Lanches>> GetAll() => LancheService.GetAll();

        //Recuperar apenas um lanche
        [HttpGet("{id}")]
        public ActionResult<Lanches> Get(int id)
        {
            var lanche = LancheService.Get(id);

            if (lanche == null)
                return NotFound();

            return lanche;
        }

        //Adicionar lanche
        [HttpPost]
        public IActionResult Create(Lanches lanche)
        {
            LancheService.Add(lanche);
            return CreatedAtAction(nameof(Create), new { id = lanche.id }, lanche);
        }

        //Remover lanche
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lanche = LancheService.Get(id);
            if (lanche == null)
                return NotFound();

            LancheService.Delete(id);
            return NoContent();
        }

        //Modificar lanche
        [HttpPut("{id}")]
        public IActionResult Update(int id, Lanches lanche)
        {
            if (id != lanche.id)
                return BadRequest();

            var existingLanche = LancheService.Get(id);
            if (existingLanche is null)
                return NotFound();

            LancheService.Update(lanche);

            return NoContent();
        }
    }
}