using UnitTestingA1Base.Data;
using UnitTestingA1Base.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        private BusinessLogicLayer _initializeBusinessLogic()
        {
            return new BusinessLogicLayer(new AppStorage());
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidId_ReturnsRecipesWithIngredient()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingridientId = 6;
            int recipeCount = 2;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingridientId, null);

            // assert
            //Assert.IsNotNull(recipes);
            Assert.AreEqual(recipeCount, recipes.Count());
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidName_ReturnsRecipesWithIngredient()
        {

        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidId_ReturnsNull()
        {

        }
    }
}