<template>
  <div class="row px-3 m-0">
    <div class="col-12 bg-secondary rounded info-card">
      <div class="row bg-info text-light rounded-top text-center">
        <div class="col-12">
          <h4 class="my-1">
            Ingredients
            <i
              v-if="activeRecipe.creatorId == account.id"
              class="mdi mdi-plus selectable"
              title="Add Ingredient"
              @click="showInput"
            ></i>
          </h4>
        </div>
      </div>
      <form
        id="add-ingredient"
        class="row pt-1 hidden"
        @submit.prevent="handleSubmit"
      >
        <div class="col-5 px-1">
          <div class="mb-3">
            <input
              type="text"
              class="form-control"
              name="quantity"
              id="quantity"
              aria-describedby="helpId"
              placeholder="Amt/measure..."
              v-model="editable.quantity"
            />
          </div>
        </div>
        <div class="col-7 px-1">
          <div class="mb-3 d-flex align-items-center">
            <input
              type="text"
              class="form-control"
              name="name"
              id="name"
              aria-describedby="helpId"
              placeholder="Name..."
              v-model="editable.name"
            />
            <button class="btn">
              <i class="mdi mdi-plus" title="Add Ingredient"></i>
            </button>
          </div>
        </div>
      </form>
      <div class="row">
        <div class="col-12" v-for="i in ingredients" :key="i.id">
          <div class="d-flex justify-content-between">
            <span>{{ i.quantity }} {{ i.name }}</span>
            <div>
              <i
                v-if="account.id == activeRecipe.creatorId"
                @click="deleteIngredient"
                id="edit-step"
                class="mdi mdi-delete text-danger selectable"
                title="Delete Step"
              ></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"
import { ingredientsService } from "../services/IngredientsService";
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      ingredients: computed(() => AppState.activeRecipe?.ingredients),
      activeRecipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      showInput() {
        if (document.getElementById('add-ingredient').classList.contains('hidden')) {
          document.getElementById('add-ingredient').classList.remove('hidden')
        } else {
          document.getElementById('add-ingredient').classList.add('hidden')
        }
      },
      async handleSubmit() {
        try {
          editable.value.recipeId = AppState.activeRecipe.id
          await ingredientsService.addIngredient(editable.value)
          editable.value = {}
          document.getElementById('add-ingredient').classList.add('hidden')
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteIngredient() {
        try {
          logger.error('Not yet set up')
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
.info-card {
  min-height: 40vh;
  max-height: 40vh;
  overflow: auto;
}
.hidden {
  display: none;
}
</style>