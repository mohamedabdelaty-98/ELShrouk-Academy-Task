$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });
        swal.fire({
            title: "هل انت متأكد؟",
            text: "لن تستطيع التراجع عن ذلك!",
            icon: "تحذير",
            showCancelButton: true,
            confirmButtonText: "نعم,قم بالحذف",
            cancelButtonText: "لا,إلغاء",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Cashier/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire({
                            title: "تم الحذف",
                            text: "لقد تم حذف الملف الخاص بك.",
                            icon: "success"
                        });
                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire({
                            title: "لم يتم الحذف",
                            text: "هناك خطأ ما",
                            icon: "error"
                        });
                    }
                })
               
            }
        });
        
        console.log(btn.data('id'));
    })
})