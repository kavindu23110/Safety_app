using Safety_app.Validation.Abstracts;
using Safety_app.Validation.BaseBehaviors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Safety_app.Validation.Behaviors
{
    public class PasswordValidationBehavior : EntryBehaviorText
    {

        public override bool Validate(TextChangedEventArgs e)
        {
            return new IsNotNullOrEmptyRule<string>().Check(e.NewTextValue);
        }
    }
}
