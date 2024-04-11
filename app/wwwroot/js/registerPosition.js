let register = document.getElementById("btnRegister")

register.addEventListener("click", async () => {
    let position = document.getElementById("position").value
    const positionData = {
        position: position
    };
    
    const jsonData = JSON.stringify(positionData);

    try {
        const response = await fetch('/registerPosition', {
            method: 'POST',
            body: jsonData
        });
        const data = await response.json();

        if (response.ok) {
            alert("Se agregó el cargo: " + data.position)
        } else {
            alert('Error en la solicitud: ' + data.msg)
        }
    } catch (error) {
        alert('Error: ' + error);
    }
})