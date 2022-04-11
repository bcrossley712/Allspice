import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getAccountRecipes() {
    const res = await api.get('account/recipes')
    logger.log('[getAccountRecipes]', res.data)
    AppState.favorites = res.data
  }
  async editAccount(update) {
    const res = await api.put('account', update)
    AppState.account = res.data
  }
}

export const accountService = new AccountService()
