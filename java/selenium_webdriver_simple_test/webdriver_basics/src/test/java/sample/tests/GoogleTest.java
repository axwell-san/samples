package sample.tests;

import driver.Driver;
import org.junit.*;
import org.openqa.selenium.WebDriver;
import pages.GoogleSearchPage;

public class GoogleTest {

    WebDriver browser;

    @Before
    public void Before(){
        browser = Driver.GetBrowser();
        browser.manage().window().maximize();
        browser.get("https://www.google.com");
    }

    @After
    public void After(){
        browser.quit();
    }

    @Test
    public void GoogleSearchTest()
    {
        GoogleSearchPage page = new GoogleSearchPage(browser);
        page.searchInput.sendKeys("EPAM");
        page.searchInput.submit();
        Assert.assertEquals("https://www.epam.com/", page.searchResultsLinks.iterator().next().getText());
    }
}
