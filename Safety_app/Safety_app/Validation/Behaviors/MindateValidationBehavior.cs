using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Safety_app.Validation.Behaviors
{
    class MindateValidationBehavior : Safety_app.Validation.BaseBehaviors.DatePickerBehavior
    {
        public override bool Validate(DateChangedEventArgs e)
        {
            return e.NewDate >= DateTime.Now;
        }
    }
}
