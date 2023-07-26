using Microsoft.AspNetCore.Mvc.Rendering;

namespace AttendanceSystem.ViewModel
{
    public class StudentRegistrationViewModel
    {
        public StudentRegistrationViewModel()
        {
            GroupData = new List<SelectListItem>(); //To initialize list. Declaring constructor.
            LevelData = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? LevelName { get; set; }
        public int? LevelId { get; set; }
        public List<SelectListItem> GroupData { get; set; }
        public List<SelectListItem> LevelData { get; set; }
    }
}
