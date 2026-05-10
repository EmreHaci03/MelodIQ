using DapperProject.Entities;

namespace DapperProject.Services
{
    public interface IMusicService
    {
        Task<long> GetTotalListenCountAsync();
        Task<string> GetMostListenedSongAsync();
        Task<string> GetMostUsedPlatformAsync();

        Task<Dictionary<string,int>> GetListenCountByCityAsync(); //Dictionary Key Valueye Göre Çalışır Örn:"İstanbul" → 1250000
        Task<Dictionary<string, int>> GetListenCountByGenreAsync();
        Task<Dictionary<string, int>> GetListenCountByAgeGroupAsync();
        Task<Dictionary<string, int>> GetListenCountByPlatformAsync();


        //Veri Tablosu
        Task<List<MusicData>> GetAllPagedAsync(int page , int pagesize);
        Task<List<MusicData>> SearchBySongNameAsync(string songName);
        Task<MusicData> GetByIdAsync(int id);
        Task UpdateAsync(MusicData musicData);
        Task DeleteAsync(int id);
        Task<int> GetTotalCountAsync();

    }
}
