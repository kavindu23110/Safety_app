using Safety_app.Validation.BaseBehaviors;
using System;
using Xamarin.Forms;

namespace Safety_app.Validation.Behaviors
{
    public class DatetimeNullvalidationBehavior : DatePickerBehavior
    {
        public override bool Validate(DateChangedEventArgs e)
        {
            return new IsNotNullOrEmptyRule<DateTime>().Check(e.NewDate);
        }
    }
}
