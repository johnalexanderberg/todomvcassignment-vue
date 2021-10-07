<template>
  <div :class="[this.toggleState ? 'checked' : '']">
    <input @change="onToggleAll"  class="toggle-all" id="toggle-all" type="checkbox"/>
    <label for="toggle-all">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" >
        <path d="M24 24H0V0h24v24z" fill="none" opacity=".87"/>
        <path d="M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6-1.41-1.41z"/>
      </svg>
    </label>
  </div>
</template>

<script>
export default {
  name: "ToggleAllButton",
  props: {
    toggleState: Boolean
  },
  methods: {
    onToggleAll(){
      this.$emit('onToggleAll', !this.toggleState)
    },
  },
}
</script>

<style scoped>
div {
  position: absolute;
  top: 16px;
  left: -8px;
}

input{
  visibility: hidden;
}

svg {
  fill: #d4d4d4;
  width: 36px;
  height: 36px;
}

.checked svg{
  fill: #4d4d4d;
}
</style>
