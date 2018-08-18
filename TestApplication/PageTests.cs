using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;

namespace TestApplication
{
	[TestClass]
	public class PageTests
	{
		[TestInitialize]
		public void Init()
		{
			Driver.Initialize();
		}

		[TestMethod]
		public void Can_Edit_A_Page_Test()
		{
			LoginPage.GoTo();
			LoginPage.LoginAs("root").WithPassword("novell").Login();

			ListPostsPage.GoTo(PostType.Page);
			ListPostsPage.SelectPost("Sample Page");

			Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
			Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match"); 
			

		}

		[TestCleanup]
		public void Cleanup()
		{
			Driver.Close();
		}
	}
}
