using fmmApp.Models;
using fmmApp.Models.Navigation;
using fmmApp.Views.Detail;
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

        public Dream Dream
        {
            get; set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDreamViewModel" /> class
        /// </summary>
        public AddDreamViewModel()
        {
            Dream = new Dream();
            var stepList = new ObservableCollection<Step>();
            stepList.Add(CreateStepInfo("Ordered and Approved1", StepStatus.NotStarted, 0, "Task 1 desc"));
            stepList.Add(CreateStepInfo("Ordered and Approved2", StepStatus.InProgress, 50, "Task 2 desc"));
            stepList.Add(CreateStepInfo("Ordered and Approved3", StepStatus.Completed, 100, "Task 3 desc"));

            CategoryList = GetCategories();
            VolunteersList = GetVolunteers();
            StepList = stepList;

            BackCommand = new Command(GoToDreamerDetailPage);
            SubmitCommand = new Command(SubmitClicked);
            CancelCommand = new Command(GoToDreamerDetailPage);
            AddStepCommand = new Command(AddStepClicked);
        }

        private List<Category> GetCategories()
        {
            //shoul be fee                                                                                                                                                                                                                          ded from the db
            var category = new Category
            {
                Description = "Category"
            };
            var categoryTwo = new Category
            {
                Description = "SecondCategory"
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
                FirstName = "First Volo"
            };
            var volTwo = new Volunteer
            {
                FirstName = "Second Volo"
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

        }

        private void AddStepClicked(Object obj)
        {
            App.Current.MainPage = new AddStepPage();
        }

        private void GoToDreamerDetailPage()
        {
            App.Current.MainPage = new DreamerDetailPage();
        }
        #endregion
    }
}