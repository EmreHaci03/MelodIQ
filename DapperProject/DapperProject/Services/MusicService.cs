using Dapper;
using DapperProject.Context;
using DapperProject.Entities;

namespace DapperProject.Services
{
    public class MusicService : IMusicService
    {
        private readonly DapperContext _context;

        public MusicService(DapperContext context)
        {
            _context = context;
        }

        //Query First Veri Okuma İçin Executede Yazma Silme Ekleme Güncelleme İçin Kullanılır.

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From MusicData Where Id=@id";
            var parametres = new DynamicParameters();
            parametres.Add("@id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query,parametres);
        }

        public async Task<Dictionary<string, int>> GetListenCountByPlatformAsync()
        {
            string query = "SELECT Platform, SUM(ListenCount) as TotalCount FROM MusicData GROUP BY Platform";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<(string Platform, int TotalCount)>(query);
            return result.ToDictionary(x => x.Platform, x => x.TotalCount);
        }

        public async Task<List<MusicData>> GetAllPagedAsync(int page, int pagesize)
        {
            string query = "SELECT * FROM MusicData ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            var parameters = new DynamicParameters();
            parameters.Add("@Offset", (page - 1) * pagesize);
            parameters.Add("@PageSize", pagesize);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<MusicData>(query, parameters);
            return result.ToList();
        }
        public async Task<List<MusicData>> SearchBySongNameAsync(string songName)
        {
            string query = "SELECT TOP 100 * FROM MusicData WHERE SongName LIKE @songName ORDER BY Id";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<MusicData>(query, new { songName = "%" + songName + "%" });
            return result.ToList();
        }

        public async Task<MusicData> GetByIdAsync(int id)
        {
            string query = "Select * From MusicData Where Id=@id";
            var parametres = new DynamicParameters();
            parametres.Add("@id", id);
            using var connection= _context.CreateConnection();
            return await connection.QueryFirstAsync<MusicData>(query,parametres);
        }

        public async Task<Dictionary<string, int>> GetListenCountByAgeGroupAsync()
        {
            string query = "Select AgeGroup,Sum(ListenCount) as TotalCount From MusicData Group By AgeGroup";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<(string AgeGroup, int totalCount)>(query);
            return result.ToDictionary(x => x.AgeGroup, x => x.totalCount); // Key,Value
        }

        public async Task<Dictionary<string, int>> GetListenCountByCityAsync()
        {
            string query = "Select City,Sum(ListenCount) as TotalCount From MusicData Group By City";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<(string city, int TotalCount)>(query);
            return result.ToDictionary(x => x.city, x => x.TotalCount);
        }

        public async Task<Dictionary<string, int>> GetListenCountByGenreAsync()
        {
            string query = "Select Genre, Sum(ListenCount) as TotalCount From MusicData Group By Genre";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<(string Genre, int TotalCount)>(query);
            return result.ToDictionary(x=>x.Genre, x=>x.TotalCount);
        }

        public async Task<string> GetMostListenedSongAsync()
        {
            string query = "Select Top 1 SongName,Sum(ListenCount) as TotalCount From MusicData Group By SongName Order By Count(*) Desc";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstAsync<string>(query);
        }

        public async Task<string> GetMostUsedPlatformAsync()
        {
            string query = "Select Top 1 Platform From MusicData Group By Platform Order By Count(*) Desc ";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstAsync<string>(query);
        }

        public async Task<int> GetTotalCountAsync()
        {
            string query = "Select Count(*)  From MusicData";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstAsync<int>(query);
        }

        public async Task<long> GetTotalListenCountAsync()
        {
            string query = "SELECT SUM(CAST(ListenCount AS BIGINT)) FROM MusicData";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstAsync<long>(query);
            return result;
        }

        public async Task UpdateAsync(MusicData musicData)
        {
            string query = "Update MusicData Set SongName=@SongName, ArtistName=@ArtistName,Genre=@Genre,City=@City,Platform=@Platform,ListenCount=@ListenCount,AgeGroup=@AgeGroup,ListenDate=@ListenDate Where Id=@Id ";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query,musicData);
        }
    }
}
