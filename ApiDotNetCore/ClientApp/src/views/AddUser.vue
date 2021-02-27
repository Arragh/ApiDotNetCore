<template>
    <div>
        <form @submit="postData" method="post">
            <input type="text" name="firstName" placeholder="firstName" v-model="posts.firstName"><br><br>
            <input type="text" name="lastName" placeholder="lastName" v-model="posts.lastName"><br><br>
            <input type="number" name="age" placeholder="age" v-model="posts.age"><br><br>
            <button type="submit">Post</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            posts: {
                firstName: null,
                lastName: null,
                age: null
            }
        }
    },
    methods: {
        postData(e) {
            console.warn(this.posts)
            axios.post("api/users", this.posts)
            this.posts.firstName = null
            this.posts.lastName = null
            this.posts.age = null
            e.preventDefault();
        }
    }
}
</script>