
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.NotificationView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrugView : ContentPage
    {


        public DrugView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Notification.NotificationViewModel();
        }
    }
}