<template>
  <div class="rounded elevation-5 vault-card mb-3 modal-content modal-xl" v-if="vault">
    <div class="modal-content ">
      <div class="modal-header">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body container">
        <section class="row">
          <div class="col-md-6 col-12">
            <img class="img-fluid" :src="vault.img" alt="keep.name">
          </div>
          <div class="col-md-6 col-12">
            <div class="row h-100 justify-content-between">
              <div class="col-12">
                <h2 class="text-center">{{ vault.name }}</h2>
              </div>
              <div class="col-12">
                <div class="d-flex justify-content-around">
                  <p>{{ vault.description }}</p>
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed } from 'vue';
export default {
  setup() {
    return {
      vault: computed(() => AppState.activeVault)
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