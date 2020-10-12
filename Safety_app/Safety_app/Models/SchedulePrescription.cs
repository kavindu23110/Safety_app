using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
  public  class SchedulePrescription : BaseModel
    {
     
        public int PrescriptionId { get; set; }
        public int ScheduleId { get; set; }
    }
}
