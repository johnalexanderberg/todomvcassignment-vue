<template>
  <li :class="[todo.isCompleted ? 'isCompleted' : '']">
    <div>
      <button :class="[todo.isCompleted ? 'isCompleted' : '', 'completedButton', todo.isEditing ? 'editing' : '']"
              @click="$emit('onClick', todo.id)">
        <svg class="completedIcon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
          <path d="M0 0h24v24H0V0z" fill="none"/>
          <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41L9 16.17z"/>
        </svg>
      </button>
    </div>

    <form :class="[todo.isEditing ? 'editing' : '']" @submit="$emit('onSubmit', todo.id)"
          @submit.prevent="preventDefault"><input v-model="todo.text" class="edit" type="text" autofocus></form>
    <h2 :class="[todo.isEditing ? 'editing' : '']" @dblclick="$emit('onDblClick', todo.id)"> {{ todo.text }} </h2>

    <div :class="[todo.isEditing ? 'editing' : '', 'deleteContainer']">
      <button :class="[todo.isEditing ? 'editing' : '', 'deleteButton']" @click="$emit('onDeleteClick', todo.id)">

        <svg class="deleteButton" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
          <path d="M0 0h24v24H0V0z" fill="none"/>
          <path
              d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12 19 6.41z"/>
        </svg>
      </button>
    </div>
    <div class="border"></div>
  </li>
</template>

<script>

export default {
  name: "Todo",
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

/* Delete Button */
li:hover .deleteContainer {
  visibility: visible;
}

.deleteContainer {
  visibility: hidden;
}

.deleteContainer.editing {
  display: none;
}

.deleteButton svg {
  fill: #a51818;
  width: 24px;
  height: 24px;
  opacity: 0.5;
  transition-property: opacity;
  transition-duration: 0.4s;
}

.deleteButton svg:hover {
  opacity: 1;
}


.deleteButton {
  position: relative;
  border-radius: 100%;
  background-color: white;
  height: 32px;
  width: 32px;
  border: none;
  display: inline;
  margin: 8px;
}

/* Completed Button */

.completedButton.editing {
  visibility: hidden;
}

.completedButton .completedIcon {
  visibility: hidden;
  fill: #4fe585;
  width: 24px;
  height: 24px;
}

.isCompleted .completedIcon {
  visibility: visible;
}

.completedButton {
  border-radius: 100%;
  background-color: white;
  height: 32px;
  width: 32px;
  outline: none;
  display: inline;
  border: solid #eeeeee 1px;
  margin-left: 8px;
}

.completedButton.isCompleted {

  border: solid #dbdbdb 1px;

}

.completedButton.editing>svg{
  visibility: hidden;
}

/* List Item */
li {
  height: 50px;
  display: flex;
  align-items: center;
  border-top: 1px solid #E6E6E6FF;
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

li.isCompleted h2 {
  color: #e3e3e3;
  text-decoration: line-through;
}

h2.editing {
  display: none;
}

/* Form (When editing) */

form {
  display: none;
  box-sizing: border-box;
}

form.editing {
  display: flex;
  width: 100%;
  height: 100%;
}

input {
  display: flex;
  align-items: stretch;
  box-shadow: inset 0 0 6px 0px rgba(104, 104, 104, 0.22);
  padding: 8px 12px;
  margin: 0;
  outline: none;
  border: 1px solid #959595;
  cursor: text;
}


</style>
