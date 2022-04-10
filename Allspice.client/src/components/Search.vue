<template>
  <div class="my-2 my-lg-0 d-flex">
    <input
      type="text"
      class="form-control-me"
      name="search"
      id="search"
      aria-describedby="helpId"
      placeholder="Search..."
    />
    <button class="btn-me">
      <i class="mdi mdi-magnify"></i>
    </button>
  </div>
</template>


<script>
import { ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.form-control-me {
  display: block;
  width: 100%;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #212529;
  background-color: #e5e5e5;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  appearance: none;
  border-top-left-radius: 0.25rem;
  border-bottom-left-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
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
  background-color: #e5e5e5;
  border: 1px solid #e5e5e5;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  border-bottom-right-radius: 0.25rem;
  border-top-right-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
</style>