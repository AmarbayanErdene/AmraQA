using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        // open chrome browser
        IWebDriver driver = new ChromeDriver();

        // launch turnup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // identify username textbox and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        // identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        // click login button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);

        // check if user has loggen in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello hari!") 
        {
            Console.WriteLine("User has logged in successfully");
        }
        else
        {
            Console.WriteLine("User has not logged in");
        }

        // Create new record

        // navigate to TM page
        IWebElement administrationtab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationtab.Click();

        IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        tmOption.Click();

        // click on create new button
        IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createnewButton.Click();

        // select time from dropdown list
        IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        typecodeDropdown.Click();
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        timeOption.Click();
        // input code
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("May2023");
        // input description
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("May2023");

        // input price per unit
        IWebElement price = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        price.SendKeys("3000");
        // click on save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);

        // navigate to the last page
        IWebElement lastpage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastpage.Click();
        Thread.Sleep(3000);

        // check if record is present in the table
        IWebElement newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newcode.Text == "May2023")
        {
            Console.WriteLine("Time record created successfully");
        }
        else
        {
            Console.WriteLine("Time records has not been created successfully");
        }

    }
}