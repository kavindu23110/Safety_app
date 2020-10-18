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
        public static readonly BindableProperty DisableButton = BindableProperty.Create("DisableButton", typeof(string), typeof(EntryBehaviorText), string.Empty);
        public static readonly BindableProperty Toolbar = BindableProperty.Create("ToolbarItem", typeof(string), typeof(EntryBehaviorText), string.Empty);
        public static readonly BindableProperty IsOnPlaceholder = BindableProperty.Create("IsOnPlaceholder", typeof(bool), typeof(EntryBehaviorText), false);


        public bool Placeholder
        {
            get { return (bool)GetValue(IsOnPlaceholder); }
            set { SetValue(IsOnPlaceholder, value); }
        }

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
        public string ToolbarItemName
        {
            get { return (string)GetValue(Toolbar); }
            set { SetValue(Toolbar, value); }
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
            Label errorLabel = ((CEntry)sender).FindByName<Label>(Errorlabel);
            Button Buttons = ((CEntry)sender).FindByName<Button>(ButtonName);
            ToolbarItem toolbar = ((CEntry)sender).FindByName<ToolbarItem>(ToolbarItemName);
            if (!isValid)
            {
                
                ((CEntry)sender).IsBorderErrorVisible = true;
                if (Placeholder)
                {
                    control.Placeholder = Message;
                    control.PlaceholderColor = control.BorderErrorColor;
                    control.Text = string.Empty;
                }
                else
                {
                    if (errorLabel != null)
                    {
                        errorLabel.IsVisible = true;
                        errorLabel.Text = Message;
                        errorLabel.TextColor = Xamarin.Forms.Color.Red;


                    }
                }

                if (Buttons != null)
                    Buttons.IsEnabled = false && Buttons.IsEnabled;

              
                
                if (toolbar != null)
                    toolbar.IsEnabled = false ;
            }
            else
            {
                ((CEntry)sender).IsBorderErrorVisible = false;
                
                if (Placeholder)
                {
                    control.Placeholder = _placeHolder;
                    control.PlaceholderColor = _placeHolderColor;
                }
                else
                {
                    if (errorLabel != null)
                    {
                        errorLabel.IsVisible = false;

                    }
                }
                if (toolbar != null)
                     toolbar.IsEnabled = true;
              
            }
        }

        protected override void OnDetachingFrom(CEntry bindable)
        {

            bindable.TextChanged -= HandleChanges;
            base.OnDetachingFrom(bindable);
        }



    }
}
