$(document).ready(function () {
     
    CKEDITOR.replace('Bio', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

    CKEDITOR.replace('Interesse', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });
    
    CKEDITOR.replace('Observacao', {
        extraPlugins: 'autogrow',
        autoGrow_bottomSpace: 50
    });

});
