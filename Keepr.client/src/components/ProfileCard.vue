<template>
  <template>
    <div class="card">
      <div class="card-body">
        <div class="profile-card mb-2 text-center">
          <p class="text-center mb-0">
            <img class="rounded-circle profile-picture" :src="profile.picture" :alt="profile.name">
          </p>
        </div>
        <p><b>{{ profile.name }}</b></p>
      </div>
    </div>
  </template>
</template>


<script>
import { computed } from 'vue';
import { Account, Profile } from "../models/Account.js";
export default {
  props: {
    profile: { type: [Profile, Account], required: true }
  },
  setup(props) {
    return {
      coverImg: computed(() => `url(${props.profile?.coverImg})`)
    }
  }
};
</script>


<style lang="scss" scoped>
.profile-card {
  background-image: v-bind(coverImg);
  aspect-ratio: 1/1;
  height: 150px;
  min-width: 100%;
  background-size: cover;
  background-repeat: no-repeat;
  display: grid;
  place-content: center;
}

.profile-picture {
  height: 100px;
  aspect-ratio: 1/1;
  object-fit: cover;
}
</style>