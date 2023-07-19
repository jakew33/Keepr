<template>
  <div class="modal-content">
    <div class="modal-header">
      <h5 class="modal-title">Create Vault</h5>
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
    </div>
    <form @submit.prevent="createVault()">
      <div class="modal-body">
        <div class="mb-3">
          <label for="name" class="form-label">Name</label>
          <input v-model="editable.name" type="text" class="form-control" id="name" placeholder="Name">
        </div>
        <div class="mb-3">
          <label for="coverImg" class="form-label">Image</label>
          <input v-model="editable.img" type="text" class="form-control" id="coverImg" placeholder="image">
        </div>
        <textarea v-model="editable.description" class="form-control w-100" name="description" id="description" cols="30"
          rows="10">Description</textarea>
      </div>
      <div class="modal-footer">
        <div class="form-check form-switch m-3">
          <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckChecked" checked
            v-model="editable.isPrivate">
          <label class="form-check-label" for="flexSwitchCheckChecked">Make Vault Private?</label>
        </div>
        <button type="submit" class="btn btn-success">Create Vault</button>
      </div>
    </form>
  </div>
</template>


<script>
import { ref } from "vue";
import { vaultsService } from "../services/VaultsService.js";
import { Modal } from "bootstrap";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async createVault() {
        try {
          const vaultData = editable.value
          await vaultsService.createVault(vaultData)
          editable.value = {}
          Modal.getOrCreateInstance('#vaultForm').hide()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'didnt work')

        }
      }
    }
  }
};
</script>


<style lang="scss" scoped></style>