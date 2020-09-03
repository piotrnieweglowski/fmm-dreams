using Xamarin.Forms;
using fmmApp.Models.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using fmmApp.Views.Forms;

namespace fmmApp.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DreamerDetailViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<Dreamer> DreamerDetails { get; set; }
        #endregion

        #region Constructor
        public DreamerDetailViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.EditCommand = new Command(this.EditButtonClicked);
            this.DeleteCommand = new Command(this.DeleteButtonClicked);
            this.AddDreamCommand = new Command(this.AddDreamButtonClicked);

            this.DreamerDetails = new ObservableCollection<Dreamer>()
            {
                new Dreamer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    City = "Home",
                    Address = "114 Ridge St NW, Hudson, NC 28638",
                    PhoneNumber = "(828) 228-2882",
                    UrlAddress = "www.onet.pl",
                    Dream="I have a dream"
        }
    };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
            //App.Current.MainPage = new DreamerListPage();
        }

        /// <summary>
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            App.Current.MainPage = new EditDreamerPage();

        }

        /// <summary>
        /// Invoked when the delete button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void DeleteButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddDreamButtonClicked(object obj)
        {
            App.Current.MainPage = new AddDreamPage();
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the delete button is clicked.
        /// </summary>
        public Command DeleteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddDreamCommand { get; set; }

        #endregion
    }
}
