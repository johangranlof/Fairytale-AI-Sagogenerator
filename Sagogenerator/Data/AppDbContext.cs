using Microsoft.EntityFrameworkCore;
using Sagogenerator.Models.Entities;

namespace Sagogenerator.Data
{
    public class AppDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration.GetConnectionString("DbConnectionString"), MySqlServerVersion.AutoDetect(Configuration.GetConnectionString("DbConnectionString")));
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public void SeedDB()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Spänning"
                },
                new Genre
                {
                    Name = "Djur"
                },
                new Genre
                {
                    Name = "Vänskap"
                },

                new Genre
                {
                    Name = "Godnattsaga"
                },
                new Genre
                {
                    Name = "Familj"
                },

                new Genre
                {
                    Name = "Magi"
                },

                new Genre
                {
                    Name = "Äventyr"
                },
                new Genre
                {
                    Name = "Fantasy"
                },
                new Genre
                {
                    Name = "Mysterium"
                },
                new Genre
                {
                    Name = "Sport"
                },
                new Genre
                {
                    Name = "Miljömedvetenhet"
                },
                new Genre
                {
                    Name = "Ensamt barn"
                },
                new Genre
                {
                    Name = "Humor"
                },
   
                new Genre
                {
                    Name = "Dinosaurier"
                },
                //new Genre
                //{
                //    Name = "Fängelse"
                //},
                new Genre
                {
                    Name = "Olika kulturer"
                },

            };
            Genres.AddRange(genres);
            SaveChanges();


            var users = new List<User>
            {
                new User
                {
                    Username = "1",
                    Password = "1"
                },
                new User
                {
                    Username = "2",
                    Password = "2"
                },
                new User
                {
                    Username = "3",
                    Password = "3"
                },
                new User
                {
                    Username = "4",
                    Password = "4"
                },
                new User
                {
                    Username = "5",
                    Password = "5"
                }
            };
            Users.AddRange(users);
            SaveChanges();
            /*
            var stories = new List<Story>
            {
                new Story
                {
                    Title = "Sagan om Bröd",
                    Genres = new List<Genre> { genres[0], genres[1] },
                    Content = "En gång i en mysig liten by bodde det en ensam brödbit vid namn Smulan. " +
                    "Smulan hade en vacker gyllenbrun yta och en spröd skorpa som fått en fin rostning i ugnen. " +
                    "Men trots sin skönhet kände sig Smulan ensam och övergiven i brödburken.",
                    User = users[0]
                },
                new Story
                {
                    Title = "Sagan om Majs",
                    Genres = new List<Genre> { genres[2], genres[7] },
                    Content = "En gång i en mysig liten by bodde det en ensam majsbit vid namn Olle. " +
                    "Olle hade en vacker gyllenbrun yta och en spröd skorpa som fått en fin rostning i ugnen. " +
                    "Men trots sin skönhet kände sig Olle ensam och övergiven i brödburken.",
                    User = users[1]
                },
                new Story
                {
                    Title = "Sagan om nötter",
                    Genres = new List<Genre> { genres[1], genres[6] },
                    Content = "Nötter, en ekorre som förstår fåglarnas sång, hjälper skogens varelser och blir en legendarisk figur genom att sprida glädje och harmoni",
                    User = users[2]
                },
                new Story
                {
                    Title = "Borås plockar skräp",
                    Genres = new List<Genre> { genres[3], genres[2] },
                    Content = "En gripande saga om en stad där invånarna enas för att återställa dess skönhet genom gemensamt arbete och ansvarstagande kommer de framåt i att städa upp staden",
                    User = users[3]
                },
                new Story
                {
                    Title = "test",
                    Genres = new List<Genre> { genres[5], genres[4] },
                    Content = "test",
                    User = users[4]
                }
            };
            Stories.AddRange(stories);
            SaveChanges();

            */
        }
    }
}
