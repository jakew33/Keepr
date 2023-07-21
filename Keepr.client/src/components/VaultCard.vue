<template>
  <div class="card text-white bg rounded my-3">
    <router-link :to="{ name: 'VaultKeeps', params: { id: vault?.id } }">
      <img class="img-fluid rounded elevation-5" :src="vault.img" :alt="vault?.name">
    </router-link>
    <div class="card-body">
      <div class="d-flex justify-content-around p-1">
      </div>
      <p class="text-center text-dark p-2 label label-default favorite elevation-5 rounded">
        {{ vault.name }}
      </p>
    </div>
    <div v-if="vault?.creatorId == account.id" class="d-flex justify-content-around">
      <button class="btn btn-dark elevation-5 text-white" @click="deleteMyVault()">Delete Vault</button>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { vaultsService } from "../services/VaultsService.js";
import { Modal } from "bootstrap";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { router } from "../router.js";
import { accountService } from "../services/AccountService.js";

export default {
  props: {
    vault: { type: Vault, required: true }
  },
  setup(props) {

    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.activeVault),

      async setActiveVault(vaultId) {
        try {
          await vaultsService.setActiveVault(vaultId)
          Modal.getOrCreateInstance('#activeVaultCard').show()
        } catch (error) {
          logger.log(error)
          Pop.error(error)
          router.push('/')
        }
      },

      async deleteMyVault() {
        try {
          if (await Pop.confirm())
            await accountService.deleteMyVault(props.vault.id)
        } catch (error) {
          logger.error(error)
          Pop.error(error.message);

        }
      }
    }
  }
};
</script>


<style lang="scss" scoped></style>