namespace Sagogenerator.Models.Entities
{
    public class Story
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }

        public string Img { get; set; }

        public ICollection<Genre> Genres { get; set; } = null!;
        public User? User { get; set; }
    }
}
