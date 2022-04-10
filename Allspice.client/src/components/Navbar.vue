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
  background-image: url("https://s3-alpha-sig.figma.com/img/137d/d14c/aa93e0df14a805e8e10c9f1221ba5131?Expires=1650240000&Signature=QDklkOQqyZ-P-3Bd77XJ~HHGOU8xpAGC~t3yTSHDO-CiKPA1TDRy4QjlFs0C3n4CrvN6TYh~ht7p1SWSmSkEd8cjqDQJ2hXrAgM-rP-50011tWQCBpbszDWCFlBg5iDHecehWJIoNsBacOOtjTfuLlJywl5ywlmsZzUKIhetnugmDiuLsGgUu4LvGPsLFYkbaYObmsLYXFMKjPguSYVZ3jZ-Bs1fThfLXuAMPVxjoEpi9~h4BmIGC2qH6RW4SABaKdjdibQurjlmDFSL~Q1vZzh9OCY7cJMGHsn60Nz1cM~2l3wXNI5by-gvKOA~zwI0DGNbQWU8FH3iSmFSl8xPyw__&Key-Pair-Id=APKAINTVSUGEWH5XD5UA");
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
