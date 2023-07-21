import { AppState } from "../AppState.js";
import { VaultKeep } from "../models/VaultKeep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultKeepsService {

  async getVaultKeepsByVaultId(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log('Getting VaultKeeps', res.data)
    AppState.vaultKeeps = res.data.map(vk => new VaultKeep(vk));
  }

}

export const vaultKeepsService = new VaultKeepsService()