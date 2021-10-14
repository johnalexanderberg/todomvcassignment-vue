<template>
  <ul>

    <div v-if='todos.length > 0'
         :class="[todos.filter((todo) => todo.isCompleted === true).length === todos.length ? 'checked' : '', 'toggleAllContainer']">
      <input @change="$emit('onToggleAll')" class="toggle-all" id="toggle-all" type="checkbox"/>
      <label for="toggle-all">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
          <path d="M24 24H0V0h24v24z" fill="none" opacity=".87"/>
          <path d="M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6-1.41-1.41z"/>
        </svg>
      </label>
    </div>

    <li :key="todo.id" v-for="todo in filteredTodos">
      <Todo :isEditing="isEditing" @onSubmit="$emit('onEditSubmit' ,todo.id)" @onDblClick="$emit('onDblClick', todo.id)"
            @onDeleteClick="$emit('onDeleteClick', todo.id)" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    </li>
  </ul>
</template>

<script>

import Todo from './Todo.vue'

export default {
  name: "Todos",
  props: {
    todos: Array,
    isEditing: Boolean
  },
  components: {
    Todo
  },
  methods: {

  },
  computed: {
    filteredTodos() {

      return this.todos.filter(todo => {

        switch (location.hash) {
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
  emits: ['onClick', 'onToggleAll', 'onEditSubmit']
}
</script>

<style scoped>

.toggleAllContainer {
  position: absolute;
  top: 16px;
  left: -8px;
}

input {
  visibility: hidden;
}

svg {
  fill: #d4d4d4;
  width: 36px;
  height: 36px;
}

.checked svg {
  fill: #4d4d4d;
}

ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}

</style>
