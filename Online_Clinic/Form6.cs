﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Online_Clinic
{
  
    public partial class Form6 : KryptonForm
    {
       
            string email = Form1.email;
            int account_Type = Form1.account_Type;
            int verificationCode;
            bool isCheaked = false;
            SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
            SqlCommand cmd;
        
        
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label2.Text = "We have sent you the verification code to your email " + email + "\n ,please enter the code in the field below to complete the login.";

            int account_Type = Form1.account_Type;
            Random rad = new Random();
            verificationCode = rad.Next(10000000, 99999999);
            string emall = Form1.email;
            switch (account_Type)
            {
                case 0:
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE doctor SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + emall + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        var client = new SmtpClient()
                        {
                            Host = "smtp.zoho.com",
                            EnableSsl = true,
                            Port = 587,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                        };
                        client.Send("support@awd.somee.com", emall, "Please verify your email address", "Thank you for choosing Online Clinic!\nPlease write the verification code below in the app to confirm your email address \n\n" + Convert.ToString(verificationCode) + "\n\nIf you did not sign up for a Online Clinic account, please ignore this email. \nPlease feel free to contact us with any questions or comments.\nRegards,\nCustomer ServiceAWD Systems, Inc. \nhttps://awd.somee.com \nsupport@awd.somee.com");
                        break;
                    }
                case 1:
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE patient SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + emall + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        var client = new SmtpClient()
                        {
                            Host = "smtp.zoho.com",
                            EnableSsl = true,
                            Port = 587,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                        };
                        client.Send("support@awd.somee.com", emall, "Please verify your email address", "Thank you for choosing Online Clinic!\nPlease write the verification code below in the app to confirm your email address \n\n" + Convert.ToString(verificationCode) + "\n\nIf you did not sign up for a Online Clinic account, please ignore this email. \nPlease feel free to contact us with any questions or comments.\nRegards,\nCustomer ServiceAWD Systems, Inc. \nhttps://awd.somee.com \nsupport@awd.somee.com");
                        break;
                    }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string email = Form1.email;
            int account_Type = Form1.account_Type;

            switch (account_Type)
            {
                case 0:
                    {
                        SqlDataAdapter sdafw = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE verificationCode='" + kryptonTextBox1.Text + "'", con);
                        DataTable dseg = new DataTable();
                        sdafw.Fill(dseg);
                        if (dseg.Rows[0][0].ToString() == "1")
                        {
                            con.Open();
                            cmd = new SqlCommand("UPDATE doctor SET verificationCode='verified' WHERE email='" + email + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            isCheaked = true;
                            Form7 ww = new Form7();
                            ww.Show();
                            this.Hide();
                        }
                        else
                        {
                            label3.Visible = true;

                        }
                        break;
                    }
                case 1:
                    {
                        SqlDataAdapter dafw = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE verificationCode='" + kryptonTextBox1.Text + "'", con);
                        DataTable seg = new DataTable();
                        dafw.Fill(seg);
                        if (seg.Rows[0][0].ToString() == "1")
                        {
                            con.Open();
                            cmd = new SqlCommand("UPDATE patient SET verificationCode='verified' WHERE email='" + email + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            isCheaked = true;
                            Form8 qs = new Form8();
                            qs.Show();
                            this.Hide();
                        }
                        else
                        {
                            label3.Visible = true;
                        }

                        break;
                    }
            }
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isCheaked == false)
            {
                int account_Type = Form1.account_Type;
                string email = Form1.email;
                switch (account_Type)
                {
                    case 0:
                        {

                            con.Open();
                            cmd = new SqlCommand("UPDATE doctor SET verificationCode='unverified' WHERE email='" + email + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            break;
                        }
                    case 1:
                        {

                            con.Open();
                            cmd = new SqlCommand("UPDATE patient SET verificationCode='unverified' WHERE email='" + email + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();



                            break;
                        }
                }

                Application.Exit();
            } 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label2.Text = "We have sent you the verification code to your email " + email + "\n ,please enter the code in the field below to complete the login.";

            int account_Type = Form1.account_Type;
            Random rad = new Random();
            verificationCode = rad.Next(10000000, 99999999);
            string emall = Form1.email;
            switch (account_Type)
            {
                case 0:
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE doctor SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + emall + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        var client = new SmtpClient()
                        {
                            Host = "smtp.zoho.com",
                            EnableSsl = true,
                            Port = 587,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                        };
                        client.Send("support@awd.somee.com", emall, "Please verify your email address", "Thank you for choosing Online Clinic!\nPlease write the verification code below in the app to confirm your email address \n\n" + Convert.ToString(verificationCode) + "\n\nIf you did not sign up for a Online Clinic account, please ignore this email. \nPlease feel free to contact us with any questions or comments.\nRegards,\nCustomer ServiceAWD Systems, Inc. \nhttps://awd.somee.com \nsupport@awd.somee.com");
                        break;
                    }
                case 1:
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE patient SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + emall + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        var client = new SmtpClient()
                        {
                            Host = "smtp.zoho.com",
                            EnableSsl = true,
                            Port = 587,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                        };
                        client.Send("support@awd.somee.com", emall, "Please verify your email address", "Thank you for choosing Online Clinic!\nPlease write the verification code below in the app to confirm your email address \n\n" + Convert.ToString(verificationCode) + "\n\nIf you did not sign up for a Online Clinic account, please ignore this email. \nPlease feel free to contact us with any questions or comments.\nRegards,\nCustomer ServiceAWD Systems, Inc. \nhttps://awd.somee.com \nsupport@awd.somee.com");
                        break;
                    }
            }


        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter the verification eode.")
                kryptonTextBox1.Text = "";
            kryptonTextBox1.AlwaysActive = true;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

                int account_Type = Form1.account_Type;
            Random rad = new Random();
            verificationCode = rad.Next(10000000, 99999999);
            string emall = Form1.email;
            switch (account_Type)
            {
                case 0:
                    {
                        con.Open();

                        SqlCommand command = new SqlCommand("select phone_secretary from doctor where email ='" +  Form1.email + "';", con);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            label4.Text = reader.GetValue(0).ToString();
                        con.Close();
                   
                        con.Open();
                        cmd = new SqlCommand("UPDATE doctor SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + Form1.email + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

         
                        
                        var accountSid = "AC3fe9d391e490c4da8d29bec79c27be39";
                        var authToken = "a9aa0162cacc39ca5bd4b62b6c4aa37f";
                        TwilioClient.Init(accountSid, authToken);
                      
                        var messageOptions = new CreateMessageOptions(
                            new PhoneNumber("+964"+label4.Text));
                        messageOptions.MessagingServiceSid = "MG76b1eb83d3f57557f2b11fb432c5f6e0";
                        messageOptions.Body = "Online Clinic Account code   "+ Convert.ToString(verificationCode);
                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);


                        label2.Text = "We have sent you the verification code to your phone number 0" + label4.Text + "\n,please enter the code in the field below to complete the login.";

                        break;
                    }
                case 1:
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("select mobile_numbur from patient where email ='" + Form1.email + "';", con);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            label4.Text = reader.GetString(0);
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("UPDATE patient SET verificationCode='" + Convert.ToString(verificationCode) + "' WHERE email='" + emall + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        var accountSid = "AC3fe9d391e490c4da8d29bec79c27be39";
                        var authToken = "a9aa0162cacc39ca5bd4b62b6c4aa37f";
                        TwilioClient.Init(accountSid, authToken);

                        var messageOptions = new CreateMessageOptions(
                            new PhoneNumber("+964"+label4.Text));
                        messageOptions.MessagingServiceSid = "MG76b1eb83d3f57557f2b11fb432c5f6e0";
                        messageOptions.Body = "Online Clinic Account code   " + Convert.ToString(verificationCode);
                        var message = MessageResource.Create(messageOptions);
                        Console.WriteLine(message.Body);


                        label2.Text = "We have sent you the verification code to your phone number 0" + label4.Text + "\n,please enter the code in the field below to complete the login.";


                        break;
                    }



            }
        }
    }
}
