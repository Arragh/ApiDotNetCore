<template>
  <table border="1" align="center">
    <tr v-for="forecast of forecasts" v-bind:key="forecast">
                <td>{{ forecast.userId }}</td>
                <td>{{ forecast.firstName }}</td>
                <td>{{ forecast.lastName }}</td>
                <td>{{ forecast.age }}</td>
            </tr>
  </table>
</template>

<script>
import axios from 'axios'
export default {
  name: "About",
  data() {
    return {
      forecasts: []
      }
    },
    methods: {
      getWeatherForecasts() {
        axios.get('https://localhost:44308/api/users')
        .then((response) => { this.forecasts =  response.data; }).catch(function (error) { alert(error); });
      }
    },
    mounted() {
      this.getWeatherForecasts();
    }
  }
</script>