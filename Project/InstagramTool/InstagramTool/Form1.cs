using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace InstagramTool
{
    public partial class Form1 : Form
    {
        public static IWebDriver driver;
        public static bool IsLogin = false;
        public static string username;
        public static string password;


        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (username == null || username == "" || password == null || password == "")
                {
                    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu");
                    return;
                }
                driver = new ChromeDriver();

                driver.Navigate().GoToUrl("https://www.instagram.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                IWebElement user = driver.FindElement(By.Name("username"));
                IWebElement pass = driver.FindElement(By.Name("password"));
                //IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement login = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button")));
                user.SendKeys(username_box.Text);
                pass.SendKeys(password_box.Text);
                login.Click();
                try
                {
                    //var saveInfor = driver.FindElement(By.XPath("//button[contains(text(),'Save info')]"));
                    var saveInfor = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Save info')]")));
                    IsLogin = true;
                    this.Activate();
                    MessageBox.Show("Đăng nhập thành công");
                }
                catch
                {
                    IsLogin = false;
                }
            }
            catch
            {
                this.Activate();
                MessageBox.Show("Xảy ra lỗi khi đăng nhập");
            }
        }



        private void autotimbtn_Click(object sender, EventArgs e)
        {
            // First load
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            try
            {
                foreach (string line in urlTextBox.Lines)
                {
                    driver.Navigate().GoToUrl(line);
                    Thread.Sleep(5000);
                    IWebElement divElement = driver.FindElement(By.XPath("/html/body/div[2]"));
                    string userID = divElement.GetAttribute("id");
                    IWebElement selectPost = driver.FindElement(By.XPath("//*[@id=\"" + userID + "\"]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[3]/article/div/div/div[1]/div[1]/a"));
                    selectPost.Click();
                    Thread.Sleep(3000);
                    IWebElement nextButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button"));
                    IWebElement timButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));
                    IWebElement isLiked = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div/div/span"));
                    while (nextButton.Displayed)
                    {
                        try
                        {

                            if (isLiked.FindElement(By.TagName("svg")).GetAttribute("aria-label").Contains("Like"))
                            {
                                timButton.Click();
                            }

                            Thread.Sleep(2000);
                            nextButton.Click();

                            nextButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button"));

                            timButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));
                            isLiked = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div/div/span"));

                        }
                        catch (NoSuchElementException)
                        {
                            try
                            {
                                timButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div"));
                                isLiked = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div/div/span"));
                                if (isLiked.FindElement(By.TagName("svg")).GetAttribute("aria-label").Contains("Like"))
                                {
                                    timButton.Click();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Element not found");
                            }
                            break;
                        }
                        catch
                        {

                            break;
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
            {
                driver.Quit();
            }

        }
        private void CrawlImage_btn_Click(object sender, EventArgs e)
        {
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                MessageBox.Show("Chưa chọn thư mục lưu ảnh");
                return;
            }
            foreach (string line in urlTextBox.Lines)
            {
                try
                {
                    driver.Navigate().GoToUrl(line);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); break; }
                Thread.Sleep(5000);
                int postCount = 1;
                IWebElement user = driver.FindElement(By.XPath("//header//section//h2"));
                string username = user.Text;
                IList<IWebElement> postElements = driver.FindElements(By.XPath("//article//a"));
                postElements[0].Click();
                try
                {
                    postCount = 1;
                    //Nếu không phải post cuối cùng
                    IWebElement nextButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button"));
                    while (nextButton.Displayed)
                    {
                        try
                        {
                            EachImage(username, postCount, folderDialog);
                            nextButton.Click();
                            Thread.Sleep(2000);
                            postCount++;
                            nextButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button"));
                        }
                        catch (NoSuchElementException)
                        {
                            //Post cuối cùng
                            EachImage(username, postCount, folderDialog);
                            SendKeys.Send("{ESC}");
                            MessageBox.Show("Tải về thành công");
                            break;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                catch (NoSuchElementException)
                {
                    //Post cuối cùng
                    EachImage(username, postCount, folderDialog);
                    SendKeys.Send("{ESC}");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            MessageBox.Show("Tải về thành công");
        }
        public void EachImage(string username, int postCount, FolderBrowserDialog folderDialog)
        {
            string lastImg = "";
            int imageCount = 1;
            try
            {
                IWebElement nextImgButton;
                if (postCount == 1)
                {
                    nextImgButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[1]/div/div[1]/div[2]/div/button/div"));
                }
                else
                    nextImgButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[1]/div/div[1]/div[2]/div/button/div"));
                try
                {

                    while (nextImgButton.Displayed)
                    {
                        try
                        {
                            Thread.Sleep(2000);
                            if (imageCount == 1)
                            {
                                IList<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@role='dialog']//article[@role='presentation']//li[@class='_acaz']//div[@role='button']//div[@class='_aagv']//img"));
                                string imageUrl = imageElements[0].GetAttribute("src");
                                lastImg = imageUrl;
                                if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram"))
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        string fileName = $"{username}_post_{postCount}_image_{imageCount}.jpg";
                                        string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                                        client.DownloadFile(new Uri(imageUrl), filePath);
                                        imageCount++;
                                    }
                                }
                            }
                            else
                            {
                                string imageUrl;
                                IList<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@role='dialog']//article[@role='presentation']//li[@class='_acaz']//div[@role='button']//div[@class='_aagv']//img"));
                                for (int i = 0; i < imageElements.Count(); i++)
                                {
                                    imageUrl = imageElements[i].GetAttribute("src");
                                    if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram")
                                        && imageUrl == lastImg)
                                    {
                                        using (WebClient client = new WebClient())
                                        {
                                            imageUrl = imageElements[i + 1].GetAttribute("src");
                                            string fileName = $"{username}_post_{postCount}_image_{imageCount}.jpg";
                                            string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                                            client.DownloadFile(new Uri(imageUrl), filePath);
                                            imageCount++;
                                            lastImg = imageUrl;
                                            break;
                                        }
                                    }
                                }
                            }
                            nextImgButton.Click();

                            //post đầu tiên
                            if (postCount == 1)
                                nextImgButton = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[1]/div/div[1]/div[2]/div/button[2]"));
                            else
                                nextImgButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[1]/div/div[1]/div[2]/div/button[2]/div"));

                        }
                        catch (NoSuchElementException)
                        {
                            //Ảnh cuối cùng
                            try
                            {
                                IList<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@role='dialog']//article[@role='presentation']//li[@class='_acaz']//div[@role='button']//div[@class='_aagv']//img"));
                                string imageUrl = imageElements[imageElements.Count() - 1].GetAttribute("src");
                                if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram"))
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        string fileName = $"{username}_post_{postCount}_image_{imageCount}.jpg";
                                        string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                                        client.DownloadFile(new Uri(imageUrl), filePath);
                                        imageCount++;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message); break;
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (NoSuchElementException)
            {
                //Co duy nhat 1 anh1    `
                try
                {
                    IList<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@role='dialog']//article[@role='presentation']//div[@role='button']//div[@class='_aagv']//img"));
                    string imageUrl = imageElements[0].GetAttribute("src");
                    if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram"))
                    {
                        using (WebClient client = new WebClient())
                        {
                            string fileName = $"{username}_post_{postCount}_image_{imageCount}.jpg";
                            string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                            client.DownloadFile(new Uri(imageUrl), filePath);
                            imageCount++;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void username_box_TextChanged(object sender, EventArgs e)
        {
            username = username_box.Text;
        }

        private void password_box_TextChanged(object sender, EventArgs e)
        {
            password = password_box.Text;
        }

        private void autocmtbtn_Click(object sender, EventArgs e)
        {
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            else
            {
                Form2 f2 = new Form2(this, driver);
                this.Hide();
                f2.Show();
            }

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            try
            {
                if (driver != null && driver.WindowHandles.Count == 0)
                {
                    IsLogin = false;
                }
            }
            catch
            {
                IsLogin = false;
                //DialogResult result = MessageBox.Show("Bạn có muốn chạy lại?", "Xảy ra lỗi khi chạy Browser", MessageBoxButtons.YesNo);
                //if (result == DialogResult.Yes)
                //    button1_Click(sender, e);
                //else
                //{
                driver.Quit();
                driver = null;
                //}
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void userfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog getFile = new OpenFileDialog();
            getFile.Filter = "Tệp văn bản (*.txt)|*.txt";
            getFile.Title = "Chọn file txt chứa link user";
            if (getFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    urlTextBox.Text = File.ReadAllText(getFile.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra khi nhập từ file. Vui lòng thử lại!");
                }
            }
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
            List<int> error = new List<int>();
            if (Form1.IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            if (urlTextBox.Text == null || urlTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập url");
                return;
            }
            string[] input = urlTextBox.Text.Split('\n');
            List<string> urls = removeErrorUrls(input);
            int indexError;
            for (indexError = 0; indexError < urls.Count; indexError++)
            {
                try
                {
                    if (driver == null)
                    {
                        MessageBox.Show("Có lỗi xảy ra vui lòng thực hiện lại");
                    }
                    try
                    {
                        driver.Navigate().GoToUrl(urls[indexError]);
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        IWebElement followBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Follow']")));

                        followBtn.Click();
                        Thread.Sleep(2000);
                        error.Add(indexError);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi ở followbtn");
                    }


                }
                catch (Exception)
                {
                    error.Add(indexError);
                }
            }
            this.Activate();
            if (error.Count != 0)
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count + "\nBị lỗi ở url: " + PrintList(error));
            else
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count);
        }
    }
}
