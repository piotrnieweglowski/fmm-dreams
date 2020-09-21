using fmmApp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using fmmApp.Models.Navigation;
using System.Collections.ObjectModel;
using fmmApp.Models;
using System.Runtime.CompilerServices;

namespace fmmApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for Business Registration Form page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class EditDreamViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EditDreamViewModel" /> class
        /// </summary>
        public EditDreamViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitClicked);
            this.BackCommand = new Command(this.BackButtonClicked);
            this.CancelCommand = new Command(this.CancelClicked);
            this.AddStepCommand = new Command(this.AddStepClicked);
        }
        #endregion

        #region Properties
        public bool IsUrgent { get; set; }
        public bool CanBeDone { get; set; }
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Full Name from user.
        /// </summary>
        public string DreamTitle { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Business Name from user.
        /// </summary>
        public string Description { get; set; }

        List<Category> categoryList;
        public List<Category> CategoryList
        {
            get { return categoryList; }
            set
            {
                if (categoryList != value)
                {
                    categoryList = value;
                    OnPropertyChanged();
                }
            }
        }

        Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Voulunteers { get; set; }

        public ObservableCollection<Step> StepList { get; set; }

        #endregion 

        #region Comments

        /// <summary>
        /// Gets or sets the command is executed when the Submit button is clicked.
        /// </summary>
        public Command SubmitCommand { get; set; }

        public Command BackCommand { get; set; }

        public Command CancelCommand { get; set; }

        public Command AddStepCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Submit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SubmitClicked(Object obj)
        {

        }

        private void BackButtonClicked(object obj)
        {
            //App.Current.MainPage = new DreamerListPage();
        }

        private void CancelClicked(Object obj)
        {
            //App.Current.MainPage = new DreamListPage();
        }

        private void AddStepClicked(Object obj)
        {
            App.Current.MainPage = new AddStepPage();
        }

        #endregion
    }
}