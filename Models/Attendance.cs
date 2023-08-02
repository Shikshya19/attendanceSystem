namespace AttendanceSystem.Models
{
    public class Attendance
    {
        public Attendance()
        {
            AttendanceDetails = new List<AttendanceDetail>();
            Level = new Level();
            Group = new Group();
            Subject = new Subject();

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int LevelId { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<AttendanceDetail> AttendanceDetails { get;}
        public Level Level { get; set; }
        public Group Group { get; set; }
        public  Subject Subject { get; set; }
    }
}
