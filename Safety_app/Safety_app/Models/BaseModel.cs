using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
   public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    

    }
}
