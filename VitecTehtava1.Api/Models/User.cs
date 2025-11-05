using System.ComponentModel.DataAnnotations;

namespace VitecTehtava1.Api.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
