using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Safety_app.Models
{

    public class User : INotifyPropertyChanged//,INotifyDataErrorInfo
    {
        //[Range(1000, 1500, ErrorMessage = "EmployeeID should be between 1000 and 1500")]
        public string username { get; set; }
        public string password { get; set; }

        ////public bool HasErrors => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
