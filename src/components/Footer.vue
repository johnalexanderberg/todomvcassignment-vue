<template>
  <footer id="navigation">
    <span id="todo-count"> {{
        todos.filter((todo) => todo.isCompleted === false).length
      }} {{ todos.filter((todo) => todo.isCompleted === false).length === 1 ? 'item' : 'items' }} left</span>
    <div class="buttons">
      <button id="all" :class="currentView" @click="handleAllClick">All</button>
      <button id="active" :class="currentView" @click="handleActiveClick">Active</button>
      <button id="completed" :class="currentView" @click="handleCompletedClick">Completed</button>
    </div>
    <button id="clearCompleted" v-if="todos.filter((todo) => todo.isCompleted === true).length > 0" @click="$emit('onClearCompletedClick')">Clear Completed</button>
  </footer>
</template>

<script>


export default {
  name: 'Footer',
  props: {
    todos: Array,
    counter: Number
  },
  methods: {
    handleAllClick() {
      location.hash = '';
      location.reload();

    },
    handleCompletedClick() {
      location.hash = '#completed';
      location.reload();
    },
    handleActiveClick() {
      location.hash = '#active';
      location.reload();

    },

  },
  computed: {
    currentView() {
      switch (location.hash) {
        case '#active':
          return 'active';
        case '#completed':
          return 'completed';
        default:
          return 'all';
      }
    }
  },

}


</script>


<style scoped>

button, span {
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: 100;
  font-size: 15px;
  color: #777;
}

.buttons {
  text-align: center;
}

#clearCompleted {
  position: absolute;
  right: 12px;
  border: none;
}

#clearCompleted:hover {
  position: absolute;
  right: 12px;
  border: none;
  text-decoration: underline;
  cursor: pointer;
}

#todo-count {
  position: absolute;
  left: 12px;
  text-align: center;

}

#navigation {
  display: flex;
  width: 100%;
  justify-content: center;
  align-items: center;
  border-top: 1px solid #e6e6e6;
  padding: 8px 15px;
  box-shadow: 0 1px 1px rgb(0 0 0 / 20%), 0 8px 0 -3px #f6f6f6, 0 9px 1px -3px rgb(0 0 0 / 20%), 0 16px 0 -6px #f6f6f6, 0 17px 2px -6px rgb(0 0 0 / 20%);
}

#all.all, #completed.completed, #active.active {
  border-color: rgba(175, 47, 47, 0.2);
}


button {
  margin: 0 4px;
  background-color: white;
  border: 1px solid transparent;
  border-radius: 3px;
  display: inline;
  padding: 4px 7px;
  outline: none;
  text-align: center;
}

button:hover {
  border-color: rgba(175, 47, 47, 0.1);
}

</style>
