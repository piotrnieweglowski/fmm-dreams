using fmmApp.Models;
using fmmApp.Models.Navigation;
using fmmApp.ViewModels.Forms;
using Syncfusion.XForms.ProgressBar;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AddDreamPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDreamPage" /> class.
        /// </summary>
        public AddDreamPage()
        {
            InitializeComponent();
            var stepList = new ObservableCollection<Step>();
            stepList.Add(CreateStepInfo("Ordered and Approved1", StepStatus.NotStarted, 0));
            stepList.Add(CreateStepInfo("Ordered and Approved2", StepStatus.InProgress, 50));
            stepList.Add(CreateStepInfo("Ordered and Approved3", StepStatus.Completed, 100));
            this.BindingContext = new AddDreamViewModel
            {
                CategoryList = GetCategories(),
                StepList = stepList
            };
        }
        private List<Category> GetCategories()
        {
            var category = new Category
            {
                CategoryName = "Category"
            };
            var categoryTwo = new Category
            {
                CategoryName = "SecondCategory"
            };
            var categoryList = new List<Category>();
            categoryList.Add(category);
            categoryList.Add(categoryTwo);
            return categoryList;
        }

        

        public Step CreateStepInfo(string description, StepStatus status, int progress)
        {
            Step step = new Step()
            {
                Description = description,
                Status = status,
                ProgressValue = progress
            };

            return step;
        }
    }
}