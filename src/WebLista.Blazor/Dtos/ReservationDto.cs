using System.ComponentModel.DataAnnotations;

namespace WebLista.Blazor.Dtos;

public class ReservationDto
{
    [Required]
    public string? ReservationEmail { get; set; }
}