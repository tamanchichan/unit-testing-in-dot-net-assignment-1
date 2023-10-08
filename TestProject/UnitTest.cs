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
        public void GetRecipesByIngredient_InvalidId_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 20;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, null);
            });

        }

        [TestMethod]
        public void GetRecipesByIngredient_InvalidName_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string ingredientName = "Banana";

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(null, ingredientName);
            });
        }

        [TestMethod]
        public void GetRecipesByIngredient_NullParameters_ThrowsArgumentNullException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();

            // act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(null, null);
            });
        }

        [TestMethod] // existing Id and Name, but no sequence found, mismatch/inalid parameter
        public void GetRecipesByIngredient_InvalidParameters_ThrowsInvalidOperationException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 1;
            string ingredientName = "Eggs";

            // act and assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, ingredientName);
            });
        }

        [TestMethod] // have Ingredient, but doesn't have RecipeIngredient
        public void GetRecipesByIngredient_RecipeIngredientNullOrEmpty_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 1111;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, null);
            });
        }

        [TestMethod] // have Ingredient and RecipeIngredient, but doesn't have Recipe
        public void GetRecipesByIngredient_RecipeNullOrEmpty_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int ingredientId = 2222;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByIngredients(ingredientId, null);
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

        [TestMethod]
        public void GetRecipesByDietary_ValidName_ReturnsRecipesWithDietary()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string dietaryName = "Vegetarian";

            // act
            HashSet<Recipe> recipes = bll.GetRecipesByDietary(null, dietaryName);

            // assert
            int expectedResult = 3;
            int actualResult = recipes.Count();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidId_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 0;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);
            });
        }

        [TestMethod]
        public void GetRecipesByDietary_InvalidName_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string dietaryName = "Invalid Name";

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(null, dietaryName);
            });
        }

        [TestMethod]
        public void GetRecipesByDietary_NullParameters_ThrowsArgumentNullException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();

            // act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(null, null);
            });
        }
    }
}