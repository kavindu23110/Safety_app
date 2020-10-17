using Safety_app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.DependancyService
{
  public  interface ITaskSchedular
    {
        void TimerAddSchedule(Shedule shedule);
        void TimerDeactivateSchedule(Shedule shedule);
    }
}
