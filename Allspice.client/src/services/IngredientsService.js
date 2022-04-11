import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {
  async addIngredient(ingredientBody) {
    const res = await api.post('api/ingredients', ingredientBody)
    logger.log('[addStep]', res.data)
    AppState.activeRecipe.ingredients.push(res.data)
  }
}
export const ingredientsService = new IngredientsService()