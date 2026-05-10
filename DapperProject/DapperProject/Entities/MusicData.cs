namespace DapperProject.Entities
{
    public class MusicData
    {
            public int Id { get; set; }
            public string SongName { get; set; }
            public string ArtistName { get; set; }
            public string Genre { get; set; }
            public string City { get; set; }
            public string Platform { get; set; }
            public int ListenCount { get; set; }
            public string AgeGroup { get; set; }
            public DateTime ListenDate { get; set; }
        
    }
}
