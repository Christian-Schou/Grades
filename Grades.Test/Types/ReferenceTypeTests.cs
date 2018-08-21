using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "christian";
            name = name.ToUpper();

            Assert.AreEqual("CHRISTIAN", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2017, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        // We take 46 that is inside of x. Copy it into number, when we invoke the method IncrementNumber
        // Since it is a copy of that value, we can make any changes that we want, with this number variable.
        // The changes we make will only be visible inside of IncrementNumber. Therefore the test will pass.
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number =+ 1;
        }

        [TestMethod]
        // when we invoke BiveBookAName the value of book2 into the paramteter book
        // and that value is a pointer
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Christian";
            string name2 = "christian";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        //Only true if the variables type is a reference type
        public void GradeBookVariablesHoldAReference()
        {
            // Instantiate two Gradebooks and have two variables
            // that i think are pointing to the same gradebook
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            // Set the name through one variable
            g1.Name = "Christian's grade book";

            // then assert that the following things are equal
            // hopefully the name is the same in our memory
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
