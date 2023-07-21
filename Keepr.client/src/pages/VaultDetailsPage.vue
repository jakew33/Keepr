<template>
  <div class="Vault-Page container-fluid" v-if="vault">
    <div class="align-itmes-center">
      <div class="col-12 ps-4">
        <h1>{{ vault.name }}</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-between align-items-center">
          <h2>Vaults:</h2>

        </div>
      </div>
    </div>

    <div class="container">
    </div>
    <div class="row my-3">
      <div class="col-md-4" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { useRoute, useRouter } from "vue-router";
import { vaultsService } from "../services/VaultsService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
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
        Pop.error("No vault here, fam")
        router.push('/')
      }
    }

    onMounted(() => {
      getVaultsByProfileId()
    })
    return {
      vault: computed(() => AppState.vault),
      keeps: computed(() => AppState.activeVaultKeep)
    }
  }
};
</script>


<style lang="scss" scoped></style>