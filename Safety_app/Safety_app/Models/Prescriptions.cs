﻿using System;

namespace Safety_app.Models
{
    public class Prescription : BaseModel
    {
        public Prescription()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        public string Name { get; set; }
        public string Doctorname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
