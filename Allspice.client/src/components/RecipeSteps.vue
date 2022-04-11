<template>
  <div class="row px-3 m-0">
    <div class="col-12 bg-secondary rounded info-card">
      <div class="row bg-info text-light rounded-top text-center">
        <div class="col-12">
          <h4 class="my-1">
            Recipe Steps
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
        id="add-form"
        class="row pt-1 hidden"
        @submit.prevent="handleSubmit"
      >
        <div class="col-4 px-1">
          <div class="mb-3">
            <input
              type="text"
              class="form-control"
              name="sequence"
              id="sequence"
              aria-describedby="helpId"
              placeholder="Sequence..."
              v-model="editable.sequence"
            />
          </div>
        </div>
        <div class="col-8 px-1">
          <div class="mb-3 d-flex align-items-center">
            <input
              type="text"
              class="form-control"
              name="body"
              id="body"
              aria-describedby="helpId"
              placeholder="Body..."
              v-model="editable.body"
            />
            <i class="mdi mdi-plus"></i>
          </div>
        </div>
      </form>
      <div class="row">
        <div class="col-12" v-for="s in steps" :key="s.id">
          <span>{{ s.sequence }}. {{ s.body }}</span>
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
    const editable = ({})
    return {
      editable,
      steps: computed(() => AppState.activeRecipe?.steps),
      activeRecipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      showInput() {
        if (document.getElementById('add-form').classList.contains('hidden')) {
          document.getElementById('add-form').classList.remove('hidden')
        } else {
          document.getElementById('add-form').classList.add('hidden')
        }
      },
      async handleSubmit() {
        try {

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