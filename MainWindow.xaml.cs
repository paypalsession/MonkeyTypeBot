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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://monkeytype.com/");
            while (true)
            {

                var letters = "";
                for (int i = 0; i < driver.FindElementById("words").FindElement(By.XPath("//div[@class='word active']")).FindElements(By.XPath(".//letter")).Count; i++)
                {
                    var letter = driver.FindElementById("words").FindElement(By.XPath("//div[@class='word active']")).FindElement(By.XPath($".//letter[{i + 1}]"));
                    letters += letter.Text;
                }

                foreach (char c in letters)
                {
                    driver.FindElementById("words").Click();

                    driver.FindElementById("wordsInput").SendKeys(c.ToString());

                }

                driver.FindElementById("wordsInput").SendKeys(" ");

            }
        }
    }
}
