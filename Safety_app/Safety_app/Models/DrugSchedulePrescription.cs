using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{

    public  class DrugSchedulePrescription : BaseModel
    {
     
        public string PrescriptionId { get; set; }
        public string ScheduleId { get; set; }
        public string DrugId { get; set; }
        public string Notes { get; set; }
        public int    Quantity { get; set; }
        
    }
}
