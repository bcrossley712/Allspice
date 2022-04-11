using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Recipe> GetAll()
    {
      string sql = @"
      SELECT 
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a WHERE a.id = r.creatorId
      ;";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;

      }).ToList();
    }
    internal Recipe GetById(int id)
    {
      string sql = @"
      SELECT 
      r.*,
      a.*
      FROM recipes r 
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @id";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }, new { id }).FirstOrDefault();
    }
    internal List<RecipeViewModel> GetRecipesByAccount(string id)
    {
      string sql = @"
      SELECT
      r.*,
      a.*,
      f.*
      FROM favorites f
      JOIN recipes r ON f.recipeId = r.id
      JOIN accounts a ON f.accountId = a.id
      WHERE f.accountId = @id;
      ";
      List<RecipeViewModel> recipes = _db.Query<RecipeViewModel, Account, Favorite, RecipeViewModel>(sql, (recipe, account, favorite) =>
      {
        recipe.Creator = account;
        recipe.FavoriteId = favorite.Id;
        return recipe;
      }, new { id }).ToList<RecipeViewModel>();
      return recipes;
    }
    internal Recipe Create(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes
      (title, subtitle, category, imgUrl, creatorId)
      VALUES
      (@Title, @Subtitle, @Category, @ImgUrl, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }
    internal void Update(Recipe original)
    {
      string sql = @"
      UPDATE recipes
      SET
      title = @Title,
      subtitle = @Subtitle,
      category = @Category,
      imgUrl = @ImgUrl
      WHERE id = @Id;";
      _db.Execute(sql, original);
    }
    internal void Remove(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}