<template>
  <div>
    <button :class="[todo.isCompleted ? 'isCompleted' : '', 'completedButton']" @click="$emit('onClick', todo.id)">
      <svg class="completedIcon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" >
        <path d="M0 0h24v24H0V0z" fill="none"/>
        <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41L9 16.17z"/>
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  name: "CompletedButton",
  props: {
    todo: Object
  },
    emits: ['onClick']
}

</script>

<style scoped>

div.editing {
  visibility: hidden;
}
.completedButton svg{
  visibility: hidden;
  fill: #4fe585;
  width: 24px;
  height: 24px;
}

.isCompleted svg{
  visibility: visible;
}

.completedButton {
  border-radius: 100%;
  background-color: white;
  height: 32px;
  width: 32px;
  outline: none;
  border: solid #eeeeee 1px;
  display: inline;
  margin-left: 8px;
}

.completedButton.isCompleted {

  border: solid #dbdbdb 1px;

}


</style>
