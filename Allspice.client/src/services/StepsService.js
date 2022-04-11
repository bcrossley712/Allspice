import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class StepsService {
  async addStep(stepBody) {
    const res = await api.post('api/steps', stepBody)
    logger.log('[addStep]', res.data)
    //NOTE Will I need this?
    // AppState.recipes[index].steps.push(res.data)
    AppState.activeRecipe.steps.push(res.data)
  }
}
export const stepsService = new StepsService()