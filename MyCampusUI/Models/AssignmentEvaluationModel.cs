using System.ComponentModel.DataAnnotations;

namespace MyCampusUI.Models
{
    public class AssignmentEvaluationModel
    {
#nullable disable
        [Required, MaxLength(20)]
        public string Evaluation { get; set; }
#nullable enable
        [MaxLength(1024)]
        public string? Notes { get; set; }
    }
}
