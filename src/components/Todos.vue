<template>
  <ul>
    <li :key="todo.id" v-for="todo in todos">
      <Todo @onDeleteClick="$emit('onDeleteClick', todo.id)" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    </li>
  </ul>
</template>

<script>

import Todo from './Todo.vue'


export default {
  name: "Todos",
  props: {
    todos: Array
  },
  components: {
    Todo
  },
  emits: ['onClick']
}
</script>

<style scoped>


ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}


</style>
