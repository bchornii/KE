using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pro_MVC_15_UrlRouting;

namespace UrlRouting.Tests
{
    [TestClass]
    public class RouteTest
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // create request mock
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(r => r.HttpMethod).Returns(httpMethod);

            // create response mock
            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(r => r.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);

            // create context mock
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request).Returns(mockRequest.Object);
            mockContext.Setup(r => r.Response).Returns(mockResponse.Object);

            // returns context
            return mockContext.Object;
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
            object propSet = null)
        {
            Func<object, object, bool> valCompare =
                (v1, v2) => StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            var result = valCompare(routeResult.Values["controller"], controller) &&
                         valCompare(routeResult.Values["action"], action);
            if (propSet != null)
            {
                PropertyInfo[] propertyInfo = propSet.GetType().GetProperties();
                foreach (var pInfo in propertyInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pInfo.Name) &&
                        valCompare(routeResult.Values[pInfo.Name], pInfo.GetValue(propSet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProps = null,
            string httpMethod = "GET")
        {
            // arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProps));
        }

        private void TestRouteFail(string url)
        {
            // arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // act
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // assert
            Assert.IsTrue(result?.Route == null);
        }

        [TestMethod]
        public void TestIncomingRequest()
        {
            // P1
            //// check match
            //TestRouteMatch("~/", "Home", "Index");
            //TestRouteMatch("~/Customer", "Customer", "Index");
            //TestRouteMatch("~/XCustomer/Index", "Customer", "Index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            //TestRouteMatch("~/Shop/Index", "Home", "Index");
            //TestRouteMatch("~/Shop/OldAction","Home","Index");

            //// ensure that too much or too few is fail
            //TestRouteFail("~/Admin/Index/Segment");   

            // P2
            //// check match
            ////TestRouteMatch("~/", "Home", "Index", new { id = "DefaultId" }); // when 'id' is not optional
            //TestRouteMatch("~/", "Home", "Index");
            ////TestRouteMatch("~/Customer", "Customer", "index", new { id = "DefaultId" }); // when 'id' is not optional
            //TestRouteMatch("~/Customer", "Customer", "index");
            ////TestRouteMatch("~/Customer/List", "Customer", "List", new { id = "DefaultId" }); // when 'id' is not optional
            //TestRouteMatch("~/Customer/List", "Customer", "List");

            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });

            //TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List", 
            //        new { id = "All", catchall = "Delete" });
            //TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List",
            //        new { id = "All", catchall = "Delete/Perm" });

            //// check fail
            ////TestRouteFail("~/Customer/List/All/Delete");            

            // P3
            // check match
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");
            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",
            new
            {
                id = "MyId",
                catchall = "More/Segments"
            });
            TestRouteMatch("~/Customer/Index", "Customer", "Index");
            TestRouteMatch("~/Customer/Test", "Customer", "Test");

            // check fail
            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Account/Index");
            TestRouteFail("~/Account/About");
        }
    }
}
