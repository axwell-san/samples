package driver;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class Driver {

    private static Driver instance;

    public static WebDriver GetBrowser() {
        if (instance == null)
        {
            instance = new Driver();
        }

        System.setProperty("webdriver.chrome.driver", instance.getClass().getClassLoader().getResource("chromedriver.exe").getFile());
        return new ChromeDriver();
    }
}
