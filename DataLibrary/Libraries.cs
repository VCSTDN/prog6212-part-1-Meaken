using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataLibrary
{
        public class ModuleData
        {

            //public generic list named nData, that stores all of the users information
            public static List<ModuleData> mData = new List<ModuleData>();

            //private declared variables
            private string moduleName;
            private string moduleCode;
            private int noOfCredits;
            private double classHours;
            private double selfStudy;
            private int weeks;
            private DateTime startDate;

            //getters and setters for the private variables that were declared
            public string ModuleName
            {
                get { return moduleName; }
                set { moduleName = value; }
            }

            public string ModuleCode
            {
                get { return moduleCode; }
                set { moduleCode = value; }
            }

            public int NoOfCredits
            {
                get { return noOfCredits; }
                set { noOfCredits = value; }
            }

            public double ClassHours
            {
                get { return classHours; }
                set { classHours = value; }
            }

             public double SelfStudy
             {
                get { return selfStudy; }
                set { selfStudy = value; }
             }
      
             public int Weeks
             { 
                get { return weeks; }
                set { weeks = value; }
             }

             public DateTime StartDate
             {
               get { return startDate; }
               set { startDate = value; }
             }



        //empty moduledata constructor
        public ModuleData()
            {

            }

            //contructor for moduledata that includes parameters
            public ModuleData(string name, string code, int credit, int hour, int week, DateTime date)
            {

                moduleName = name;
                moduleCode = code;
                noOfCredits = credit;
                classHours = hour;
                weeks = week;
                startDate = date;

            }

            //method that calculates the study hours of the user or student
            public double selfStudyHour(int credit, double hours, int weeks)
            {

                double selfStudy = (credit * 10 / weeks) - hours;
                return selfStudy;
            }

        }

    }

