﻿using FluentValidation;
using Safety_app.Validation.Abstracts;
using Safety_app.Validation.Behaviors;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Validation.BaseBehaviors
{
    public abstract class EntryBehaviorText : Behavior<Entry>
    {

        public static readonly BindableProperty Errorlabelname = BindableProperty.Create("ErrorLabel", typeof(string), typeof(EntryBehaviorText), string.Empty);
        public static readonly BindableProperty ErrorMessage = BindableProperty.Create("Message", typeof(string), typeof(EntryBehaviorText), string.Empty);
        public static readonly BindableProperty DisableButton = BindableProperty.Create("DisableButton", typeof(string), typeof(DatePickerBehavior), string.Empty);


        public string Errorlabel
        {
            get { return (string)GetValue(Errorlabelname); }
            set { SetValue(Errorlabelname, value); }
        }

        public string Message
        {
            get { return (string)GetValue(ErrorMessage); }
            set { SetValue(ErrorMessage, value); }
        }

        public string ButtonName
        {
            get { return (string)GetValue(DisableButton); }
            set { SetValue(DisableButton, value); }
        }


        public void HandleChanges(object sender, TextChangedEventArgs e)
        {
            AddValidationBehavior(sender, Validate(e));
        }

        public abstract bool Validate(TextChangedEventArgs e);

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleChanges;
            base.OnAttachedTo(bindable);
        }

        public virtual void AddValidationBehavior(object sender, bool isValid)
        {

            Label errorLabel = ((Entry)sender).FindByName<Label>(Errorlabel);
            Button Buttons = ((Entry)sender).FindByName<Button>(ButtonName);
            if (isValid)
            {
                errorLabel.IsVisible = false;
                errorLabel.Text = string.Empty;
              
                if (Buttons != null)
                    Buttons.IsEnabled = false && Buttons.IsEnabled;

            }
            else
            {
                errorLabel.IsVisible = true;
                errorLabel.Text = (string)GetValue(ErrorMessage);

                if (Buttons != null)
                    Buttons.IsEnabled = true && Buttons.IsEnabled;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleChanges;
            base.OnDetachingFrom(bindable);
        }
    }
}