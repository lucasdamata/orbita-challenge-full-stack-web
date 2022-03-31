<template>
  <div class="container-menu">
    <header class="header">
      <img src="../../assets/logo.svg" alt="Logo">
      <p>Módulo Acadêmico</p>
    </header>
    <nav class="nav-menu">
      <a href="#" rel="noopener noreferrer">Alunos</a>
    </nav>

    <button class="logout" @click="logout">logout</button>
  </div>
</template>

<style src='./styles.scss' ></style>

<script lang="ts">
export default {
  methods: {
    logout() {
      window.localStorage.clear()
      window.location.reload();
      this.$router.push({ name: 'Login' })
    }
  }
}
</script>

