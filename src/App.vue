<template>
  <div id="app">
    <AddTodo @onSubmit="handleSubmit"/>
    <Todos @onToggleAll="handleToggleAll" @onDeleteClick="handleDeleteClick" @onClick="handleCompletedClick"
           :todos="todos" :toggleState="toggleState"/>
    <Footer v-if='todos.length > 0' :todos="todos" />
  </div>
</template>

<script>

import AddTodo from './components/AddTodo.vue'
import Todos from './components/Todos.vue'
import Footer from './components/Footer.vue'

//todo ToggleAllButtons ska bara synas om det finns todos i listan

export default {
  name: 'App',
  components: {
    AddTodo,
    Todos,
    Footer
  },
  data() {
    return {
      todos: [],
      toggleState: Boolean,
      counter: Number
    }
  },
  methods: {
    handleToggleAll(toggleState) {

      this.todos.forEach(todo => {
        todo.isCompleted = toggleState ? true : false
      });

      this.toggleState = toggleState;

      this.saveTodos();
      this.saveToggleState();
    },
    handleCounter() {
      this.todos.forEach(todo => {
        if (todo.isCompleted === false) {
        this.counter++
      }
      else {this.counter--}
      })
      
    },
    
    handleCompletedClick(id) {
      this.todos.forEach(todo => {
        if (todo.id === id) {
          todo.isCompleted = !todo.isCompleted;
        }
      })

      if (this.toggleState){
        this.toggleState = false;
      }
      this.saveToggleState();
      this.saveTodos();
    },
    handleDeleteClick(id) {
      this.todos = this.todos.filter((todo) => todo.id !== id);

      //todo if remaining items are all completed, toggle toggleAll
      this.saveTodos();

    },
    handleSubmit(text) {
      let trimmedText = text.trim();

      if (trimmedText.length === 0) {
        return
      }

      const newTodo = {
        //todo: always make unique IDs
        id: Math.round(Math.random() * 100000),
        text: text,
        isCompleted: false
      }

      this.todos.push(newTodo)
      this.saveTodos();

    },
    saveTodos() {
      const parsed = JSON.stringify(this.todos);
      localStorage.setItem('todos', parsed);
    },
    saveToggleState() {

      const parsed = JSON.stringify(this.toggleState);
      localStorage.setItem('todoToggle', parsed);
    },
    
  },


  mounted() {
    //load stored todos
    if (localStorage.getItem('todos')) {
      try {
        this.todos = JSON.parse(localStorage.getItem('todos'));
      } catch (e) {
        localStorage.removeItem('todos');
      }
    }

    //load toggle state
    if (localStorage.getItem('todoToggle')) {
      try {
        this.toggleState = JSON.parse(localStorage.getItem('todoToggle'));
      } catch (e) {
        localStorage.removeItem('todoToggle');
      }
    }

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
