<template>
  <ul>
    <ToggleAllButton v-if='todos.length > 0' @onToggleAll="onToggleAll" :toggleState="toggleState"></ToggleAllButton>
    <li :key="todo.id" v-for="todo in filteredTodos">
      <Todo :isEditing="isEditing" @onSubmit="handleEdit" @onDblClick="handleDblClick"
            @onDeleteClick="$emit('onDeleteClick', todo.id)" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
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
    toggleState: Boolean,
    isEditing: Boolean,
    filter: String
  },
  components: {
    ToggleAllButton,
    Todo
  },
  methods: {

    onToggleAll(toggleState) {
      this.$emit('onToggleAll', toggleState)
    },
    handleDblClick(id) {

      // if else statement is to reset isEditing states before editing a new one
      //first we check if an item is currently being edited and reset state.
      if (this.isEditing === true) {
        this.todos.forEach((todo) => {
          if (todo.isEditing === true) {
            todo.isEditing = false;
          }
        })
        //else no item is currently being edited and we can set isEditing to true without looping through the items.
      } else {
        this.isEditing = true;

      }

      //now we can set the individual items state to isEditing.
      this.todos.forEach((todo) => {
        if (todo.id === id) {
          todo.isEditing = true;
        }
      })


    },
    handleEdit(id) {
      this.isEditing = false;
      this.todos.forEach((todo) => {
        if (todo.id === id) {
          todo.isEditing = false;
        }
      })
    },
  },
  computed: {
    filteredTodos() {

      return this.todos.filter(todo => {

        switch(location.hash) {
          case '#active':
            return !todo.isCompleted;
          case '#completed':
            return todo.isCompleted;
          default:
            return true;
        }
      });
    }
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
