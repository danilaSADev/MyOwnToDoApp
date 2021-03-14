using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksLibrary;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TasksLibrary.Task> Tasks { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TasksLibrary.Task>();
            TasksLibrary.Task temp = new TasksLibrary.Task("NoName", "NoDescription", DateTime.Now.AddDays(1));
            Tasks.Add(temp);
            this.BindingContext = this;
        }

        private int counter = 0;


        void CreateNewTask(object sender, System.EventArgs e)
        {
            tasksList.BeginRefresh();
            TasksLibrary.Task temp = new TasksLibrary.Task("NoName", "NoDescription", DateTime.Now.AddDays(1));
            Tasks.Add(temp);
            tasksList.EndRefresh();
        }

        void CloseButton(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            counter++;
            ((Button)sender).Text = $"{counter} click!";
        }
    }
}
