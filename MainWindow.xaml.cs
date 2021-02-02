using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonkeyTypeBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChromeDriver driver = new ChromeDriver();

                driver.Navigate().GoToUrl("https://monkeytype.com/");

                var letters = "";


                var words = driver.FindElements(By.XPath("/html/body/div[18]/div/div[2]/div[1]/div[1]/div[8]/div//div"));



                foreach (var word in words)
                {
                    var letterlist = word.FindElements(By.XPath(".//letter"));

                    foreach (var letter in letterlist)
                    {
                        letters += letter.Text;
                    }

                    letters += " ";
                }



                foreach (char c in letters)
                {
                    driver.FindElementById("wordsInput").SendKeys(c.ToString());
                }


                while (true)
                {
                    letters = "";
                    for (int i = 0; i < driver.FindElements(By.XPath("/html/body/div[18]/div/div[2]/div[1]/div[1]/div[8]/div//div[@class='word active']//letter")).Count; i++)
                    {
                        var letter = driver.FindElement(By.XPath($"/html/body/div[18]/div/div[2]/div[1]/div[1]/div[8]/div//div[@class='word active']//letter[{i + 1}]"));
                        letters += letter.Text;
                    }
                    letters += " ";

                    foreach (char c in letters)
                    {
                        driver.FindElement(By.XPath("/html/body/div[18]/div/div[2]/div[1]/div[1]/input")).SendKeys(c.ToString());
                    }
                }
            }
            catch
            {
                return;
            }
            
        }
    }
}
