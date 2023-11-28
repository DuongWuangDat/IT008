using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace InstagramTool
{
    public partial class AutoFollow : Form
    {

        string username;
        string password;
        public AutoFollow()
        {
            InitializeComponent();
            username = Form1.username;
            password = Form1.password;
        }

        private string PrintList(List<int> a)
        {
            string result = "";
            foreach (int t in a)
            {
                result += $"{(t + 1).ToString()} ";
            }
            return result;
        }
        private List<string> removeErrorUrls(string[] a)
        {
            List<string> result = new List<string>();
            foreach (var item in a)
            {
                if (item != null && item != "")
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private void AutoFl_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Form1.driver == null || Form1.driver.WindowHandles.Count == 0)
                {
                    Form1.IsLogin = false;
                    this.Owner.Show();
                    this.Close();
                }
            }
            catch
            {
                Form1.IsLogin = false;
                this.Owner.Show();
                this.Close();
            }

        }

        private void autoFollowbtn_Click(object sender, EventArgs e)
        {
            List<int> error = new List<int>();
            if (Form1.IsLogin == false)
            {
                MessageBox.Show("Vui lòng login lại");
                return;
            }
            if (urlTextBox.Text == null || urlTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập url");
                return;
            }
            IWebDriver driver = Form1.driver;

            string[] input = urlTextBox.Text.Split('\n');
            List<string> urls = removeErrorUrls(input);
            int indexError;
            for (indexError = 0; indexError < urls.Count; indexError++)
            {
                try
                {
                    driver.Navigate().GoToUrl(urls[indexError]);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                    IWebElement followBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Follow']")));
                    //followBtn.Click();
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    error.Add(indexError);
                }
            }
            this.Focus();
            this.Activate();
            if (error.Count != 0)
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count + "\nBị lỗi " + PrintList(error));
            else
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count);
        }

        private void AutoFollow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
