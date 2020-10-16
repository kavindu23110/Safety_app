using Safety_app.Customization;
using Xamarin.Forms;

namespace Safety_app.Validation.BaseBehaviors
{
    public abstract class EntryBehaviorText : Behavior<CEntry>
    {
        CEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;
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

        protected override void OnAttachedTo(CEntry bindable)
        {
            bindable.TextChanged += HandleChanges;

            control = (CEntry)bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
            base.OnAttachedTo(bindable);
        }

        public virtual void AddValidationBehavior(object sender, bool isValid)
        {

         if  (!isValid)
            {
               control.Placeholder = Message;
                control.PlaceholderColor = control.BorderErrorColor;
                control.Text = string.Empty;
                ((CEntry)sender).IsBorderErrorVisible = true;


            }
            else
            {
                ((CEntry)sender).IsBorderErrorVisible = false;
                control.Placeholder = _placeHolder;
                control.PlaceholderColor = _placeHolderColor;

            }
        }

        protected override void OnDetachingFrom(CEntry bindable)
        {

            bindable.TextChanged -= HandleChanges;
            base.OnDetachingFrom(bindable);
        }



    }
}
