import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
mode: 'hash',
base: '/',
routes: [
{
path: '/',
name: 'home',
component: HomePage
},
{
path: '/search/:term',
name: 'search',
component: SearchPage
},
{
path: '/weather/:woeid',
name: 'weather',
component: WeatherPage
}
]
})
