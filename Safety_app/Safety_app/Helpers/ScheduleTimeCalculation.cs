using Safety_app.Data.DatabaseOperation.ModeldatabaseOperations;
using Safety_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Safety_app.Helpers
{
    public class ScheduleTimeCalculation
    {
        public string _ScheduleId { get; set; }

        public ScheduleTimeCalculation(String ScheduleId)
        {

            this._ScheduleId = ScheduleId;

        }
        public ScheduleTimeCalculation()
        {

        }

        public void ReAddScheduleCalculation(object scheduleId)
        {

            var schedule = LoadSchedulebyId((string)scheduleId).Result;
            if (schedule.IsTimeBased)
            {
                var estimatedTime = DateTime.Now.AddDays(1);
                var x = DateTime.Now - estimatedTime;
                var remainingTimeDuration = x.TotalMilliseconds;
                StaticFunctions.ActivateSchedule(schedule, (long)remainingTimeDuration);
            }
            else
            {
                var estimatedTime = DateTime.Now.AddHours(schedule.Hours).AddMinutes(schedule.Miunites);
                var x = DateTime.Now - estimatedTime;
                var remainingTimeDuration = x.TotalMilliseconds;
                StaticFunctions.ActivateSchedule(schedule, (long)remainingTimeDuration);

            }
         
        }

        public void AddnewSchedule()
        {
            var schedule = LoadSchedulebyId(_ScheduleId).Result;
            if (schedule.IsTimeBased)
            {
                TimeBasedScheduleCalculation(schedule);
            }
            else
            {
                DurationBasedScheduleCalculation(schedule);
            }

        }

        private System.Threading.Tasks.Task<Models.Shedule> LoadSchedulebyId(string scheduleId)
        {
            return App.Database.GetScheduleOperator().GetSelectedAsync(p => p.Id == scheduleId);
        }


        private void DurationBasedScheduleCalculation(Shedule schedule)
        {
           
            var estimatedTime = DateTime.Today.AddDays(1).AddHours(schedule.Hours).AddMinutes(schedule.Miunites);
            var x= DateTime.Now - estimatedTime;
            var remainingTimeDuration = x.TotalMilliseconds;
            StaticFunctions.ActivateSchedule(schedule, (long)remainingTimeDuration);

        }

        private void TimeBasedScheduleCalculation(Shedule schedule)
        {
            
            var estimatedTime = DateTime.Today.AddDays(1).AddTicks(schedule.TimeSpan);
            var x = DateTime.Now - estimatedTime;
            var remainingTimeDuration = x.TotalMilliseconds;
            StaticFunctions.ActivateSchedule(schedule, (long)remainingTimeDuration);
        }

    }
}
