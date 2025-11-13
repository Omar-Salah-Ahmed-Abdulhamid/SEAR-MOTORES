$(document).ready(function () {
    let selectedFiles = [];

    $('#images').on('change', function () {
        let container = $('#images-preview');

        for (let i = 0; i < this.files.length; i++) {
            selectedFiles.push(this.files[i]);
        }


        container.empty();

        selectedFiles.forEach((file, index) => {
            let col = $('<div>', { class: 'col-md-4 mb-3 position-relative' });
            let card = $('<div>', { class: 'card shadow-sm border-0' });

            let img = $('<img>', {
                class: 'card-img-top img-fluid rounded',
                src: URL.createObjectURL(file),
                css: { height: '200px', objectFit: 'cover' }
            });

            let removeBtn = $('<div>', {
                html: '&times;',
                class: 'position-absolute d-flex align-items-center justify-content-center',
                css: {
                    top: '5px',
                    right: '15px',
                    width: '25px',
                    height: '25px',
                    background: 'red',
                    color: 'white',
                    borderRadius: '50%',
                    cursor: 'pointer',
                    fontSize: '18px',
                    fontWeight: 'bold',
                    lineHeight: '25px',
                    textAlign: 'center'
                }
            });

            removeBtn.on('click', function () {
                selectedFiles.splice(index, 1); 
                col.remove(); 
            });

            card.append(img);
            col.append(card).append(removeBtn);
            container.append(col);
        });

        this.value = ""; 
    });

    $('form').on('submit', function (e) {
        e.preventDefault();

        let formData = new FormData(this);

        selectedFiles.forEach(file => {
            formData.append("Images", file);
        });

        $.ajax({
            url: this.action,
            type: this.method,
            data: formData,
            processData: false,
            contentType: false,
            success: function () {
                window.location.href = "/Cars/Index";
            }
        });
    });
});
