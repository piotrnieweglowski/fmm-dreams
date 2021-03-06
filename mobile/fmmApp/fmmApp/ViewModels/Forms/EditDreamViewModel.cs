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
            Dream = new Dream();
            SubmitCommand = new Command(UpdateDream);
            BackCommand = new Command(GoToDreamerListPAge);
            CancelCommand = new Command(GoToDreamerListPAge);
            AddStepCommand = new Command(AddStep);
        }
        #endregion
        public Dream Dream { get; set; }
        #region Properties
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
        private void UpdateDream(Object obj)
        {

        }

        private void GoToDreamerListPAge()
        {
            //App.Current.MainPage = new DreamerListPage();
        }
        
        private void AddStep(Object obj)
        {
            App.Current.MainPage = new AddStepPage();
        }

        #endregion
    }
}