<template>
  <nav class="navbar navbar-expand-lg navbar-color border border-primary px-3">
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'Home' }" class="btn text-black color">
            Home
          </router-link>
        </li>
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle text-black mx-5 color" type="button" data-bs-toggle="dropdown"
            aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item text-black" data-bs-toggle="modal" data-bs-target="#modal">Keep</a></li>
            <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#vaultForm">Vault</a></li>
          </ul>
        </div>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

/* .navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
} */

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }

  .btn-light {
    box-shadow: 0px 0px 9px 0px #00000040;

  }
}

.navbar-color {
  background-color: #fef0f0;
  border-style: ridge;
}

.color {
  background-color: #cab2b0;
}
</style>
