import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {

  async getVaultKeepsByVaultId(vaultId) {
    AppState.vaultKeeps = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('Getting VaultKeeps', res.data)
    AppState.vaultKeeps = res.data.map(k => new Keep(k));
  }

  async createVaultKeep(vaultId) {
    const res = await api.post('api/vaultkeeps', { vaultId })
    logger.log('Creating vault keep', res.data)
    AppState.activeVault.kept++
    AppState.vaultKeeps.push(new Keep(res.data))
  }

  async removeVaultKeep(vaultKeepId) {
    const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    logger.log("deleting vaultKeep", res.data)
    AppState.activeVault.kept--
    AppState.vaultKeeps = AppState.vaultKeeps.filter(k => k.id != vaultKeepId)
  }


}

export const vaultKeepsService = new VaultKeepsService()