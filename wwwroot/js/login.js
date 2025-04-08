
function login() {

    const usuarioData = {
        UsuarioID: document.getElementById("idUsuario").value,
        USU_Password: document.getElementById("usuario").value,
    };
    const baseUrl = window.location.origin;
    fetch("Login/LogIn", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(usuarioData)
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
            
                alert(data.message);
                window.location.href = baseUrl + "/swagger/index.html";
            } else {
                alert(data.message);
               
            }
        })
        .catch(error => console.error("Error:", error));

}