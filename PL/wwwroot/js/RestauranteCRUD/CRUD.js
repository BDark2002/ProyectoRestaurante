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