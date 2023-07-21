<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="container">
          <div class="container">
            <div class="row my-3">
              <div class="col-md-4" v-for="k in keeps" :key="k.id">
                <KeepCard :keep="k" />
              </div>
            </div>
          </div>
        </div>
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
import { useRoute } from 'vue-router';
import { vaultsService } from "../services/VaultsService.js";
export default {
  setup() {
    const route = useRoute()

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
      }
    }

    onMounted(() => {
      getVaultById()
      getVaultKeepsByVaultId()
    })
    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.myKeeps)

    }
  }
};
</script>


<style lang="scss" scoped></style>