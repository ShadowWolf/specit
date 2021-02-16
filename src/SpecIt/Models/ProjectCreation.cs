using System.ComponentModel.DataAnnotations;

namespace SpecIt.Models
{
    public class ProjectCreation
    {
        [Required]
        public string ProjectName { get; set; }
    }
}