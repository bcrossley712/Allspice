import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {
  async createFavorite(recipeId) {
    const res = await api.post('api/favorites', { recipeId: recipeId })
    logger.log("[createFavorite]", res.data)
    AppState.favorites.push(res.data)
  }
  async deleteFavorite(recipeId) {
    const favorite = AppState.favorites.find(f => f.id == recipeId)
    const res = await api.delete(`api/favorites/${favorite.favoriteId}`)
    logger.log('[deleteFavorite]', res.data)
    AppState.favorites = AppState.favorites.filter(f => f.favoriteId != favorite.favoriteId)
  }
}
export const favoritesService = new FavoritesService()