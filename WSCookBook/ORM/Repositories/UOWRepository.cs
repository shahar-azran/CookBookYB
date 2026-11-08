namespace WSCookBook.ORM.Repositories
{
    public class UOWRepository
    {
        UserRepository userRepository;
        RecipeRepository recipeRepository;
        UnitRepository unitRepository;
        RatingRepository ratingRepository;
        LikedRecipeRepository likedRecipeRepository;
        IngredientRepository ingredientRepository;
        CatagoriesRepository catagoriesRepository;

        DBContext dBContext;
        UOWModelCreator modelCreator;

        public UOWRepository(DBContext dBContext, UOWModelCreator modelCreator)
        {
            this.dBContext = dBContext;
            this.modelCreator = modelCreator;
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.dBContext, this.modelCreator);
                }
                return this.userRepository;
            }
        }
        public RecipeRepository RecipeRepository
        {
            get
            {
                if (this.recipeRepository == null)
                {
                    this.recipeRepository = new RecipeRepository(this.dBContext, this.modelCreator);
                }
                return this.recipeRepository;
            }
        }
        public UnitRepository UnitRepository
        {
            get
            {
                if (this.unitRepository == null)
                {
                    this.unitRepository = new UnitRepository(this.dBContext, this.modelCreator);
                }
                return this.unitRepository;
            }
        }
        public RatingRepository RatingRepository
        {
            get
            {
                if (this.ratingRepository == null)
                {
                    this.ratingRepository = new RatingRepository(this.dBContext, this.modelCreator);
                }
                return this.ratingRepository;
            }
        }
        public LikedRecipeRepository LikedRecipeRepository
        {
            get
            {
                if (this.likedRecipeRepository == null)
                {
                    this.likedRecipeRepository = new LikedRecipeRepository(this.dBContext, this.modelCreator);
                }
                return this.likedRecipeRepository;
            }
        }
        public IngredientRepository IngredientRepository
        {
            get
            {
                if (this.ingredientRepository == null)
                {
                    this.ingredientRepository = new IngredientRepository(this.dBContext, this.modelCreator);
                }
                return this.ingredientRepository;
            }
        }
        public CatagoriesRepository CatagoriesRepository
        {
            get
            {
                if (this.catagoriesRepository == null)
                {
                    this.catagoriesRepository = new CatagoriesRepository(this.dBContext, this.modelCreator);
                }
                return this.catagoriesRepository;
            }
        }

        public void OpenTransaction()
        {
            this.dBContext.OpenTransaction();
        }
        public void Commit()
        {
            this.dBContext.Commit();
        }
        public void Rollback()
        {
            this.dBContext.Rollback();
        }
    }
}