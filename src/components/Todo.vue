<template>
  <li :class="[todo.isCompleted ? 'isCompleted' : '']" @mouseenter="hover = true" @mouseleave="hover = false">
    <Button @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    <h2>{{ todo.text }}</h2>
    <div>
    <DeleteButton :class="[hover ? 'visible' : '']" @onDeleteClick="$emit('onDeleteClick', todo.id)" :todo="todo"/>
    </div>
  </li>
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

li {
  display: flex;
  align-items: center;

}

h2 {
  overflow-wrap: anywhere;
  line-height: 1.8rem;
  margin-left: 12px;
  width: 100%;
  font-size: 24px;
  font-weight: 100;
  text-align: left;
}

li.isCompleted h2 {
  color: #e3e3e3;
  text-decoration: line-through;
}

</style>
