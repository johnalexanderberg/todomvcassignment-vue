<template>
  <footer id="navigation">
    <span id="todo-count"> {{
        todos.filter((todo) => todo.isCompleted === false).length
      }} {{ todos.filter((todo) => todo.isCompleted === false).length === 1 ? 'item' : 'items' }} left</span>
    <div class="buttons">
      <button>All</button>
      <button>Active</button>
      <button>Completed</button>
    </div>
  </footer>
</template>

<script>


export default {
  name: 'Footer',
  props: {
    todos: Array,
    counter: Number
  },
}


</script>


<style scoped>

button, span{
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
  font-weight: 100;
  font-size: 15px;
  color: #777;
}

.buttons {
  text-align: center;
}

#todo-count {
  float: left;
  text-align: center;

}

#navigation {
  align-items: center;
  border-top: 1px solid #e6e6e6;
  padding: 8px 15px;
  box-shadow: 0 1px 1px rgb(0 0 0 / 20%), 0 8px 0 -3px #f6f6f6, 0 9px 1px -3px rgb(0 0 0 / 20%), 0 16px 0 -6px #f6f6f6, 0 17px 2px -6px rgb(0 0 0 / 20%);
}

button {
  background-color: white;
  border: 1px solid transparent;
  border-radius: 3px;
  display: inline;
  padding: 4px 7px;

  text-align: center;
}

button:hover {
  border-color: rgba(175, 47, 47, 0.2);
}

button {

}

</style>
