<template>
  <nav class="container-fluid bg-photo rounded">
    <div class="row p-2">
      <div class="col-12 d-flex justify-content-end">
        <div class="me-3">
          <Search />
        </div>
        <div>
          <Login />
        </div>
      </div>
    </div>
    <div
      class="
        row
        text-light text-center text-shadow
        min-height
        d-flex
        flex-column
        justify-content-center
      "
    >
      <div class="col-md-2 offset-md-5">
        <h1 class="d-flex justify-content-center">All-Spice</h1>

        <h3 class="d-flex justify-content-center">
          Cherish Your Family And Their Cooking
        </h3>
      </div>
    </div>
    <div class="row">
      <div
        class="col-md-6 offset-md-3 rounded bg-light p-3 transition elevation-3"
      >
        <Filter />
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
.bg-photo {
  background-image: url("https://images.unsplash.com/photo-1615937722923-67f6deaf2cc9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80");
  background-repeat: no-repeat;
  background-size: cover;
}
.text-shadow {
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.514),
    -1px -1px 3px rgba(0, 0, 0, 0.514);
}
.transition {
  transform: translateY(50%);
}
.min-height {
  min-height: 25vh;
}
</style>
