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
            HashSet<RecipeIngredient> recipeIngredients = new HashSet<RecipeIngredient>();

            if (id == null && name == null)
            {
                throw new ArgumentNullException($"Both {nameof(id)} and {nameof(name)} are null.");
            }
            else
            {
                if (id != null && String.IsNullOrEmpty(name))
                {
                    ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Id == id);

                    if (ingredient == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(ingredient));
                    }
                }
                else if (id == null && !String.IsNullOrEmpty(name))
                {
                    ingredient = _appStorage.Ingredients.FirstOrDefault(i => i.Name == name);

                    if (ingredient == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(ingredient));
                    }
                }

                recipeIngredients = _appStorage.RecipeIngredients
                    .Where(rI => rI.IngredientId == ingredient.Id)
                    .ToHashSet();

                if (recipeIngredients == null || recipeIngredients.Count == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(recipeIngredients));
                }

                recipes = _appStorage.Recipes
                    .Where(r => recipeIngredients.Any(rI => rI.RecipeId == r.Id))
                    .ToHashSet();

                if (recipes == null || recipes.Count == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(recipes));
                }
            }

            return recipes;
        }

        public HashSet<Recipe> GetRecipesByDietary(int? id, string? name)
        {
            DietaryRestriction dietaryRestriction = null;
            HashSet<IngredientRestriction> ingredientRestrictions = new HashSet<IngredientRestriction>();
            HashSet<RecipeIngredient> recipeIngredients = new HashSet<RecipeIngredient>();
            HashSet<Recipe> recipes = new HashSet<Recipe>();

            if (id == null && name == null)
            {
                throw new ArgumentNullException($"Both {nameof(id)} and {nameof(name)} are null.");
            }
            else
            {
                if (id != null && String.IsNullOrEmpty(name))
                {
                    dietaryRestriction = _appStorage.DietaryRestrictions.FirstOrDefault(dR => dR.Id == id);

                    if (dietaryRestriction == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(dietaryRestriction));
                    }
                }
                else if (id == null & !String.IsNullOrEmpty(name))
                {
                    dietaryRestriction = _appStorage.DietaryRestrictions.FirstOrDefault(dR => dR.Name == name);

                    if (dietaryRestriction == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(dietaryRestriction));
                    }
                }

                ingredientRestrictions = _appStorage.IngredientRestrictions
                    .Where(iR => iR.DietaryRestrictionId == dietaryRestriction.Id)
                    .ToHashSet();

                if (ingredientRestrictions == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(ingredientRestrictions));
                }

                recipeIngredients = _appStorage.RecipeIngredients
                    .Where(rI => ingredientRestrictions.Any(iR => iR.IngredientId == rI.IngredientId))
                    .ToHashSet();

                if (recipeIngredients == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(recipeIngredients));
                }

                recipes = _appStorage.Recipes
                    .Where(r => recipeIngredients.Any(rI => rI.RecipeId == r.Id))
                    .ToHashSet();

                if (recipes == null || recipes.Count == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(recipes));
                }
            }

            return recipes;
        }
    }
}
