<template>
  <div class="card text-white recipe-card my3 bg rounded">
    <img class="rounded elevation-5" :src="keep.img" :alt="keep.name">
    <div class="card-img-overlay">
      <div class="d-flex justify-content-around p-1">
      </div>
      <p class="text-center p-2 label label-default favorite elevation-5 rounded">{{ keep.name }}</p>
    </div>
  </div>
</template>


<script>
import { Keep } from "../models/Keep.js";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped></style>