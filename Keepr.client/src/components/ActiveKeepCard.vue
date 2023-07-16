<template>
  <div class="mb-3 modal-content" v-if="keep">
    <img class="img" :src="keep.img" alt="keep.name">
  </div>
  <div class="card">
    {{ 'whatup, fam' }}
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from "../models/Keep.js";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {

    return {

      // keep: computed(() => AppState.activeKeep)
    }
  }
};
</script>


<style lang="scss" scoped></style>