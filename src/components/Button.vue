<template>
  <div>
    <button @click="$emit('onClick', todo.id)">
      <svg :class="[todo.isCompleted ? 'isCompleted' : '']" xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 0 24 24" width="24px" fill="#000000">
        <path d="M0 0h24v24H0V0z" fill="none"/>
        <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41L9 16.17z"/>
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  name: "Button",
  props: {
    todo: Object
  },
    emits: ['onClick']
}

</script>

<style scoped>

svg{
  visibility: hidden;
}

.isCompleted{
  visibility: visible;
}

button {
  border-radius: 100%;
  background-color: white;
  height: 32px;
  width: 32px;
  outline: none;
  border: solid #eeeeee 1px;
  display: inline;
  margin: 8px;
}


</style>
