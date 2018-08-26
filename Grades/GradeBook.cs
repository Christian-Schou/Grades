using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades;

        public GradeBook()
        {
            _name = "Grade book without name";
            grades = new List<float>();
        }

        public bool ThrowAwayLowest { get; set; }

        public override void AddGrade(float grade)
        {
            //Add the grade to our "grades" list
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook::ComputeStatistics");
            //Instantiate our GradeStatistics class
            GradeStatistics stats = new GradeStatistics();

            //We have to give the sum a start value
            float sum = 0;

            //Our foreach loop checking every grade in the list for max, min value
            //and calculating the average of all the grades in the list
            foreach (float grade in grades)
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

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

    }
}
