using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLibrary;

namespace ModulesApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Creating objects of classes
        ModuleData md = new ModuleData();
        ViewModules vm = new ViewModules();

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {
            // Hiding the current window once the view button has been clicked/selected
            this.Hide();

            // Calling and showing the view modules window
            vm.Show();

            // Declaring and adding headers into the listbox for the user to see
            string lineHeaders = "{0, -20}{1, -20}{2, -25}{3,-30}{4, -35}";
            string lineHeaders2 = "{0, -30}{1, -30}{2, -45}{3, -50}{4, -55}";

            vm.viewList.Items.Add(String.Format(lineHeaders, "MODULE CODE", "MODULE NAME", "NUMBER OF CREDITS", "CLASS HOURS PER WEEK", "SELF STUDY HOURS"));

            // Foreach loop that goes through each of the stored module data
            foreach (var list in ModuleData.mData)
            {
                /** if the calculated selfstudy returns a value less than 1, then the value will get multiplied by 60 in order to get it to minutes
                    else if the value is greater than 60, then the value will get displayed without being multiplied */
                if (list.SelfStudy < 1)
                {
                    double sum = list.SelfStudy * 60;
                    vm.viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode, list.ModuleName, list.NoOfCredits, list.Weeks, sum));
                }
                else
                {
                    vm.viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode, list.ModuleName, list.NoOfCredits, list.Weeks, list.SelfStudy));
                }
            }

            // Display to the user once the modules have been added
            MessageBox.Show(ModuleData.mData.Count().ToString() + " module(s) have been added!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(startDateBox.Text))
            {
                MessageBox.Show("Please select a valid start date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (DateTime.TryParse(startDateBox.Text, out DateTime startDate))
            {
                // Use the 'startDate' variable in your logic
                // For example, you can add the startDate to the ModuleData
                ModuleData.mData.Add(new ModuleData
                {
                    ModuleName = nameTbx.Text,
                    ModuleCode = codeTbx.Text,
                    NoOfCredits = int.Parse(creditsTbx.Text),
                    ClassHours = double.Parse(classHoursTbx.Text),
                    Weeks = int.Parse(noOfWeeksTbx.Text),
                    StartDate = startDate,
                    SelfStudy = md.selfStudyHour(int.Parse(creditsTbx.Text), double.Parse(classHoursTbx.Text), int.Parse(noOfWeeksTbx.Text))
                });

                // Clears the textboxes once the user clicks the add button
                nameTbx.Clear();
                codeTbx.Clear();
                creditsTbx.Clear();
                classHoursTbx.Clear();
                noOfWeeksTbx.Clear();
                startDateBox.SelectedDate = null;
            }
            else
            {
                MessageBox.Show("Invalid date format. Please use a valid date format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void creditsTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the user enters anything other than a number/digit, they get notified
            if (!string.IsNullOrWhiteSpace(creditsTbx.Text) && !System.Text.RegularExpressions.Regex.IsMatch(creditsTbx.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Input for credits was not in the correct format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                creditsTbx.Clear();
            }
        }

        private void noOfWeeksTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the user enters anything other than a number/digit, they get notified
            if (!string.IsNullOrWhiteSpace(noOfWeeksTbx.Text) && !System.Text.RegularExpressions.Regex.IsMatch(noOfWeeksTbx.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Input for number of weeks was not in the correct format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                noOfWeeksTbx.Clear();
            }
        }

        private void classHoursTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the user enters anything other than a number/digit, they get notified
            if (!string.IsNullOrWhiteSpace(classHoursTbx.Text) && !System.Text.RegularExpressions.Regex.IsMatch(classHoursTbx.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Input for class hours was not in the correct format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                classHoursTbx.Clear();
            }
        }

        private void nameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // You can add additional validation for the name textbox if needed
        }

        private void codeTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // You can add additional validation for the code textbox if needed
        }
    }
}
