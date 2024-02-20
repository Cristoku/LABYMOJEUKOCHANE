namespace LibApp.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public GenreDto? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int NumberInStock { get; set; }
    }
}