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
  <AccountForm />
</template>

<script>
import { computed, onMounted, ref } from 'vue'
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
img {
  max-width: 100px;
}
</style>

<style scoped>
img {
  max-width: 100px;
}
</style>
