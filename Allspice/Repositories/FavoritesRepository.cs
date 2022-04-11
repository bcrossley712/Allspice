using System.Data;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Favorite GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM favorites f
      WHERE f.id = @id;
      ";
      return _db.QueryFirstOrDefault<Favorite>(sql, new { id });
    }
    internal Favorite Create(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites
      (recipeId, accountId)
      VALUES
      (@RecipeId, @AccountId);
      SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }

    internal void Remove(int id)
    {
      string sql = @"
      DELETE FROM favorites WHERE id = @id LIMIT 1;
      ";
      _db.Execute(sql, new { id });
    }

  }
}