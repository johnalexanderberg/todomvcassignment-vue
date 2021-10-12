<template>
  <div class="container">
    <button class="deleteButton" @click="$emit('onDeleteClick', todo.id)">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" >
        <path d="M0 0h24v24H0V0z" fill="none"/>
        <path
            d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12 19 6.41z"/>
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  name: "DeleteButton",
  props: {
    todo: Object
  },
  emits: ['onDeleteClick']
}

</script>

<style scoped>

.container {
  visibility: hidden;
}
.container.visible{
  visibility: visible;
}

.container.editing{
  display: none;
}

svg {
  fill: #a51818;
  width: 24px;
  height: 24px;
  opacity: 0.5;
  transition: 0.4s;
}

svg:hover {
  opacity: 1;
}


button {
  position: relative;
  border-radius: 100%;
  background-color: white;
  height: 32px;
  width: 32px;
  border: none;
  display: inline;
  margin: 8px;
}


</style>
