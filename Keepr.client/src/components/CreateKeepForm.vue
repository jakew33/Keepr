<template>
  <div class="modal-content">
    <div class="modal-header">
      <h5 class="modal-title">Create A Keep</h5>
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
    </div>
    <form @submit.prevent="createKeep()">
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
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-success">Post Keep</button>
      </div>
    </form>
  </div>
</template>


<script>
import { ref } from "vue";
import { keepsService } from "../services/KeepsService.js";
import { Modal } from "bootstrap";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async createKeep() {
        try {
          const keepData = editable.value
          await keepsService.createKeep(keepData)
          editable.value = {}
          Modal.getOrCreateInstance('#modal').hide()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'aw shucks')

        }
      }
    }
  }
};
</script>


<style lang="scss" scoped></style>