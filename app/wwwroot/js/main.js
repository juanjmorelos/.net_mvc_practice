let users = document.getElementById("users")
let registerUser = document.getElementById("registerUser")
let registerPosition = document.getElementById("registerPosition")

users.addEventListener('click', () => {
    window.location.href = "/users"
})
registerUser.addEventListener('click', () => {
    window.location.href = "/registerUser"
})
registerPosition.addEventListener('click', () => {
    window.location.href = "/newPosition"
})