<template>
  <div class="row m-2">
    <div
      class="
        col-12
        rounded
        shadow
        bg-img
        p-2
        d-flex
        flex-column
        justify-content-between
      "
    >
      <div class="d-flex justify-content-between">
        <div>
          <span class="p-1 bg-blur text-light rounded-pill fw-bold">
            {{ recipe.category }}
          </span>
        </div>
        <FavoritesSelector :recipe="recipe" />
      </div>
      <div
        @click="setActive"
        data-bs-toggle="modal"
        data-bs-target="#active-recipe"
        class="
          p-1
          bg-blur
          text-light
          rounded
          d-flex
          flex-column
          w-100
          fw-bold
          selectable
        "
      >
        <span>
          {{ recipe.title }}
        </span>
        <span class="fw-light">{{ recipe.subtitle }}</span>
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
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      backgroundImage: computed(() => `url('${props.recipe.imgUrl}')`),
      setActive() {
        AppState.activeRecipe = props.recipe
        logger.log("[Set to Active]", props.recipe)
      }

    }
  }
}
</script>


<style lang="scss" scoped>
.bg-img {
  background-image: v-bind(backgroundImage);
  // background-position: center;
  background-size: cover;
  min-height: 20vw;
  width: 100%;
}
.bg-blur {
  backdrop-filter: blur(20px);
  background-color: rgb(61, 61, 61);
  opacity: 0.85;
}
// .text-shadow {
//   text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.514),
//     -1px -1px 3px rgba(0, 0, 0, 0.514);
// }
</style>