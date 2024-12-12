using Microsoft.AspNetCore.Mvc;
using QuranDataLayer.Repositories;
using QuranWebApp.Utils;

namespace QuranWebApp.Controllers
{
    public class ChapterController : Controller
    {
        ChapterRepository _chapterRepository;
        public ChapterController(ChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<IActionResult> Index()
        {
            var chapters =await _chapterRepository.GetAll();
            return View();
        }

        [HttpGet("chapters/{id}")]

        public async Task<IActionResult> GetById(byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Index");   
            }
            var chapter=await _chapterRepository.GetById(id);
            if (chapter == null)
                return NotFound();
            return View(Mappers.ToChapterDto(chapter));
        }
    }
}
