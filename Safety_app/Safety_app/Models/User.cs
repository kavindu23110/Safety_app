using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;



namespace Safety_app.Models
{

    public class User : INotifyPropertyChanged
    {
        public string username { get; set; }
    public string password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
