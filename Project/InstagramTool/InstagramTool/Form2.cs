using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InstagramTool
{
    public partial class Form2 : Form
    {
        private Form1 f1;
        IWebDriver driver;
        private string user;
        private string pass;
        private List<stringitem> ListUser;
        private List<stringitem> ListCmt;
        public Form2(Form1 f1, string a, string b)
        {
            InitializeComponent();
            this.f1 = f1;
            ListUser = new List<stringitem>();
            ListCmt = new List<stringitem>();
            user = a;
            pass = b;   
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void adduser_Click(object sender, EventArgs e)
        {
            ListUser.Add(new stringitem { text=userbox.Text});
            userbox.Text = string.Empty;
            griduser.DataSource = null;
            griduser.DataSource = ListUser;
        }

        private void addcmt_Click(object sender, EventArgs e)
        {
            ListCmt.Add(new stringitem { text=cmtbox.Text});
            cmtbox.Text = string.Empty;
            gridcmt.DataSource = null;
            gridcmt.DataSource = ListCmt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement user1 = driver.FindElement(By.Name("username"));
            IWebElement pass1 = driver.FindElement(By.Name("password"));
            IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button"));
            user1.SendKeys(user);
            pass1.SendKeys(pass);
            Thread.Sleep(2000);
            login.Click();
        }
    }
    public  class stringitem
    {
        public string text { get; set; }
    }
}
