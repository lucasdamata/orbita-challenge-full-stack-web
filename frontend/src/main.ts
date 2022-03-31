import 'vuetify/styles'
import { createApp } from 'vue'
import App from './pages/app/index.vue'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import router from './router'
import { store } from './store'
import Maska from 'maska'
import Toast, { POSITION } from "vue-toastification";
import "vue-toastification/dist/index.css";

loadFonts()

createApp(App)
  .use(vuetify)
  .use(store)
  .use(router)
  .use(Maska)
  .use(Toast, {position : POSITION.TOP_RIGHT})
  .mount('#app')
