using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuranDataLayer.Entities;
using QuranDataLayer.Repositories;
using QuranWebApp.Models;
using QuranWebApp.Utils;
using QuranWebApp.ViewComponents;

namespace QuranWebApp.Controllers
{
    public class JuzController : Controller
    {
        JuzRepository _juzRepository;
        public JuzController(JuzRepository juzRepository)
        {
            _juzRepository = juzRepository;
        }

        [HttpGet("juzes")]
        public async Task<IActionResult> GetJuzes()
        {
            List<JuzDto> juzes;
            try
            {
                juzes = (await _juzRepository.GetAll()).Select(Mappers.ToJuzDto).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return View(juzes);
        }

        [HttpGet("juzes/{id}")]
        public async Task<IActionResult> GetJuzVersesById(byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var versesData = await _juzRepository.GetJuzVerses(id);
            var juzData = await _juzRepository.GetById(id);

            List<VerseDto> verses = versesData.Select(Mappers.ToVerseDto).ToList();
            JuzDto juz = Mappers.ToJuzDto(juzData);

            return View(new JuzVersesViewModel() { Juz = juz, Verses = verses });
        }

    }
}