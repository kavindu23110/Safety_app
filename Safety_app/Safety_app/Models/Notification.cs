using Safety_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Models
{
 public   class Notification:BaseViewModel
    {
        public DrugSchedulePrescription  DrugSchedulePrescription { get; set; }
        public Prescription Prescription { get; set; }
        public Drugs  Drugs { get; set; }
    }
}
