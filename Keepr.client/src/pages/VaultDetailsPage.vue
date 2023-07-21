<template>
  <div class="Vault-Page container-fluid" v-if="vault">
    <div class="align-itmes-center">
      <div class="col-12 ps-4">
        <img :src="vault.img" alt="vault.name">
        <h1>{{ vault.name }}</h1>
      </div>
    </div>

    <div class="container">
      <div class="row my-3">
        <div class="col-md-4" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from "vue-router";
import { vaultsService } from "../services/VaultsService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
export default {
  setup() {

    const router = useRouter()
    const route = useRoute()

    // async function getVaultsByProfileId() {
    //   try {
    //     const vaultId = route.params.vaultId;
    //     await vaultsService.getVaultsByProfile(vaultId);

    //   } catch (error) {

    //   }
    // }

    async function getVaultsByProfileId() {
      try {
        vaultsService.getVaultById(route.params.id)
        vaultsService.getVaultsByProfile(route.params.id)
      } catch (error) {
        logger.log(error)
        Pop.error("Private Vault")
        router.push('/')
      }
    }

    async function getVaultKeepsByVaultId() {
      try {
        const vaultId = route.params.id
        await vaultKeepsService.getVaultById(vaultId)
      } catch (error) {
        logger.log(error)
        Pop.toast(error.message, 'error')
      }
    }

    onMounted(() => {
      getVaultsByProfileId()
      getVaultKeepsByVaultId()
    })
    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.activeVaultKeep)
    }
  }
};
</script>


<style lang="scss" scoped></style>