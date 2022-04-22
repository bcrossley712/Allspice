import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
  async createFavorite(recipeId) {
    const res = await api.post('api/favorites', { recipeId: recipeId })
    logger.log("[createFavorite]", res.data)
    const exists = AppState.favorites.find(f => f.recipeId == recipeId)
    if (!exists) {
      AppState.favorites.push(res.data)
    }
  }
  async deleteFavorite(recipeId, userId) {
    logger.error("Method not setup")
  }
}
export const favoritesService = new FavoritesService()