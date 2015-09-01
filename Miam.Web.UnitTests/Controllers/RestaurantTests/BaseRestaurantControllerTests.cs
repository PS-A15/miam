using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.TestUtility.AutoFixture;
using Miam.Web.Controllers;
using Miam.Web.ViewModels.Restaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{

    public class BaseRestaurantControllerTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Restaurant> RestaurantRepository;
        protected IEntityRepository<Review> ReviewRepository;
        
        protected RestaurantController RestaurantController;

        protected Fixture _fixture;


        [TestInitialize]
        public void AdminControllerTestInit()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            RestaurantRepository = Substitute.For<IEntityRepository<Restaurant>>();
            ReviewRepository = Substitute.For<IEntityRepository<Review>>();

            RestaurantController = new RestaurantController(RestaurantRepository);
        }
    }

    
}