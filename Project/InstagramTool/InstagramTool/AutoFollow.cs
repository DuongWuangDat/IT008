using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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
                // Do not thing
            }

        }

        private void autoFollowbtn_Click(object sender, EventArgs e)
        {
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            string[] input = urlTextBox.Text.Split('\n');
            List<string> urls = removeErrorUrls(input);
            int indexError;
            for (indexError = 0; indexError < urls.Count; indexError++)
            {
                try
                {
                    driver.Navigate().GoToUrl(urls[indexError]);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                    //IWebElement followBtn = wait.Until(c => c.FindElement(By.XPath("//*[text()='Follow']")));
                    IWebElement followBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Follow']")));
                    //var followBtn = driver.FindElement(By.XPath("//*[text()='Follow']"));
                    //var followBtn = driver.FindElement(By.CssSelector("#mount_0_0_I6 > div > div > div.x9f619.x1n2onr6.x1ja2u2z > div > div > div > div.x78zum5.xdt5ytf.x1t2pt76.x1n2onr6.x1ja2u2z.x10cihs4 > div.x9f619.xvbhtw8.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1uhb9sk.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x1qjc9v5.x1oa3qoh.x1qughib > div.x1gryazu.xh8yej3.x10o80wk.x14k21rp.x17snn68.x6osk4m.x1porb0y > div:nth-child(2) > section > main > div > header > section > div.x6s0dn4.x78zum5.x1q0g3np.xs83m0k.xeuugli.x1n2onr6 > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.xmn8rco.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > div > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1i64zmx.x1n2onr6.x1plvlek.xryxfnj.x1iyjqo2.x2lwn1j.xeuugli.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > button"));
                    followBtn.Click();
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
                MessageBox.Show("Thành công " + (urls.Count - error.Count)+"/" + urls.Count + "\nBị lỗi " + PrintList(error));
            else
                MessageBox.Show("Thành công " + (urls.Count - error.Count) +"/" + urls.Count);
        }

        private void AutoFollow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
