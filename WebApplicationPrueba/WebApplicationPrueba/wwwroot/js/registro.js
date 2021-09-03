document.getElementById("btn__iniciar-sesion").addEventListener("click", iniciarSesion);
document.getElementById("btn__registrarse").addEventListener("click", register);


window.addEventListener("resize",anchoPagina);

var contenedor_login_register= document.querySelector(".contenedor__login-register");
var formulario_login= document.querySelector(".formulario__login");
var formulario_register= document.querySelector(".formulario__register");
var caja_trasera_login= document.querySelector(".caja__trasera-login");
var caja_trasera_register= document.querySelector(".caja__trasera-register");

function anchoPagina(){
    if (window.innerWidth > 850){
        caja_trasera_login.style.display="block";
        caja_trasera_register.style.display="block";
    }else{
        caja_trasera_register.style.display="block";
        caja_trasera_register.style.opacity="1";
        caja_trasera_login.style.display="none";
        formulario_login.style.display="block";
        formulario_register.style.display="none";
        contenedor_login_register.style.left="0px";
    }
}

anchoPagina();

function iniciarSesion(){

    if (window.innerWidth > 850){
        formulario_register.style.display ="none";
        contenedor_login_register.style.left ="10px";
        formulario_login.style.display="block";
        caja_trasera_register.style.opacity="1";
        caja_trasera_login.style.opacity="0";
    }else{
        formulario_register.style.display ="none";
        contenedor_login_register.style.left ="0px";
        formulario_login.style.display="block";
        caja_trasera_register.style.display="block";
        caja_trasera_login.style.display="none";
    }
        
}

function register(){

    if (window.innerWidth > 850){
        formulario_register.style.display ="block";
        contenedor_login_register.style.left ="410px";
        formulario_login.style.display="none";
        caja_trasera_register.style.opacity="0";
        caja_trasera_login.style.opacity="1";   
    }else{
        formulario_register.style.display ="block";
        contenedor_login_register.style.left ="0px";
        formulario_login.style.display="none";
        caja_trasera_register.style.display="none";
        caja_trasera_login.style.display="block";
        caja_trasera_login.style.opacyty="1"
    } 
}

var usuarios =[];
var apellidosNombres =[];
var claves = [];

function login(userName, password){
    let indice = -1;
    let i = -1;
    let validacionUsuario = false
    usuarios.forEach(usuario => {
        i++;
        if (userName == usuario && password == claves[i]){
            validacionUsuario= true;
            indice = i;
        }
    });
    if (validacionUsuario){
        localStorage.setItem('usuarioLogueado', userName);
        localStorage.setItem('nombreUsuario', apellidosNombres[indice])
        alert('Bienvenido');
        window.open("../", "_self")
    }else{
        alert('El Usuario y/o la contraseña no son correctos')
    }
}

function login2(userName, password){
    let validacionUsuario= false;
    let indice= -1;
    for (let i=0; i<usuarios.lenth; i++){
        indice++;
        if (userName == usuario[i] && password == claves[i]){
            validacionUsuario = true;
            indice = i;
        }
    };
    if (validacionUsuario){
        localStorage.setItem('usuarioLogueado', userName);
        localStorage.setItem('nombreUsuario', apellidosNombres[indice])
        alert('Bienvenido');
        window.open('inicio.html');
    }else{
        alert('El Usuario y/o la contraseña no son correctos')
    }
} 

function registrarUsuario (userName, password, nombres){
    apellidosNombres.push(nombres);
    usuarios.push(userName);
    claves.push(password);
    alert('usuario registrado, seras redirigido al login');
    mostrarLogin()
}

function mostrarRegistro(){
    document.getElementById('titulo').innerHTML= 'Registrarse'
    document.getElementById('register_form').style.display= 'block'
    document.getElementById('login-form').style.display= 'none'
}

function mostrarLogin(){
    document.getElementById('titulo').innerHTML= 'Iniciar sesion'
    document.getElementById('register_form').style.display= 'none'
    document.getElementById('login-form').style.display= 'block'
}