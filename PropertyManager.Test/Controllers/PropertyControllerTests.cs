using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyManager.API.Controllers;
using PropertyManager.Core.Model;
using PropertyManager.Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PropertyManager.Test.Controllers
{
    [TestClass]
    public class PropertyControllerTests : BaseTest
    {
        [TestMethod]
        public void GetPropertyTest()
        {
            using (var controller = new PropertiesController())
            {
                var httpResult = controller.GetProperty(1) as OkNegotiatedContentResult<PropertyModel>;

                Assert.IsNull(httpResult);
            }
        }
    }
}
