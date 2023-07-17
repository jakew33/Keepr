<template>
  <div class="profile-page">

    <div class="container">
      <div class="row mt-2" v-if="profile">
        <div class="col-md-8 m-auto">
          <div>
            <ProfileCard :profile="profile" />
            <div class="card">
              <div class="profileCard text-center">
                <p class="text-center mb-0">
                  <img class="coverImg image-fluid" :src="profile.coverImg" alt="profile.name">
                  <img class="rounded-circle profilePicture justify-content-start" :src="profile.picture"
                    alt="profile.name">
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="row my-3">
        <div class="col-md-8 m-auto" v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
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




    onMounted(() => {
      getProfileById();

    })


    return {
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),


    }
  },
  // components: { KeepCard }
}
</script>


<style lang="scss" scoped></style>