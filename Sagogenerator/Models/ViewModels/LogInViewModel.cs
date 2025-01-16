using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Sagogenerator.Models.ViewModels
{
    public class LogInViewModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}