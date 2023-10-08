using UnitTestingA1Base.Models;

namespace UnitTestingA1Base.Data
{
    public class BusinessLogicLayer
    {
        private AppStorage _appStorage;

        public BusinessLogicLayer(AppStorage appStorage)
        {
            _appStorage = appStorage;
        }

        public HashSet<Recipe> GetRecipesByIngredients(int? id, string? name)
        {
            Ingredient ingredient = null;
            HashSet<Recipe> recipes = new HashSet<Recipe>();

            if (id == null && name == null)
            {
                throw new ArgumentNullException($"Both {nameof(id)} and {nameof(name)} are null.");
            }
            else
            {
                if (id != null && String.IsNullOrEmpty(name))
                {
                    ingredient = _appStorage.Ingredients.First(i => i.Id == id);
                }
                else if (id == null && !String.IsNullOrEmpty(name))
                {
                    ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name == name);
                }

                if (ingredient == null)
                {
                    throw new ArgumentNullException(nameof(ingredient));
                }
                else
                {
                    HashSet<RecipeIngredient> recipeIngredients = _appStorage.RecipeIngredients
                        .Where(rI => rI.IngredientId == ingredient.Id)
                        .ToHashSet();

                    recipes = _appStorage.Recipes
                        .Where(r => recipeIngredients.Any(rI => rI.RecipeId == r.Id))
                        .ToHashSet();
                }
            }

            return recipes;
        }
    }
}
