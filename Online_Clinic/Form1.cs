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
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Online_Clinic
{
    public partial class Form1 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        
        SqlCommand cmd;

        public static string email;
        public static int account_Type = 0;

        public Form1()
        {
           InitializeComponent();
        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            for (int v = 0; v <= 4; v++)
            {
                switch (v)
                {
                    case 0:
                        try
                        {
                            SqlDataAdapter sdafw = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox1.Text + "' AND password='" + kryptonTextBox2.Text + "'", con);
                            DataTable dseg = new DataTable();
                            sdafw.Fill(dseg);
                            if (dseg.Rows[0][0].ToString() == "1")
                            {
                                account_Type = 0;
                                SqlDataAdapter sdaq = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox1.Text + "' AND verificationCode !='" + "verified" + "'", con);
                                DataTable dtddd = new DataTable();
                                sdaq.Fill(dtddd);
                                if (dtddd.Rows[0][0].ToString() == "1")
                                {
                                    //MessageBox.Show("doctor but u have to vr ur email");
                                    Form6 f = new Form6();
                                    email = kryptonTextBox1.Text;
                                    f.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Form7 fe = new Form7();
                                    email = kryptonTextBox1.Text;
                                    fe.Show();
                                    this.Hide();
                                    con.Open();
                                    cmd = new SqlCommand("UPDATE doctor SET Dstate='actve' WHERE email='" + email + "'", con);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    // "doctor and the email is vertfied"
                                }
                            }
                        }
                        catch 
                        {
                            MessageBox.Show("connection error");                        }
                        break;
                    case 1:
                        try
                        {
                            SqlDataAdapter sca = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox1.Text + "' AND password='" + kryptonTextBox2.Text + "'", con);
                            DataTable dtsx = new DataTable();
                            sca.Fill(dtsx);
                            if (dtsx.Rows[0][0].ToString() == "1")
                            {
                                account_Type = 1;
                                SqlDataAdapter sdasz = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox1.Text + "' AND verificationCode !='" + "verified" + "'", con);
                                DataTable dtddad = new DataTable();
                                sdasz.Fill(dtddad);
                                if (dtddad.Rows[0][0].ToString() == "1")
                                {
                                    //"ur patient but u have to vertfie ur email"
                                    email = kryptonTextBox1.Text;
                                    Form6 g = new Form6();
                                    g.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    email = kryptonTextBox1.Text;
                                    // patient and the email is vertfied"
                                    Form8 s = new Form8();
                                    s.Show();
                                    this.Hide();
                                }
                            }
                        } catch //(Exception ex)
                        { MessageBox.Show("connection error"); }
                        break;
                    default:
                        {

                            label3.Visible = true;

                        }
                        break;
                }
            }
            //  Form6 a = new Form6();
            //  a.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox2.Visible= false;
            kryptonTextBox2.UseSystemPasswordChar = false;
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter your email address")
                kryptonTextBox1.Text = "";
            kryptonTextBox1.AlwaysActive = true;
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter the password")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.UseSystemPasswordChar = true;
                kryptonTextBox2.AlwaysActive = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible=false;
            kryptonTextBox2.UseSystemPasswordChar = true;
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            if(kryptonTextBox2.UseSystemPasswordChar == true )
                pictureBox2.Visible = true;
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "")
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = "0afa11ba9556@tmail.ws";
            con.Open();
            cmd = new SqlCommand("UPDATE doctor SET Dstate='actve' WHERE email='" + email + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Form7 a = new Form7();
            a.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email = "test@.com";
            Form8 a = new Form8();
            a.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }
    }
}
