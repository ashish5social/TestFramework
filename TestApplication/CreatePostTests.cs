using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework;

namespace TestApplication
{
	[TestClass]
	public class CreatePostTests
	{
		[TestInitialize]
		public void Init()
		{
			Driver.Initialize();
		}

		[TestMethod]
		public void Can_Create_A_Basic_Post_Test()
		{
			LoginPage.GoTo();
			LoginPage.LoginAs("root").WithPassword("novell").Login();

			NewPostPage.GoTo();
			NewPostPage.CreatePost("This is the test post title")
				.WithBody("This is the bod of new post")
				.Publish();
			NewPostPage.GoToNewPost(); 

			Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match with new post title");
		}

		[TestCleanup]
		public void Cleanup()
		{
			Driver.Close();
		}
	}
}
