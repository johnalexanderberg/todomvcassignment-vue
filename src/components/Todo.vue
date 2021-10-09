<template>
  <li :class="[todo.isCompleted ? 'isCompleted' : '']" @mouseenter="hover = true" @mouseleave="hover = false">
    <Button :class="[isEditing ? 'editing' : '']" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    <form :class="[isEditing ? 'editing' : '']" @submit="handleEdit" @submit.prevent="preventDefault"><input v-model="todo.text" class="edit" type="text"></form>
    <h2 :class="[isEditing ? 'editing' : '']" > {{ todo.text }}</h2>
    <div>
    <DeleteButton :class="[hover ? 'visible' : '', isEditing ? 'editing' : '']" @onDeleteClick="$emit('onDeleteClick', todo.id)" :todo="todo"/>
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
    hover: false,
      isEditing: true
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

h2, input {
  font-family: inherit;
  padding: 15px 15px 15px 0px;
  overflow-wrap: anywhere;
  line-height: 1.8rem;
  margin-left: 12px;
  width: 100%;
  font-size: 24px;
  font-weight: 100;
  text-align: left;
}

form{
  display: none;
  box-sizing: border-box;
}

form.editing{
  display: block;
}
input{
  box-shadow:inset 0 0 6px 0px rgba(104, 104, 104, 0.22);
  padding: 8px 12px;
  margin: 0;
  outline: none;
  border: 1px solid #959595;
}

li.isCompleted h2 {
  color: #e3e3e3;
  text-decoration: line-through;
}

</style>
