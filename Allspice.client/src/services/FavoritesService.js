import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
  async createFavorite(recipeId) {
    const res = await api.post('api/favorites', { recipeId: recipeId })
    logger.log("[createFavorite]", res.data)
    AppState.favorites.push(res.data)
  }
}
export const favoritesService = new FavoritesService()