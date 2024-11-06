using System.ComponentModel.DataAnnotations;

namespace ChariTov.Models
{
    public class ContributionType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;
    }


}
