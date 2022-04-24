using System.Data;
using System.Linq;
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

    internal Favorite Get(string accountId, int recipeId)
    {
      string sql = @"
      SELECT
      f.*
      FROM favorites f
      WHERE f.accountId = @accountId AND f.recipeId = @recipeId
      ";
      return _db.Query<Favorite>(sql, new { accountId, recipeId }).FirstOrDefault();
    }

    internal RecipeViewModel FindNewFav(Favorite favoriteData)
    {
      string sql = @"
      SELECT
      a.*,
      r.*,
      f.id AS favoriteId
      FROM favorites f
      JOIN accounts a ON f.accountId = a.id
      JOIN recipes r ON f.recipeId = r.id
      WHERE f.id = @id
      ";
      return _db.Query<Account, RecipeViewModel, RecipeViewModel>(sql, (a, r) =>
      {
        r.Creator = a;
        return r;
      }, favoriteData).FirstOrDefault();
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