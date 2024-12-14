using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranDataLayer.Repositories;
using QuranWebApp.Models;
using QuranWebApp.Utils;
using System.Text.RegularExpressions;

namespace QuranWebApp.Controllers
{
    public class ChapterController : Controller
    {
        ChapterRepository _chapterRepository;
        public ChapterController(ChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        [HttpGet("/")]
        [HttpGet("chapters")]
        public async Task<IActionResult> Index()
        {
            List<ChapterDto> chapters;
            try
            {
                chapters = (await _chapterRepository.GetAll()).Select(chapter=>Mappers.ToChapterDto(chapter)).ToList();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return View(chapters);
        }

        [HttpGet("chapters/{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(byte id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Index");   
            }
            ChapterDto chapter;
            try
            {
                chapter = Mappers.ToChapterDto((await _chapterRepository.GetById(id)));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            if (chapter == null)
                return NotFound();
            return View(chapter);
        }

        [HttpGet("chapters/suggestions/{searchTerm}")]
        public async Task<IActionResult> GetSuggestions (string searchTerm) {
            List<ChapterDto> chapters;
            try
            {
                chapters = (await _chapterRepository.Filer(ch=>ch.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) || ch.Id.ToString().Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))).Select(chapter => Mappers.ToChapterDto(chapter)).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Json(chapters);
        }
    }
}
//ch.id


//    searchterm may contain names or digits 
//    for searchterm may not contain complete name 
//    searchterm may not contain complete digit 
//    we want to use throttle 

//    how would you approach that?

//    first we need to do some cleaning 
//    when searching for names, remove the digits from the searchterm 
//    when searching for digits, remove the characters or non digit from the searchterm
//    then see if the id contains and the same for name 


//    ## throttle 

//##  full search crucial -- reall a very great feature to implement 