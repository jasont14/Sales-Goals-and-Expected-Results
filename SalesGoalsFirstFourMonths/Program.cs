/* Program.cs                                       Jason Thatcher
 *                                                  December 2017
 * 
 * Simple app to set sales goals for up to x-people and view
 * simple table.
 * 
 * C#, Probability, Loop, Conditional, Methods Comments, Console.
*/


using System;
using System.Collections.Generic;

namespace SalesGoalsAndExpectedResults
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            Console.WriteLine("View Sales Goals Options:\n");
            ShowMenu(run);                      
        }

        public static void ShowMenu(bool r)
        {
            while (r)
            {
                int optionSelected;
                Console.WriteLine("1 = Run with Default Data");
                Console.WriteLine("2 = User Enters Raw Data)");
                Console.WriteLine("0 = Quit");
                Console.Write("\nENTER OPTION: ");
                int.TryParse(Console.ReadLine(), out optionSelected);

                switch (optionSelected)
                {
                    case 1:
                        RunWithDefaultData();
                        break;
                    case 2:
                        RunWithUserInput();
                        break;
                    case 0:
                        r = false;
                        ShowMenu(r);
                        break;
                    default:
                        ShowMenu(r);
                        break;
                }
            }
        }

        public static void RunWithDefaultData()
        {
            SalesGoals SG = new SalesGoals(6, 5.00);
            SalesPerson SP = new SalesPerson();

            Console.Clear();
            Console.WriteLine("--Set Sales Goal--\n");

            //Default Data 
            List<SalesPerson> SalesPeople = new List<SalesPerson>
            {
                new SalesPerson(){FirstName="James",LastName = "Howlett", SalesGoal = 5000.00, StartDate=Convert.ToDateTime("12/05/2017")},
                new SalesPerson(){FirstName="Fred", LastName = "Johnson", SalesGoal = 2500.00, StartDate=Convert.ToDateTime("10/01/2017")},
                new SalesPerson(){FirstName="Diana", LastName = "Prince", SalesGoal=5000.00,StartDate=Convert.ToDateTime("9/1/2017")}
            };

            WriteResults(SG, SalesPeople);

        }

        public static void RunWithUserInput()
        {            
            List<SalesPerson> myListSP = new List<SalesPerson>();

            int numberOfSalesPeople = 0;
            int numberOfMonths = 0;
            double percentIncrease = 0.00;

            Console.Clear();
            Console.WriteLine("--Set Sales Goal--\n");
                        
            Console.Write("Months to Forecast: ");
            int.TryParse(Console.ReadLine(), out numberOfMonths);

            Console.Write("Monthly Sales Increase (Pecent): ");
            double.TryParse(Console.ReadLine(), out percentIncrease);

            SalesGoals SG = new SalesGoals(numberOfMonths, percentIncrease);

            Console.Write("Number of Sales People: ");
            int.TryParse(Console.ReadLine(), out numberOfSalesPeople);

            for (int i = 0; i < numberOfSalesPeople; i++)
            {
                SalesPerson mSP = new SalesPerson();

                Console.Clear();
                Console.Write("Enter Hire Date (MM/DD/YYYY):");
                mSP.StartDate = Convert.ToDateTime(Console.ReadLine());

                Console.Clear();
                Console.Write("(" + (i+1).ToString() + ") First Name:");
                mSP.FirstName = Console.ReadLine();

                Console.Clear();
                Console.Write("(" + (i + 1).ToString() + ") Last Name:");
                mSP.LastName = Console.ReadLine();
                
                Console.Clear();
                Console.Write("(" + (i + 1).ToString() + ") 1st Month Goal:");
                mSP.SalesGoal = Convert.ToDouble(Console.ReadLine());

                myListSP.Add(mSP);
            }

            WriteResults(SG, myListSP);
        }

        public static void WriteResults(SalesGoals sg, List<SalesPerson> spp)
        {
            Console.Clear();
            Console.WriteLine("EXPECTED RESULTS");

            sg.WriteSalesGoalHeaderToConsole();

            //Sales Goal Table
            foreach (SalesPerson sp in spp)
            {
                sg.WriteSalesGoalDataToConsole(sp);
            }

            Console.WriteLine("\n\n\nCONTINUE? ");
        }
    }
}
