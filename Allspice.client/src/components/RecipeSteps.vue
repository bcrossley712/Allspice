<template>
  <div class="row px-3 m-0">
    <div class="col-12 bg-secondary rounded info-card">
      <div class="row bg-info text-light rounded-top">
        <div class="col-12 d-flex justify-content-center align-items-center">
          <div>
            <i
              @click="editStep"
              v-if="activeRecipe.creatorId == account.id"
              class="mdi mdi-pencil selectable me-2"
              title="Edit Step"
            >
              <!-- FIXME add function to call another modal or add hidden edit buttons -->
            </i>
          </div>
          <h4 class="my-1">
            Recipe Steps
            <i
              v-if="activeRecipe.creatorId == account.id"
              class="mdi mdi-plus selectable"
              title="Add Step"
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
        <div class="col-3 px-1">
          <div class="mb-3">
            <input
              type="number"
              class="form-control"
              name="sequence"
              id="sequence"
              aria-describedby="helpId"
              placeholder="#"
              v-model="editable.sequence"
              required
            />
          </div>
        </div>
        <div class="col-9 px-1">
          <div class="mb-3 d-flex align-items-center">
            <input
              type="text"
              class="form-control"
              name="body"
              id="body"
              aria-describedby="helpId"
              placeholder="Body..."
              v-model="editable.body"
              required
            />
            <button class="btn">
              <i class="mdi mdi-plus selectable" title="Add Step"></i>
            </button>
          </div>
        </div>
      </form>
      <div class="row">
        <div class="col-12" v-for="s in steps" :key="s.id">
          <div class="d-flex justify-content-between">
            <span>{{ s.sequence }}. {{ s.body }}</span>
            <div>
              <i
                v-if="account.id == activeRecipe.creatorId"
                @click="deleteStep"
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
import { stepsService } from "../services/StepsService";
import { Modal } from "bootstrap"
export default {
  setup() {
    const editable = ref({})
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
      showEdit() {

      },
      async handleSubmit() {
        try {
          editable.value.recipeId = AppState.activeRecipe.id
          await stepsService.addStep(editable.value)
          editable.value = {}
          document.getElementById('add-form').classList.add('hidden')
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteStep() {
        try {
          logger.error('Not yet set up')
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async editStep() {
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