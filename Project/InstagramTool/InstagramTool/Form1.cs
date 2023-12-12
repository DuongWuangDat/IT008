using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
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
        private Random random;
        private int curent;
        private int max;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        private bool IsClosedBrowser(IWebDriver driver)
        {
            try
            {
                return (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.hidden");
            }
            catch (Exception)
            {
                return true;
            }
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
                    By saveInfoBy = By.XPath("//button[contains(text(),'Save info')]");

                    Func<IWebDriver, IWebElement> saveInfoCondition = (d) =>
                    {
                        try
                        {
                            if (d.WindowHandles.Count == 0)
                            {
                                return null; // No open window, return null
                            }
                            IWebElement element = d.FindElement(saveInfoBy);
                            if (element == null)
                                return null;
                            else
                                return element.Displayed ? element : null;
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    };

                    IWebElement saveInfoElement = wait.Until(saveInfoCondition);

                    if (saveInfoElement != null)
                    {
                        IsLogin = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    IsLogin = false;
                }
            }
            catch
            {
                IsLogin = false;
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
                progressBar1.Value = 0;
                toollabel.Text = "Auto tim";
                max = user_RichTb.Lines.Count();
                if (max > 0)
                {
                    maxlabel.Text = max.ToString();
                }
                curent = 0;
                foreach(string line in user_RichTb.Lines)
                {
                    
                    
                    driver.Navigate().GoToUrl(line);
                    Thread.Sleep(5000);
                    IList<IWebElement> postElements = driver.FindElements(By.XPath("//article//a"));
                    postElements[0].Click();
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
                    curent++;
                    curlabel.Text = curent.ToString();
                    progressBar1.Value = (curent * 100) / max;
                }
                MessageBox.Show("Đã xong");
                curlabel.Text = "";
                maxlabel.Text = "";
                
            }
            catch
            {
                curent++;
                curlabel.Text = curent.ToString();
                progressBar1.Value = (curent * 100) / max;
                MessageBox.Show("Xảy ra lỗi");
                curlabel.Text = "";
                maxlabel.Text = "";
                progressBar1.Value = 0;

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
            progressBar1.Value = 0;
            toollabel.Text = "Crawl image";
            max = user_RichTb.Lines.Count();
            if (max > 0)
            {
                maxlabel.Text = max.ToString();
            }
            curent = 0;
            foreach (string line in user_RichTb.Lines)
            {
                try
                {
                    
                    driver.Navigate().GoToUrl(line);
                }
                catch (NullReferenceException ex) { MessageBox.Show(ex.Message); }
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
                curent++;
                curlabel.Text = curent.ToString();
                progressBar1.Value = (curent * 100) / max;
            }
                    MessageBox.Show("Tải về thành công");
            curlabel.Text = "";
            maxlabel.Text = "";
            progressBar1.Value = 0;

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
                    bool check = false;
                    try
                    {
                        check = nextImgButton.Displayed;
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                    while (check)
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
                            if(postCount==1)
                                try
                                {
                                    check = nextImgButton.Displayed;
                                }
                                catch(Exception ex) { MessageBox.Show(ex.Message); }
                            else
                                try
                                {
                                    check = nextImgButton.Displayed;
                                }
                                catch(NullReferenceException ex) { MessageBox.Show(ex.Message); }
                       
                                                   

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
                catch(Exception ex) { MessageBox.Show(ex.Message); }    
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
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
            List<string> ListCmt = new List<string>();
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            else
            {
                progressBar1.Value = 0;
                toollabel.Text = "Auto comment";
                max = user_RichTb.Lines.Count();
                if (max > 0)
                {
                    maxlabel.Text = max.ToString();
                }
                curent = 0;
                foreach (string cmt in comment_RichTb.Lines)
                    ListCmt.Add(cmt);
                foreach (string url in user_RichTb.Lines)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                    driver.Navigate().GoToUrl(url);
                    Thread.Sleep(2000);
                    int flag = 1;
                    IList<IWebElement> listpost = driver.FindElements(By.XPath("//article//a"));
                    listpost[0].Click();
                    IWebElement nextbtn = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button"));
                    while (flag == 1)
                    {
                        random = new Random();
                        int i = random.Next(0, ListCmt.Count);
                        string comment = ListCmt[i];
                        try
                        {
                            try
                            {
                                var commentbox = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                commentbox.SendKeys(comment);
                                Thread.Sleep(200);
                            }
                            catch
                            {
                                try
                                {
                                    var commentbox = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                    commentbox.SendKeys(comment);
                                    Thread.Sleep(200);
                                }
                                catch
                                {
                                    try
                                    {
                                        var commentbox = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                        commentbox.SendKeys(comment);
                                        Thread.Sleep(200);
                                    }
                                    catch
                                    {
                                        var commentbox = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                        commentbox.SendKeys(comment);
                                        Thread.Sleep(200);
                                    }

                                }
                            }
                            finally
                            {
                                Thread.Sleep(200);
                            }

                            Thread.Sleep(500);
                            try
                            {
                                var btnpost = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/div[2]"));
                                btnpost.Click();
                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                var btnpost = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/div[2]"));
                                btnpost.Click();
                                Thread.Sleep(2000);
                            }
                            finally
                            {
                                Thread.Sleep(200);
                            }
                            try
                            {

                                nextbtn.Click();
                                Thread.Sleep(500);
                            }
                            catch
                            {
                                try
                                {
                                    nextbtn = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button"));
                                    nextbtn.Click();
                                }
                                catch
                                {
                                    flag = 0;
                                }
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Đã bình luận xong");
                    }
                    else
                    { MessageBox.Show("Đã dừng bình luận"); }
                    curent++;
                    curlabel.Text = curent.ToString();
                    int value = (curent * 100) / max;
                    progressBar1.Value = value;
                }
                MessageBox.Show("Đã bình luận xong tất cả");
                curlabel.Text = "";
                maxlabel.Text = "";
                progressBar1.Value = 0;
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
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
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
            if (IsLogin == false)
            {
                MessageBox.Show("Chưa đăng nhập");
                return;
            }
            if (user_RichTb.Text == null || user_RichTb.Text == "")
            {
                MessageBox.Show("Vui lòng nhập url");
                return;
            }
            string[] input = user_RichTb.Text.Split('\n');
            List<string> urls = removeErrorUrls(input);
            int indexError;
            progressBar1.Value = 0;
            toollabel.Text = "Auto follow";
            maxlabel.Text = urls.Count.ToString();
            curlabel.Text = "0";

            for (indexError = 0; indexError < urls.Count; indexError++)
            {
                try
                {
                    if (driver != null)
                    {
                        driver.Navigate().GoToUrl(urls[indexError]);
                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                        try
                        {
                            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                            By followBy = By.XPath("//*[text()='Follow']");

                            Func<IWebDriver, IWebElement> followCondition = (d) =>
                            {
                                try
                                {
                                    if (d.WindowHandles.Count == 0)
                                    {
                                        return null;
                                    }
                                    IWebElement element = d.FindElement(followBy);
                                    if (element == null)
                                        return null;
                                    else
                                        return element.Displayed ? element : null;
                                }
                                catch (Exception)
                                {
                                    return null;
                                }
                            };

                            IWebElement followBtn = wait.Until(followCondition);

                            if (followBtn != null)
                            {
                                followBtn.Click();
                                Thread.Sleep(2000);
                                curlabel.Text = (int.Parse(curlabel.Text) + 1).ToString();
                                Invoke(new Action(() => progressBar1.Value = int.Parse(curlabel.Text) * 100 / urls.Count));
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception)
                {
                    error.Add(indexError);
                }
            }
            this.Focus();
            this.Activate();
            if (error.Count != 0)
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count + "\nBị lỗi ở url: " + PrintList(error));
            else
                MessageBox.Show("Thành công " + (urls.Count - error.Count) + "/" + urls.Count);
        }

        private void userfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog userfile = new OpenFileDialog();
            userfile.Filter = "Text Files (*.txt)|*.txt"; // Bộ lọc file chỉ cho phép chọn file .txt
            userfile.FilterIndex = 1; // Đặt bộ lọc mặc định
            if (userfile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = userfile.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    user_RichTb.AppendText(fileContent);
                    MessageBox.Show("Đã thêm file user thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog cmtfile = new OpenFileDialog();
            cmtfile.Filter = "Text Files (*.txt)|*.txt"; // Bộ lọc file chỉ cho phép chọn file .txt
            cmtfile.FilterIndex = 1; // Đặt bộ lọc mặc định
            if (cmtfile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = cmtfile.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    comment_RichTb.AppendText(fileContent);
                    MessageBox.Show("Đã thêm file comment thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file: " + ex.Message);
                }
            }
        }
    }
}
