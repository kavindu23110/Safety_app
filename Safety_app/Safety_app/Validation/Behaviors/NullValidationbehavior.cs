﻿using Safety_app.Validation.BaseBehaviors;
using Xamarin.Forms;

namespace Safety_app.Validation.Behaviors
{
    public class NullValidationbehavior : EntryBehaviorText
    {
        public override bool Validate(TextChangedEventArgs e)
        {
            return new IsNotNullOrEmptyRule<string>().Check(e.NewTextValue);
        }
    }
}
