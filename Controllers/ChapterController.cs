using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranDataLayer.Entities;
using QuranDataLayer.Repositories;
using QuranWebApp.Models;
using QuranWebApp.Utils;
using QuranWebApp.ViewModels;
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
                chapters = (await _chapterRepository.GetAll()).Select(chapter => Mappers.ToChapterDto(chapter)).ToList();
            }
            catch (Exception ex)
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
            AudioFileDto audioFile;
            try
            {
                chapter = Mappers.ToChapterDto((await _chapterRepository.GetById(id)));
                var audioFileData = await _chapterRepository.GetChapterAudioFileById(id);
                audioFile = audioFileData== null?null: Mappers.ToAudioFileDto(audioFileData);;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            if (chapter == null)
                return NotFound(); 
            return View(new ChapterViewModel() { Chapter=chapter, AudoFile=audioFile});
        }

        [HttpGet("chapters/suggestions/{searchTerm}")]
        public async Task<IActionResult> GetSuggestions(string searchTerm) {
            List<ChapterDto> chapters;
            try
            {
                chapters = (await _chapterRepository.Filer(ch => ch.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) || ch.Id.ToString().Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))).Select(chapter => Mappers.ToChapterDto(chapter)).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Json(chapters);
        }

        [HttpGet("chapters/info")]
        public async Task<IActionResult> GetChapterInfo()
        {
            return View();
        }


        [HttpGet("chapters/info/search/{id}")]
        public async Task<IActionResult> GetChapterInfoJson(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Index");
            }
            ChapterInfoDto chapterInfo;
            try
            {
                chapterInfo = Mappers.ToChapterInfoDto((await _chapterRepository.GetChapterInfoById(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            if (chapterInfo == null)
                return NotFound();
            return Json(chapterInfo);
        }
    }
}



// Download the URL and create a table that contains 
// the url on the chapter the url is its name basically because it will 
// be placed in the wwwroot - the list also will contain 
// which chapter is ulr for - say so we maintain the chapter id 
// the reciter id and receitier number 
// and then we maintian information on the receitier himself 
// such as his name, etc 
// of course an identitty id but i will stay away from identity ids and 
// create instead an id that's created with the same chapter not 
// because i may want to add receititer but i may use differnt generated id 
//  
// i will also include some unnessary data but just to make the task more interesting 
//id: 11818
//chapter_id: 5
//file_size: 78850176
//format: "mp3"
//audio_url: "https://download.quranicaudio.com/qdc/hani_ar_rifai/murattal/5.mp3"

// i may go for the easy path now and may make it complocated 
// but most likely i will try to balance 

// 5 audios now and display them on the page 







// filter by date 
// for each date get total mobile only 
// then group by user 
// wrong approach 

// filter by mobile only users - desktop users - mobile and desktop users 
// group by user and get ditinsct platform 
// case if it 2 then these are moible and desktop 
// if it one then these are mobile 
// if it one then these are desktop 
// use window function so you could easily see the current user platform 
// and conclude from it it it mobile only or desktop only 
// then what? 
// now we label each user with a category, a type 
// wrong approach - wrong understanding for the problem 
// forget to mention you will do that category based on diving by date 
// creating groups by date 
// then use group by date and category and count both done over 
// easy ان شاء الله 

// think about implementation 
// we create the category for each row by using window functions 
// counting of platform and dividing by date and then we learnt 
// which category where this user involved in on this date 
// then we group by date and  category and do the counting for 
// the total_amount, total_users 

// a problem we did not account for 
// you cannot use distinct with window functions 
// seems like distinct gets executed first before windows functions 
// so it's not logical to use it 
// so instead we can get the category filter using distinct with the 
// platform, spend_date, user_id 
// but we sacrafised the amount and it will be lost 
// so to resolve this issue we use a cte for calculating 
// only the category and then do joing get the category with the other data
// then simply do the rest of the work which is grouping by spend_date 
// and counting the total_amount and the total_customers 

// say we 

// I think, I needed to think more about this problem than I did 
// don't ever hesitate to back up and rethink about the problem 
// and never let yourself to the case where to try different 
// codes, halk-backed ideas without enough thinking and at the 
// end most of these ideas turns out to be useless 

