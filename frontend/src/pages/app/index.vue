<template>
  <v-app>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  name: "App",

  components: {},

  data() {
    return {
      //
    };
  },
});
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100;300;400;500;600;900&display=swap');
html {
  font-size: 62.5%;
  /* 62.5% of the base size of 16px = 10px.*/
}
body {
  font-size: 1.6rem;
  /* reset 10*1.6 = 16px, to make sure you do not get any 10px around */
}
:root {
  --green-primary: #00a0a6;
  --green-500: #59f9ff;
  --green-600: #61ced2;
  --green-700: #00b8bf;
  --green-800: #006f73;
  --green-900: #003d40;

  --red-secondary: #ce002e;
  --red-500: #ff4069;
  --red-600: #d24a67;
  --red-700: #bf0029;
  --red-800: #730019;
  --red-900: #40000e;

  --black: #2d2c2c;

  --gray-50: #faf4f4;
  --gray-100: #e5e0e0;
  --gray-200: #d1cccc;
  --gray-300: #bdb9b9;
  --gray-400: #a8a5a5;
  --gray-500: #949191;
  --gray-600: #807d7d;
  --gray-700: #6b6969;
  --gray-800: #575555;
  --gray-900: #424141;
}


body, input, textarea, select, button {
  font: 400 1.6rem "Poppins", sans-serif;
}

button {
  cursor: pointer;
}

a {
  color: inherit;
  text-decoration: none;
}

</style>
