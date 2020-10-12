using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
  public  class Drugs : BaseModel
    {
        public String Name { get; set; }
        public String Notes { get; set; }

    }
}
