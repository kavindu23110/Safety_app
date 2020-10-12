using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
   public class Drug_Schedule:BaseModel
    {
        public int SchedulePrescriptionId { get; set; }
        public int DrugId { get; set; }
        public int Quanitity { get; set; }
    }
}
