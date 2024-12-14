using Microsoft.AspNetCore.Mvc;
using QuranDataLayer.Repositories;
using QuranWebApp.Models;
using QuranWebApp.Utils;

namespace QuranWebApp.ViewComponents
{
    public class ChaptersListViewComponent : ViewComponent
    {
        ChapterRepository _chapterRepository;
        public ChaptersListViewComponent(ChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<ChapterDto> chapters;
            try
            {
                chapters = (await _chapterRepository.GetAll()).Select(chapter => Mappers.ToChapterDto(chapter))
                    .ToList();
            }
            catch (Exception ex)
            {
                return Content("An error has occured while retrieving chapters data");
            }
            return View(chapters);
        }
    }
}
