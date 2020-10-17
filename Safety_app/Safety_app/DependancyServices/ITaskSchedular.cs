using Safety_app.Models;

namespace Safety_app.DependancyService
{
    public interface ITaskSchedular
    {
        void TimerAddSchedule(Shedule shedule);
        void TimerDeactivateSchedule(Shedule shedule);
    }
}
