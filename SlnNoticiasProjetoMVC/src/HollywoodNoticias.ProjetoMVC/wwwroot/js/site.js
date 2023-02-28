//modal
msgModalMessage = (message, origin, callback) => {
    $('#modal-origin').html(origin);
    $('#modal-body').html(message);


    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
};

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide');
};

//toast
liveToastMessage = (message, origin) => {
    $('#toast-origin').html(origin);
    $('#toast-body').html(message);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-br', {
        hour12: false,
        hour: "numeric",
        minute: "numeric"
    }));

    const toastLiveMessages = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessages)
    toast.show()
};

//deletar 
const deleteRegistro = (idParam, origin, urlParam) => {
    msgModalMessage(`Deseja realmente excluir o Registro ${idParam}?`, origin, () => {
        $.ajax({
            url: urlParam,
            method: 'POST',
            data: {
                id: idParam
            },
            success: (resp) => {
                if (resp.code == '200') {
                    liveToastMessage(`O Registro ${idParam} foi excluído.`, origin);
                    setTimeout(() => { window.location.reload(); }, 4000);
                }
            }
        });
        closeMsgModalMessage();
    });
}