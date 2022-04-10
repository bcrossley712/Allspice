<template>
  <div class="container-fluid mt-3 px-4">
    <button
      data-bs-toggle="modal"
      data-bs-target="#new-recipe"
      class="btn rounded-circle btn-info fixed p-0 m-0"
    >
      <div>
        <i class="mdi mdi-plus text-light fs-1 p-2"></i>
      </div>
    </button>
    <div class="row">
      <div class="col-12 col-md-4 col-xl-3" v-for="r in recipes" :key="r.id">
        <Recipe :recipe="r" />
      </div>
    </div>
    <Modal id="active-recipe">
      <template #body><ActiveRecipeForm /></template>
    </Modal>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { recipesService } from "../services/RecipesService";
import { AppState } from "../AppState";
export default {
  setup() {
    onMounted(async () => {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    }
    )
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
.fixed {
  position: fixed;
  bottom: 30px;
  right: 30px;
}
// .btn-me{
//   display: inline-block;
//     font-weight: 400;
//     line-height: 1.5;
//     color: #212529;
//     text-align: center;
//     text-decoration: none;
//     vertical-align: middle;
//     cursor: pointer;
//     user-select: none;
//     background-color: transparent;
//     border: 1px solid transparent;
//     padding: 0.375rem 0.75rem;
//     font-size: 1rem;
//     border-radius: 0.25rem;
//     transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
//     height: 5vh;
//     width: 5vh;
// }
</style>
