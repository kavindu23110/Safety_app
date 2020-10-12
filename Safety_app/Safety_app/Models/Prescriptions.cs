using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
   public class Prescriptions : BaseModel
    { 
   
        public string Doctorname{ get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
        public bool IsActive{ get; set; }
   
    }
}
