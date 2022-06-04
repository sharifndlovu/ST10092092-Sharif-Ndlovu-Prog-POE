using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace FinancialPOE
{

    public interface IExpenses // interface 
    {
        double CalculateMonthlyRepayment(); // interface method
    }

    public class Vehicle : IExpenses
    {
        private string model, make;
        private double purchasePrice, deposit, interestRate, insurancePremium,monthlyVehicleRepayment;
        public double tempResult, remainingBalance;

        public Vehicle(string model, string make, double purchasePrice, double deposit, double interestRate, double insurancePremium)
        {
            SetModel(model);
            SetMake(make);
            SetPurchasePrice(purchasePrice);
            SetDeposit(deposit);
            SetInterestRate(interestRate);
            SetInsurancePremium(insurancePremium);
        }

        //getters
        public double GetMonthlyVehicleRepayment()
        {
            return monthlyVehicleRepayment;
        }
        public string GetModel()
        {
            return model;
        }

        public string GetMake()
        {
            return make;
        }

        public double GetPurchasePrice()
        {
            return purchasePrice;
        }

        public double GetDeposit()
        {
            return deposit;
        }

        public double GetInterestRate()
        {
            return interestRate;
        }

        public double GetInsurancePremium()
        {
            return insurancePremium;
        }

        // overriden method from Expenses interface
        public double CalculateMonthlyRepayment()
        {
            remainingBalance = purchasePrice - deposit;
            tempResult = remainingBalance * (1 + interestRate / 100 * 60);
            monthlyVehicleRepayment = tempResult + insurancePremium;

            return monthlyVehicleRepayment;
        }

        public void SetInsurancePremium(double insurancePremium)
        {
            this.insurancePremium = insurancePremium;
        }

        public void SetInterestRate(double interestRate)
        {
            this.interestRate = interestRate;
        }

        public void SetDeposit(double deposit)
        {
            this.deposit = deposit;
        }

        public void SetPurchasePrice(double price)
        {
            this.purchasePrice = price;
        }

        public void SetMake(string make)
        {
            this.make = make;
        }

        public void SetModel(string model)
        {
            this.model = model;
        }
    }

    public class GeneralExpenses : IExpenses
    {
        private double groceries, waterAndElectricity, travelCost, cellPhone;
        public double monthlyRepayment;

        // constructor
        public GeneralExpenses(double groceries, double waterAndElectricity, double travelCost, double cellPhone)
        {
            SetGroceries(groceries);
            SetCellPhoneBill(cellPhone);
            SetTravelCost(travelCost);
            SetWaterAndElectricity(waterAndElectricity);
        }

        // getters and setters

        public double GetGroceries()
        {
            return groceries;
        }
        public double GetWaterAndElectricity()
        {
            return waterAndElectricity;
        }

        public double GetTravelCost()
        {
            return travelCost;
        }

        public double GetCellPhoneBill()
        {
            return cellPhone;
        }

        public void SetGroceries(double groceries)
        {
            this.groceries = groceries;
        }

        public void SetWaterAndElectricity(double waterAndElectricity)
        {
            this.waterAndElectricity = waterAndElectricity;
        }

        public void SetTravelCost(double travelCost)
        {
            this.travelCost = travelCost;
        }

        public void SetCellPhoneBill(double cellPhoneBill)
        {
            this.cellPhone = cellPhoneBill;
        }

        public double GetMonthlyRepayment()
        {
            return monthlyRepayment;
        }

        // overriden method from Expenses
        public double CalculateMonthlyRepayment()
        {
            monthlyRepayment = groceries + waterAndElectricity + travelCost + cellPhone;
            return monthlyRepayment;
        }
    }

    public class HomeLoan : IExpenses
    {
        private double propertyPrice, deposit, HomeLoanRepayment;
        private int monthsToPay, interestRate;

        // constructor
        public HomeLoan(double propertyPrice, double deposit, int interestRate, int monthsToPay)
        {
            SetPropertyPrice(propertyPrice);
            SetDeposit(deposit);
            SetMonthsToPay(monthsToPay);
            SetInterestRate(interestRate);
        }

        public double GetHomeLoanRepayment()
        {
            return HomeLoanRepayment;
        }

        // overriden method from Expenses interface
        public double CalculateMonthlyRepayment()
        {
            double remainingBalance = propertyPrice - deposit;

            double tempResult = remainingBalance * (1 + interestRate / 100 * monthsToPay);

            HomeLoanRepayment = tempResult / monthsToPay;
            return HomeLoanRepayment;
        }

        // check if student can afford the loan
        public void CheckForAlert()
        {
            string message;
            double income = Income.GetIncomeAfterTax();
            double priceCeiling = income / 3;

            if (priceCeiling > HomeLoanRepayment)
            {
                message = null;
            }
            else
            {
                message = "Your application for a loan will most likely be declined,";
            }

            Console.WriteLine(message);
        }

        // getters and setters
        public double GetPropertyPrice()
        {
            return propertyPrice;
        }

        public double GetDeposit()
        {
            return deposit;
        }

        public int GetInterestRate()
        {
            return interestRate;
        }

        public int GetMonthsToPay()
        {
            return monthsToPay;
        }

        public void SetPropertyPrice(double propertyPrice)
        {
            this.propertyPrice = propertyPrice;
        }

        public void SetDeposit(double deposit)
        {
            this.deposit = deposit;
        }

        public void SetInterestRate(int interestRate)
        {
            this.interestRate = interestRate;
        }

        public void SetMonthsToPay(int monthsToPay)
        {
            this.monthsToPay = monthsToPay;
        }
    }

    public class Income
    {
        private static double monthlyIncome, taxDeduction;

        // constructor
        public Income(double monthlyIncome, double taxDeduction)
        {
            SetMonthlyIncome(monthlyIncome);
            SetTaxDeduction(taxDeduction);
        }


        public static double GetIncomeAfterTax()
        {
            return monthlyIncome - taxDeduction;
        }

        // getters and setters
        public void SetMonthlyIncome(double monthlyIncome)
        {
            Income.monthlyIncome = monthlyIncome;
        }

        public void SetTaxDeduction(double taxDeduction)
        {
            Income.taxDeduction = taxDeduction;
        }

        public double GetTaxDeduction()
        {
            return taxDeduction;
        }

        public double GetMonthlyIncome()
        {
            return monthlyIncome;
        }

    }


    public class Renting : IExpenses
    {
        public double rentCost;

        // constructor
        public Renting(double rentCost)
        {
            SetRentCost(rentCost);
        }

        public double GetRentCost()
        {
            return rentCost;
        }

        // overridden method from expenses interfaces
        public double CalculateMonthlyRepayment()
        {
            return rentCost;
        }

        // setter for Rent Cost
        public void SetRentCost(double rentCost)
        {
            this.rentCost = rentCost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrintSheet.CollectValues(); // call method to begin

        }
    }

    //class NullStringException : Exception
    //{
    //    NullStringException(String message): base(message)
    //    { }
    //    }

    //}

    public class PrintSheet
    {
        // Declerations for Selections
        public static int accomodationSelection, vehicleSelection, rentOrLoan;

        // Declarations
        public static double tempIncome, tempDeduction, tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone;

        public static string tempModel, tempMake;
        public static double tempPurchasePrice, tempVehicleDeposit, tempVehicleInterestRate, tempEstimatedInsurancePremium;

        public static double tempRent;
        public static double tempPropertyPrice, tempHouseDeposit, tempHouseInterestRate, tempMonths;

        public static Dictionary<string, Double> expenses = new Dictionary<string, double>();

        public static bool whileFlag = true;

        // gather input required to begin processing
        public static void CollectValues()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Please provide your amounts for the following...");
                    Console.WriteLine("Monthly Income (Before Tax) :");
                    tempIncome = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Tax Reduction :");
                    tempDeduction = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Please provide your expense costs for the following...");
                    Console.WriteLine("Groceries : ");
                    tempGroceries = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Water & Electricity : ");
                    tempWaterAndElectricity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Travel Cost (inc Petrol) : ");
                    tempTravelCost = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Cell/Telephone Bill : ");
                    tempCellPhone = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch (Exception e) // catch input errors
                {
                    Console.WriteLine("ERROR: " + e + "\nRefreshing...\n");
                }
            }


            while (whileFlag)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please provide the number for your preferred accommodation...");
                        Console.WriteLine("Renting (1) or Buying a Home (2)");
                        accomodationSelection = Convert.ToInt16(Console.ReadLine());
                        break;

                    }
                    catch (Exception e) // catch input errors
                    {
                        Console.WriteLine("ERROR: " + e + "\nRefreshing...\n");
                    }
                }


                switch (accomodationSelection)
                {
                    case 1:
                        Console.WriteLine("You have selected Renting...");
                        RentSelection();
                        whileFlag = false;
                        rentOrLoan = 0;
                        break;

                    case 2:
                        Console.WriteLine("You have selected Buying a Home...");
                        HomeLoanSelection();
                        whileFlag = false;
                        rentOrLoan = 1;
                        break;

                    default:
                        Console.WriteLine("Incorrect input please try again (1 or 2)\n");
                        whileFlag = true;
                        break;
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Additionally if you would like to add a vehicle press (1) or (2) to continue without a vehicle.");

                    vehicleSelection = Convert.ToInt16(Console.ReadLine());

                    if (vehicleSelection.Equals(1))
                    {
                        BuyVehicle();
                        break;

                    }
                    else if (vehicleSelection.Equals(2))
                    {
                        if (rentOrLoan.Equals(0))
                        {
                            PrintResultR();

                        } else
                        {
                            PrintResultL();
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input, please try again...");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e + "\nRetrying...\n");
                }
            }
        }

        // buy vehicle method
        public static void BuyVehicle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please provide the following information for your car purchase...");
                    Console.WriteLine("Model:");
                    tempModel = Console.ReadLine();
                    Console.WriteLine("Make:");
                    tempMake = Console.ReadLine();

                    Console.WriteLine("Purchae Price:");
                    tempPurchasePrice = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Deposit:");
                    tempVehicleDeposit = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Interest Rate:");
                    tempVehicleInterestRate = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Estimated Insurance Premium:");
                    tempEstimatedInsurancePremium = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }

            if (rentOrLoan.Equals(0))
            {
                PrintResultR(0);
            } else
            {
                PrintResultL(1);
            }
        }

        // rent selection
        public static void RentSelection()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please provide the cost of your rent..");
                    Console.WriteLine("Rent : ");
                    tempRent = Convert.ToDouble(Console.ReadLine());
                    break;

                }
                catch (Exception e) // catch input errors
                {
                    Console.WriteLine("ERROR: " + e + "\nRefreshing...\n");
                }
            }
        }

        // home selection
        public static void HomeLoanSelection()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nBeginning Home Loan Calculation");
                    Console.WriteLine("Please provide the amounts of the following...");
                    Console.WriteLine("Property Price : ");
                    tempPropertyPrice = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Initial Deposit : ");
                    tempHouseDeposit = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Interest rate");
                    tempHouseInterestRate = Convert.ToInt16(Console.ReadLine());

                    whileFlag = true;
                    while (true)
                    {
                        Console.WriteLine("Number of Months to pay (240-360):");
                        tempMonths = Convert.ToInt16(Console.ReadLine());

                        if ((tempMonths >= 240) && (tempMonths <= 360))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nNumber of months should be limited in between 240 - 360..");
                            Console.WriteLine("Please provide the amounts of the following...");
                        }
                    }

                    break;

                }
                catch (Exception e) // catch input errors
                {
                    Console.WriteLine("ERROR: " + e + "\nRefreshing...\n");
                }
            }
        }

        // store expenses into dictionary
        public static void StoreExpenses(double car,double houseRepayment)
            {
                Dictionary <string, Double> expenses = new Dictionary<string, double>();
        
                if (rentOrLoan.Equals(0))
                {
                    expenses.Add("Groceries", tempGroceries);
                    expenses.Add("Water & Electricity", tempWaterAndElectricity);
                    expenses.Add("Cellphone", tempCellPhone);
                    expenses.Add("Rent", tempRent);
                    expenses.Add("Vehicle Loan", car);
                    expenses.Add("Insurance", tempEstimatedInsurancePremium);
                } else
                {
                    expenses.Add("Groceries", tempGroceries);
                    expenses.Add("Water & Electricity", tempWaterAndElectricity);
                    expenses.Add("Cellphone", tempCellPhone);
                    expenses.Add("Home Loan", houseRepayment);
                    expenses.Add("Vehicle Loan", car);
                    expenses.Add("Insurance", tempEstimatedInsurancePremium);
                }

                PrintDictionary();
            }

        // method override
        public static void StoreExpenses(double houseRepayment)
            {        
                if (rentOrLoan.Equals(0))
                {
                    expenses.Add("Groceries", tempGroceries);
                    expenses.Add("Water & Electricity", tempWaterAndElectricity);
                    expenses.Add("Cellphone", tempCellPhone);
                    expenses.Add("Rent", tempRent);
                    expenses.Add("Insurance", tempEstimatedInsurancePremium);
                } else
                {
                    expenses.Add("Groceries", tempGroceries);
                    expenses.Add("Water & Electricity", tempWaterAndElectricity);
                    expenses.Add("Cellphone", tempCellPhone);
                    expenses.Add("Home Loan", houseRepayment);
                    expenses.Add("Insurance", tempEstimatedInsurancePremium);
                }

                PrintDictionary();
            }

        // print dictionary and sort by desc
        public static void PrintDictionary()
        {
            Console.WriteLine("Printing Expenditure list (Desc Order)");
            Console.WriteLine("==============================================");

            foreach (KeyValuePair<string,double> expense in expenses.OrderByDescending(key => key.Value))
            {
                Console.WriteLine(expense.Key + ": " + expense.Value.ToString("C",CultureInfo.CurrentCulture));
            }

        }

        //public static void StoreExpensesIntoArray(double housing)
        //{
        //    string[] expenseNames = { "Groceries", "Electricity & Water", "Travel Costs", "CellPhone", "Rent/House" };
        //    double[] expenses = { tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone, housing };

        //    Console.WriteLine("Would you like to view your expenses? Enter (1) for Yes or any other key for No");
        //    string selection = Console.ReadLine();

        //    if (selection.Equals("1"))
        //    {
        //        for (int x = 0; x < 5; x++)
        //        {
        //            Console.WriteLine(expenseNames[x] + ": " + expenses[x].ToString("C", CultureInfo.CurrentCulture));
        //        }
        //    }
        //    Console.ReadKey();
        //}

        // display renting option
        public static void PrintResultR()
        {
            Income inc = new Income(tempIncome, tempDeduction);
            Renting rent = new Renting(tempRent);
            GeneralExpenses genExpenses = new GeneralExpenses(tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone);

            rent.CalculateMonthlyRepayment();
            genExpenses.CalculateMonthlyRepayment();

            double tempExpense = rent.GetRentCost() + genExpenses.GetMonthlyRepayment();
            double moneyAvailable = inc.GetMonthlyIncome()  - tempExpense;

            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Income (After Tax): " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Expenses : " + tempExpense.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Groceries : " + genExpenses.GetGroceries().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Water & Electricity : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Travel : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("CellPhone : " + genExpenses.GetCellPhoneBill().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Rent : " + rent.GetRentCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Money Remaining After Expenses : " + moneyAvailable.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.Read();

            CheckIncAgainstExpensesPtr obj = new CheckIncAgainstExpensesPtr(CheckIncAgainstExpenses);
            obj.Invoke(inc.GetMonthlyIncome(), tempExpense);

            StoreExpenses(0);
        }

        // display buying home option
        public static void PrintResultL()
        {
            Income inc = new Income(tempIncome, tempDeduction);
            HomeLoan home = new HomeLoan(tempPropertyPrice, tempHouseDeposit, Convert.ToInt16(tempHouseInterestRate), Convert.ToInt16(tempMonths));
            GeneralExpenses genExpenses = new GeneralExpenses(tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone);

            home.CalculateMonthlyRepayment();
            genExpenses.CalculateMonthlyRepayment();

            double tempExpense = home.GetHomeLoanRepayment() + genExpenses.GetMonthlyRepayment();
            double moneyAvailable = inc.GetMonthlyIncome() - tempExpense;
            double tempRemainingOwed = home.GetPropertyPrice() - home.GetDeposit();

            Console.WriteLine("House");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Property Price : " + home.GetPropertyPrice().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Deposit : " + home.GetDeposit().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Amount after deposit : " + tempRemainingOwed.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Interest Rate : " + home.GetInterestRate() + "%");
            Console.WriteLine("Months to Pay : " + home.GetMonthsToPay());
            Console.WriteLine("Monthly Repayment For Home Loan : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));

            Console.WriteLine("Your Income : " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Loan Repayment : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));
            home.CheckForAlert();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("");

            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Income (After Tax): " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Expenses : " + tempExpense.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Groceries : " + genExpenses.GetGroceries().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Water & Electricity : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Travel : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("CellPhone : " + genExpenses.GetCellPhoneBill().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Home Loan (Monthly) : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Money Remaining After Expenses : " + moneyAvailable.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.Read();

            CheckIncAgainstExpensesPtr obj = new CheckIncAgainstExpensesPtr(CheckIncAgainstExpenses);
            obj.Invoke(inc.GetMonthlyIncome(), tempExpense);
            StoreExpenses(home.GetHomeLoanRepayment());
        }

        // display renting option + vehicle
        public static void PrintResultR(int x)
        {
            Income inc = new Income(tempIncome, tempDeduction);
            Renting rent = new Renting(tempRent);
            GeneralExpenses genExpenses = new GeneralExpenses(tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone);
            Vehicle car = new Vehicle(tempModel, tempMake, tempPurchasePrice, tempVehicleDeposit, tempVehicleInterestRate, tempEstimatedInsurancePremium);

            car.CalculateMonthlyRepayment();
            rent.CalculateMonthlyRepayment();
            genExpenses.CalculateMonthlyRepayment();

            double tempExpense = rent.GetRentCost() + genExpenses.GetMonthlyRepayment() + car.GetMonthlyVehicleRepayment() + car.GetInsurancePremium();
            double moneyAvailable = inc.GetMonthlyIncome() - tempExpense - car.GetMonthlyVehicleRepayment();

            Console.WriteLine("Vehicle");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Model : " + car.GetMake());
            Console.WriteLine("Make : " + car.GetModel());
            Console.WriteLine("Purchase Price : " + car.GetPurchasePrice().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Deposit : " + car.GetDeposit().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Interest Rate : " + car.GetInterestRate().ToString("C", CultureInfo.CurrentCulture) + " %");
            Console.WriteLine("Insurance Premium (Estimated) : " + car.GetInsurancePremium().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");

            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Income (After Tax): " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Expenses : " + tempExpense.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Groceries : " + genExpenses.GetGroceries().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Water & Electricity : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Travel : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("CellPhone : " + genExpenses.GetCellPhoneBill().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Rent : " + rent.GetRentCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Vehicle : " + car.GetMonthlyVehicleRepayment().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Insurance Premium : " + car.GetInsurancePremium().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Money Remaining After Expenses : " + moneyAvailable.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.Read();

            CheckIncAgainstExpensesPtr obj = new CheckIncAgainstExpensesPtr(CheckIncAgainstExpenses);
            obj.Invoke(inc.GetMonthlyIncome(), tempExpense);

            StoreExpenses(car.GetMonthlyVehicleRepayment(), 0);
        }

        // display buying home option + vehicle
        public static void PrintResultL(int x)
        {
            Income inc = new Income(tempIncome, tempDeduction);
            HomeLoan home = new HomeLoan(tempPropertyPrice, tempHouseDeposit, Convert.ToInt16(tempHouseInterestRate), Convert.ToInt16(tempMonths));
            GeneralExpenses genExpenses = new GeneralExpenses(tempGroceries, tempWaterAndElectricity, tempTravelCost, tempCellPhone);
            Vehicle car = new Vehicle(tempModel, tempMake, tempPurchasePrice, tempVehicleDeposit, tempVehicleInterestRate, tempEstimatedInsurancePremium);

            car.CalculateMonthlyRepayment();
            home.CalculateMonthlyRepayment();
            genExpenses.CalculateMonthlyRepayment();

            double tempExpense = home.GetHomeLoanRepayment() + genExpenses.GetMonthlyRepayment() + car.GetInsurancePremium() + car.GetMonthlyVehicleRepayment();
            double moneyAvailable = inc.GetMonthlyIncome() - tempExpense;
            double tempRemainingOwed = home.GetPropertyPrice() - home.GetDeposit();

            Console.WriteLine("House");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Property Price : " + home.GetPropertyPrice().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Deposit : " + home.GetDeposit().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Amount after deposit : " + tempRemainingOwed.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Interest Rate : " + home.GetInterestRate() + "%");
            Console.WriteLine("Months to Pay : " + home.GetMonthsToPay());
            Console.WriteLine("Monthly Repayment For Home Loan : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));

            Console.WriteLine("Your Income : " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Loan Repayment : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));
            home.CheckForAlert();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("");

            Console.WriteLine("Vehicle");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Model : " + car.GetMake());
            Console.WriteLine("Make : " + car.GetModel());
            Console.WriteLine("Purchase Price : " + car.GetPurchasePrice().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Deposit : " + car.GetDeposit().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Interest Rate : " + car.GetInterestRate().ToString("C", CultureInfo.CurrentCulture) + " %");
            Console.WriteLine("Insurance Premium (Estimated) : " + car.GetInsurancePremium().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");

            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Income (After Tax): " + inc.GetMonthlyIncome().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Monthly Expenses : " + tempExpense.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Groceries : " + genExpenses.GetGroceries().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Water & Electricity : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Travel : " + genExpenses.GetTravelCost().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("CellPhone : " + genExpenses.GetCellPhoneBill().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Home Loan (Monthly) : " + home.GetHomeLoanRepayment().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Vehicle : " + car.GetMonthlyVehicleRepayment().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Insurance Premium : " + car.GetInsurancePremium().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Money Remaining After Expenses : " + moneyAvailable.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("*********************************************************");
            Console.Read();

            CheckIncAgainstExpensesPtr obj = new CheckIncAgainstExpensesPtr(CheckIncAgainstExpenses);
            obj.Invoke(inc.GetMonthlyIncome(), tempExpense);

            StoreExpenses(car.GetMonthlyVehicleRepayment(), home.GetHomeLoanRepayment());

        }
        public delegate void CheckIncAgainstExpensesPtr(double income, double expenses);
        static void CheckIncAgainstExpenses(double income, double expenses)
        {
            double temp = income * 0.75;
            if (expenses > temp)
            {
                Console.WriteLine("Your expenses 75% of your income.");
            }
        }
    } 
}