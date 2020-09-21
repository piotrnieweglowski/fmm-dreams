using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// Page to add business details such as name, email address, and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDreamPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditDreamPage" /> class.
        /// </summary>
        public EditDreamPage()
        {
            InitializeComponent();
        }
    }
}