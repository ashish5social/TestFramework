using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFramework
{
	public class NewPostPage
	{
		public static  string Title {
			get
			{
				var title = Driver.Instance.FindElement(By.Id("title"));
				if (title != null)
					return title.GetAttribute("value");
				return String.Empty; 
			}

		}

		public static void GoTo()
		{
			var menuPosts = Driver.Instance.FindElement(By.Id("wp-admin-bar-new-content"));
			menuPosts.Click();  

		}

		public static CreatePostCommand CreatePost(string title)
		{

			return new CreatePostCommand(title); 
		}

		public static void GoToNewPost()
		{
			var message = Driver.Instance.FindElement(By.Id("message"));
			var newPostLink = message.FindElements(By.TagName("a"))[0];
			newPostLink.Click(); 
		}

		public static bool IsInEditMode()
		{
			return Driver.Instance.FindElement(By.ClassName("wp-heading-inline"))  != null; 
		}
	}

	public class CreatePostCommand
	{
		private string body;

		public void Publish()
		{
			Driver.Instance.FindElement(By.Id("title")).SendKeys(title);
			Driver.Instance.SwitchTo().Frame("content_ifr");
			Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
			Driver.Instance.SwitchTo().DefaultContent();

			Thread.Sleep(1000);
			Driver.Instance.FindElement(By.Id("publish")).Click(); 
		}

		private readonly string title;

		public CreatePostCommand(string title)
		{
			this.title = title;
		}

		public CreatePostCommand WithBody(string body)
		{
			this.body = body;
			return this; 
		}
	}
}
