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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace InstagramTool
{
    public partial class Form2 : Form
    {
        private Form1 f1;
        IWebDriver driver;
        private Random random;
        private string user;
        private string pass;
        private List<stringitem> ListUser;
        private List<stringitem> ListCmt;
        public Form2(Form1 f1, IWebDriver c)
        {
            InitializeComponent();
            this.f1 = f1;
            ListUser = new List<stringitem>();
            ListCmt = new List<stringitem>();
   
            driver = c;

        }
        private void Form2_Activated(object sender, EventArgs e)
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void adduser_Click(object sender, EventArgs e)
        {
            ListUser.Add(new stringitem { text = userbox.Text });
            userbox.Text = string.Empty;
            griduser.DataSource = null;
            griduser.DataSource = ListUser;
        }

        private void addcmt_Click(object sender, EventArgs e)
        {
            ListCmt.Add(new stringitem { text = cmtbox.Text });
            cmtbox.Text = string.Empty;
            gridcmt.DataSource = null;
            gridcmt.DataSource = ListCmt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //
            foreach (stringitem url in ListUser)
            {

                driver.Navigate().GoToUrl(url.text);
                Thread.Sleep(2000);
                bool isEndOfPage = false;
                int x = 0;
                while (!isEndOfPage)
                {
                    int y = 0;
                    IList<IWebElement> listpost = driver.FindElements(By.XPath("//article//a"));
                    foreach (var post in listpost)
                    {
                        y++;
                        if (y >= x)
                        {
                            x++;
                            try { post.Click(); }
                            catch {  }
                            finally { Thread.Sleep(2000); }
                          
                            random = new Random();
                            int i = random.Next(0, ListCmt.Count);
                            string comment = ListCmt[i].text;
                            try
                            {
                                var commentbox = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                commentbox.SendKeys(comment);
                                Thread.Sleep(500);
                            }
                            catch
                            {
                                try
                                {
                                    var commentbox = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                    commentbox.SendKeys(comment);
                                    Thread.Sleep(500);
                                }
                                catch
                                {
                                    try
                                    {
                                        var commentbox = driver.FindElement(By.XPath("/html/body/div[8]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                        commentbox.SendKeys(comment);
                                        Thread.Sleep(500);
                                    }
                                    catch
                                    {
                                        var commentbox = driver.FindElement(By.XPath("/html/body/div[8]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/textarea"));
                                        commentbox.SendKeys(comment);
                                        Thread.Sleep(500);
                                    }

                                }
                            }
                            finally
                            {
                                Thread.Sleep(500);
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
                                var btnpost = driver.FindElement(By.XPath("/html/body/div[8]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[3]/div/form/div/div[2]"));
                                btnpost.Click();
                                Thread.Sleep(2000);
                            }
                            finally
                            {
                                Thread.Sleep(500);
                            }
                            try
                            {
                                var close = driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[2]"));
                                close.Click();
                                Thread.Sleep(500);
                            }
                              catch
                            {
                                var close = driver.FindElement(By.XPath("/html/body/div[8]/div[1]/div/div[2]"));
                                close.Click();
                                Thread.Sleep(500);
                            }  
                            finally
                            {
                                Thread.Sleep(100);
                            }

                            }
                    }
                    try
                    {
                        // Cuộn trang xuống dưới (đây là một ví dụ, bạn có thể cần điều chỉnh cho phù hợp)
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

                        // Đợi một khoảng thời gian trước khi lấy các phần tử tiếp theo
                        Thread.Sleep(1000); // Hoặc có thể sử dụng WebDriverWait để đợi sự kiện cụ thể
                    }
                    catch (Exception)
                    {
                        isEndOfPage = true; // Đánh dấu kết thúc trang khi không thể cuộn nữa
                    }



                }
            }
        }
    }
    public  class stringitem
    {
        public string text { get; set; }
    }
}

