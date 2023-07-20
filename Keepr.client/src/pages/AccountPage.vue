<template>
  <div class="container text-center position-relative">
    <img class="rounded cvrImg mx-auto d-block" :src="account.coverImg" alt="" />
    <div class="about position-absolute top-65 start-50 translate-middle my-3">
      <img class="rounded-circle actPic" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
    </div>
    <div>

    </div>
    <div class="btn btn-success"></div>
    <AccountForm />
  </div>

  <!-- <div class="row my-3">
    <div class="col-md-4" v-for="v in vaults" :key="v.id">
      <KeepCard :vault="v" />
    </div>
  </div> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.myKeeps)
    }
  }
}
</script>

<style scoped>
.actPic {
  max-width: 100px;
  aspect-ratio: 1/1;
}

/* .cvrImg {} */
</style>

