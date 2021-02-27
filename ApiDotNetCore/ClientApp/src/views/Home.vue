<template>
  <div>
    <table border="1">
      <tr v-for="user in users" :key="user">
        <td>{{ user.userId }}</td>
        <td>{{ user.firstName }}</td>
        <td>{{ user.lastName }}</td>
        <td>{{ user.age }}</td>
      </tr>
    </table>
  </div>
  <h1>Methods</h1>
  <p>Name: {{ name }}</p>
  <button @click="changeName">Change Name</button>
  <p>{{ counter }}</p>
  <button @click="increaseCounter">Increase</button>&nbsp;&nbsp;&nbsp;<button @click="decreaseCounter">Decrease</button>&nbsp;&nbsp;&nbsp;<button @click="counter++">++</button>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      users: [],
      name: 'Вася Пупкин',
      counter: 0
    }
  },
  methods: {
    changeName() {
      if(this.name == 'Вася Пупкин') {
        this.name = 'Петя Кукин'
      }
      else {
        this.name = 'Вася Пупкин'
        this.alertHandler()
      }
    },
    alertHandler() {
      alert('Да ты охуел там чтоли, сука??!!!')
    },
    increaseCounter() {
        this.counter++
      },
    decreaseCounter() {
      if(this.counter === 0) {
        alert('Счетчик уже ноль')
      }
      else {
        this.counter--
      }
    }
  }
}
</script>
