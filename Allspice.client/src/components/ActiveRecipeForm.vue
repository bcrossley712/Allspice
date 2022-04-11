<template>
  <div class="containter-fluid">
    <div class="row">
      <div class="col-12">
        <div class="row">
          <div class="col-4 bg-img img-fluid rounded-start">
            <div class="d-flex justify-content-end"><FavoritesSelector /></div>
          </div>
          <div class="col-8 px-4">
            <div class="text-end">
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="d-flex align-items-center">
              <h4 class="m-0 px-4 text-success">{{ activeRecipe.title }}</h4>
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
export default {
  setup() {
    return {
      backgroundImage: computed(() => `url('${AppState.activeRecipe.imgUrl}')`),
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>
.bg-img {
  background-image: v-bind(backgroundImage);
  // background-position: center;
  background-size: cover;
  min-height: 30vw;
}
.bg-blur {
  backdrop-filter: blur(20px);
  background-color: rgb(61, 61, 61);
  opacity: 0.85;
}
</style>