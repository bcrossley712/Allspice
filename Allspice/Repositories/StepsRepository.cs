using System.Collections.Generic;
using System.Data;
using System.Linq;
using Allspice.Models;
using Dapper;

namespace Allspice.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;

    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Step> GetAll()
    {
      string sql = @"
      SELECT *
      FROM steps
      ";
      return _db.Query<Step>(sql).ToList();
    }

    internal Step GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM steps i
      WHERE i.id = @id;
      ";
      return _db.QueryFirstOrDefault<Step>(sql, new { id });
    }

    internal Step Create(Step stepData)
    {
      string sql = @"
      INSERT INTO steps
      (body, sequence, recipeId)
      VALUES
      (@Body, @Sequence, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, stepData);
      stepData.Id = id;
      return stepData;
    }

    internal void Update(Step updateData)
    {
      string sql = @"
      UPDATE steps
      SET
        body = @Body,
        sequence = @Sequence
      WHERE id = @Id;
      ";
      _db.Execute(sql, updateData);
    }

    internal void Remove(int id)
    {
      string sql = @"
      DELETE FROM steps WHERE id = @id LIMIT 1;
      ";
      _db.Execute(sql, new { id });
    }
  }
}