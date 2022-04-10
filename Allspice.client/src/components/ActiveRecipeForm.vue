<template>
  <div class="component">
    {{ activeRecipe.title }}
  </div>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"
export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>