<template>
  <form @submit.prevent="handleSubmit">
    <div class="mb-3">
      <label for="title" class="form-label">Title:</label>
      <input
        type="text"
        class="form-control"
        name="title"
        id="title"
        aria-describedby="helpId"
        placeholder="Title..."
        v-model="editable.title"
        required
      />
    </div>
    <div class="mb-3">
      <label for="subtitle" class="form-label">Subtitle:</label>
      <input
        type="text"
        class="form-control"
        name="subtitle"
        id="subtitle"
        aria-describedby="helpId"
        placeholder="Subtitle..."
        v-model="editable.subtitle"
        required
      />
    </div>
    <div class="mb-3">
      <label for="imgUrl" class="form-label">ImgUrl:</label>
      <input
        type="text"
        class="form-control"
        name="imgUrl"
        id="imgUrl"
        aria-describedby="helpId"
        placeholder="ImgUrl..."
        v-model="editable.imgUrl"
        required
      />
    </div>
    <div class="mb-3">
      <label for="category" class="form-label">Category:</label>
      <select
        class="form-select"
        name="category"
        id="category"
        v-model="editable.category"
        required
      >
        <option disabled selected>Select a category...</option>
        <option>Appetizers/Beverages</option>
        <option>Breads/Muffins</option>
        <option>Soups/Salads</option>
        <option>Beef/Pork/Lamb</option>
        <option>Seafood/Poultry</option>
        <option>Pasta/Casseroles</option>
        <option>Vegetables/Vegetarian</option>
        <option>Desserts</option>
        <option>Miscellaneous</option>
      </select>
    </div>
    <div class="text-end">
      <button class="btn btn-info">Submit</button>
    </div>
  </form>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"
import { Modal } from "bootstrap"
import { recipesService } from "../services/RecipesService"
export default {
  setup() {
    const editable = ref({ category: "Select a category..." })
    return {
      editable,
      recipes: computed(() => AppState.recipes),
      async handleSubmit() {
        try {
          await recipesService.createRecipe(editable)
          Modal.getOrCreateInstance(document.getElementById('new-recipe')).hide
          editable.value = { category: "Select a category..." }
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