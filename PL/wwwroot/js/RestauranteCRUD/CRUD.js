$(document).ready(function () {
    GetAll();
});

function GetAll() {
    $.ajax({
        url: '/Restaurante/GetAllRestaurante',
        type: 'GET',
        dataType: 'json',
        success: function (result) {

            let filas = '';

            $.each(result, function (i, item) {

                filas += `
                    <tr>
                        <td>${item.nombre}</td>
                        <td><img src="${item.logo ?? ''}" width="50"/></td>
                        <td>${item.fechaApertura}</td>
                        <td>${item.fechaCierre}</td>
                        <td>${item.direccion.colonia.nombre}</td>
                        <td>${item.direccion.colonia.municipio.nombre}</td>
                        <td>${item.direccion.colonia.municipio.estado.nombre}</td>
                        <td>
                        <button class="btn btn-warning" onclick="OpenModal(${item.idRestaurante})">
                                Editar
                            </button>
                        <button class = "btn btn-danger" onclick ="Delete(${item.idRestaurante})">
                        Eliminar
                         </button>
                        
                        </td>
                    </tr>
                `;
            });

            $('#restauranteTabla').html(filas);
        },
        error: function () {
            alert('Error al obtener los datos');
        }
    });
}


function Delete(id){
    if(!confirm ("Estas seguro de que quieres elminar el restaurante?")){
        return;
    }
    $.ajax ({
        url: '/Restaurante/Delete',
        type: 'Post',
        data: {id: id},
        success: function (result){

            if(result.success){
                alert('Eliminado correctamente');
                GetAll();
            }else{
                alert(result.error || 'Error al eliminar');
            }
        },
        error: function(){
            alert ('Error ');
        }
    });
}


function OpenModal(id) {

    $.ajax({
        url: '/Restaurante/GetById',
        type: 'GET',
        data: { id: id },
        success: function (item) {

            $('#IdRestaurante').val(item.idRestaurante);
            $('#Nombre').val(item.nombre);
            $('#Logo').val(item.logo);
            $('#FechaApertura').val(FormatearFecha(item.fechaApertura));
            $('#FechaCierre').val(item.fechaCierre ? FormatearFecha(item.fechaCierre) : '');
            $('#IdDireccion').val(item.direccion.idDireccion);

            $('#modalEditar').show(); 
        },
        error: function () {
            alert('Error al obtener datos');
        }
    });
}
function CerrarModal() {
    $('#modalEditar').hide();
}

function FormatearFecha(fecha) {
    let d = new Date(fecha);
    return d.toISOString().split('T')[0];
}


function Update(){
    let restaurante = {
        idRestaurante: $('#IdRestaurante').val(),
        nombre: $('#Nombre').val(),
        logo: $('#Logo').val(),
        fechaApertura: $('#FechaApertura').val(),
        fechaCierre: $('#FechaCierre').val(),
        direccion: {
            idDireccion: $('#IdDireccion').val()
        }
    };

    $.ajax({
        url: '/Restaurante/Update',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(restaurante),
        success: function (result)
        {
            if ( result.success){
                alert('Actualizado correctamente');
                $('modalEditar').hide();
                GetAll();

                let modal = bootstrap.Modal.getInstance(document.getElementById('modalEditar'));
                modal.hide();
            }else{
                alert(result.error || 'Error al actualizar');
            }
        }
    });
    
}

