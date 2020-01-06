function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $('a[data-modal]').on('click',
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#AddressTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

function SearchPostalCode() {
    $(document).ready(function () {

        function clearPostalCodeForm() {
            $('#Address_Street').val('');
            $('#Address_District').val('');
            $('#Address_City').val('');
            $('#Address_State').val('');
        }

        $('#Address_PostalCode').blur(function () {

            var postalCode = $(this).val().replace(/\D/g, '');

            if (postalCode != '') {

                var validatePostalCode = /^[0-9]{8}$/;

                if (validatePostalCode.test(postalCode)) {

                    $('#Address_Street').val('...');
                    $('#Address_District').val('...');
                    $('#Address_City').val('...');
                    $('#Address_State').val('...');

                    $.getJSON('https://viacep.com.br/ws/' + postalCode + '/json/?callback=?',
                        function (data) {

                            if (!('erro' in data)) {
                                $('#Address_Street').val(data.logradouro);
                                $('#Address_District').val(data.bairro);
                                $('#Address_City').val(data.localidade);
                                $('#Address_State').val(data.uf);
                            }
                            else {
                                clearPostalCodeForm();
                                alert('Postal Code not found.');
                            }
                        });
                }
                else {
                    clearPostalCodeForm();
                    alert('Postal Code in invalid format.');
                }
            }
            else {
                clearPostalCodeForm();
            }
        });
    });
}
