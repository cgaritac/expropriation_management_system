document.addEventListener("DOMContentLoaded", function () {

    const toastMessage = document.body.getAttribute("data-toast");

    if (toastMessage === "success") {
        const successToast = new bootstrap.Toast(document.getElementById('successToast'));
        successToast.show();
    } else if (toastMessage === "error") {
        const errorToast = new bootstrap.Toast(document.getElementById('errorToast'));
        errorToast.show();
    }

    document.getElementById('editButton').addEventListener('click', enableInputs);
    document.getElementById('cancelButton').addEventListener('click', disableInputs);

    //const hash = window.location.hash;

    //if (hash === "#owner-tab") {
    //    const ownerTab = document.getElementById("owner-tab");
    //    if (ownerTab) {
    //        ownerTab.click();
    //    }
    //}


    //const tabs = document.querySelectorAll('button[data-bs-toggle="tab"]');

    //// Agregar un evento clic a cada pestaña
    //tabs.forEach(tab => {
    //    tab.addEventListener("click", function () {
    //        const target = this.getAttribute("data-bs-target"); // Obtener el ID del contenido de la pestaña
    //        const tabId = target.replace("#", ""); // Quitar el "#" para obtener el nombre de la pestaña
    //        window.location.hash = tabId; // Actualizar la URL con el fragmento
    //    });
    //});

    //// Activar la pestaña correcta si hay un fragmento en la URL
    //const hash = window.location.hash;
    //if (hash) {
    //    const tabButton = document.querySelector(`button[data-bs-target="${hash}"]`);
    //    if (tabButton) {
    //        tabButton.click(); // Simular un clic en la pestaña correspondiente
    //    }
    //}
});

//window.addEventListener('beforeunload', function () {
//    fetch('/Auth/Logout', { method: 'POST', keepalive: true });
//});

function enableInputs() {
    document.getElementById('faseInput').disabled = false;
    document.getElementById('statusInput').disabled = false;
    document.getElementById('startDateInput').disabled = false;
    document.getElementById('finishDateInput').disabled = false;
    document.getElementById('projectnumberInput').disabled = false;    
    document.getElementById('sectionInput').disabled = false; 
    document.getElementById('kmInput').disabled = false; 
    document.getElementById('commentsInput').disabled = false;

    document.getElementById('editButton').classList.add('d-none');
    document.getElementById('saveButton').classList.remove('d-none');
    document.getElementById('cancelButton').classList.remove('d-none');
}

function disableInputs() {
    document.getElementById('faseInput').disabled = true;
    document.getElementById('statusInput').disabled = true;
    document.getElementById('startDateInput').disabled = true;
    document.getElementById('finishDateInput').disabled = true;
    document.getElementById('projectnumberInput').disabled = true;
    document.getElementById('sectionInput').disabled = true;
    document.getElementById('kmInput').disabled = true; 
    document.getElementById('commentsInput').disabled = true;

    document.getElementById('editButton').classList.remove('d-none');
    document.getElementById('saveButton').classList.add('d-none');
    document.getElementById('cancelButton').classList.add('d-none');
}