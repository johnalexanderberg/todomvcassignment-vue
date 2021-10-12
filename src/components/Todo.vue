<template>
  <li :class="[todo.isCompleted ? 'isCompleted' : '']" @mouseenter="hover = true" @mouseleave="hover = false">
    <CompletedButton :class="[todo.isEditing ? 'editing' : '']" @onClick="$emit('onClick', todo.id)" :todo="todo"/>
    <form :class="[todo.isEditing ? 'editing' : '']" @submit="$emit('onSubmit', todo.id)" @submit.prevent="preventDefault"><input v-model="todo.text" class="edit" type="text"></form>
    <h2 :class="[todo.isEditing ? 'editing' : '']" @dblclick="$emit('onDblClick', todo.id)" > {{ todo.text }} </h2>
    <div>
    <DeleteButton :class="[hover ? 'visible' : '', todo.isEditing ? 'editing' : '']" @onDeleteClick="$emit('onDeleteClick', todo.id)" :todo="todo"/>
    </div>
  </li>
</template>

<script>


import CompletedButton from './CompletedButton.vue'
import DeleteButton from './DeleteButton.vue'

export default {
  name: "Todo",
  components: {
    CompletedButton,
    DeleteButton
  },
  data() {
    return{
    hover: false,
    }
  },
  props: {
    todo: Object,
    isEditing: Boolean
  },
  methods: {
    preventDefault() {

    }
  },
  emits: ['onClick', 'onDeleteClick']
}
</script>

<style scoped>

li {
  height: 50px;
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

h2.editing {
  display: none;
}


form{
  display: none;
  box-sizing: border-box;
}

form.editing{
  display: flex;
}
input{
  display: flex;
  align-items: stretch;
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
