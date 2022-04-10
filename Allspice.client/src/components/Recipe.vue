<template>
  <div
    class="row m-2"
    @click="setActive"
    data-bs-toggle="modal"
    data-bs-target="#active-recipe"
  >
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
        selectable
      "
    >
      <div class="d-flex justify-content-between">
        <div>
          <span class="p-1 bg-blur text-light rounded-pill fw-bold">
            {{ recipe.category }}
          </span>
        </div>
        <button class="btn-me" title="Favorite" @click="favoriteToggle">
          <i class="mdi mdi-heart-outline fs-4"></i>
        </button>
      </div>
      <div
        class="p-1 bg-blur text-light rounded d-flex flex-column w-100 fw-bold"
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
      },
      async favoriteToggle() {
        try {
          logger.error("Need to set up")
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
  min-height: 20vw;
  width: 100%;
}
.bg-blur {
  backdrop-filter: blur(20px);
  background-color: gray;
  opacity: 0.8;
}
// .text-shadow {
//   text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.514),
//     -1px -1px 3px rgba(0, 0, 0, 0.514);
// }
.btn-me {
  display: inline-block;
  font-weight: 400;
  line-height: 1.5;
  color: #212529;
  text-align: center;
  text-decoration: none;
  vertical-align: middle;
  cursor: pointer;
  user-select: none;
  opacity: 0.8;
  background-color: grey;
  border: 1px solid grey;
  font-size: 1rem;
  border-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
</style>