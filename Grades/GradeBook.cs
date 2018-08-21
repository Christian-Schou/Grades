using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        List<float> grades;
        private string _name;
        public NameChangedDelegate NameChanged;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if(_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;

                        NameChanged(this, args);
                    }

                    _name = value;
                }
            }
        }
        public GradeBook()
        {
            _name = "Grade book without name";
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            //Add the grade to our "grades" list
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            //Instantiate our GradeStatistics class
            GradeStatistics stats = new GradeStatistics();
            
            //We have to give the sum a start value
            float sum = 0;

            //Our foreach loop checking every grade in the list for max, min value
            //and calculating the average of all the grades in the list
            foreach(float grade in grades)
            {
                //Check max and min grade
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

                //Add grade to the sum value
                sum += grade;
            }

            //Calculate Average grade and place it in AverageGrade in GradeStatistics
            stats.AverageGrade = sum / grades.Count;

            //Return the data from GradeStatistics
            return stats;
        }
    }
}
