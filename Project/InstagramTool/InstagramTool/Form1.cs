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
                ChromeOptions options = new ChromeOptions();
                options.SetLoggingPreference("browser", LogLevel.Off);
                options.SetLoggingPreference("driver", LogLevel.Off);
                options.SetLoggingPreference("performance", LogLevel.Off);
                driver = new ChromeDriver(options);
                
                driver.Navigate().GoToUrl("https://www.instagram.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                IWebElement user = driver.FindElement(By.Name("username"));
                IWebElement pass = driver.FindElement(By.Name("password"));
                IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div/div[3]/button"));
                user.SendKeys(username_box.Text);
                pass.SendKeys(password_box.Text);
                Thread.Sleep(2000);
                login.Click();
                Thread.Sleep(5000);
                try
                {
                    var saveInfor = driver.FindElement(By.XPath("//button[contains(text(),'Save Info')]"));
                    IsLogin = true;
                }
                catch
                {
                    IsLogin = false;
                }
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(IsLogin == false)
                {
                    MessageBox.Show("Chưa đăng nhập");
                    return;
                }

                driver.Navigate().GoToUrl(urlbox.Text);
                Thread.Sleep(5000);
                IWebElement divElement = driver.FindElement(By.XPath("/html/body/div[2]"));
                string userID = divElement.GetAttribute("id");
                IWebElement selectPost = driver.FindElement(By.XPath("//*[@id=\"" + userID + "\"]/div/div/div[2]/div/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[3]/article/div[1]/div/div[1]/div[1]/a"));
                selectPost.Click();
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi");
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
                driver.Navigate().GoToUrl(urlbox.Text);
                Thread.Sleep(5000);
                IWebElement divElement = driver.FindElement(By.XPath("/html/body/div[2]"));
                string userID = divElement.GetAttribute("id");
                IWebElement selectPost = driver.FindElement(By.XPath("//*[@id=\"" + userID + "\"]/div/div/div[2]/div/div/div/div[1]/div[1]/div[2]/div[2]/section/main/div/div[3]/article/div[1]/div/div[1]/div[1]/a"));
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
            try
            {
                driver.Navigate().GoToUrl(urlbox.Text);
            }
            catch(Exception ex){ MessageBox.Show(ex.Message); }
            Thread.Sleep(5000);
            int postCount = 1;
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
                        EachImage(postCount, folderDialog);
                        nextButton.Click();
                        Thread.Sleep(2000);
                        postCount++;
                        nextButton = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button"));
                    }
                    catch (NoSuchElementException)
                    {
                        //Post cuối cùng
                        EachImage(postCount, folderDialog);
                        SendKeys.Send("{ESC}");
                        MessageBox.Show("Tải về thành công");
                        break;
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            catch (NoSuchElementException)
            {
                //Post cuối cùng
                EachImage(postCount, folderDialog);
                SendKeys.Send("{ESC}");
                MessageBox.Show("Tải về thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void EachImage(int postCount, FolderBrowserDialog folderDialog)
        {
            string lastImg="";
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
                                    string fileName = $"post_{postCount}_image_{imageCount}.jpg";
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
                                for (int i = 0;i < imageElements.Count();i++)
                                {
                                    imageUrl = imageElements[i].GetAttribute("src");
                                    if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram")
                                        &&imageUrl==lastImg)
                                        {
                                            using (WebClient client = new WebClient())
                                            {
                                                imageUrl = imageElements[i+1].GetAttribute("src");
                                                string fileName = $"post_{postCount}_image_{imageCount}.jpg";
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
                            string imageUrl = imageElements[imageElements.Count()-1].GetAttribute("src");
                            if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("s150x150") && !imageUrl.Contains("_n.jpg?_nc_ht=instagram"))
                            {
                                using (WebClient client = new WebClient())
                                {
                                    string fileName = $"post_{postCount}_image_{imageCount}.jpg";
                                    string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                                    client.DownloadFile(new Uri(imageUrl), filePath);
                                    imageCount++;
                                }
                            }                          
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);break;
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
            catch(NoSuchElementException)
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
                            string fileName = $"post_{postCount}_image_{imageCount}.jpg";
                            string filePath = Path.Combine(folderDialog.SelectedPath, fileName);
                            client.DownloadFile(new Uri(imageUrl), filePath);
                            imageCount++;
                        }
                    }
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }    
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void autofollowbtn_Click(object sender, EventArgs e)
        {
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }

            else
            {
                AutoFollow autoFollow = new AutoFollow();
                autoFollow.Show(this);
                this.Hide();
            }
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
                if (driver == null || driver.WindowHandles.Count == 0)
                {
                    IsLogin = false;
                }
            }
            catch
            {
                // Do not thing
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
