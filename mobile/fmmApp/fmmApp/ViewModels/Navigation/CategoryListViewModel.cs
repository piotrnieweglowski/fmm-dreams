using fmmApp.DataService;
using fmmApp.Models;
using fmmApp.Models.Navigation;
using fmmApp.Views.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace fmmApp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for the Songs play list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CategoryListViewModel
    {

        #region Fields
        
        private Command<object> itemSelectedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CategoryListViewModel"/> class.
        /// </summary>
        public CategoryListViewModel()
        {
            AddCategoryCommand = new Command(AddCategory);
            //BackCategoryCommand = new Command();
            DeleteCategoryCommand = new Command(async () => await DeleteCommand());

        }
        #endregion

        #region Properties

        public Command AddCategoryCommand { get; set; }
        public Command DeleteCategoryCommand { get; set; }
        public Command BackCategoryCommand { get; set; }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Songs play list page.
        /// </summary>
        [DataMember(Name = "categoryPageList")]
        public ObservableCollection<Category> CategoryList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the Songs play list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            
            var obj = selectedItem as Category;       
        }

        private void AddCategory()
        {
            App.Current.MainPage = new AddCategoryPage();
        }

        private async Task DeleteCommand()
        {
            //await CategoryListDataService.Instance.DeleteCategory();            
        }

        #endregion
    }
}
