<template>
  <div class="container">
    <div class="container-form">
      <v-form ref="form" class="form">
        <v-text-field
          v-model="userName"
          label="Usuário"
          required
        ></v-text-field>

        <v-text-field
          type="password"
          v-model="userPassword"
          label="Senha"
          required
        ></v-text-field>

        <v-btn
          color="success"
          class="mr-4"
          @click="login()"
        >
          Validate
        </v-btn>
      </v-form>
    </div>
  </div>
</template>

<style lang="scss" src="./styles.scss"></style>
<script lang="ts">
  import { mapActions, mapGetters } from 'vuex';

export default {
	data() {
		return {
			userName: '',
			userPassword: '',
		};
	},
	computed: {
		...mapGetters({
			getterAccount: 'getterAccount',
		}),
	},
	methods: {
		...mapActions({
			actionLogin: 'actionLogin',
		}),
		login() {
			const params = {
				username: this.userName,
				password: this.userPassword,
			};

			this.actionLogin(params)
				.then((response) => {
					console.log('Usuário autenticado com sucesso!');

					this.$router.push({ name: 'Academic' })
				})
				.catch((err) => {
					console.log(err);
					console.log(err.data.error.message);

					console.log(err);
				});
		},
		register() {
			this.$router.push({
				name: 'Register',
				query: {
					user_type_id: this.$route.query.user_type_id,
				},
			});
		},
		goBack() {
			this.$router.go(-1);
		},
	},
};
</script>
