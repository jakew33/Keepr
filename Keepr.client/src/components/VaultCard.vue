<template>
  <div class="card text-white keep-card my3 bg rounded">
    <img class="rounded elevation-5" :src="vault.img" :alt="vault.name">
    <div class="card-img-overlay">
      <div class="d-flex justify-content-around p-1">
      </div>
      <p class="text-center p-2 label label-default favorite elevation-5 rounded">
        {{ vault.name }}</p>
    </div>
  </div>
  <div v-if="vault.creatorId == account.id" class="d-flex justify-content-around">
    <!-- <button class="btn btn-dark elevation-5 text-white" @click="deleteKeep()">Delete Keep</button> -->
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped></style>