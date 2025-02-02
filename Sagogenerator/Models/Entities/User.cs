﻿namespace Sagogenerator.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public ICollection<Story>? Stories { get; set; }
    }
}