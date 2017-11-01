$(document).ready(function () {
    $('#btnEnviar').on('click', function () {
        if (Validar() == true) {
            Enviar();
        }
    });
});

function Enviar() {
    var url = 'http://emailapi.supernovaweb.com.br/api/contato';

    var nome = $('#name').val();
    var email = $('#email').val();
    var telefone = $('#phone').val();
    var mensagem = $('#message').val();
    var assunto = 'Contato do Site Prudente Imobiliária';
    var destinatario = destinatario;

    var data = { nome: nome, email: email, telefone: telefone, mensagem: mensagem, destinatario: destinatario, assunto: assunto };

    $.ajax({
        url: url,
        data: data,
        type: 'POST',
        success: function (res) {
            var contato = { nome: nome, email: email, telefone: telefone, mensagem: mensagem, destinatario: destinatario, assunto: assunto };
            if (res != 'success') {
                //swal('Ops...', 'ocorreu algum erro. Tente novamente mais tarde', 'error');
                $('#success').removeClass('hidden');
                $('#success').addClass('alert alert-danger');
                $('#success').html('Ocorreu um erro ao enviar a sua mensagem. Por favor, tente novamente mais tarde.');
            } else {
                //swal('Mensagem Enviada com sucesso.');
                $('#success').removeClass('hidden');
                $('#success').addClass('alert alert-success');
                $('#success').html('Sua mensagem foi enviada com sucesso. Em breve responderemos.');
                limparFormulario();
            }
            //SalvarNoBanco(contato);
        },
        error: function (data) {
            swal('Ops...', 'ocorreu algum erro. Tente novamente mais tarde', 'error');
        }
    });

    return false;
}

function limparFormulario() {
    $('#name').val('');
    $('#email').val('');
    $('#phone').val('');
    $('#message').val('');
}

function Validar() {
    if ($('#name').val() == '') {
        sweetAlert("Oops...", "Por favor, preencha seu nome!", "error");
        $('#name').focus();
        return false;
    }
    if ($('#email').val() == '') {
        sweetAlert("Oops...", "Por favor, informe seu email!", "error");
        $('#email').focus();
        return false;
    } else {
        var email = $("#email").val();
        if (!validateEmail(email)) {
            sweetAlert("Oops...", "Por favor, informe um e-mail válido!", "error");
            $('#email').focus();
            return false;
        }
    }
    if ($('#message').val() == '') {
        sweetAlert("Oops...", "Por favor, escreva sua mensagem!", "error");
        $('#message').focus();
        return false;
    }

    return true;
}

function validateEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}