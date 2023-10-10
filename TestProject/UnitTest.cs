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

        #region GetRecipesByIngredient
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
        #endregion

        #region GetRecipesByDietary
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

        [TestMethod] // existing Id and Name, but no sequence found, mismatch/invalid parameter
        public void GetRecipesByDietary_InvalidParameters_ThrowsInvalidOperationException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1;
            string dietaryName = "Vegan";

            // act and assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, dietaryName);
            });
        }

        [TestMethod] // have DietaryRestrictions, but doesn't have IngredientRestrictions 
        public void GetRecipesByDietary_IngredientRestricionsNullOrEmpty_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 1111;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);
            });
        }

        [TestMethod] // have DietaryRestrictions and IngredientRestrictions, but doesn't have RecipeIngredients
        public void GetRecipesByDietary_RecipeIngredientsNullOrEmpty_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 2222;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);
            });
        }

        [TestMethod] // have DietaryRestrictions, IngredientRestrictions and RecipeIngredients, but doesn't have Recipe
        public void GetRecipesByDietary_RecipeNullOrEmpty_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int dietaryId = 3333;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipesByDietary(dietaryId, null);
            });
        }
        #endregion

        #region GetRecipes
        [TestMethod]
        public void GetRecipes_ValidId_ReturnsRecipes()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;

            // act
            HashSet<Recipe> recipes = bll.GetRecipes(recipeId, null);

            // assert
            int expectedResult = 1;
            int actualResult = recipes.Count();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetRecipes_ValidName_ReturnsRecipes()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "Salmon";

            // act
            HashSet<Recipe> recipes = bll.GetRecipes(null, recipeName);

            // assert
            int expectedResult = 2;
            int actualResult = recipes.Count();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetRecipes_InvalidId_ThrowsArgumentOutOfRange()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 0;

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipes(recipeId, null);
            });
        }

        [TestMethod]
        public void GetRecipes_InvalidName_ThrowsArgumentOutOfRange()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            string recipeName = "Invalid Name";

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipes(null, recipeName);
            });
        }

        [TestMethod]
        public void GetRecipes_NullParameters_ThrowsArgumentNullException()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();

            // act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipes(null, null);
            });
        }

        [TestMethod]
        public void GetRecipes_InvalidParameters_ThrowsArgumentOutOfRange()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            int recipeId = 1;
            string recipeName = "Chicken Alfredo";

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                HashSet<Recipe> recipes = bll.GetRecipes(recipeId, recipeName);
            });
        }
        #endregion

        #region
        [TestMethod]
        public void CreateRecipe_ValidParameter_PostRecipe()
        {
            // arrange
            BusinessLogicLayer bll = _initializeBusinessLogic();
            
            CreateRecipe createRecipe = new CreateRecipe()
            {
                Name = "Test Recipe",
                Description = "Post recipe",
                Servings = 1,
                Ingredients = { new Ingredient() { Name = "Pineapple" } }
            };

            string ingredientName = "Pineapple";

            // act
            bll.CreateRecipe(createRecipe);
            HashSet<Recipe> recipes = bll.GetRecipesByIngredients(null, ingredientName);

            // assert
            int expectedResult = 1;
            int actualResult = recipes.Count();
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion
    }
}