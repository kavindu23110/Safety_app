using SQLite;
using System;

namespace Safety_app.Models
{
    public class Drugs : BaseModel
    {
        public String Name { get; set; }
        public String Notes { get; set; }
        [Ignore]
        public int Quantity { get; set; }

    }
}
