using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private int counter = 0;
        void CloseButton(object sender, System.EventArgs e)
        {
            counter++;
            ((Button)sender).Text = $"{counter} click!";
        }
    }
}
