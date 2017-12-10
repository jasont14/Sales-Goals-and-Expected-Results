/* SalesGoals.cs                                       Jason Thatcher
 *                                                     December 2017
 * 
 * Class to receive sales information, calculate sales goals, and
 * display a table of expected results.
 * 
 * Class, Fields, Propeties, Methods, Geometric Series, Console
*/

using System;

namespace SalesGoalsAndExpectedResults
{
    class SalesGoals
    {
        int goalPeriodInMonths;
        double monthlyPercentIncrease;
        double startingSalesValue;

        public int GoalPeriodInMonths { get => goalPeriodInMonths; set => goalPeriodInMonths = value; }
        public double MonthlyPercentIncrease { get => monthlyPercentIncrease*100; set => monthlyPercentIncrease = value/100; }
        public double StartingSalesValue { get => startingSalesValue; set => startingSalesValue = value; }

        public SalesGoals(int goalPeriodMonths,double monthlyIncreasePercent)
        {
            GoalPeriodInMonths = goalPeriodMonths;
            MonthlyPercentIncrease = monthlyIncreasePercent;            
        }

        public SalesGoals(int goalPeriodMonths, double monthlyIncreasePercent, double salesExpectedMonthOne)
        {
            GoalPeriodInMonths = goalPeriodMonths;
            MonthlyPercentIncrease = monthlyIncreasePercent;
            startingSalesValue = salesExpectedMonthOne;
        }

        public double GetSalesGoalForMonth(int a, double startSales)
        {
            double result = 0.00d;

            result = startSales * Math.Pow((1.00+monthlyPercentIncrease), Convert.ToDouble(a));

            return result;
        }
        
        public double[] GetSalesGoalTable(int a, double startSales)
        {
            double[] result = new double[goalPeriodInMonths];

            for (int i=0; i<goalPeriodInMonths; i++)
            {
                result[i] = GetSalesGoalForMonth(i, startSales);
            }

            return result;
        }

        public void WriteSalesGoalHeaderToConsole()
        {
            Console.Write("\n{0,-20}{1,12}{2,12}", "Last Name, First", "Start Date", "+" + GoalPeriodInMonths + "-Months");
            for (int i = 0; i < GoalPeriodInMonths; i++)
            {
                Console.Write("{0,12}", "Month-" + (i + 1).ToString());
            }
        }

        public void WriteSalesGoalDataToConsole(SalesPerson s)
        {   
            Console.Write("\n{0,-20} {1,12} {2,12}", s.LastName + ", " + s.FirstName, s.StartDate.ToShortDateString(), s.StartDate.AddMonths(goalPeriodInMonths).ToShortDateString());
            for (int i = 0; i<GoalPeriodInMonths; i++)
            {
                Console.Write("{0,12}", GetSalesGoalForMonth(i, s.SalesGoal).ToString("$#0.00"));
            }
        }
    }
}
