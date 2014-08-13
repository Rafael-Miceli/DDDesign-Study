using System;
using FrontDesk.Web.Controllers.Api;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace FrontDeskTests
{
    [TestFixture]
    public class ClientsControllerShould
    {
        [Test]
        public void Get_All_Clients()
        {
            var clientsController = new ClientsController();

            var result = clientsController.Get();

            Assert.IsNotNull(result);
        }
    }
}
