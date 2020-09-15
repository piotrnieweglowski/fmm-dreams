using fmmApp.Models;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views.Detail
{
    /// <summary>
    /// Page to show my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DreamerDetailPage
    {
        fmmApp.ViewModels.Detail.DreamerDetailViewModel viewModel;
        /// <summary>
        /// Initializes a new instance of the <see cref="DreamerDetailPage" /> class.
        /// </summary>
        public DreamerDetailPage()
        {
            InitializeComponent();
        }

        public DreamerDetailPage(Dreamer dreamer)
        {
            InitializeComponent();
            viewModel.DreamerDetails.Add(dreamer);
            BindingContext = this.viewModel = viewModel;
        }
    }
}