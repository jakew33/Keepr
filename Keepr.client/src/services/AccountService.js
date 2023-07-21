import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(formData) {
    const res = await api.put('/account', { ...formData })
    AppState.account = new Account(res.data)
  }

  async getMyVaults() {
    const res = await api.get(`account/vaults`)
    logger.log("Getting MyVaults", res.data)
    AppState.myVaults = res.data.map(v => new Vault(v))
    logger.log(AppState.myVaults)
  }

  async setActiveVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log('Setting Active Vault', res.data)
    AppState.activeVault = new Vault(res.data)
  }

  async deleteMyVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    AppState.myVaults = AppState.myVaults.filter(v => v.id != vaultId)
    logger.log("deleting MyVault", res.data)

  }

}

export const accountService = new AccountService()
