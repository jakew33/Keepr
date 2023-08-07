<template>
  <div class="Vault-Page container-fluid" v-if="vault">
    <div class="align-itmes-center">
      <div class="col-12 ps-4">
        <img :src="vault.img" alt="vault.name">
        <h1>{{ vault.name }}</h1>
      </div>
    </div>

    <div class="container">
    </div>
    <div class="row my-3">
      <div class="col-md-4" v-for="k in keeps" :key="k.id">
        <VaultKeepCard :keep="k" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { logger } from "../utils/Logger.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { useRoute, useRouter } from 'vue-router';
import { vaultsService } from "../services/VaultsService.js";
export default {
  setup() {
    const route = useRoute()
    const router = useRouter()
    async function getVaultKeepsByVaultId() {
      try {
        const vaultId = route.params.id
        await vaultKeepsService.getVaultKeepsByVaultId(vaultId)
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    async function getVaultById() {
      try {
        const vaultId = route.params.id
        await vaultsService.setActiveVault(vaultId)
      } catch (error) {
        logger.log(error)
        Pop.toast(error.message, 'error')
        router.push({ name: 'Home' })
      }
    }

    async function removeVaultKeep() {
      try {
        if (await Pop.confirm())
          await vaultKeepsService.removeVaultKeep()
      } catch (error) {
        logger.error(error)
        Pop.error(error.message)
      }
    }

    onMounted(() => {
      getVaultById()
      getVaultKeepsByVaultId()
    })
    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.vaultKeeps)

    }
  }
};
</script>


<style lang="scss" scoped></style>