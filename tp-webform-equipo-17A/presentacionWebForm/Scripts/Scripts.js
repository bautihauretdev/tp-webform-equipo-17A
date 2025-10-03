(function () {
    'use strict'
    var formSection = document.querySelector('.form-section');
    var inputs = formSection.querySelectorAll('input, textarea, select');
    // Agrega validación visual
    formSection.addEventListener('submit', function (event) {
        if (!formSection.closest('form').checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
        }
        formSection.closest('form').classList.add('was-validated')
    }, false);
    // CheckBox debe estar tildado
    var btn = document.getElementById('<%=btnParticipar.ClientID%>');
    if (btn) {
        btn.onclick = function (ev) {
            var terminos = document.getElementById('<%=chkTerminos.ClientID%>');
            if (terminos && !terminos.checked) {
                terminos.classList.add('is-invalid');
                ev.preventDefault();
                return false;
            }
            else {
                terminos.classList.remove('is-invalid');
            }
        }
    }
})()