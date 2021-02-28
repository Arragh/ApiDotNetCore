<template>
    <div>
        <p v-if="errors.length > 0">
            <b>Пожалуйста исправьте указанные ошибки:</b>
            <ul>
                <li v-for="error in errors">{{ error }}</li>
            </ul>
        </p>
    </div>
    <div>
        <form @submit="postData" method="post">
            <input type="text" name="firstName" placeholder="firstName" v-model="user.firstName"><br><br>
            <input type="text" name="lastName" placeholder="lastName" v-model="user.lastName"><br><br>
            <input type="number" name="age" placeholder="age" v-model="user.age"><br><br>
            <button type="submit">Post</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            user: {
                firstName: '',
                lastName: '',
                age: 0
            },
            errors: []
        }
    },
    methods: {
        postData(e) {
            if(this.user.firstName.length > 3 && this.user.lastName.length > 3) {
                this.errors = []
                console.warn(this.user)
                axios.post("api/users", this.user)
                this.user.firstName = null
                this.user.lastName = null
                this.user.age = null
                e.preventDefault();
            }
            else {
                this.errors = []
                if(this.user.firstName.length < 4) {
                    this.errors.push('Длина имени должна быть не менее 4 символов.')
                }
                if(this.user.lastName.length < 4) {
                    this.errors.push('Длина фамилии должна быть не менее 4 символов.')
                }
                e.preventDefault();
            }
        }
    }
}
</script>