var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: "/Admin/User/ChangStatus",
                data: { id: id },
                dataType: "json",
                type: 'POST',
                success: function (response) {
                    console.log(response)
                    if (response.stutus == true) {
                        $(this).text('Kích hoạt');
                    }
                    else {
                        $(this).text('Khóa');
                    }
                }
            });
        });
    }
}
user.init();