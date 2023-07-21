<template>
  <div class="card text-white keep-card my3 bg rounded">
    <img class="rounded elevation-5" :src="vault.img" :alt="vault.name">
    <div class="card-img-overlay">
      <div class="d-flex justify-content-around p-1">
      </div>
      <p class="text-center p-2 label label-default favorite elevation-5 rounded">
        {{ vault.name }}</p>
    </div>
  </div>
  <div v-if="vault.creatorId == account.id" class="d-flex justify-content-around">
    <!-- <button class="btn btn-dark elevation-5 text-white" @click="deleteVault()">Delete Vault</button> -->
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
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped></style>