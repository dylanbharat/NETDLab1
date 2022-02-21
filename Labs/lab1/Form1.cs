/* Dylan Bharat
   January 21, 2021
   Lab 1 - Average units shipped
   This form will display user input in a textbox for 7 days
   and calculate the average shipped per day. The average will be displayed
   in another textbox */

using System;
using System.ComponentModel;
using System.Windows.Forms;



namespace Lab_1___Average_Units_Shipped___Dylan_Bharat
{
    public partial class Average_units_shipped : Form
    {
        // Variable
        private int counter = 1;

        public Average_units_shipped()
        {
            InitializeComponent();
        }
        // Load with the correct day label.
        private void Average_units_shipped_Load(object sender, EventArgs e)
        {
            lblDay.Text = "Day " + counter + ":";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int units = 0;

            if (counter < 8)
            {
                /* Only proceed if the input is an integer.
                       Method before did not stop an empty input from 
                       being entered. */
                try
                {
                    units = int.Parse(txtInput.Text);
                    if (units > 0)
                        lbxDisplay.Items.Add(int.Parse(txtInput.Text.Trim()));
                        counter = counter + 1;
                        lblDay.Text = "Day " + counter + ":";
                        txtInput.Clear();
                        txtInput.Focus();
                }
                catch
                {
                    MessageBox.Show("Please enter a whole number within the" +
                    " valid range");
                    txtInput.Clear();
                    txtInput.Focus();
                }
                
            }

            if (counter == 8)
            {
                txtInput.ReadOnly = true;
                btnEnter.Enabled = false;
                lblDay.Text = "Day 7:";

                // Add together each numbered entered and sotre in variable
                // total.
                int total = 0;
                for (int i = 0; i < lbxDisplay.Items.Count; i++)
                {
                    total += int.Parse(lbxDisplay.Items[i].ToString());
                }
                // Calculate the average units for the 7 days.
                double average = Math.Round((double)total / 7, 2);
                txtMessage.Text = "Average per day: " + average;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Completely reset the form.
            lbxDisplay.Items.Clear();
            counter = 1;
            lblDay.Text = "Day 1:";
            txtMessage.Clear();
            txtInput.ReadOnly = false;
            btnEnter.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            // If an entered input is not an integer or out of the valid
            // range, display error message box.
            if (txtInput.Text.Trim().Length > 0)
            {
                if (!Utility.isInterger(txtInput.Text) || 
                    !Utility.isInRange(0, 1000, txtInput.Text))
                {
                    MessageBox.Show("Please enter a whole number within" +
                        " the valid range");
                    txtInput.Clear();
                    txtInput.Focus();
                }
            }
        }
        // Display the tooltips on mouse hover.
        private void txtInput_MouseHover(object sender, EventArgs e)
        {
            ttpInput.SetToolTip(txtInput, "Enter the number of units being shipped here");
        }

        private void lbxDisplay_MouseHover(object sender, EventArgs e)
        {
            ttpDisplay.SetToolTip(lbxDisplay, "Units entered will be displayed here");
        }

        private void txtMessage_MouseHover(object sender, EventArgs e)
        {
            ttpMessage.SetToolTip(txtMessage, "The average units shipped per day will be displayed here");
        }
    }
}
