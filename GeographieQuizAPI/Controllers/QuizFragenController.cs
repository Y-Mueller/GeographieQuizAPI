using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeographieQuizAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeographieQuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizFragenController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuizFragenController(QuizDbContext context)
        {
            _context = context;
        }

        // Hinzufügen einer neuen Kategorie
        [HttpPost("kategorien")]
        public async Task<ActionResult<Kategorie>> CreateKategorie([FromBody] string kategorieName)
        {
            var kategorie = new Kategorie { KategorieName = kategorieName };
            _context.Kategorien.Add(kategorie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKategorie), new { id = kategorie.KategorieID }, kategorie);
        }

        // Abrufen einer spezifischen Kategorie
        [HttpGet("kategorien/{id}")]
        public async Task<ActionResult<Kategorie>> GetKategorie(int id)
        {
            var kategorie = await _context.Kategorien.FindAsync(id);
            if (kategorie == null)
            {
                return NotFound();
            }
            return kategorie;
        }

        // Hinzufügen einer neuen Frage (inklusive Antworten)
        [HttpPost("fragen")]
        public async Task<ActionResult<Frage>> CreateFrage([FromBody] Frage frage)
        {
            _context.Fragen.Add(frage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFrage), new { id = frage.FrageID }, frage);
        }

        // Abrufen einer spezifischen Frage (inklusive Antworten)
        [HttpGet("fragen/{id}")]
        public async Task<ActionResult<Frage>> GetFrage(int id)
        {
            var frage = await _context.Fragen.Include(f => f.Antworten).FirstOrDefaultAsync(f => f.FrageID == id);
            if (frage == null)
            {
                return NotFound();
            }
            return frage;
        }

        // Hinzufügen einer Antwort zu einer bestehenden Frage
        [HttpPost("antworten/{frageId}")]
        public async Task<ActionResult<Antwort>> CreateAntwort(int frageId, [FromBody] Antwort antwort)
        {
            var frage = await _context.Fragen.FindAsync(frageId);
            if (frage == null)
            {
                return NotFound($"Frage mit ID {frageId} nicht gefunden.");
            }
            antwort.FrageID = frageId;
            _context.Antworten.Add(antwort);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAntwort", new { id = antwort.AntwortID }, antwort);
        }

        // Abrufen einer spezifischen Antwort
        [HttpGet("antworten/{id}")]
        public async Task<ActionResult<Antwort>> GetAntwort(int id)
        {
            var antwort = await _context.Antworten.FindAsync(id);
            if (antwort == null)
            {
                return NotFound();
            }
            return antwort;
        }
    }
}
