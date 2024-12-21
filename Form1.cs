using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form1 : Form
    {
        string[] gasTypes = {
            "ប្រេងសាំង",
            "ប្រេងម៉ាស៊ូត",
            "ហ្គាស់",
            "ប្រេងយន្តហោះ",
            "ប្រេងដូង",
            "ប្រេងបាត",
            "ប្រេងឆៅ"
        };
        double[] prices = {3200,3400,2000,5000,1500,3000,2200 };
        double totalGas, totalCafe;
        public Form1()
        {
            InitializeComponent();
        }

        private void CbGasType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbGasUnitPrice.Text = prices[CbGasType.SelectedIndex].ToString();
            CalculateGasPayment();
        }

        private void RbAmtLitre_CheckedChanged(object sender, EventArgs e)
        {
            TbAmtLitre.Enabled = RbAmtLitre.Checked;
            CalculateGasPayment();
        }

        private void RbAmtRiel_CheckedChanged_1(object sender, EventArgs e)
        {
            TbAmtRiel.Enabled = RbAmtRiel.Checked;
            CalculateGasPayment();
        }

        private void CafeChkChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == CbHotDog) TbHotDogAmt.Enabled = cb.Checked;
            else if (cb == CbBurger) TbBurgerAmt.Enabled = cb.Checked;
            else if (cb == CbFr) TbFrAmt.Enabled = cb.Checked;
            else if (cb == CbCoke) TbCokeAmt.Enabled = cb.Checked;
        }
        void CalculateGasPayment()
        {
            try
            {
                if (RbAmtRiel.Checked) LbGasPayment.Text = TbAmtRiel.Text;
                else if (RbAmtLitre.Checked)
                    LbGasPayment.Text = (Convert.ToInt32(TbAmtLitre.Text) * Convert.ToDouble(TbGasUnitPrice.Text)).ToString();
            }
            catch
            {
                LbGasPayment.Text = "0.00";
            }
            try { totalGas = Convert.ToDouble(LbGasPayment.Text); } catch { }
            CalculateTotal();
        }
        void CalculateCafePayment()
        {
            double total = 0;
            if (CbHotDog.Checked)
            {
                try
                {
                    total += Convert.ToDouble(TbHotDogUnitPrice.Text) * Convert.ToInt32(TbHotDogAmt.Text);
                }
                catch { }
            }
            if (CbBurger.Checked)
            {
                try
                {
                    total += Convert.ToDouble(TbBurgerUnitPrice.Text) * Convert.ToInt32(TbBurgerAmt.Text);
                }
                catch { }
            }
            if (CbFr.Checked)
            {
                try
                {
                    total += Convert.ToDouble(TbFrUnitPrice.Text) * Convert.ToInt32(TbFrAmt.Text);
                }
                catch { }
            }
            if (CbCoke.Checked)
            {
                try
                {
                    total += Convert.ToDouble(TbCokeUnitPrice.Text) * Convert.ToInt32(TbCokeAmt.Text);
                }
                catch { }
            }
            LbCafePayment.Text = total.ToString();
            totalCafe = total;
            CalculateTotal();
        }
        void CalculateTotal()
        {
            LbTotal.Text = (totalCafe + totalGas).ToString();
        }

        private void TbAmtRiel_TextChanged(object sender, EventArgs e)
        {
            CalculateGasPayment();
        }

        private void CafeTextChanged(object sender, EventArgs e)
        {
            CalculateCafePayment();
        }

        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Receipt r = new Receipt();
            r.LbGasType.Text = CbGasType.Text;
            r.LbGas.Text = LbGasPayment.Text;
            try
            {
                r.LbHotdog.Text = (
                    Convert.ToDouble(TbHotDogUnitPrice.Text)
                    * Convert.ToInt32(TbHotDogAmt.Text)).ToString();
            }
            catch { r.LbHotdog.Text = "0"; }
            try
            {
                r.LbBurger.Text = (
                    Convert.ToDouble(TbBurgerUnitPrice.Text)
                    * Convert.ToInt32(TbBurgerAmt.Text)).ToString();
            }
            catch { r.LbBurger.Text = "0"; }
            try
            {
                r.LbFr.Text = (
                    Convert.ToDouble(TbFrUnitPrice.Text)
                    * Convert.ToInt32(TbFrAmt.Text)).ToString();
            }
            catch { r.LbFr.Text = "0"; }
            try
            {
                r.LbCoke.Text = (
                    Convert.ToDouble(TbCokeUnitPrice.Text)
                    * Convert.ToInt32(TbCokeAmt.Text)).ToString();
            }
            catch { r.LbCoke.Text = "0"; }
            r.ShowDialog();
        }

        private void TbAmtLitre_TextChanged(object sender, EventArgs e)
        {
            CalculateGasPayment();
        }
    }
}
