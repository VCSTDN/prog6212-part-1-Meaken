using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary;

namespace ModulesApplication
{
    public partial class ViewModules : Window
    {
        public ViewModules()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clear the module data from the list box
            viewList.Items.Clear();

            // Declaring and adding headers into the listbox for the user to see
            string lineHeaders = "{0, -20}{1, -20}{2, -25}{3,-30}{4, -35}";
            string lineHeaders2 = "{0, -30}{1, -30}{2, -45}{3, -50}{4, -55}";

            viewList.Items.Add(String.Format(lineHeaders, "MODULE CODE", "MODULE NAME", "NUMBER OF CREDITS", "CLASS HOURS PER WEEK", "SELF STUDY HOURS"));

            // Loop through each of the stored module data
            foreach (var list in ModuleData.mData)
            {
                // If the calculated self-study returns a value less than 1, multiply by 60 to get minutes, else display without being multiplied
                if (list.SelfStudy < 1)
                {
                    double sum = list.SelfStudy * 60;
                    viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode, list.ModuleName, list.NoOfCredits, list.Weeks, sum));
                }
                else
                {
                    viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode, list.ModuleName, list.NoOfCredits, list.Weeks, list.SelfStudy));
                }
            }
        }

        private void viewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle list selection change event
        }
    }
}
