import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[getRecipes]', res.data)
    AppState.recipes = res.data
  }
  async createRecipe(recipeData) {
    const res = await api.post('api/recipes', recipeData)
    logger.log('[createRecipe]', res.data)
    AppState.recipes.push(res.data)
    AppState.activeRecipe = res.data
  }
}
export const recipesService = new RecipesService()