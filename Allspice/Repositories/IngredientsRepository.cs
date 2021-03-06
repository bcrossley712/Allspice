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

    internal List<Ingredient> GetAll(int id)
    {
      string sql = @"
      SELECT *
      FROM ingredients i
      WHERE i.recipeId = @id
      ";
      return _db.Query<Ingredient>(sql, new { id }).ToList();
    }

    internal Ingredient GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM ingredients i
      WHERE i.id = @id;
      ";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
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

    internal void Update(Ingredient original)
    {
      string sql = @"
      UPDATE ingredients
      SET
        name = @Name,
        quantity = @Quantity
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
    }

    internal void Remove(int id)
    {
      string sql = @"
      DELETE FROM ingredients WHERE id = @id LIMIT 1;
      ";
      _db.Execute(sql, new { id });
    }
  }
}