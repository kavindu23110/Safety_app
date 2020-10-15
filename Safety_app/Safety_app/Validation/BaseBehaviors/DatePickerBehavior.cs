using Xamarin.Forms;

namespace Safety_app.Validation.BaseBehaviors
{
    public abstract class DatePickerBehavior : Behavior<DatePicker>
    {
        public static readonly BindableProperty Errorlabelname = BindableProperty.Create("ErrorLabel", typeof(string), typeof(DatePickerBehavior), string.Empty);
        public static readonly BindableProperty ErrorMessage = BindableProperty.Create("Message", typeof(string), typeof(DatePickerBehavior), string.Empty);
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


        public void HandleChanges(object sender, DateChangedEventArgs e)
        {
            AddValidationBehavior(sender, Validate(e));

        }

        public abstract bool Validate(DateChangedEventArgs e);


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



        protected override void OnAttachedTo(DatePicker bindable)
        {
            bindable.DateSelected += HandleChanges;
            base.OnAttachedTo(bindable);
        }


        protected override void OnDetachingFrom(DatePicker bindable)
        {
            bindable.DateSelected -= HandleChanges;
            base.OnDetachingFrom(bindable);
        }
    }
}
