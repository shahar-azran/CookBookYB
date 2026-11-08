using WSCookBook.ORM.ModelCreator;

namespace WSCookBook.ORM
{
    public class UOWModelCreator
    {
        CatagoriesCreator catagoriesCreator;
        IngredientCreator ingredientCreator;
        LikedRecipeCreator likedRecipeCreator;
        RatingCreator ratingCreator;
        RecipesCreator recipesCreator;
        UnitCreator unitCreator;
        UserCreator userCreator;

        public CatagoriesCreator CatagoriesCreator
        {
            get
            {
                if (this.catagoriesCreator == null)
                {
                    this.catagoriesCreator = new CatagoriesCreator();
                }
                return this.catagoriesCreator;
            }
        }
        public IngredientCreator IngredientCreator
        {
            get
            {
                if (this.ingredientCreator == null)
                {
                    this.ingredientCreator = new IngredientCreator();
                }
                return this.ingredientCreator;
            }
        }
        public LikedRecipeCreator LikedRecipeCreator
        {
            get
            {
                if (this.likedRecipeCreator == null)
                {
                    this.likedRecipeCreator = new LikedRecipeCreator();
                }
                return this.likedRecipeCreator;
            }
        }
        public RatingCreator RatingCreator
        {
            get
            {
                if (this.ratingCreator == null)
                {
                    this.ratingCreator = new RatingCreator();
                }
                return this.ratingCreator;
            }
        }
        public RecipesCreator RecipesCreator
        {
            get
            {
                if (this.recipesCreator == null)
                {
                    this.recipesCreator = new RecipesCreator();
                }
                return this.recipesCreator;
            }
        }
        public UnitCreator UnitCreator
        {
            get
            {
                if (this.unitCreator == null)
                {
                    this.unitCreator = new UnitCreator();
                }
                return this.unitCreator;
            }
        }
        public UserCreator UserCreator
        {
            get
            {
                if (this.userCreator == null)
                {
                    this.userCreator = new UserCreator();
                }
                return this.userCreator;
            }
        }


    }
}
