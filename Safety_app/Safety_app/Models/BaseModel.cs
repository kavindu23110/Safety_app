using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Safety_app.Models
{
   public class BaseModel:INotifyPropertyChanged
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
