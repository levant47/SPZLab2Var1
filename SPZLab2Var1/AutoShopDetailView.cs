using System;
using System.Windows.Forms;

namespace SPZLab2Var1
{
    public partial class AutoShopDetailView : Form
    {
        public enum Mode
        {
            Create = 1,
            Edit = 2,
        }

        private Mode _mode;
        private AutoShop _autoShop;
        private Action<AutoShop> _onAutoShopCreation;

        public AutoShopDetailView(Mode mode, AutoShop autoShop, Action<AutoShop> onAutoShopCreation)
        {
            InitializeComponent();
            _mode = mode;
            _autoShop = autoShop;
            _onAutoShopCreation = onAutoShopCreation;

            if (_mode == Mode.Edit)
            {
                departmentCountTextBox.Text = autoShop.DepartmentCount.ToString();
                nameTextBox.Text = autoShop.Name;
                averageMonthlyIncomeTextBox.Text = autoShop.AverageMonthlyIncome.ToString();
                totalEmployeeExpensesTextBox.Text = autoShop.TotalEmployeeExpenses.ToString();
                totalMaterialExpensesTextBox.Text = autoShop.TotalMaterialExpenses.ToString();
                employeeCountTextBox.Text = autoShop.EmployeeCount.ToString();
                addressTextBox.Text = autoShop.Address;
                productCountTextbox.Text = autoShop.ProductCount.ToString();

                yearlyIncomeTextBox.Text = autoShop.GetTotalYearlyIncome().ToString();
                monthlyIncomeTextBox.Text = autoShop[0].ToString();
                taxesAmountTextBox.Text = autoShop.GetTaxesAmount().ToString();
                descriptionTextBox.Text = autoShop.ToString();

                addEmployeeButton.Enabled = true;
                removeEmployeeButton.Enabled = true;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var (maybeDepartmentCount, maybeDepartmentCountErrorMessage) = SafeGetDepartmentCount(departmentCountTextBox.Text);
            if (maybeDepartmentCountErrorMessage != null)
            {
                MessageBox.Show("Department count: " + maybeDepartmentCountErrorMessage);
                return;
            }
            var (maybeName, maybeNameErrorMessage) = SafeGetName(nameTextBox.Text);
            if (maybeNameErrorMessage != null)
            {
                MessageBox.Show("Name: " + maybeNameErrorMessage);
                return;
            }
            var (maybeAverageMonthlyIncome, maybeAverageMonthlyIncomeErrorMessage) = SafeGetAverageMonthlyIncome(averageMonthlyIncomeTextBox.Text);
            if (maybeAverageMonthlyIncomeErrorMessage != null)
            {
                MessageBox.Show("Average Monthly Income: " + maybeAverageMonthlyIncomeErrorMessage);
                return;
            }
            var (maybeTotalEmployeeExpenses, maybeTotalEmployeeExpensesErrorMessage) = SafeGetTotalEmployeeExpenses(totalEmployeeExpensesTextBox.Text);
            if (maybeTotalEmployeeExpensesErrorMessage != null)
            {
                MessageBox.Show("Total Employee Expenses: " + maybeTotalEmployeeExpensesErrorMessage);
                return;
            }
            var (maybeTotalMaterialExpenses, maybeTotalMaterialExpensesErrorMessage) = SafeGetTotalMaterialExpenses(totalMaterialExpensesTextBox.Text);
            if (maybeTotalMaterialExpensesErrorMessage != null)
            {
                MessageBox.Show("Total Material Expenses: " + maybeTotalMaterialExpensesErrorMessage);
                return;
            }
            var (maybeEmployeeCount, maybeEmployeeCountErrorMessage) = SafeGetEmployeeCount(employeeCountTextBox.Text);
            if (maybeEmployeeCountErrorMessage != null)
            {
                MessageBox.Show("Employee Count: " + maybeEmployeeCountErrorMessage);
                return;
            }
            var (maybeAddress, maybeAddressErrorMessage) = SafeGetAddress(addressTextBox.Text);
            if (maybeAddressErrorMessage != null)
            {
                MessageBox.Show("Address" + maybeAddressErrorMessage);
                return;
            }
            var (maybeProductCount, maybeProductCountErrorMessage) = SafeGetProductCount(productCountTextbox.Text);
            if (maybeProductCountErrorMessage != null)
            {
                MessageBox.Show("Product Count: " + maybeProductCountErrorMessage);
                return;
            }

            _onAutoShopCreation(new AutoShop
            {
                DepartmentCount = (int)maybeDepartmentCount,
                Name = maybeName,
                AverageMonthlyIncome = (int)maybeAverageMonthlyIncome,
                TotalEmployeeExpenses = (int)maybeTotalEmployeeExpenses,
                TotalMaterialExpenses = (int)maybeTotalMaterialExpenses,
                EmployeeCount = (int)maybeEmployeeCount,
                Address = maybeAddress,
                ProductCount = (int)maybeProductCount,
            });

            Close();
        }

        private (int?, string) SafeGetDepartmentCount(string source) => SafeGetPositiveInteger(source);

        private (string, string) SafeGetName(string source) => SafeGetNonEmptyString(source);

        private (int?, string) SafeGetAverageMonthlyIncome(string source) => SafeGetPositiveInteger(source);

        private (int?, string) SafeGetTotalEmployeeExpenses(string source) => SafeGetPositiveInteger(source);

        private (int?, string) SafeGetTotalMaterialExpenses(string source) => SafeGetPositiveInteger(source);

        private (int?, string) SafeGetEmployeeCount(string source) => SafeGetPositiveInteger(source);

        private (string, string) SafeGetAddress(string source) => SafeGetNonEmptyString(source);

        private (int?, string) SafeGetProductCount(string source) => SafeGetPositiveInteger(source);

        private (int?, string) SafeGetPositiveInteger(string source)
        {
            var maybePositiveInteger = Utilities.SafeParseInt(source);
            if (maybePositiveInteger == null)
            {
                return (null, "Not a valid number");
            }

            if (maybePositiveInteger <= 0)
            {
                return (null, "Must be a positive number");
            }

            return (maybePositiveInteger, null);
        }

        private (string, string) SafeGetNonEmptyString(string source)
        {
            if (source == "")
            {
                return (null, "Should not be empty");
            }
            return (source, null);
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            _autoShop++;
            employeeCountTextBox.Text = _autoShop.EmployeeCount.ToString();
        }

        private void removeEmployeeButton_Click(object sender, EventArgs e)
        {
            _autoShop--;
            employeeCountTextBox.Text = _autoShop.EmployeeCount.ToString();
        }
    }
}
