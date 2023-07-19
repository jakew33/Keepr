<template>
  <div class="Home-Page">

    <div class="container">
      <div class="row my-3">
        <div class="col-md-4" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>

  <!-- <div class="row my-3">
    <div class="col-md-4" v-for="v in vaults" :key="v.id">
      <KeepCard :vault="v" />
    </div>
  </div> -->
</template>

<script>
import { logger } from "../utils/Logger.js"
import { keepsService } from "../services/KeepsService.js"
import Pop from "../utils/Pop.js"
import { computed, onMounted, ref } from "vue"
import { AppState } from "../AppState.js"
import { vaultsService } from "../services/VaultsService.js"
export default {
  setup() {
    const filterBy = ref('')

    async function getAllKeeps() {
      try {
        logger.log('getting keeps')
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    // async function getAllVaults() {
    //   try {
    //     logger.log('Getting Vaults')
    //     await vaultsService.getAllVaults()
    //   } catch (error) {
    //     Pop.error(error.message)
    //     logger.log(error)
    //   }
    // }

    onMounted(() => {
      getAllKeeps()
      getAllKeeps()
    })
    return {
      filterBy,
      appState: computed(() => AppState),
      keeps: computed(() => {
        if (filterBy.value == "") {
          return AppState.keeps
        } else {
          return AppState.keeps.filter(k => k.name == filterBy.value)
        }
      })
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
