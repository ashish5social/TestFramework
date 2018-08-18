using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
	public class DashboardPage
	{
		public static bool IsAt
		{
			get
			{
				var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
				IReadOnlyCollection<IWebElement> h1s = wait.Until(driver => driver.FindElements(By.TagName("h1")));
				//var elements = wait.Until(condition =>
				//{
				//	try
				//	{
				//		var elementToBeDisplayed = Driver.Instance.FindElements(By.TagName("h2"));
				//		return elementToBeDisplayed; 
				//	}
				//	catch (StaleElementReferenceException)
				//	{
				//		return false;
				//	}
				//	catch (NoSuchElementException)
				//	{
				//		return false;
				//	}
				//});


				//var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
				//wait.Until(ExpectedConditions.ElementExists((By.TagName("h2")))); 
				//wait.Until(d => d.SwitchTo().ActiveElement(). GetAttribute("id") == "user_login");
				//var h2s = Driver.Instance.FindElements(By.TagName("h2"));
				if (h1s.Count > 0)
				{
					//If there is an element with tag=h2 and having text as "Dashboard", then return true, else, return false. 
					return h1s.ElementAt<IWebElement>(0).Text == "Dashboard"; 

					//return h2s.GetEnumerator().Current.Text == "Dashboard";
				}
				else
				{
					return false; 
				}
			}

		}
	}
}
