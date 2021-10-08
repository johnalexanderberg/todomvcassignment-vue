<template>
    <footer id="navigation">
        <span id="todo-count"> {{ todos.filter((todo) => todo.isCompleted === false).length }} {{todos.filter((todo) => todo.isCompleted === false).length === 1 ? 'item' : 'items'}} left</span>
        <div class="buttons">
            <button>All</button>
            <button>Active</button>
            <button>completed</button>
        </div>
    </footer>
</template>

<script>


export default {
    name: 'Footer',
    props: {
        todos: Object,
        counter: Number
    },
}




</script>


<style scoped>
.buttons {
    float: center;
    text-align: center;
}
#todo-count {
    float: left;
    text-align: center;

}
#navigation {
    border-top: 1px solid #e6e6e6;
    padding: 10px 15px;
    box-shadow: 0 1px 1px rgb(0 0 0 / 20%), 0 8px 0 -3px #f6f6f6, 0 9px 1px -3px rgb(0 0 0 / 20%), 0 16px 0 -6px #f6f6f6, 0 17px 2px -6px rgb(0 0 0 / 20%);
}
#navigation button {
    display: inline;
    color: #777;
    height: 20px;
    margin: 3px;
    padding: 3px 7px;
    text-decoration: none;

    text-align: center;
}
button:hover {
    border-color: rgba(175, 47, 47, 0.2);
}
button {
    background-color: white;
    border: 1px solid transparent;
    border-radius: 3px;
}

</style>
