using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SPZLab2Var1
{
    public partial class Form1 : Form
    {
        private List<AutoShop> _autoShops = new List<AutoShop>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateAutoShopButton_Click(object sender, EventArgs e) => new AutoShopDetailView
        (
            AutoShopDetailView.Mode.Create,
            null,
            newAutoShop =>
            {
                _autoShops = _autoShops.Append(newAutoShop).OrderBy(autoShop => autoShop).ToList();
                UpdateAutoShopList();
            }
        ).Show();

        private void UpdateAutoShopList()
        {
            autoShopsListBox.Items.Clear();
            _autoShops.ForEach(autoShop => autoShopsListBox.Items.Add(autoShop.Name));
        }

        private void autoShopsListBox_DoubleClick(object sender, EventArgs e)
        {
            var index = autoShopsListBox.IndexFromPoint((e as MouseEventArgs).Location);
            if (index == ListBox.NoMatches)
            {
                return;
            }
            new AutoShopDetailView
            (
                AutoShopDetailView.Mode.Edit,
                _autoShops[index],
                updatedAutoShop =>
                {
                    _autoShops[index] = updatedAutoShop;
                    UpdateAutoShopList();
                }
            ).Show();
        }
    }
}
