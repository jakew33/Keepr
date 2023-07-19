<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>

  <div class="row my-3">
    <div class="col-md-4" v-for="v in vaults" :key="v.id">
      <KeepCard :vault="v" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from '../AppState'
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js"
import { vaultsService } from "../services/VaultsService.js"
export default {
  setup() {
    const filterBy = ref('')

    async function getAllVaults() {
      try {
        logger.log('Getting Vaults')
        await vaultsService.getAllVaults()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    onMounted(() => {
      getAllVaults()
    })

    return {
      filterBy,
      account: computed(() => AppState.account),
      vaults: computed(() => {
        if (filterBy.value == "") {
          return AppState.vaults
        } else {
          return AppState.vaults.filter(v => v.name == filterBy.value)
        }
      })
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>

<style scoped>
img {
  max-width: 100px;
}
</style>
