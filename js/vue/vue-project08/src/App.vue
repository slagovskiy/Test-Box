<template>
  <div id="app" class="container pt-2">
    <div class="form-group">
      <label for="name">Car name</label>
      <input type="text" id="name" class="form-control" v-model.trim="carName">
    </div>
    <div class="form-group">
      <label for="year">Car year</label>
      <input type="text" id="year" class="form-control" v-model.number="carYear">
    </div>
    <button class="btn btn-success" v-on:click="createCar">Create car</button>
    <button class="btn btn-primary" v-on:click="loadCars">Load card</button>
    <hr>
    <ul class="list-group">
      <li
              class="list-group-item"
              v-for="car in cars"
              v-bind:key="car.id"
      >
        <strong>{{car.name}}</strong> - {{car.year}}
      </li>
    </ul>
  </div>
</template>

<script>

export default {
  name: 'app',
  data() {
    return {
      carName: '',
      carYear: 2019,
      cars: [],
      resource: null
    }
  },
  methods: {
    createCar() {
      const car = {
        name: this.carName,
        year: this.carYear
      };
      /*
      this.$http.post('http://localhost:3000/cars', car)
              .then(response => {
                return response.json()
              })
              .then(newCar => {
                /!* eslint-disable *!/console.log(newCar);
                this.carName = '';
                this.carYear = 0
              })
      */
      this.resource.save({}, car)
    },
    loadCars() {
      /*
      this.$http.get('')
              .then(response => {
                return response.json()
              })
              .then(listCars => {
                this.cars = listCars
              })
      */
      this.resource.get()
              .then(response => response.json())
              .then(cars => this.cars = cars)
    }
  },
  created() {
    this.resource = this.$resource('cars')
  }
}
</script>

<style>

</style>
