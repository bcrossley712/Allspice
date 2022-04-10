using System.Collections.Generic;

namespace Allspice.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Category { get; set; }
    public string ImgUrl { get; set; }
    public string CreatorId { get; set; }

    //Virtual
    public Account? Creator { get; set; }
    public List<Step>? Steps { get; set; }
    public List<Ingredient>? Ingredients { get; set; }
  }
}