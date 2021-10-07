<template>
  <header class="header">
    <h1>todos</h1>
    <input class="new-todo" type="text" placeholder="What needs to be done?">
  </header>
</template>

<script>
export default {
  name: "AddTodo"
}
</script>

<style scoped>
h1 {
  position: absolute;
  top: -75px;
  width: 100%;
  font-size: 100px;
  font-weight: 100;
  text-align: center;
  color: rgba(175, 47, 47, 0.15);
}

input {
  outline: none;
  display: inline-block;
  text-align: start;
  cursor: text;
  padding: 1px 2px;
  border-width: 2px;
  border-style: inset;
  border-image: initial;
}

input::placeholder {
  color: #E2E2E2;
  font-style: italic;
}

.new-todo, .edit {
  position: relative;
  width: 100%;
  font-size: 24px;
  font-family: inherit;
  font-weight: inherit;
  line-height: 1.4em;
  padding: 6px;
  border: 1px solid #999;
  box-shadow: inset 0 -1px 5px 0 rgb(0 0 0 / 20%);
  -webkit-font-smoothing: antialiased;
}

.new-todo {
  padding: 16px 16px 16px 60px;
  border: none;
  background: rgba(0, 0, 0, 0.003);
  box-shadow: inset 0 -2px 1px rgb(0 0 0 / 3%);
}


</style>
