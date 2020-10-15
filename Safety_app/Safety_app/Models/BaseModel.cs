using SQLite;
using System;
using System.ComponentModel;

namespace Safety_app.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
            IsActive = 1;
        }
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
