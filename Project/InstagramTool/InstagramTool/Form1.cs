using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
using System.Xml.Linq;
namespace InstagramTool
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        bool IsStop = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.instagram.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IWebElement user = driver.FindElement(By.Name("username"));
                IWebElement pass = driver.FindElement(By.Name("password"));
                IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button"));
                user.SendKeys(username_box.Text);
                pass.SendKeys(password_box.Text);
                Thread.Sleep(2000);
                login.Click();
            }
            catch
            {
                MessageBox.Show("Xay ra loi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                driver.Navigate().GoToUrl(urlbox.Text);
                Thread.Sleep(5000);
                IWebElement divElement = driver.FindElement(By.XPath("/html/body/div[2]"));
                string userID = divElement.GetAttribute("id");
                IWebElement selectPost = driver.FindElement(By.XPath("//*[@id=\"" + userID + "\"]/div/div/div[2]/div/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[3]/article/div[1]/div/div[1]/div[1]/a"));
                selectPost.Click();
            }
            catch
            {
                MessageBox.Show("Xay ra loi");
            }

        }

        private void autotimbtn_Click(object sender, EventArgs e)
        {
            // First load
            IWebElement nextButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button"));
            IWebElement timButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));

            while (nextButton.Displayed && !IsStop)
            {
                try
                {
                    timButton.Click();
                    Thread.Sleep(2000);
                    nextButton.Click();

                    nextButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button"));

                    timButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));

                }
                catch (NoSuchElementException)
                {
                    try
                    {
                        timButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));
                        timButton.Click();
                    }
                    catch
                    {
                        Console.WriteLine("Element not found");
                    }
                    break;
                }
                catch
                {

                    break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
            {
                driver.Quit();
            }

        }
    }
}
