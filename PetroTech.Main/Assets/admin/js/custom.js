$(document).ready(function () {
    $('#dtTableName').DataTable({
    });

    $('#calendar').datepicker({
    });

    !function ($) {
        $(document).on("click", "ul.nav li.parent > a ", function () {
            $(this).find('em').toggleClass("fa-minus");
        });
        $(".sidebar span.icon").find('em:first').addClass("fa-plus");
    }

        (window.jQuery);
    $(window).on('resize', function () {
        if ($(window).width() > 768) $('#sidebar-collapse').collapse('show')
    })
    $(window).on('resize', function () {
        if ($(window).width() <= 767) $('#sidebar-collapse').collapse('hide')
    })

    $(document).on('click', '.panel-heading-roles span.clickable', function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body .roles').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-up').addClass('fa-toggle-down');
        } else {
            $this.parents('.panel').find('.panel-body .roles').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-down').addClass('fa-toggle-up');
        }
    })

    $(document).on('click', '.panel-heading-users span.clickable', function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body .users').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-up').addClass('fa-toggle-down');
        } else {
            $this.parents('.panel').find('.panel-body .users').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-down').addClass('fa-toggle-up');
        }
    })

    $(document).on('click', '.panel-heading-funcs span.clickable', function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body .funcs').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-up').addClass('fa-toggle-down');
        } else {
            $this.parents('.panel').find('.panel-body .funcs').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('em').removeClass('fa-toggle-down').addClass('fa-toggle-up');
        }
    })
});