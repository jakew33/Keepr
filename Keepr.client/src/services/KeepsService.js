import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {


  async getAllKeeps() {
    const res = await api.get('api/keeps')
    logger.log('Getting Keeps', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async setActiveKeep(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log('Getting Active Keep', res.data)
    AppState.activeKeep = new Keep(res.data)
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('[Creating Keep]', res.data)
    AppState.keeps.unshift(new Keep(res.data))
  }


  // async getMyKeeps() {
  //   const res = await api.get(`account/keeps`)
  //   logger.log("Getting MyKeeps", res.data)
  //   AppState.myKeeps = res.data.map(k => new Keep(k))
  //   logger.log(AppState.myKeeps)
  // }

  async saveKeep(keepData) {
    const res = api.post('api/keeps', keepData)
    logger.log(res.data)
    AppState.myKeeps.push(new Keep(res.data))
    AppState.activeVaultKeep.kept++
  }
  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
    AppState.activeVaultKeep.kept--
    logger.log('[Deleting Keep]', res.data)
  }

}

export const keepsService = new KeepsService()