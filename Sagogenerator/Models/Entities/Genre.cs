using Sagogenerator;

namespace Sagogenerator.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
