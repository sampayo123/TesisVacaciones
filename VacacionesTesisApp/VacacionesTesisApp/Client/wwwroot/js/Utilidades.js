function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Éxito',
                    'Registro eliminado',
                    'success'
                )
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}

function CustomConfirmCreate(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Éxito',
                    'Registro creado',
                    'success'
                )
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}


function CustomConfirmCreate2(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                //Swal.fire(
                //    'Éxito',
                //    'Registro creado',
                //    'success'
                //)
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}




function CustomConfirmUpdate(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Éxito',
                    'Registro modificado',
                    'success'
                )
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}



function AbrirReporte(pagina, nombreParametros, valoresParametros) {
    //alert("Hola");
    let strParametros = "";
    if (nombreParametros.length > 0) strParametros = "?";
    for (let i = 0; i < nombreParametros.length; i++) {

        strParametros += nombreParametros[i] + "=" + valoresParametros[i] + "&"

    }

    strParametros = strParametros.substring(0, strParametros.length - 1);

    //alert(strParametros);

    let url = pagina + strParametros;
    window.open(url, "_blank");


    //callOtherDomain();

};









