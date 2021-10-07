<template>
  <div :class="[todo.isCompleted ? 'isCompleted' : '']" @mouseover="hovering">
    <Button @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    <h1>{{ todo.text }}</h1>
    <DeleteButton @onClick="$emit('onDeleteClick', todo.id)" :todo="todo"/>
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
  props: {
    todo: Object
  },
  data: {
    hovering: false
  },
  methods: {
    hovering(){
    this.data.hovering = true;
    }
  },
    emits: ['onClick', 'onDeleteClick']
}
</script>

<style scoped>

div {
  display: flex;
  align-items: center;
}

div:hover {
display: none
}

h1 {
  margin-left: 12px;
  width: 100%;
  font-size: 24px;
  font-weight: 100;
  text-align: left;
}

div.isCompleted h1{
  color: gray;
 text-decoration: line-through;
}

</style>
