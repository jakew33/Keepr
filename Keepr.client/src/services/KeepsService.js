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

  async getKeepsByVaultId(vaultId) {
    AppState.keeps = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('getting keeps in vault', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async getKeepsByProfile(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log("[getting profile Keeps]", res.data)
    AppState.activeProfileKeeps = res.data.map(k => new Keep(k))
  }


  async saveKeep(vaultKeepData) {

    // TODO review endpoint here....
    // TODO what does the server need in order to make a vaultkeep
    const res = api.post('api/vaultKeeps', vaultKeepData)
    logger.log(res.data)
    // AppState.keeps.find(k => k.id == vaultKeepData.vaultId).kept++
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
    // AppState.activeVaultKeep.kept--
    logger.log('[Deleting Keep]', res.data)
  }

  async getMyKeeps() {
    const res = await api.get(`api/keeps`)
    logger.log("Getting MyKeeps", res.data)
    AppState.myKeeps = res.data.map(k => new Keep(k))
    logger.log(AppState.myKeeps)
  }

}


export const keepsService = new KeepsService()