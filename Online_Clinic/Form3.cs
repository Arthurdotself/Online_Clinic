﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Online_Clinic
{
    public partial class Form3 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;

        int age = 0;
        
        bool Valid_email = false;
        bool password_macth = false;
        bool gander_Checked = false;
        bool Email_available_check = false;


        string gander;

        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 a = new Form1();
            a.Show();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            // Form5 a = new Form5();
            // a.Show();
            SqlDataAdapter ska = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable mail = new DataTable();
            ska.Fill(mail);

            if (age > 16
                && kryptonTextBox1.Text != ""
                && kryptonTextBox2.Text != ""
                && kryptonTextBox3.Text != ""
                && kryptonTextBox4.Text != ""
                && kryptonTextBox5.Text != ""
                && kryptonTextBox6.Text != ""
                && kryptonTextBox7.Text != ""
                && kryptonTextBox8.Text != ""
                && password_macth == true
                && Valid_email == true
                && gander_Checked == true
                && Email_available_check == true)
            {

                if (mail.Rows[0][0].ToString() == "0")
                {
                    string userID = Guid.NewGuid().ToString("N");
                    string name = kryptonTextBox1.Text.ToString() + kryptonTextBox3.Text.ToString();
                    string email = kryptonTextBox2.Text;
                    con.Open();
                    //
                    cmd = new SqlCommand("insert into patient ([userID],[name],email,password,birthday,gender,[mobile_numbur],verificationCode )values('" + userID + "','" + name + "','" + email + "','" + kryptonTextBox5.Text + "','" + kryptonTextBox6.Text + kryptonComboBox2.SelectedValue.ToString() + kryptonTextBox7.Text + "','" + gander + "','" + kryptonTextBox8.Text + "','" + "unverified" + "')", con);
                    //

                    cmd.ExecuteNonQuery();
                    con.Close();
                    //
                    var client = new SmtpClient()
                    {
                        Host = "smtp.zoho.com",
                        EnableSsl = true,
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                    };
                    client.Send("support@awd.somee.com", email, "Welcome to AWD ", "HI " + name + "\nThank you for using AWD");
                    //


                    DialogResult dialogResult = MessageBox.Show("your account is sucssfully created!!");
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("you have to Complete the fields");
                if (kryptonTextBox1.Text == "" || kryptonTextBox3.Text == "")
                    label2.ForeColor = Color.Red;

                if (kryptonTextBox2.Text == "")
                    label1.ForeColor = Color.Red;

                // if (textBox3.Text == "")

                if (kryptonTextBox4.Text == "")
                    label3.ForeColor = Color.Red;

                if (kryptonTextBox5.Text == "")
                    label4.ForeColor = Color.Red;

                if (kryptonTextBox6.Text == "" || kryptonTextBox7.Text == "")
                    label5.ForeColor = Color.Red;

                if (age < 16)
                    label5.ForeColor = Color.Red;

                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                    label6.ForeColor = Color.Red;

                if (kryptonTextBox8.Text == "")
                    label7.ForeColor = Color.Red;

                if (kryptonTextBox4.Text != kryptonTextBox5.Text && kryptonTextBox4.Text != "")
                {
                    label12.Visible = true;

                }
                else if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox4.Text != "")
                {

                    label12.Visible = false;
                    kryptonTextBox4.ForeColor = Color.Green;
                    kryptonTextBox5.BackColor = Color.Green;
                }




            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            // label1.ForeColor = Color.Black;
        }

        private void kryptonTextBox7_TextChanged(object sender, EventArgs e)
        {
            //age = DateTime.Today.Year - dateTimePicker1.Value.Year;
            //label6.ForeColor = Color.Black;
        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void kryptonTextBox6_TextChanged(object sender, EventArgs e)
        {
            //  label5.ForeColor = Color.Black;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            gander = "male";
            gander_Checked = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            gander = "female";
            gander_Checked = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            gander = "none";
            gander_Checked = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox5_TextChanged(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox4.Text != "")
                password_macth = true;
            else
                password_macth = false;
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            //check avelabeil in Patient table
            SqlDataAdapter ska = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable mail = new DataTable();
            ska.Fill(mail);
            //check avelabeil in doctor table
            SqlDataAdapter dska = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable doctor_mail = new DataTable();
            dska.Fill(doctor_mail);
            if (kryptonTextBox2.Text.Contains('@') && kryptonTextBox2.Text.Contains("."))
            {


                if (mail.Rows[0][0].ToString() == "0" && doctor_mail.Rows[0][0].ToString() == "0")
                {
                    label10.Visible = false;
                    Email_available_check = true;
                }

                else
                {
                    label10.Visible = true;
                    Email_available_check = false;
                }
                Valid_email = true;
            }
            else
            {

                if (mail.Rows[0][0].ToString() == "0" && doctor_mail.Rows[0][0].ToString() == "0")
                {
                    label10.Visible = false;
                    Email_available_check = true;
                }
                else
                {
                    label10.Visible = true;
                    Email_available_check = false;
                }
                Valid_email = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }

        private void kryptonTextBox5_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }

        private void kryptonTextBox6_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void kryptonTextBox7_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void kryptonTextBox8_Enter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }


        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }


        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void kryptonTextBox7_Leave(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            age = (int)(DateTime.Today.Year - Convert.ToInt64(kryptonTextBox7.Text));
            label6.ForeColor = Color.Black;
        }
    }
    
}