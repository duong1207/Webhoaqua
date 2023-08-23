$(document).ready(function () {
    // Thêm class khi hover
    $(document).on('mouseenter', '.myclass', function () {
        $(this).addClass('hovered');
    });

    // Xóa class khi di chuột ra ngoài
    $(document).on('mouseleave', '.myclass', function () {
        $(this).removeClass('hovered');


    });

   
});

