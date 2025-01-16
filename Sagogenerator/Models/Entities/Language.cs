namespace Sagogenerator.Models.Entities
{

    public class Language
    {
        public string Name { get; set; }
        public static readonly List<Language> Languages = new List<Language>()

       {
            new Language { Name = "Swedish" },
            new Language { Name = "English" },
            new Language {Name = "Arabic"},
            new Language { Name = "Norwegian" },
            new Language { Name = "Danish" },
            new Language { Name = "Somali" },
            new Language { Name = "Spanish" },
            new Language { Name = "Icelandic" },
            new Language { Name = "Faroese" },
            new Language { Name = "Finnish" },
            new Language { Name = "Russian" },
             
            };

    }


}
