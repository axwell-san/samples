package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;

import java.util.List;

public class GoogleSearchPage {

    @FindBy(name = "q")
    public WebElement searchInput;

    @FindBy(css = "cite")
    public List<WebElement> searchResultsLinks;

    public GoogleSearchPage(WebDriver driver)
    {
        PageFactory.initElements(driver, this);
    }
}
