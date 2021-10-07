<template>
  <div :class="[todo.isCompleted ? 'isCompleted' : '']" @mouseenter="hover = true" @mouseleave="hover = false">
    <Button @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    <h2>{{ todo.text }}</h2>
    <div v-if="hover">
    <DeleteButton @onClick="$emit('onDeleteClick', todo.id)" :todo="todo"/>
    </div>
  </div>
</template>

<script>


import Button from './Button.vue'
import DeleteButton from './DeleteButton.vue'

export default {
  name: "Todo",
  components: {
    Button,
    DeleteButton
  },
  data() {
    return{
    hover: false
    }
  },
  props: {
    todo: Object
  },

  emits: ['onClick', 'onDeleteClick']
}
</script>

<style scoped>

div {
  display: flex;
  align-items: center;
}

h2 {
  margin-left: 12px;
  width: 100%;
  font-size: 24px;
  font-weight: 300;
  text-align: left;
}

div.isCompleted h1 {
  color: #e3e3e3;
  text-decoration: line-through;
}

</style>
