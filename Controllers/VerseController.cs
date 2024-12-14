using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranDataLayer.Entities;
using QuranDataLayer.Repositories;
using QuranWebApp.Utils;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace QuranWebApp.Controllers
{
    public class VerseController : Controller
    {
        private VerseRepository _verseRepository;
        public VerseController(VerseRepository verseRepository)
        {
            _verseRepository = verseRepository;
        }

        [HttpGet("verses/searchInQuran/{text}")]
        public async Task<IActionResult> SearchInQuran(string text)
        {
            text = text.Normalize(NormalizationForm.FormC);
            if (string.IsNullOrEmpty(text))
                return BadRequest("search term cannot be empty");
            try
            {
                var versesDto = (await _verseRepository.Filter(verse => EF.Functions.Like(verse.Text, $"%{text}%"))).Select(Mappers.ToVerseDto).ToList();
                return View(versesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("verses/sajda")]
        public async Task<IActionResult> GetVersesContainingSajda() {
            try
            {
                var versesDto = (await _verseRepository.GetContainingSajda()).
                    Select(Mappers.ToVerseDto).ToList();
                return View(versesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
