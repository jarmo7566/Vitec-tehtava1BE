using System.ComponentModel.DataAnnotations;

namespace VitecTehtava1.Api.Models;

public class Feedback
{
    public int Id { get; set; }
    [Required]
    public string User_id { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Created_at { get; set; } = string.Empty;
}
