<template>
  <div class="container-student">

    <div class="header-container">
      <div class="header-actions">
        <div>
          <!-- <input type="search" v-model="search" @change="filter" />
          <button >Pesquisar</button> -->
        </div>
        <button class="registerBtn" @click="dialog = true">Cadastrar Aluno</button>
      </div>
    </div>
    <v-table fixed-header height="60rem">
        <thead  class="table">
          <tr class="table-head">
            <th class="table-head--title text-center">Registro Acadêmico</th>
            <th class="table-head--title text-center">Nome</th>
            <th class="table-head--title text-center">CPF</th>
            <th class="table-head--title text-center">Ações</th>
          </tr>
        </thead>
        <tbody class="table-body">
          <tr
            v-for="item in students"
            :key="item.id"
            class="table-body--content"
          >
            <td class="text-center" style="font-size: 1.5rem">{{ item.ra }}</td>
            <td class="text-center" style="font-size: 1.5rem">
              {{ item.name }}
            </td>
            <td class="text-center" style="font-size: 1.5rem">
              {{ item.cpf }}
            </td>
            <td class="text-center" style="font-size: 1.5rem">
              <div>
                <button @click="open(item)">[editar]</button>
                <button @click="openConfirmDelete(item.id)">[deletar]</button>
              </div>
            </td>
          </tr>
        </tbody>
      
    </v-table>
  </div>
  <v-dialog
      v-model="dialog" 
      max-height="600"
      width="1400"
    >
      <v-card width="1000">
        <v-card-title class="card-title">
          <span class="text-h5">Cadastro de Aluno</span>
        </v-card-title>
        <v-card-text>
         <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
           <div>
             <span>Nome</span>
             <v-text-field
              required
              :rules="[v => !!v || 'Campo obrigatório']"
              v-model="name"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">E-mail</span>
             <v-text-field
              required
              :rules="emailRules"
              v-model="email"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">RA</span>
             <v-text-field
              required
              v-model="ra"
              :rules="[v => !!v || 'Campo obrigatório']"
              type="number"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">CPF</span>
             <v-text-field
              required
              v-model="cpf"
               :rules="cpfRules"
               v-maska="'###.###.###-##'"
             >
             </v-text-field>
           </div>
         </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
          class="btnClose"
            text
            @click="close"
          >
            Cancelar
          </v-btn>
          <v-btn
            class="btnSave"
            text
            @click="register"
          >
            Salvar
          </v-btn>
        </v-card-actions>
      </v-card>
  </v-dialog>
  <v-dialog
      v-model="updateDialog" 
      max-height="600"
      width="1400"
    >
      <v-card width="1000">
        <v-card-title class="card-title">
          <span class="text-h5">Cadastro de Aluno</span>
        </v-card-title>
        <v-card-text>
         <v-form
    ref="form"
    v-model="updateValid"
    lazy-validation
  >
           <div>
             <span>Nome</span>
             <v-text-field
              required
              :rules="[v => !!v || 'Campo obrigatório']"
              v-model="name"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">E-mail</span>
             <v-text-field
              required
              :rules="emailRules"
              v-model="email"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">RA</span>
             <v-text-field
              required
              v-model="ra"
              :rules="[v => !!v || 'Campo obrigatório']"
              disabled
              type="number"
             >
             </v-text-field>
           </div>
           <div>
             <span for="">CPF</span>
             <v-text-field
              required
              v-model="cpf"
               :rules="cpfRules"
               disabled
               v-maska="'###.###.###-##'"
             >
             </v-text-field>
           </div>
         </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
          class="btnClose"
            text
            @click="close"
          >
            Fechar
          </v-btn>
          <v-btn
            class="btnSave"
            text
            @click="update"
          >
            Salvar
          </v-btn>
        </v-card-actions>
      </v-card>
  </v-dialog>
  <v-dialog
      v-model="deleteDialog" 
      max-height="600"
      width="1800"
    >
      <v-card width="500">
        <v-card-text>
         <h1>Deseja excluir este estudante?</h1>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
          class="btnClose"
            text
            @click="close"
          >
            Fechar
          </v-btn>
          <v-btn
            class="btnSave"
            text
            @click="remove"
          >
            Confirmar
          </v-btn>
        </v-card-actions>
      </v-card>
  </v-dialog>
</template>

<style src='./styles.scss'></style>

<script lang="ts">
import { mapActions, mapGetters } from "vuex";
import { useToast } from 'vue-toastification'
interface Students {
  id: number;
  name: string;
  ra: string;
  cpf: string;
  email: string
}

export default {
setup(){
  const toast = useToast()
  return { toast }
},
  mounted() {
    this.gettAllStudents();
  },
  updated() {
    this.gettAllStudents();
    this.remove;
  },
  data() {
    return {
      students: Array<Students>(),
      dialog: false,
      updateDialog: false,
      deleteDialog: false,
      search: '',
      id: 0,
      name : '',
      email: '',
      ra: '',
      cpf: '',
      valid: true,
      updateValid: true,
      emailRules: [
        (v : any) => !!v || 'Campo obrigatório',
        (v : any) => /.+@.+\..+/.test(v) || 'E-mail inválido. Ex: nome@gmail.com...',
      ],
      cpfRules: [
        (v : any) => !!v || 'Campo obrigatório',
        (v : any) => (/^([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11})|([0-9]{9}-[0-9]{2})$/ || v.lenght == 11).test(v) || 'CPF inválido'
      ]
    };
  },
  computed: {
    ...mapGetters({
      getterStudents: "getterStudents",
    }),
  },
  methods: {
    ...mapActions({
      actionGetAllStudents: "actionGetAllStudents",
      actionCreateStudent: "actionCreateStudent",
      actionDeleteStudentById: "actionDeleteStudentById",
      actionPutStudentById: "actionPutStudentById"
    }),
    async gettAllStudents() {
      this.students = await this.actionGetAllStudents();
    },
    close() {
      this.name = ''
      this.ra = ''
      this. cpf = ''
      this.email = ''
      this.dialog = false
      this.updateDialog = false
      this.deleteDialog = false
    },
    async register() {
      const Student = {
        name: this.name,
        email: this.email,
        ra: this.ra.toString(),
        cpf: this.cpf
      }
      const refs: any = this.$refs.form
      const validate = await refs.validate()
      console.log(validate.valid)
      try{
        if(validate.valid == true) {
        this.actionCreateStudent(Student)
        this.gettAllStudents()
        this.toast.success("Cadastrado com sucesso!")
        this.close()
      }
      }catch (error) {
        this.toast.error("Erro ao cadastrar")
      }
    },
    async open(student: Students) {
      this.id = student.id
      this.name = student.name
      this.email = student.email
      this.ra = student.ra
      this.cpf = student.cpf
      this.updateDialog = true
    },
    async update() {
      const UpdateStudent = {
        id: this.id,
        data: {
          name: this.name,
          email: this.email
        }
      }
      await this.actionPutStudentById(UpdateStudent)
      this.gettAllStudents()  
    },
    openConfirmDelete(id: number) {
      this.id = id
      this.deleteDialog = true
    },
    async remove() {
       try {
         await this.actionDeleteStudentById(this.id)
         this.gettAllStudents()
         this.toast.success("Deletado com sucesso")
         this.deleteDialog =  false
       }catch (err) {
         this.toast.error("Erro ao deletar")
       }
    }
  },
};
</script>
