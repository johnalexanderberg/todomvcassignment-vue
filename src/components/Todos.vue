<template>
  <ul>
    <ToggleAllButton v-if='todos.length > 0' @onToggleAll="onToggleAll" :toggleState="toggleState"></ToggleAllButton>
    <li :key="todo.id" v-for="todo in todos">
      <Todo @onOutsideClick="handleOutsideClick" :isEditing="isEditing" @onSubmit="handleEdit" @onDblClick="handleDblClick" @onDeleteClick="$emit('onDeleteClick', todo.id)" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    </li>
  </ul>
</template>

<script>

import Todo from './Todo.vue'
import ToggleAllButton from './ToggleAllButton.vue'


export default {
  name: "Todos",
  props: {
    todos: Array,
    toggleState: Boolean
  },
  components: {
    ToggleAllButton,
    Todo
  },
  data() {
    return {
    isEditing : false
    }
  },
  methods: {
    handleOutsideClick(id){

      alert(id)

      //this.isEditing = false;
    },
    onToggleAll(toggleState){
      this.$emit('onToggleAll', toggleState)
    },
    handleDblClick(id){
      if (this.isEditing === false){
        this.isEditing = true;

        this.todos.forEach((todo) => {
          if (todo.id === id){
            todo.isEditing = true
          }
        })
      } else {
        this.todos.forEach((todo) => {
          if (todo.isEditing === true){
            todo.isEditing = false;

            this.todos.forEach((todo) => {
              if (todo.id === id) {
                todo.isEditing = true;
              }
            })

          }

        })
      }
      },
    handleEdit(id){
      this.isEditing = false;
      this.todos.forEach((todo) => {
        if (todo.id === id){
          todo.isEditing = false;
        }
      })
    },
  },
  emits: ['onClick', 'onToggleAll']
}
</script>

<style scoped>


ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}


</style>
