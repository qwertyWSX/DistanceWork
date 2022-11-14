using System.ComponentModel.DataAnnotations;

namespace DistanceWork.Models
{
    public class Job
    {
        public int Id { get; set; }
  
        public int Master { get; set; }

        public int Worker { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
       
        public string Answer { get; set; }
        public string TaskFile { get; set; }
        public string CompleteFile { get; set; }
        public string Status { get; set; } 
        public string DateBegin { get; set; }
        public string Deadline { get; set; }
        public string DateComplite { get; set; }
    }
}
