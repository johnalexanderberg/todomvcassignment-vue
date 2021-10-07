<template>
  <header class="header">
    <h1>todos</h1>
    <form @submit="$emit('onSubmit', text)" @submit.prevent="preventDefault"><input v-model="text" class="todo" type="text" placeholder="What needs to be done?"></form>
  </header>
</template>

<script>

export default {
  name: "AddTodo",
  data() {
    return{
      text: ''
    }
  },
  methods: {
    preventDefault() {
      this.text = '';
    }
  },
  emits: ['onSubmit'],
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
  color: #dedede;
  font-style: italic;
}

.todo {
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

.todo {
  padding: 16px 16px 16px 60px;
  border: none;
  background: rgba(0, 0, 0, 0.003);
  box-shadow: inset 0 -2px 1px rgb(0 0 0 / 3%);
}


</style>
