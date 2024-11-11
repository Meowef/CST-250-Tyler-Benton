using System;
using System.Windows.Forms;
/*
 * Tyler Benton
 * CST-250
 * Bradley Mauger
 * Activity 1
 * November 10, 2024 
 */
namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource carListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            carListBinding.DataSource = store.CarList;
            listBox1.DataSource = carListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization or load time tasks unnecessary here.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Car newCar = new Car
                {
                    Make = textBox1.Text,
                    Model = textBox2.Text,
                    Price = Decimal.Parse(textBox3.Text),
                    Year = int.Parse(textBox4.Text),
                };

                store.CarList.Add(newCar);
                carListBinding.ResetBindings(false);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for Price and Year.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                store.ShoppingList.Add((Car)listBox1.SelectedItem);
                ShoppingListBinding.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Please select a car to add to the shopping cart.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (store.ShoppingList.Count > 0)
            {
                decimal total = store.checkout();
                label5.Text = total.ToString("C"); // Format
            }
            else
            {
                MessageBox.Show("There are no items in your shopping cart to checkout.", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
