namespace AttendanceSystem.Models
{
    public class AttendanceDetail
    {
        public AttendanceDetail() 
        {
            Attendance = new Attendance();
            StudentRegistration = new StudentRegistration();

        }
        public int Id { get; set; }
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int Status { get; set;}
        public Attendance Attendance { get; set; }
        public StudentRegistration StudentRegistration { get; set; }    
    }
}
