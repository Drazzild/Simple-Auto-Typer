using System;
using System.Drawing;
using System.Windows.Forms;

namespace SAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            button2.Enabled = false;
        }

        private void zahlenbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public int randomsec(int first, int second) //Random Number generator function
        {
            int first1 = (first * 1000);
            int second1 = (second * 1000);
            Random rnd = new Random();
            int randomnumber = rnd.Next(first1, second1);
            return randomnumber;
        }

        private void timer1_Tick(object sender, EventArgs e) //Timer Shit
        {
            timer1.Interval = randomsec(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            SendKeys.Send(textBox1.Text + "{ENTER}");
        }

        private void button1_Click(object sender, EventArgs e) // Start Button
        {
            if (textBox1.Text != "")
            {
                if(textBox2.Text != "")
                {
                    if (textBox3.Text != "")
                    {
                        if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(textBox3.Text))
                        {
                            MessageBox.Show("Zahl A darf nicht größer sein als Zahl B");
                        }
                        else
                        {
                            try
                            {
                                timer1.Interval = randomsec(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                                label5.ForeColor = Color.Green;
                                label5.Text = "Aktiviert";
                                button1.Enabled = false;
                                textBox1.Enabled = false;
                                textBox2.Enabled = false;
                                textBox3.Enabled = false;
                                button2.Enabled = true;
                                timer1.Enabled = true;
                            }
                            catch
                            {
                                MessageBox.Show("Es dürfen nicht beide zahlen 0 sein");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Jo Zahl B darf nicht leer sein");
                    }
                }
                else
                {
                    MessageBox.Show("Jo Zahl A darf nicht leer sein");
                }
            }
            else
            {
                MessageBox.Show("Jo der text darf nicht leer sein");
            }
        }

        private void button2_Click(object sender, EventArgs e) // stop Button
        {
            label5.ForeColor = Color.Red;
            label5.Text = "Deaktiviert";
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button2.Enabled = false;
            timer1.Enabled = false;
        }
    }
}
