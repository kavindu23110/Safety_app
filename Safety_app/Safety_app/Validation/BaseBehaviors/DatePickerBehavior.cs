using Xamarin.Forms;

namespace Safety_app.Validation.BaseBehaviors
{
    public abstract class DatePickerBehavior : Behavior<DatePicker>
    {
        public static readonly BindableProperty Errorlabelname = BindableProperty.Create("ErrorLabel", typeof(string), typeof(DatePickerBehavior), string.Empty);
        public static readonly BindableProperty ErrorMessage = BindableProperty.Create("Message", typeof(string), typeof(DatePickerBehavior), string.Empty);
        public static readonly BindableProperty DisableButton = BindableProperty.Create("DisableButton", typeof(string), typeof(DatePickerBehavior), string.Empty);
        public static readonly BindableProperty Toolbar = BindableProperty.Create("ToolbarItem", typeof(string), typeof(EntryBehaviorText), string.Empty);
        public static readonly BindableProperty IsOnPlaceholder = BindableProperty.Create("IsOnPlaceholder", typeof(bool), typeof(EntryBehaviorText), false);
        public string Errorlabel
        {
            get { return (string)GetValue(Errorlabelname); }
            set { SetValue(Errorlabelname, value); }
        }
        public bool Placeholder
        {
            get { return (bool)GetValue(IsOnPlaceholder); }
            set { SetValue(IsOnPlaceholder, value); }
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

        public string ToolbarItemName
        {
            get { return (string)GetValue(Toolbar); }
            set { SetValue(Toolbar, value); }
        }
        public void HandleChanges(object sender, DateChangedEventArgs e)
        {
            AddValidationBehavior(sender, Validate(e));

        }

        public abstract bool Validate(DateChangedEventArgs e);


        public virtual void AddValidationBehavior(object sender, bool isValid)
        {

            Label errorLabel = ((DatePicker)sender).FindByName<Label>(Errorlabel);
            Button Buttons = ((DatePicker)sender).FindByName<Button>(ButtonName);
            ToolbarItem toolbar = ((DatePicker)sender).FindByName<ToolbarItem>(ToolbarItemName);
            if (isValid)
            {
                if (errorLabel != null)
                {
                    errorLabel.IsVisible = false;
                    errorLabel.Text = string.Empty;
               
                }
          

                if (Buttons != null)
                    Buttons.IsEnabled = false && Buttons.IsEnabled;

                if (toolbar != null)
                    toolbar.IsEnabled =false;

            }
            else
            {
                if (errorLabel != null)
                {
                    errorLabel.IsVisible = true;
                    errorLabel.Text = (string)GetValue(ErrorMessage);
                    errorLabel.TextColor = Xamarin.Forms.Color.Red;
                }

                if (Buttons != null)
                    Buttons.IsEnabled = true && Buttons.IsEnabled;

                if (toolbar != null)
                    toolbar.IsEnabled = true;
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
