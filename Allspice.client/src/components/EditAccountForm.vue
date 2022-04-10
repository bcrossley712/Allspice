<template>
  <form @submit.prevent="handleSubmit" class="mb-3">
    <div>
      <label for="name">Name:</label>
      <input
        v-model="editable.name"
        type="text"
        class="form-control my-2"
        name="name"
        id="name"
        placeholder="Name..."
        required
        minlength="3"
        maxlength="20"
      />
    </div>
    <div>
      <label for="picture">Picture Url:</label>
      <input
        v-model="editable.picture"
        type="text"
        class="form-control my-2"
        name="picture"
        id="picture"
        placeholder="Picture..."
        required
      />
    </div>
    <div class="text-end">
      <button class="btn btn-info selectable" title="Submit">
        <i class="mdi mdi-plus"></i>
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { Modal } from "bootstrap"
import { watchEffect } from "@vue/runtime-core"
import { AppState } from "../AppState"
import { accountService } from "../services/AccountService"
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      editable.value = AppState.account
    })
    return {
      editable,
      async handleSubmit() {
        try {
          logger.log(editable.value)
          await accountService.editAccount(editable.value)
          Modal.getOrCreateInstance(document.getElementById('edit-account')).hide()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>