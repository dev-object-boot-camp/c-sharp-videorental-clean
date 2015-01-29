using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using video_rental.Controllers;
using video_rental.Models;
using video_rental.Models.Comparer;
using video_rental.Models.Repositories;

namespace video_rental_test.Controllers
{
   [TestFixture]
   public class LoginControllerTest
   {
       private LoginController loginController;
       private ICustomerRepository mockCustomerRepository;

       [SetUp]
       public void Setup()
       {
           mockCustomerRepository = MockRepository.GenerateMock<ICustomerRepository>();
           loginController = new LoginController(mockCustomerRepository);
       }

       [Test]
       public void Index_ShouldReturnModelAndViewForLoginPage(){

        HashSet<Customer> customerList = new HashSet<Customer>();
        mockCustomerRepository.Expect(x => x.SelectAll(Arg<CustomersOrderedByNameComparator>.Is.Anything)).Return(customerList); //here any() is OK since the class does not really have state

        ActionResult result = loginController.Index();

        var viewResult = result as ViewResult;
        Assert.NotNull(viewResult);
        Assert.That(viewResult.Model, Is.EqualTo(customerList));
    }
   }
}
