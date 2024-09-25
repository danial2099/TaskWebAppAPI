using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TaskCreate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Task Name is required")]
        public string TaskName { get; set; } = " ";
        public string TaskDescription { get; set; } = " ";
        [Required(ErrorMessage = "Task Name is required")]
        public string CustomerName { get; set; } = " ";
        [Required(ErrorMessage = "Man Days is required")]
        public int ManDays { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        public int AddDays { get; set; }
        [Required(ErrorMessage = "Estimated Completion Date is required")]
        public DateTime Expectdate { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string PICEmail { get; set; } = " ";
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = " ";
        public DateTime CompletionDate { get; set; }
        public string Remarks { get; set; } = " ";
        [Required(ErrorMessage = "Last Communication Date is required")]
        public DateTime LastDateComs { get; set; }
    }
}
