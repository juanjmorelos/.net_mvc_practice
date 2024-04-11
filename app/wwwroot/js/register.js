let register = document.getElementById("btnRegister")

getPositions()
register.addEventListener("click", async () => {
    let name = document.getElementById("name").value
    let lastName = document.getElementById("lastName").value
    let position = document.getElementById("position").value
    const userData = {
        name: name,
        lastName: lastName,
        position: position
    };
    
    const jsonData = JSON.stringify(userData);

    try {
        const response = await fetch('/register', {
            method: 'POST',
            body: jsonData
        });
        const data = await response.json();

        if (response.ok) {
            alert("Se agregó el usuario: " + data.user.name + " " + data.user.lastName)
        } else {
            alert('Error en la solicitud: ' + data.msg)
        }
    } catch (error) {
        alert('Error: ' + error);
    }
})

async function getPositions() {
    try {
        const response = await fetch('/allPositions', {
            method: 'POST',
            body: "{}"
        });
        const data = await response.json();
        if(response.ok) {
            var select = document.getElementById("position")
            const options = data.positionData;

            options.forEach(function(position) {
                var newOption = document.createElement("option");
                newOption.value = position.positionId;
                newOption.text = position.positionName;
                select.appendChild(newOption);
            });

        } else {
            alert('Error en la solicitud: ' + data.msg)
        }

    } catch (error) {
        alert('Error: ' + error);
    }
}