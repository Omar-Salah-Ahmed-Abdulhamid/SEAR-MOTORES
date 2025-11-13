$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-success mx-2",
                cancelButton: "btn btn-danger"
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: "Are you sure to delete this car?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Cars/Delete/${btn.data('id')}`,
                    method: "DELETE",
                    success: function () {
                        swalWithBootstrapButtons.fire({
                            title: "Deleted!",
                            text: "Car has been deleted.",
                            icon: "success"
                        });
                        btn.closest("tr").remove(); // يمسح الصف من الجدول
                    btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swalWithBootstrapButtons.fire({
                            title: "Oops!",
                            text: "Something went wrong.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });
});
