// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addProduct() {
    var response = getUploadedImage();
    console.log(response);
}

function getUploadedImage() {
    var fileInput = document.getElementById("MyImage");
    if (fileInput.files.length == 0) {
        return "https://cdn.pixabay.com/photo/2022/05/23/12/49/product-7216106_640.png";
    }

    var file = fileInput.files[0];
    var formData = new FormData();
    formData.append("file", file);
    return $.ajax({
        url: 'https://localhost:22950/i',
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            return response;
        },
        error: function () {
            console.error("Request failed");
        }
    })

}