<template>
  <div class="container text-center position-relative" v-if="account">
    <img class="rounded cvrImg mx-auto d-block" :src="account.coverImg" alt="" />
    <div class="about position-absolute top-65 start-50 translate-middle my-3">
      <img class="rounded-circle actPic" :src="account.picture" alt="" />
      <h1 class="VaultName">{{ account.name }}</h1>
    </div>
    <div>
    </div>
  </div>

  <EditAccountForm />

  <div class="container">
    <div class="row my-3">
      <div class="col-md-4" v-for="v in vaults" :key="v.id">
        <VaultCard :vault="v" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from '../AppState'
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
// import { vaultsService } from "../services/VaultsService.js"
import { accountService } from "../services/AccountService.js"

export default {
  setup() {
    const filterBy = ref('')

    async function getMyVaults() {
      try {
        logger.log("Getting My Stuff")
        await accountService.getMyVaults()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    onMounted(() => {
      getMyVaults()
    })
    return {
      filterBy,
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.myVaults)
    }
  }
}
</script>

<style scoped>
.actPic {
  max-width: 100px;
  aspect-ratio: 1/1;
}

.vaultName {
  text-shadow: 2px 2px 4px rgb(0, 0, 0);
}

/* .cvrImg {} */
</style>

