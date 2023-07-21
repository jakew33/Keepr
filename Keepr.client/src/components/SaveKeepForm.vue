<template>
  <form class="saveKeepForm card" @submit.prevent="handleSubmit">

    <div class="form-group mb-3">
      <label for="vault">Save To Vault</label>
      <select name="vault" class="form-control" v-model="editable.vaultId">
        <option disabled selected value="">Choose a Vault</option>
        <option v-for="v in vaults" :key="v.id" :value="v.id">{{ v.name }}</option>
      </select>
    </div>
    <div class="button-group">
      <button class="btn me-4" type="reset">Cancel</button>
      <button class="btn btn-primary" type="submit">Save Keep</button>
    </div>

  </form>
</template>


<script setup>
import { AppState } from '../AppState';
import { computed, ref } from 'vue';
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";

const editable = ref({ vaultId: '' })
const vaults = computed(() => AppState.myVaults)


async function handleSubmit() {
  try {
    // TODO I need a keepId...where do I get this value
    editable.value.keepId = AppState.activeKeep.id
    // AppState.activeKeep
    await keepsService.saveKeep(editable.value)
    editable.value = { vaultId: '' }
  } catch (error) {
    Pop.error(error, 'saving keep')
  }
}


</script>


<style lang="scss" scoped></style>