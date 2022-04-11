<template>
  <div class="containter-fluid">
    <div class="row">
      <div class="col-12">
        <div class="row">
          <div class="col-4 bg-img img-fluid rounded-start">
            <div class="d-flex justify-content-end">
              <FavoritesSelector :recipe="activeRecipe" />
            </div>
          </div>
          <div class="col-8 px-4">
            <div class="d-flex align-items-center justify-content-end">
              <h4 class="m-0">
                <i
                  @click="deleteRecipe"
                  v-if="account.id == activeRecipe.creatorId"
                  class="mdi mdi-delete text-danger me-2 selectable"
                  title="Delete Recipe"
                ></i>
              </h4>
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="d-flex align-items-center">
              <h4 class="m-0 px-4 text-success">{{ activeRecipe.title }}</h4>
              <div class="pe-4">
                <i
                  @click="editRecipe"
                  class="mdi mdi-pencil text-warning selectable"
                  title="Edit Recipe"
                ></i>
              </div>
              <span class="p-1 bg-blur text-light rounded-pill fw-bold">
                {{ activeRecipe.category }}
              </span>
            </div>
            <h4 class="ps-4">{{ activeRecipe.subtitle }}</h4>
            <div class="row">
              <div class="col-6"><RecipeSteps /></div>
              <div class="col-6"><Ingredients /></div>
            </div>
            <div class="text-end">
              <span>Published by: {{ activeRecipe.creator?.name }}</span>
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
import { recipesService } from "../services/RecipesService"
import { Modal } from "bootstrap"
export default {
  setup() {
    return {
      backgroundImage: computed(() => `url('${AppState.activeRecipe.imgUrl}')`),
      activeRecipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      editRecipe() {
        try {
          logger.error("Not yet set up")
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteRecipe() {
        try {
          if (await Pop.confirm()) {
            await recipesService.deleteRecipe(AppState.activeRecipe.id)
            Modal.getOrCreateInstance(document.getElementById('active-recipe')).hide()
            Pop.toast('Recipe Deleted', 'success')
          }
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
.bg-img {
  background-image: v-bind(backgroundImage);
  background-position: center;
  background-size: cover;
  min-height: 30vw;
}
.bg-blur {
  backdrop-filter: blur(20px);
  background-color: rgb(61, 61, 61);
  opacity: 0.85;
}
</style>