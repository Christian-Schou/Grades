using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;

namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrades()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);

        }

        [TestMethod]
        public void ComputesLowestGrades()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);

        }

        [TestMethod]
        public void ComputesAverageGrades()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }

        [TestMethod]
        //Test the gradebook letter
        public void GradeBookLetterB()
        {        
            GradeBook book = new GradeBook();
            
            // Add new grades to the gradebook
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            // Compute the statistics
            GradeStatistics stats = book.ComputeStatistics();

            // Check if the gradebook letter is B based on the average grade
            Assert.AreEqual("B", stats.LetterGrade);
        }
    }
}
