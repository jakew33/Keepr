<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-color">
    <router-view />
  </main>

  <Modal id="modal">
    <CreateKeepForm />
  </Modal>

  <!-- <Modal id="editAccountForm">
    <AccountForm />
  </Modal> -->

  <Modal id="activeKeepCard">
    <ActiveKeepCard />
  </Modal>

  <Modal id="activeVaultCard">
    <ActiveVaultCard />
  </Modal>

  <Modal id="vaultForm">
    <CreateVaultForm />
  </Modal>
  <!-- 
  <Modal id="saveKeepForm">
    <SaveKeepForm />
  </Modal> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

.bg-color {
  background-color: #fef0f0;
}
</style>
