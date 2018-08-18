using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;

namespace TestApplication
{
	[TestClass]
	public class LoginTests
	{
		[TestInitialize]
		public void Init()
		{
			Driver.Initialize(); 
		}


		[TestMethod]
		public void Admin_User_Can_Login_Test()
		{
			LoginPage.GoTo();
			LoginPage.LoginAs("root").WithPassword("novell").Login();
			Assert.IsTrue(DashboardPage.IsAt, "Failed to login"); 
		}

		[TestCleanup]
		public void Cleanup()
		{
			//added this to github 
			Driver.Close(); 
		}
	}
}
