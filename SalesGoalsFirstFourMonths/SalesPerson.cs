/* SalesPerson.cs                                       Jason Thatcher
 *                                                  December 2017
 * 
 * Simple Sales Person class to model sales person
 * 
 * Class, Methods, Fields, Properties, Overload Constructor
*/

using System;

namespace SalesGoalsAndExpectedResults
{
    class SalesPerson
    {
        string firstName;
        string lastName;
        double salesGoal;
        DateTime startDate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public double SalesGoal { get => salesGoal; set => salesGoal = value; }

        public SalesPerson()
        {

        }

        public SalesPerson(string fName, string lName, double sGoal)
        {
            FirstName = fName;
            LastName = lName;
            SalesGoal = sGoal;
        }

        public SalesPerson(string fName, string lName, double sGoal, DateTime sDate)
        {
            FirstName = fName;
            LastName = lName;
            SalesGoal = sGoal;
            StartDate = sDate;
        }

        public DateTime GetFourMonthDate()
        {
            return StartDate.AddMonths(4);
        }


        public DateTime GetFutureDateInMonths(int a)
        {
            return StartDate.AddMonths(a);
        }
    }
}
