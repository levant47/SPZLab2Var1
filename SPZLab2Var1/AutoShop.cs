using System;
using System.Diagnostics.CodeAnalysis;

namespace SPZLab2Var1
{
    public class AutoShop : IComparable<AutoShop>
    {
        public int DepartmentCount { get; set; }

        public string Name { get; set; }

        public int AverageMonthlyIncome { get; set; }

        public int TotalEmployeeExpenses { get; set; }

        public int TotalMaterialExpenses { get; set; }

        public int EmployeeCount { get; set; }

        public string Address { get; set; }

        public int ProductCount { get; set; }

        public void AddEmployee()
        {
            TotalEmployeeExpenses += 100;
            EmployeeCount++;
        }

        public override string ToString() => string.Join(", ", new[]
        {
            $"{nameof(DepartmentCount)}: {DepartmentCount}",
            $"{nameof(Name)}: {Name}",
            $"{nameof(AverageMonthlyIncome)}: {AverageMonthlyIncome}",
            $"{nameof(TotalEmployeeExpenses)}: {TotalEmployeeExpenses}",
            $"{nameof(TotalMaterialExpenses)}: {TotalMaterialExpenses}",
            $"{nameof(EmployeeCount)}: {EmployeeCount}",
            $"{nameof(Address)}: {Address}",
            $"{nameof(ProductCount)}: {ProductCount}",
        });

        public int GetMonthlyIncome() => AverageMonthlyIncome - TotalEmployeeExpenses - TotalMaterialExpenses;

        public int GetTotalYearlyIncome() => GetMonthlyIncome() * 12;


        public void FireEmployee()
        {
            TotalEmployeeExpenses = Math.Max(0, TotalEmployeeExpenses - 100);
            EmployeeCount = Math.Max(0, EmployeeCount - 1);
        }

        public double GetTaxesAmount() => GetTotalYearlyIncome() * 0.17;

        public int CompareTo([AllowNull] AutoShop other) => Math.Clamp(GetTotalYearlyIncome() - other?.GetTotalYearlyIncome() ?? 0, -1, 1);

        public static AutoShop operator ++(AutoShop autoShop)
        {
            autoShop.AddEmployee();
            return autoShop;
        }

        public static AutoShop operator --(AutoShop autoShop)
        {
            autoShop.FireEmployee();
            return autoShop;
        }

        public int this[int index] => GetMonthlyIncome();
    }
}
