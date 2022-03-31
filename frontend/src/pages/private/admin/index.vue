<template>
  <div class="container-admin">
    <Menu />
    <Student />
  </div>
</template>

<style lang="scss" src="./styles.scss"></style>

<script lang="ts">
  import Menu from '../../../components/menu/index.vue'
  import Student from '../../../components/students/index.vue'
  export default {
    components: {
      Menu,
      Student
    }
  }
</script>