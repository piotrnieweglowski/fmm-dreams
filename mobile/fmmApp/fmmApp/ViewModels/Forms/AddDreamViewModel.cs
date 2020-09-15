using fmmApp.Models;
using fmmApp.Models.Detail;
using fmmApp.Models.Navigation;
using fmmApp.Views.Forms;
using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace fmmApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for Business Registration Form page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class AddDreamViewModel : BaseViewModel, INotifyPropertyChanged
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddDreamViewModel" /> class
        /// </summary>
        public AddDreamViewModel()
        {
            var stepList = new ObservableCollection<Step>();
            stepList.Add(CreateStepInfo("Ordered and Approved1", StepStatus.NotStarted, 0, "Task 1 desc"));
            stepList.Add(CreateStepInfo("Ordered and Approved2", StepStatus.InProgress, 50, "Task 2 desc"));
            stepList.Add(CreateStepInfo("Ordered and Approved3", StepStatus.Completed, 100, "Task 3 desc"));

            CategoryList = GetCategories();
            VolunteersList = GetVolunteers();
            StepList = stepList;

            this.BackCommand = new Command(this.BackButtonClicked);
            this.SubmitCommand = new Command(this.SubmitClicked);
            this.CancelCommand = new Command(this.CancelClicked);
            this.AddStepCommand = new Command(this.AddStepClicked);
        }

        private List<Category> GetCategories()
        {
            //shoul be feeded from the db
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

        private List<Volunteer> GetVolunteers()
        {
            //shoul be feeded from the db
            var volOne = new Volunteer
            {
                FullName = "First Volo"
            };
            var volTwo = new Volunteer
            {
                FullName = "Second Volo"
            };
            var volunteerList = new List<Volunteer>();
            volunteerList.Add(volOne);
            volunteerList.Add(volTwo);
            return volunteerList;
        }

        public Step CreateStepInfo(string description, StepStatus status, int progress, string taskDescription)
        {

            Step step = new Step()
            {
                Description = description,
                Status = status,
                ProgressValue = progress,
                TaskDescription = taskDescription
            };

            return step;
        }


        #endregion

        #region Properties

        public string DreamTitle { get; set; }

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

        List<Volunteer> volunteersList;
        public List<Volunteer> VolunteersList
        {
            get { return volunteersList; }
            set
            {
                if (volunteersList != value)
                {
                    volunteersList = value;
                    OnPropertyChanged();
                }
            }
        }

        Volunteer selectedVolunteer;
        public Volunteer SelectedVolunteer
        {
            get { return selectedVolunteer; }
            set
            {
                if (selectedVolunteer != value)
                {
                    selectedVolunteer = value;
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

        public Command CancelCommand { get; set; }

        public Command AddStepCommand { get; set; }

        public Command BackCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Submit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SubmitClicked(Object obj)
        {

            var dream = new Dream()
            {
                Title = this.DreamTitle,
                Category = this.SelectedCategory.CategoryName,
                Description = this.Description,
                Volunteer = this.SelectedVolunteer
                //add this dream to a dreamer
            };
        }

        private void CancelClicked(Object obj)
        {
            //App.Current.MainPage = new DreamListPage();
        }

        private void AddStepClicked(Object obj)
        {
            App.Current.MainPage = new AddStepPage();
        }

        private void BackButtonClicked(object obj)
        {
            //App.Current.MainPage = new DreamerListPage();
        }
        #endregion
    }
}