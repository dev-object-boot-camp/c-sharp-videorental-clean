using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using video_rental.Models;
using video_rental.Models.Repositories;
using video_rental.Repositories;

namespace video_rental
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container)) ;

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterInstance<ICustomerRepository>(new SetBasedCustomerRepository(new List<Customer>
        {
            new Customer("Benjamin Harrison"),
            new Customer("James Madison"),
            new Customer("Zackery Taylor")
        }));
        container.RegisterInstance<IMovieRepository>(new SetBasedMovieRepository(new List<Movie>
        {
            new Movie("Avatar"),
            new Movie("Up In The Air"),
            new Movie("Finding Nemo")
        }));
        container.RegisterInstance<IRentalRepository>(new SetBasedRentalRepository());
        container.RegisterInstance<ITransactionRepository>(new SetBasedTransactionRepository());
    }
  }
}