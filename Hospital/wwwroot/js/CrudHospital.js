function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7240/api/Hospital/GetAll',
        success: function (result) {
            $('#tblEmpleado tbody').empty();
            $.each(result.Objects, function (i, value) {
                var htmlTags = '<tr>' +
                    '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + value.IdHospital + ')"><span class="glyphicon glyphicon-pencil" style="color:#FFFFFF"></span></button></td>' +
                    '<td>' + value.Nombre + '</td>' +
                    '<td>' + value.Direccion + '</td>' +
                    '<td>' + value.AñodeConstruccion + '</td>' +
                    '<td>' + value.Capacidad + '</td>' +
                    '<td>' + value.Especialidad.Nombre + '</td>' +
                    '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + value.IdHospital + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'


                '</tr>';
                $("#tblEmpleado tbody").append(htmlTags);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
