import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

// grabbed from https://stackoverflow.com/questions/60144575/how-do-you-handle-click-outside-of-element-properly-in-vuejs
Vue.directive('click-outside', {
  bind: function (element, binding, vnode) {
    element.clickOutsideEvent = function (event) {  //  check that click was outside the el and his children
      if (!(element === event.target || element.contains(event.target))) { // and if it did, call method provided in attribute value
        vnode.context[binding.expression](event);
        // binding.value(); run the arg
      }
    };
    document.body.addEventListener('click', element.clickOutsideEvent)
  },
  unbind: function (element) {
    document.body.removeEventListener('click', element.clickOutsideEvent)
  }
});



new Vue({
  render: h => h(App),
}).$mount('#app')
