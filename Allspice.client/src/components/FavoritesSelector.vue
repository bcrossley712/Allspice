<template>
  <button class="btn-me" title="Favorite">
    <i
      v-if="!hearted"
      class="mdi mdi-heart-outline fs-4"
      @click.stop="createFavorite"
    ></i>
    <i
      v-else
      class="mdi mdi-heart text-danger fs-4"
      @click.stop="deleteFavorite"
    ></i>
  </button>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { favoritesService } from "../services/FavoritesService";
import { AppState } from "../AppState";
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      favorites: computed(() => AppState.favorites),
      hearted: computed(() => AppState.favorites.find(f => f.id == props.recipe.id || f.recipeId == props.recipe.id)),
      async createFavorite() {
        try {
          await favoritesService.createFavorite(props.recipe.id)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteFavorite() {
        try {
          await favoritesService.deleteFavorite(props.recipe.id)
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