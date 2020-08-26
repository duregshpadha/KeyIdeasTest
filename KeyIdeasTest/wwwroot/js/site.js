$(function () {
    var path = window.location.href;
    $(".navigation_menu .navbar-collapse .navbar-nav .nav-item a.nav-link").each(function (i) {
        if (this.href === path) {
            $(this).parent('li').addClass("active");
        }
    });

    $('#register-trigger').on('click', function () {
        $('#loginform').trigger('reset');
        $('#register-formErrors').text('');
        $('#loginformSuccess').text('');
        show_register();
    });

    $('#login-trigger').on('click', function () {
        $('#register-form').trigger('reset');
        $('#loginformErrors').text('');
        show_login();
    });


    $('#loginform').on('submit', function (e) {
        e.preventDefault();
        let loginButton = $('#wp-submit');
        let loginButtonValue = loginButton.val();
        loginButton.val('Please wait ...');
        loginButton.prop('disabled', true);
        let form = $(this);
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: form.serialize()
        }).done(function (data) {
            if (data && data.success !== 'success') {
                $('#loginformErrors').text(data.message);
                loginButton.prop('disabled', false);
                loginButton.val(loginButtonValue);
            }
            else if (data && data.success === 'success') {
                window.location.href = '/user/dashboard';
            }
            else {
                loginButton.prop('disabled', false);
                loginButton.val(loginButtonValue);
            }
        }).fail(function () {
            loginButton.prop('disabled', false);
            loginButton.val(loginButtonValue);
        });
    });

    $('#register-form').on('submit', function (e) {  
     
 e.preventDefault();        let regiButton = $('#reg_submit');
        let regiButtonVal = regiButton.val();
        regiButton.val('Please wait ...');
        regiButton.prop('disabled', true);
        let form = $(this);
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: form.serialize()
        }).done(function (data) {
            if (data && data.success !== 'success') {
                $('#register-formErrors').text(data.message);
                $('#reg_submit').prop('disabled', false);
                regiButton.val(regiButtonVal);
            }
            else if (data && data.success === 'success') {
                $('#reg_submit').prop('disabled', false);
                regiButton.val(regiButtonVal);
                $('#login-trigger').trigger('click');
                $('#loginformSuccess').text('Registration success, Please login with your user credentials');
            }
            else {
                $('#reg_submit').prop('disabled', false);
                regiButton.val(regiButtonVal);
            }
        }).fail(function () {
            $('#reg_submit').prop('disabled', false);
            regiButton.val(regiButtonVal);
        });
    });

    function show_login() {
        $("#register-form, #goback-trigger").hide();
        $("#loginform, .social-login-btns, #register-wrapper,a.password-lost").show();
    }

    function show_register() {
        $("#loginform, .social-login-btns, #register-wrapper,a.password-lost").hide();
        $("#register-form, #goback-trigger").show();
    }

});