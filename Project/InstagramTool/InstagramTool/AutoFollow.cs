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

namespace InstagramTool
{
    public partial class AutoFollow : Form
    {
        List<int> error;
        string username;
        string password;
        public AutoFollow()
        {
            InitializeComponent();
            error = new List<int>();
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

        private void autoFollowbtn_Click(object sender, EventArgs e)
        {
            if (urlTextBox.Text == null || urlTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập url");
                return;
            }
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/");
                var userfill = driver.FindElement(By.Name("username"));
                userfill.SendKeys(username);
                var passfill = driver.FindElement(By.Name("password"));
                passfill.SendKeys(password);
                var loginBtn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button/div"));
                loginBtn.Click();

                var saveInfor = driver.FindElement(By.XPath("//button[contains(text(),'Save Info')]"));
                saveInfor.Click();

                var allowNoti = driver.FindElement(By.XPath("//button[contains(text(),'Not Now')]"));
                allowNoti.Click();
            }
            catch (Exception)
            {
                this.Focus();
                this.Activate();
                MessageBox.Show("Vui lòng kiểm tra internet hoặc thông tin tài khoản", "Đăng nhập không thành công");
                driver.Quit();
                return;
            }

            string[] input = urlTextBox.Text.Split('\n');
            List<string> urls = removeErrorUrls(input);
            int indexError;
            for (indexError = 0; indexError < urls.Count; indexError++)
            {
                try
                {
                    driver.Navigate().GoToUrl(urls[indexError]);
                    var followBtn = driver.FindElement(By.XPath("//*[text()='Follow']"));
                    followBtn.Click();
                }
                catch (Exception)
                {
                    error.Add(indexError);
                }
            }
            this.Focus();
            this.Activate();
            MessageBox.Show("Thành công " + (urls.Count - error.Count) + "\nBị lỗi " + PrintList(error));
            driver.Quit();
        }

        private void AutoFollow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
