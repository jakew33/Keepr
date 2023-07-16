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

  async getKeepById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log('getting keep by id', res.data)
  }

  async setActiveKeep(keepId) {
    const keep = AppState.keeps.find(k => k.id == keepId)
    logger.log('Getting Active Keep', keep)
    AppState.activeKeep = keep
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('[Creating Keep]', res.data)
    AppState.keeps.unshift(new Keep(res.data))
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
    logger.log('[Deleting Keep]', res.data)
  }
}

export const keepsService = new KeepsService()