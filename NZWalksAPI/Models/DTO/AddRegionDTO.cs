using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO;

public class AddRegionDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "Code has to be minimum 2 characters"),MaxLength(6, ErrorMessage = "Code has to be max 6 characters")]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public string? ImageUrl { get; set; }
}