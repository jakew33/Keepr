<template>
  <div class="card text-white keep-card my3 bg rounded" @click="setActiveKeep(keep.id)">
    <img class="rounded elevation-5" :src="keep.img" :alt="keep.name">
    <div class="card-img-overlay">
      <div class="d-flex justify-content-around p-1">
      </div>
      <p class="text-center p-2 label label-default favorite elevation-5 rounded">
        {{ keep.name }}</p>
    </div>
  </div>
  <div v-if="keep.creatorId == account.id" class="d-flex justify-content-around">
    <button class="btn btn-dark elevation-5 text-white" @click="deleteKeep()">Delete Keep</button>
  </div>
</template>


<script>
import { Modal } from "bootstrap";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
// import { useRoute } from "vue-router";
import { logger } from "../utils/Logger.js";
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    // const route = useRoute()

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.activeKeep),

      async setActiveKeep(keepId) {
        try {
          await keepsService.setActiveKeep(keepId)
          Modal.getOrCreateInstance('#activeKeepCard').show()
        } catch (error) {
          logger.log(error)
          Pop.error(error)
        }
      },

      async deleteKeep() {
        try {
          if (await Pop.confirm())
            await keepsService.deleteKeep(props.keep.id)
        } catch (error) {
          logger.error(error)
          Pop.error(error.message);
        }
      },



    }
  }
}

</script>


<style lang="scss" scoped></style>