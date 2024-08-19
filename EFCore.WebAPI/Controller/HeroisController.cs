using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCore.Dominio.Models;
using EFCore.Repositorio.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFCore.WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroisController(HeroiContext context)
        {
            _context = context;
        }

        // GET: Herois
        [HttpGet("Index/{nomeHero}")]
        public async Task<IActionResult> Index(string nomeHero)
        {
            var listHerois = _context.Herois
                .Where(h => h.Nome.Contains(nomeHero))
                .ToList();

            return Ok(listHerois);
        }

        // GET: Herois/Details/5
        [HttpGet("details/{nomeHero}")]
        public ActionResult Details(string nomeHero)
        {
            var heroi = new Heroi { Nome = nomeHero };

            _context.Herois.Add(heroi);
            _context.SaveChanges();
            return Ok(heroi);
        }

        // GET: Herois/Create
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: Herois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Heroi heroi)
        {
            throw new NotImplementedException();
        }

        // GET: Herois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Herois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Heroi heroi)
        {
            throw new NotImplementedException();
        }

        // GET: Herois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Herois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        private bool HeroiExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
