class producto{
	constructor(nombre, categoria, precio, fecha, descripcion){
		this.nombre = nombre;
		this.categoria = categoria;
		this.precio = precio;
		this.fecha = fecha;
		this.descripcion = descripcion;
	}
}


class acciones{
	addProduct(produc){
		const productoAgregado = document.getElementById('productos');

		const objeto = document.createElement('div');

		objeto.innerHTML = `
		<div class="card text-center mb-5">
			<div class="card-body">
				<strong>nombre</strong>: ${produc.nombre}
				<strong>categoria</strong>: ${produc.categoria}
				<strong>precio</strong>: ${produc.precio} 
				<strong>lote</strong>: ${produc.fecha}
				<strong>descripcion</strong>: ${produc.descripcion}<br>
				<a href="#" class="btn btn-danger" name="eliminar">borrar</a>
			</div>
		</div>`;

		productoAgregado.appendChild(objeto);
		this.resetformu();
	}

	resetformu(){
		document.getElementById('formulario').reset();
	}

	deletProduct(elemento){
		if(elemento.name === 'eliminar'){
			elemento.parentElement.parentElement.parentElement.remove();
		}
	}
}


// eventos del dom
document.getElementById('formulario').addEventListener('submit', function(e){
	const nombre = document.getElementById('nombre').value;
	const categoria = document.getElementById('categoria').value;
	const precio = document.getElementById('precio').value;
	const fecha = document.getElementById('fecha').value;
	const descripcion = document.getElementById('descripcion').value;

	const produc = new producto(nombre, categoria, precio, fecha, descripcion);
	const accion = new acciones();

	e.preventDefault();

	accion.addProduct(produc);


	}, true);

document.getElementById('productos').addEventListener('click', function(e){
	const accion = new acciones();
	accion.deletProduct(e.target);
});







