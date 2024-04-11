await getPositions()
await getUsers()

document.getElementById("position").addEventListener("change", async () => {
    var select = document.getElementById("position")
    const position = select.value;
    const table = document.getElementById("table");
    const tbody = table.querySelector("tbody");
    tbody.innerHTML = "";
    if(position == "") {
        await getUsers()
    } else {
        await getUsersByPositions(position)
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

async function getUsers() {
    try {
        const table = document.getElementById("table");
        const tbody = table.querySelector("tbody");
        tbody.innerHTML = "";
        const response = await fetch('/allUsers', {
            method: 'GET',
        });
        const data = await response.json();
        if(response.ok) {
            var num = 1
            var users = data.users
            users.forEach(data => {
                const row = document.createElement("tr");
                
                const numCell = document.createElement("td");
                numCell.textContent = num;
                row.appendChild(numCell);
                
                const nameCell = document.createElement("td");
                nameCell.textContent = data.name + " " + data.lastName;
                row.appendChild(nameCell);
                
                const positionCell = document.createElement("td");
                positionCell.textContent = data.position;
                row.appendChild(positionCell);
                
                tbody.appendChild(row);
                num++;
            });

        } else {
            alert('Error en la solicitud: ' + data.msg)
        }

    } catch (error) {
        alert('Error: ' + error);
    }
}

async function getUsersByPositions(position) {
    try {
        const table = document.getElementById("table");
        const tbody = table.querySelector("tbody");
        tbody.innerHTML = "";
        const response = await fetch('/allUsersByPosition/' + position, {
            method: 'GET',
        });
        const data = await response.json();
        if (response.ok) {
            
            var num = 1
            var users = data.users
            if(users.length > 0) {
                document.getElementById("empty").style.display = "none";
                users.forEach(data => {
                    const row = document.createElement("tr");
                    
                    const numCell = document.createElement("td");
                    numCell.textContent = num;
                    row.appendChild(numCell);
                    
                    const nameCell = document.createElement("td");
                    nameCell.textContent = data.name + " " + data.lastName;
                    row.appendChild(nameCell);
                    
                    const positionCell = document.createElement("td");
                    positionCell.textContent = data.position;
                    row.appendChild(positionCell);
                    
                    tbody.appendChild(row);
                    num++;
                });
            } else {
                document.getElementById("empty").style.display = "block";
            }
            
    
        } else {
            alert('Error en la solicitud: ' + data.msg)
        }
    } catch (error) {
        console.log(error)
    }
    
}
