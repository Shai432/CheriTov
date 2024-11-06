using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChariTov.Models
{
    public class Contribution
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateOnly GregorianDate { get; set; }
        public string HebrewData { get; set; }

        [Required]
        public ContributionType ContributionType { get; set; }

        public bool IsPaid { get; set; } = false;


    }
}
