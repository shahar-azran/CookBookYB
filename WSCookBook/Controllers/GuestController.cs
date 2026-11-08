using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO_Library.ViewModels;
using WSCookBook.ORM.Repositories;
using WSCookBook.ORM;

namespace WSCookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        DBContext dbContext;
        UOWRepository uOWRepository;
        UOWModelCreator uOWModelCreator;
        public GuestController()
        {
            this.dbContext = new DBContext();
            this.uOWModelCreator = new UOWModelCreator();
            this.uOWRepository = new UOWRepository(this.dbContext, this.uOWModelCreator);

        }
        [HttpGet]
        public AllRecipesViewModel GetAllRecipesViewModel(int page = 0, int currentCatId = 0)
        {
            AllRecipesViewModel allRecipesViewModel = new AllRecipesViewModel();
            if (page == 0 && currentCatId == 0)
            {
                allRecipesViewModel.Page = 1;
                allRecipesViewModel.recipesPerPage = 6;
                allRecipesViewModel.RecipeCatagories = uOWRepository.CatagoriesRepository.SelectAll();
                allRecipesViewModel.Recipes = uOWRepository.RecipeRepository.GetRecipeByPage(allRecipesViewModel.Page, allRecipesViewModel.recipesPerPage);
                allRecipesViewModel.currentCatId = currentCatId;
                allRecipesViewModel.PageCount = uOWRepository.RecipeRepository.AllRecipes / allRecipesViewModel.recipesPerPage;
                if (uOWRepository.RecipeRepository.AllRecipes % allRecipesViewModel.recipesPerPage > 0)
                {
                    allRecipesViewModel.PageCount++;
                }
            }
            return allRecipesViewModel;
        }
    }
}
