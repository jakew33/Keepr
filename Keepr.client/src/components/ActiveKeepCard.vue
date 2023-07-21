<template>
  <div class="rounded elevation-5 keep-card mb-3 modal-content modal-xl" v-if="keep">
    <div class="modal-content ">
      <div class="modal-header">
        <div class="text-end mdi mdi-eye my-1">{{ keep.views }} Kept: {{ keep.kept }}</div>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body container">
        <section class="row">
          <div class="col-md-6 col-12">
            <img class="img-fluid" :src="keep.img" alt="keep.name">
          </div>
          <div class="col-md-6 col-12">
            <div class="row h-100 justify-content-between">
              <div class="col-12">
                <h2 class="text-center">{{ keep.name }}</h2>
              </div>
              <div class="col-12">
                <div class="d-flex justify-content-around">
                  <p>{{ keep.description }}</p>
                </div>
              </div>
              <router-link class="align-self-end" :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
                <img class="rounded-circle profile" :src="keep?.creator.picture" :alt="keep.name">
              </router-link>

            </div>
          </div>
        </section>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Save</button>
      </div>
    </div>
  </div>

  <!-- <div class="container-fluid" v-if="keep">

    <div class="row">

      <div class="col-md-6 card color">
        <h1>{{ keep.name }}</h1>
        <p>{{ keep.description }}</p>
      </div>

      <div class="col-md-6 p-l">
        <img :src="keep.img" class="keep.name">
      </div>

    </div>
  </div> -->
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
export default {
  props: {
    // keep: { type: Keep, required: true }
  },
  setup() {

    return {

      keep: computed(() => AppState.activeKeep)
    }
  }
};
</script>


<style lang="scss" scoped>
.profile {
  height: 100px;
  aspect-ratio: 1/1;
  object-fit: fit;
  bottom: 0;
  left: 0;
  right: 100px;
  padding: 1rem;
}
</style>