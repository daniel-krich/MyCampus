using System.ComponentModel.DataAnnotations;

namespace MyCampusUI.Models
{
    public class AssignmentCreationModel
    {
        [Required, MinLength(10), MaxLength(50)]
        public string Title { get; set; } = "";
        [Required]
        public string AssignmentText { get; set; } = "";
        [Required]
        public DateTime EndSubmissionAt { get; set; } = DateTime.Now.Date.AddDays(7).Add(new TimeSpan(23, 59, 59));
    }
}
