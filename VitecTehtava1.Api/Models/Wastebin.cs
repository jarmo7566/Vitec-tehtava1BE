using System.ComponentModel.DataAnnotations;

namespace VitecTehtava1.Api.Models;

public class Wastebin
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Address { get; set; } = string.Empty;
    public string Emptying_chedule { get; set; } = string.Empty;
    public string Last_emptied_at { get; set; } = string.Empty;
    [Required]
    public string User_id { get; set; } = string.Empty;
}
