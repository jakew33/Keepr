import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('[Creating Vault]', res.data)
    AppState.myVaults.unshift(new Vault(res.data))
  }

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log('get vault by id', res.data)
    AppState.activeVault = new Vault(res.data)
  }
  async getVaultsByProfile(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log("[getting profile Vaults]", res.data)
    AppState.activeProfileVaults = res.data.map(v => new Vault(v))
  }
}

export const vaultsService = new VaultsService()