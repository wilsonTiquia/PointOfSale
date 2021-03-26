using System;
using System.Globalization;
using System.Windows.Forms;



namespace pointofsaleFinal
{
    public partial class Form1 : Form
    {
        double total2 = 0;
        string personMoney = "";
        double final = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tenPcChicken_Click(object sender, EventArgs e)
        {
            double tenPcChickenPrice = 699.00;
            string tenPcChickenPriceStr = tenPcChickenPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string tenPcChicken = "Bucket Of 10@ " + tenPcChickenPriceStr;
            itemDescription.Text = tenPcChicken;

        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            try
            {
               
                int ilan = int.Parse(quantity.Text);
                int pinilingItemHaba = itemDescription.Text.Length;
                int indicator = itemDescription.Text.IndexOf("@") + 3;
                string pwesto = itemDescription.Text.Substring(indicator, pinilingItemHaba - indicator);
                double presyoNgBinili = double.Parse(pwesto);
                double hulingPresyo = presyoNgBinili * ilan;
                if (hulingPresyo <= 0)
                {
                    total2 += 0;
                }
                else
                {
                    total2 += hulingPresyo;
;                }
                string hulingPresyoStr = hulingPresyo.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
                if (ilan >= 1 && itemDescription.Text != string.Empty)
                {
                   
                    orders.Items.Add(itemDescription.Text + " X " + quantity.Text + " = " + hulingPresyoStr);
                    itemDescription.Text = "";
                    quantity.Text = "1";
                    total.Text = total2.ToString("C",CultureInfo.CreateSpecificCulture("en-PH"));
  
                }
                else if (ilan <= 0 && itemDescription.Text != string.Empty)
                {
                 
                    MessageBox.Show("Bumili ka ng item na isa pataas bobo", "tanga");
                    quantity.Text = "1";
                    itemDescription.Text = "";
                }
            }
            catch
            {
                quantity.Text = "1";
                itemDescription.Text = "";
                MessageBox.Show("BOBO pumili ka muna bago ka mag add at bawal ang negative na o wala kang binili tanga");
            }
        }
        private void orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orders.SelectedIndex != -1)
            {

                try
                {
                    string inalis = orders.GetItemText(orders.SelectedItem);
                    int inalisBilang = inalis.Length;
                    int indicator = inalis.IndexOf("=") + 3;
                    string inalisPrice = inalis.Substring(indicator, inalisBilang - indicator);
                    double inalisPriceDoub = double.Parse(inalisPrice);
                    total2 -= inalisPriceDoub;
                    total.Text = total2.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
                    orders.Items.RemoveAt(orders.SelectedIndex);
                }
                catch
                {

                }
            }
        }
        private void spaghettiPlatter_Click(object sender, EventArgs e)
        {
            double spaghettiPlatterPrice = 185.00;
            string spaghettiPlatterStr = spaghettiPlatterPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string spaghettiPlatter = "Spaghetti Platter@ " + spaghettiPlatterStr;
            itemDescription.Text = spaghettiPlatter;
        }

        private void enterPayment_Click(object sender, EventArgs e)
        {
            orders.Enabled = false;
            orders.Items.Add("Total = " + total2.ToString("C",CultureInfo.CreateSpecificCulture("en-PH")));
            if (total.Text != string.Empty)
            {
                
                addOrder.Enabled = false;
                total.ReadOnly = false;
                pos.Text = "Payment";
                total.Text = "";
                enterPayment.Enabled = false;
                change.Enabled = true;
                total.Focus();

            }
            else if (total.Text == string.Empty)
            {
                MessageBox.Show("BOBO BUMILI KA MUNA", "Tanga");

                
            }
                       
        }
        private void twisterCombo_Click(object sender, EventArgs e)
        {
            double twisterComboPrice = 145.00;
            string twisterComboPriceStr = twisterComboPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string twisterCombo = "Twister Combo@ " + twisterComboPriceStr;
            itemDescription.Text = twisterCombo;
        }

        private void change_Click(object sender, EventArgs e)
        {
            try
            {
                total.ReadOnly = true;
                pos.Text = "Change";
                enterPayment.Enabled = false;
                personMoney = total.Text;
                double personMoneyDouble = double.Parse(personMoney);

                final = personMoneyDouble - total2;
                if (final >= 0)
                {
                    total.Text = final.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
                    change.Enabled = false;
                    addOrder.Enabled = false;
                    anotherSale.Enabled = true;
                    total.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Kulang pera mo kung wala kang pera mag tusok tusok ka nalang hampas lupa", "pulube");
                    total.ReadOnly = false;
                    addOrder.Enabled = false;
                    total.Text = "";
                    anotherSale.Enabled = false;
                    total.Focus();

                }
            }
            catch
            {
                MessageBox.Show("BOBO NUMBER ILAGAY MO");
                total.ReadOnly = false;
                total.Text = "";
                total.Focus();
            }
        }   
        private void anotherSale_Click(object sender, EventArgs e)
        {
            pos.Text = "Sale";
            quantity.Text = "1";
            itemDescription.Text = "";
            total.Text = "";
            orders.Items.Clear();
            total2 = 0;
            personMoney ="";
            final = 0;
            anotherSale.Enabled = false;
            enterPayment.Enabled = true;
            addOrder.Enabled = true;
            orders.Enabled = true;
        }
        private void zingerCombo_Click(object sender, EventArgs e)
        {
            double zingerComboPrice = 147.00;
            string zingerComboPriceStr = zingerComboPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string zingerCombo = "Zinger Combo@ " + zingerComboPriceStr;
            itemDescription.Text = zingerCombo;
        }

        private void shotsCombo_Click(object sender, EventArgs e)
        {
            double shotsComboPrice = 106.00;
            string shotsComboPriceStr = shotsComboPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string shotsCombo = "Shots Combo@ " + shotsComboPriceStr;
            itemDescription.Text = shotsCombo;
        }

        private void twoPcMeal_Click(object sender, EventArgs e)
        {
            double twoPieceMealPrice = 190.00;
            string twoPieceMealPriceStr = twoPieceMealPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string twoPieceMeal = "2pc Meal@ " + twoPieceMealPriceStr;
            itemDescription.Text = twoPieceMeal;
        }

        private void onePcMeal_Click(object sender, EventArgs e)
        {
            double onePieceMealPrice = 130.00;
            string onePieceMealPriceStr = onePieceMealPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string onePieceMeal = "1pc Meal@ " + onePieceMealPriceStr;
            itemDescription.Text = onePieceMeal;
        }

        private void mashedPotato_Click(object sender, EventArgs e)
        {
            double mashedPotatoPrice = 38.00;
            string mashedPotatoPriceStr = mashedPotatoPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string mashedPotato = "Mashed Potato@ " + mashedPotatoPriceStr;
            itemDescription.Text = mashedPotato;
        }
        private void zingerSteak_Click(object sender, EventArgs e)
        {
            double zingerSteakPrice = 125.00;
            string zingerSteakPriceStr = zingerSteakPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string zingerSteak = "Zinger Steak@ " + zingerSteakPriceStr;
            itemDescription.Text = zingerSteak;
        }
        private void extraRice_Click(object sender, EventArgs e)
        {
            double extraRicePrice = 25.00;
            string extraRicePriceStr = extraRicePrice.ToString("C", CultureInfo.CreateSpecificCulture("en-PH"));
            string extraRice = "Extra Rice@ " + extraRicePriceStr;
            itemDescription.Text = extraRice;
        }

     
    }
}
