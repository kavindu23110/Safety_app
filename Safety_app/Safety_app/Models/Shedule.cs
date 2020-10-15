using SQLite;

namespace Safety_app.Models
{
    public class Shedule : BaseModel
    {
        [Unique]
        public string Name { get; set; }
        public bool IsInterval { get; set; }
        public int Hours { get; set; }
        public int Miunites { get; set; }
        public long TimeSpan { get; set; }
        public bool IsTimeBased { get; set; }
        public string timebase { get; set; }

    }
}
