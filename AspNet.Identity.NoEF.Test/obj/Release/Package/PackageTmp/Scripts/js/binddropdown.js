function binddropdown(methodname, parentcontrolid, controlid, defaulttext) {
    $(parentcontrolid).change(function () {
        $(controlid).empty();
        var idp;
        if (isNaN($(parentcontrolid).val()) || $(parentcontrolid).val() == '')
            idp = 0;
        else
            idp = $(parentcontrolid).val();
        $.ajax({
            type: 'POST',
            url: methodname,
            dataType: 'json',
            data: { id: idp },
            success: function (states) {
                $(controlid).append('<option value="' + 0 + '">---' +
                         defaulttext + '---</option>');
                $.each(states, function (i, state) {                    
                    $(controlid).append('<option value="' + state.Value + '">' +
                         state.Text + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve list.' + JSON.stringify(ex));
            }
        });
        return false;
    })
}