using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Ingredient> GetAll()
    {
      string sql = @"
      SELECT *
      FROM ingredients
      ";
      return _db.Query<Ingredient>(sql).ToList();
    }

    internal Ingredient GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM ingredients i
      WHERE i.id = @id;
      ";
      return _db.QueryFirstOrDefault(sql, new { id });
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUES
      (@Name, @Quantity, @recipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }
  }
}