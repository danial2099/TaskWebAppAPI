namespace HomeWebApp.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; } 
        public string TaskDescription { get; set; }
        public string CustomerName { get; set; } 
        public int ManDays { get; set; }
        public DateTime StartDate { get; set; }
        public int AddDays { get; set; }
        public DateTime Expectdate { get; set; }
        public string PICEmail { get; set; } 
        public string Status { get; set; } 
        public DateTime CompletionDate { get; set; }
        public string Remarks { get; set; }
        public DateTime LastDateComs { get; set; }  
    }
}
