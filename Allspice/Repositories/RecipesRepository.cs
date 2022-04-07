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
      string sql = "SELECT * FROM recipes";
      return _db.Query<Recipe>(sql).ToList();
    }

    internal Recipe GetById(int id)
    {
      string sql = "SELECT * FROM recipes WHERE id = @id";
      return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
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
  }
}