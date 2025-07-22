using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPTicketProject.Events;

public class CreateUpdateEventDto
{
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    public string name { get; set; }

    [Required]
    public bool ageRestriction { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double price { get; set; }

    [Required]
    public DateTime date { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Location cannot exceed 500 characters.")]
    public string location { get; set; }

    [Required]
    [Url(ErrorMessage = "Invalid URL format.")]
    public string imageURL { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quota must be at least 1.")]
    public int quota { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User quota must be at least 1.")]
    public int userQuota { get; set; }

    [Required]
    public bool active { get; set; }
}
