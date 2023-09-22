using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
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
            //if the module code is empty then the user will get notified 
            if (codeTbx.Text.ToString() == String.Empty || codeTbx.Text.ToString() == null)
            {
                MessageBox.Show("Please enter a module code!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (hoursWorkedTbx.Text.ToString() == String.Empty || hoursWorkedTbx.Text.ToString() == null)
            {
                MessageBox.Show("Please enter the hours worked!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (certainDateBox.SelectedDate.ToString() == null)
            {
                MessageBox.Show("Please select a date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //clears the module data from the list box
            viewList.Items.Clear();

            //declaring variables and storing the inputs from the textboxes into the variables
            double hours = double.Parse(hoursWorkedTbx.Text);
            string code = codeTbx.Text;

            //declaring and adding headers into the listbox for the user to see
            string lineHeaders = "{0, -20}{1, -20}{2, -25}{3,-30}{4, -35}";
            string lineHeaders2 = "{0, -30}{1, -30}{2, -45}{3, -50}{4, -55}";

            viewList.Items.Add(String.Format(lineHeaders, "MODULE CODE", "MODULE NAME", "NUMBER OF CREDITS", "CLASS HOURS PER WEEK", "SELF STUDY HOURS"));

            /*foreach loop that goes through each of the stored module data
              where the module codes are equal and is not empty (using linq through the lambda expression) */
            foreach (var module in ModuleData.mData.Where(x => x.ModuleCode == code && x.ModuleCode != ""))
            {
                //minuses hours from the hours that have already been added and saved
                module.SelfStudy -= hours;
            }

            //foreach loop that goes through each of the stored module data
            foreach (var list in ModuleData.mData)
            {
                /** if the calculated selfstudy returns a value less than 1, then the value will get multiplied by 60 in order to get it to minutes
                  else if the value is greater than 60, then the value will get displayed without being multiplied */

                if (list.SelfStudy < 1)
                {
                    double sum = list.SelfStudy * 60;

                    viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode ,list.ModuleName, list.NoOfCredits, list.Weeks, sum));
                }
                else
                {
                    
                    viewList.Items.Add(String.Format(lineHeaders2, list.ModuleCode ,list.ModuleName, list.NoOfCredits, list.Weeks, list.SelfStudy));
                }

                //clears the textboxes once the user clicks the add button
                hoursWorkedTbx.Clear();
                codeTbx.Clear();
                certainDateBox.SelectedDate = null;
            }
        }

        private void hoursWorkedTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if the user enters anything other a number/digit then they get notified
            if (System.Text.RegularExpressions.Regex.IsMatch(hoursWorkedTbx.Text, "[^0-9]"))
            {
                MessageBox.Show("Input number was not in the correct format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                hoursWorkedTbx.Text = "";
            }
        }

        private void codeTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void viewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void viewList_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
 