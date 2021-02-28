<template>
  <table border="1" align="center">
    <tr v-for="user of users" v-bind:key="user">
                <td>{{ user.userId }}</td>
                <td>{{ user.firstName }}</td>
                <td>{{ user.lastName }}</td>
                <td>{{ user.age }}</td>
            </tr>
  </table>
</template>

<script>
import axios from 'axios'
export default {
  name: "About",
  data() {
    return {
      users: []
      }
    },
    methods: {
      getUsers() {
        axios.get('https://localhost:44308/api/users')
        .then((response) => { this.users =  response.data; }).catch(function (error) { alert(error); });
      }
    },
    mounted() {
      this.getUsers();
    }
  }
</script>