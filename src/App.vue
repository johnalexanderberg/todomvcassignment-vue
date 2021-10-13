<template>
  <div id="app" @click="handleOutsideClick">
    <main>
      <Header @onSubmit="handleSubmit"/>
      <Todos @onDblClick="handleDblClick" @onEditSubmit="handleEditSubmit" @onToggleAll="handleToggleAll" @onDeleteClick="handleDeleteClick" @onClick="handleCompletedClick"
             :todos="todos"/>
      <Footer v-if='todos.length > 0' :todos="todos" @onClearCompletedClick="handleClearCompletedClick"/>
    </main>

    <footer id="footer">
      <p>Double-click to edit a todo</p>
      <p>
        Written by
        <a href="https://github.com/johnalexanderberg">Alexander</a> and
        <a href="https://github.com/AThomasBring">Anton</a>
      </p>
      <p>Part of <a href="https://todomvc.com/">TodoMVC</a></p>
    </footer>
  </div>
</template>

<script>

import Header from './components/Header.vue'
import Todos from './components/Todos.vue'
import Footer from './components/Footer.vue'


export default {

  name: 'App',
  components: {
    Header,
    Todos,
    Footer
  },
  data() {
    return {
      todos: [],
      toggleState: Boolean,
      isEditing: Boolean
    }
  },
  methods: {

    handleDblClick(id) {

      console.log(this.isEditing)

      //We need to reset isEditing states before editing a new one (we dont want to allow editing more than 1 item at a time).
      if (this.isEditing === true) {
        this.todos.forEach((todo) => {
          todo.isEditing = false;
        })
      } else {
        this.isEditing = true;
      }

      //now we can set the individual item's state to isEditing.
      this.todos.forEach((todo) => {
        if (todo.id === id) {
          todo.isEditing = true;
        }
      })
    },

    handleEditSubmit(id) {

      this.isEditing = false;
      this.todos.forEach((todo) => {
        if (todo.id === id) {
          todo.isEditing = false;
        }
      });

      this.saveTodos();


    },

    
    handleOutsideClick(event) {

        for (let i = 0; i < this.todos.length; i++) {
          if (this.todos[i].isEditing === true && !event.target.classList.contains('edit')) {
            this.todos[i].isEditing = false;
            this.isEditing = false;
            this.saveTodos();
          }
        }
    },

    handleToggleAll() {

      if (this.todos.filter((todo) => todo.isCompleted === true).length === this.todos.length) {

      this.todos.forEach(todo => {
        todo.isCompleted = false
      });
      } else {
        this.todos.forEach(todo => {
          todo.isCompleted = true
        });
      }

      this.saveTodos();

    },
    handleCounter() {
      this.todos.forEach(todo => {
        if (todo.isCompleted === false) {
          this.counter++
        } else {
          this.counter--
        }
      })

    },
    handleClearCompletedClick(){
      this.todos = this.todos.filter((todo) => todo.isCompleted === false);

      this.saveTodos();
    },
    handleCompletedClick(id) {
      this.todos.forEach(todo => {
        if (todo.id === id) {
          todo.isCompleted = !todo.isCompleted;
        }
      })

      this.toggleState = false;

      if (this.todos.filter((todo) => todo.isCompleted).length === this.todos.length) {
        this.toggleState = true;
      }

      this.saveTodos();
    },
    handleDeleteClick(id) {
      this.todos = this.todos.filter((todo) => todo.id !== id);

      this.saveTodos();

    },
    handleSubmit(text) {
      let trimmedText = text.trim();

      if (trimmedText.length === 0) {
        return
      }

      const newTodo = {
        //todo: göra unika id:n ist för random
        id: Math.round(Math.random() * 100000),
        text: text,
        isCompleted: false,
        isEditing: false
      }

      this.todos.push(newTodo)
      this.saveTodos();

    },
    saveTodos() {
      const parsed = JSON.stringify(this.todos);
      localStorage.setItem('todos', parsed);
    },

  },


  mounted() {

    window.addEventListener('hashchange', function () {      location.reload();})

    //load stored todos
    if (localStorage.getItem('todos')) {
      try {
        this.todos = JSON.parse(localStorage.getItem('todos'));
      } catch (e) {
        localStorage.removeItem('todos');
      }
    }
    this.todos.forEach((todo) => {
      todo.isEditing = false;
    })
  }
}

</script>

<style>

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

#app {
  position: absolute;
  width: 100%;
  height: 100%;
}

:root {
  --color-body: #4d4d4d;
}

main {
  background: #fff;
  position: relative;
  box-shadow: 0 2px 4px 0 rgb(0 0 0 / 20%), 0 25px 50px 0 rgb(0 0 0 / 10%);
  min-width: 230px;
  max-width: 550px;
  margin: 130px auto 0px auto;
}

body {
  font: 14px 'Helvetica Neue', Helvetica, Arial, sans-serif;
  line-height: 1.4em;
  background: #f5f5f5;
  color: var(--color-body);
  font-weight: 300;
}

#footer {
  position: relative;
  color: #bfbfbf;
  text-align: center;
  font-size: 10px;
  opacity: 0.7;
  text-shadow: 0 1px 0 rgb(255 255 255 / 50%);
  margin-top: 60px;
}


a:link,
a:active,
a:visited {
  font-weight: 400;
  text-decoration: none;
  color: #b7b7b7;
}

a:hover {
  color: #b7b7b7;
  text-decoration: underline;
}


</style>
