import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    logger.log('Getting Keeps', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  // async getKeepById(keepId) {
  //   const res = await api.get(`api/keeps/${keepId}`)
  //   logger.log('getting keep by id', res.data)
  // }

  async setActiveKeep(keepId) {
    // const keep = AppState.keeps.find(k => k.id == keepId)
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log('Getting Active Keep', res.data)
    AppState.activeKeep = new Keep(res.data)
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

  // FIXME rename to getVaultKeepsByVaultId
  async getVaultKeepsByVaultId(keepId) {
    const res = await api.get(`api/vaults/${keepId}`)
    logger.log('Getting VaultKeeps', res.data)
    AppState.vaultKeeps = res.data.map(vk => new VaultKeep(vk));
  }
}

export const keepsService = new KeepsService()