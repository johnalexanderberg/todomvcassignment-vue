<template>
  <div id="app">
    <AddTodo/>
    <Todos @onClick="handleCompletedClick" :todos="todos"/>

  </div>
</template>

<script>

import AddTodo from './components/AddTodo.vue'
import Todos from './components/Todos.vue'

export default {
  name: 'App',
  components: {
    AddTodo,
    Todos,
  },
  data() {
    return {
      todos: []
    }
  },
  methods: {
    handleCompletedClick(id){
      this.todos.forEach(todo => {
        if (todo.id === id){
          todo.isCompleted = !todo.isCompleted;
        }
      })
    }
  },
  created() {
    this.todos = [
      {
        id: 1,
        text: 'Doctors Appointment',
        isCompleted: true
      },
      {
        id: 2,
        text: 'Meeting at School',
        isCompleted: true
      },
      {
        id: 3,
        text: 'Create Todo App',
        isCompleted: false
      }
    ]
  }
}
</script>

<style>

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

:root {
  --color-body: #4d4d4d;
}

#app {
  background: #fff;
  margin: 130px 0 40px 0;
  position: relative;
  box-shadow: 0 2px 4px 0 rgb(0 0 0 / 20%), 0 25px 50px 0 rgb(0 0 0 / 10%);
}


body {
  font: 14px 'Helvetica Neue', Helvetica, Arial, sans-serif;
  line-height: 1.4em;
  background: #f5f5f5;
  color: var(--color-body);
  min-width: 230px;
  max-width: 550px;
  margin: 0 auto;
  font-weight: 300;
}

</style>
