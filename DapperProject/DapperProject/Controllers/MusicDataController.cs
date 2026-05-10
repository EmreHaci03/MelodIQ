using DapperProject.Entities;
using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class MusicDataController : Controller
    {
        private readonly IMusicService _musicService;

        public MusicDataController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        public async Task<IActionResult> Dashboard()
        {
            ViewBag.TotalListenCount = await _musicService.GetTotalListenCountAsync();
            ViewBag.MostListenedSong = await _musicService.GetMostListenedSongAsync();
            ViewBag.MostUsedPlatform = await _musicService.GetMostUsedPlatformAsync();
            ViewBag.TotalCount = await _musicService.GetTotalCountAsync();
            ViewBag.CityData = await _musicService.GetListenCountByCityAsync();
            ViewBag.GenreData = await _musicService.GetListenCountByGenreAsync();
            ViewBag.AgeGroupData = await _musicService.GetListenCountByAgeGroupAsync();
            ViewBag.PlatformData = await _musicService.GetListenCountByPlatformAsync();
            return View();
        }

        public async Task<IActionResult> MusicList(int page = 1, int? id = null, string? songName = null)
        {
            int pageSize = 50;
            List<MusicData> values;

            if (id.HasValue)
            {
                var item = await _musicService.GetByIdAsync(id.Value);
                values = item != null ? new List<MusicData> { item } : new List<MusicData>();
                ViewBag.TotalCount = values.Count;
                ViewBag.CurrentPage = 1;
                ViewBag.PageSize = pageSize;
            }
            else if (!string.IsNullOrEmpty(songName))
            {
                values = await _musicService.SearchBySongNameAsync(songName);
                ViewBag.TotalCount = values.Count;
                ViewBag.CurrentPage = 1;
                ViewBag.PageSize = pageSize;
            }
            else
            {
                values = await _musicService.GetAllPagedAsync(page, pageSize);
                ViewBag.TotalCount = await _musicService.GetTotalCountAsync();
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;
            }

            return View(values);
        }
        public async Task<IActionResult> DeleteMusic(int id)
        {
            await _musicService.DeleteAsync(id);
            return RedirectToAction("MusicList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMusic(int id)
        {
            var value = await _musicService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMusic(MusicData musicData)
        {
            await _musicService.UpdateAsync(musicData);
            return RedirectToAction("MusicList");
        }
    }
}
