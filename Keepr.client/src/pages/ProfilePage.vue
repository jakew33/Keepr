<template>
  <div class="profile-page">

    <div class="container">
      <div class="row mt-2" v-if="profile">
        <div class="container text-center position-relative">
          <img class="rounded cvrImg mx-auto d-block" :src="profile.coverImg" alt="" />
          <div class="about position-absolute top-65 start-50 translate-middle my-3">
            <img class="rounded-circle actPic" :src="profile.picture" alt="" />
            <h1>{{ profile.name }}</h1>
          </div>
          <div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- <div class="col-12 d-flex justify-content-center">
    <h1>Vaults</h1>
  </div> -->

  <div class="container">
    <div class="row my-3">
      <div class="col-md-4" v-for="v in vaults" :key="v.id">
        <VaultCard :vault="v" />
      </div>
    </div>
  </div>

  <!-- <div class="col-12 d-flex justify-content-center">
    <h1>Keeps</h1>
  </div> -->

  <div class="container">
    <div class="row my-3">
      <div class="col-md-4" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState.js'
import { profileService } from '../services/ProfileService.js'

import Pop from '../utils/Pop.js'
import { logger } from "../utils/Logger.js"
import { vaultsService } from "../services/VaultsService.js"
import { keepsService } from "../services/KeepsService.js"

export default {
  setup() {
    const route = useRoute()

    async function getProfileById() {
      try {
        await profileService.getProfileById(route.params.id)
        logger.log(AppState.profile)
      } catch (error) {
        Pop.error(error)
      }
    }

    async function getVaultsByProfile() {
      try {
        // const vaultId = route.params.activeProfileVaults;
        // console.log(vaultId);
        await vaultsService.getVaultsByProfile(route.params.id);
      } catch (error) {
        Pop.error(error)
      }
    }

    async function getKeepsByProfile() {
      try {
        // const keepId = route.params.activeProfileKeeps;
        await keepsService.getKeepsByProfile(route.params.id);
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(() => {
      getProfileById();
      getVaultsByProfile();
      getKeepsByProfile();

    })


    return {
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.activeProfileVaults),
      keeps: computed(() => AppState.activeProfileKeeps),


    }
  },
}
</script>


<style lang="scss" scoped>
.actPic {
  max-width: 100px;
  aspect-ratio: 1/1;
}
</style>