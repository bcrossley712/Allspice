<template>
  <header class="p-3">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <Modal id="edit-account">
    <template #title>Edit Account</template>
    <template #body><EditAccountForm /></template>
  </Modal>
  <Modal id="new-recipe">
    <template #title>New Recipe</template>
    <template #body><NewRecipeForm /></template>
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
