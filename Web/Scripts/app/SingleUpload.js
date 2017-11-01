﻿jQuery(function ($) {
    // *** editable avatar *** //
    try {//ie8 throws some harmless exceptions, so let's catch'em

        //first let's add a fake appendChild method for Image element for browsers that have a problem with this
        //because editable plugin calls appendChild, and it causes errors on IE at unpredicted points
        try {
            document.createElement('IMG').appendChild(document.createElement('B'));
        } catch (e) {
            Image.prototype.appendChild = function (el) { }
        }

        var last_gritter;
        $('#avatar').editable({
            type: 'image',
            name: 'avatar',
            value: null,
            image: {
                //specify ace file input plugin's options here
                btn_choose: 'Escolher Imagem',
                droppable: true,
                maxSize: 10485760,//~100mb

                //and a few extra ones here
                name: 'avatar',//put the field name here as well, will be used inside the custom plugin
                on_error: function (error_type) {//on_error function will be called when the selected file has a problem
                    if (last_gritter) $.gritter.remove(last_gritter);
                    if (error_type == 1) {//file format error
                        last_gritter = $.gritter.add({
                            title: 'O arquivo não é uma imagem!',
                            text: 'Por favor, escolha uma imagem no formato jpg!',
                            class_name: 'gritter-error gritter-center'
                        });
                    } else if (error_type == 2) {//file size rror
                        last_gritter = $.gritter.add({
                            title: 'O Arquivo é muito grande!',
                            text: 'A imagem deve ser menor que 10mb!',
                            class_name: 'gritter-error gritter-center'
                        });
                    }
                    else {//other error
                    }
                },
                on_success: function () {
                    $.gritter.removeAll();
                }
            },
            url: function (params) {

                var submit_url = pathSingleUpload;//please modify submit_url accordingly
                var deferred = null;
                var avatar = '#avatar';

                //if value is empty (""), it means no valid files were selected
                //but it may still be submitted by x-editable plugin
                //because "" (empty string) is different from previous non-empty value whatever it was
                //so we return just here to prevent problems
                var value = $(avatar).next().find('input[type=hidden]:eq(0)').val();
                if (!value || value.length == 0) {
                    deferred = new $.Deferred
                    deferred.resolve();
                    return deferred.promise();
                }

                var $form = $(avatar).next().find('.editableform:eq(0)')
                var file_input = $form.find('input[type=file]:eq(0)');
                var pk = $(avatar).attr('data-pk');//primary key to be sent to server

                var ie_timeout = null


                if ("FormData" in window) {
                    var formData_object = new FormData();//create empty FormData object

                    //serialize our form (which excludes file inputs)
                    $.each($form.serializeArray(), function (i, item) {
                        //add them one by one to our FormData
                        formData_object.append(item.name, item.value);
                    });
                    //and then add files
                    $form.find('input[type=file]').each(function () {
                        var field_name = $(this).attr('name');
                        var files = $(this).data('ace_input_files');
                        if (files && files.length > 0) {
                            formData_object.append(field_name, files[0]);
                        }
                    });

                    //append primary key to our formData
                    formData_object.append('pk', pk);

                    deferred = $.ajax({
                        url: submit_url,
                        type: 'POST',
                        processData: false,//important
                        contentType: false,//important
                        dataType: 'json',//server response type
                        data: formData_object
                    })
                }
                else {
                    deferred = new $.Deferred

                    var temporary_iframe_id = 'temporary-iframe-' + (new Date()).getTime() + '-' + (parseInt(Math.random() * 1000));
                    var temp_iframe =
                        $('<iframe id="' + temporary_iframe_id + '" name="' + temporary_iframe_id + '" \
			frameborder="0" width="0" height="0" src="about:blank"\
			style="position:absolute; z-index:-1; visibility: hidden;"></iframe>')
                            .insertAfter($form);

                    $form.append('<input type="hidden" name="temporary-iframe-id" value="' + temporary_iframe_id + '" />');

                    //append primary key (pk) to our form
                    $('<input type="hidden" name="pk" />').val(pk).appendTo($form);

                    temp_iframe.data('deferrer', deferred);
                    //we save the deferred object to the iframe and in our server side response
                    //we use "temporary-iframe-id" to access iframe and its deferred object

                    $form.attr({
                        action: submit_url,
                        method: 'POST',
                        enctype: 'multipart/form-data',
                        target: temporary_iframe_id //important
                    });

                    $form.get(0).submit();

                    //if we don't receive any response after 30 seconds, declare it as failed!
                    ie_timeout = setTimeout(function () {
                        ie_timeout = null;
                        temp_iframe.attr('src', 'about:blank').remove();
                        deferred.reject({ 'status': 'fail', 'message': 'Timeout!' });
                    }, 30000);
                }


                //deferred callbacks, triggered by both ajax and iframe solution
                deferred
                    .done(function (result) {//success
                        console.log(result);
                        console.log(result.success);
                        if (result.success === true) {
                            $(avatar).get(0).src = result.url;
                            if (last_gritter) {
                                $.gritter.remove(last_gritter);
                            }
                            last_gritter = $.gritter.add({
                                title: 'Upload Realizado!',
                                text: result.message,
                                class_name: 'gritter-info gritter-center'
                            });

                            $("#avatar").attr("src", "/Content/upload/temp/" + result.nome);
                            $("#Imagem").val(result.nome);
                        }
                        else {
                            console.log(result);
                            alert("Ocorreu um erro ao enviar a imagem");
                        }
                    })
                    .fail(function (result) {//failure
                        console.log(result);
                        alert("Ocorreu um erro ao enviar a imagem");
                    })
                    .always(function () {//called on both success and failure
                        if (ie_timeout) clearTimeout(ie_timeout)
                        ie_timeout = null;
                    });

                return deferred.promise();
            },
            success: function (response, newValue) {
                console.log("response: " + response);
            }
        })
    } catch (e) {
        console.log(e);
        alert("Ocorreu um erro ao enviar imagem");
    }
});