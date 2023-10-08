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
            int ingredientId = 6;
            int recipeCount = 2;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, null);

            // assert
            //Assert.IsNotNull(recipes);
            Assert.AreEqual(recipeCount, recipes.Count());
        }

        [TestMethod]
        public void GetRecipesByIngredient_ValidName_ReturnsRecipesWithIngredient()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Parmesan Cheese";
            int recipeIngredientCount = 2;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByIngredients(null, ingredientName);

            // assert
            Assert.AreEqual(recipeIngredientCount, recipes.Count());
        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 20;

            // act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, null);
            });

        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidName_ThrowsArgumentNullException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Banana";

            // act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(null, ingredientName);
            });
        }

        [TestMethod]
        public void GetRecipesByDietary_ValidId_ReturnsRecipesWithDietary()
        {
            // arange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1;

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);

            // assert
            int expectedResult = 3;
            int actualResult = recipes.Count();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}