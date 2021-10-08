<template>
  <ul>
    <ToggleAllButton v-if='todos.length > 0' @onToggleAll="onToggleAll" :toggleState="toggleState"></ToggleAllButton>
    <li :key="todo.id" v-for="todo in todos">
      <Todo @onDeleteClick="$emit('onDeleteClick', todo.id)" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
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
  methods: {
    onToggleAll(toggleState){
      this.$emit('onToggleAll', toggleState)
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
