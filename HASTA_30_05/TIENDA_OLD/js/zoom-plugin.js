$(document).ready(function () {
    initGal();
});

function initGal() {
    $("#ctl00_ContentPlaceHolder1_imgProd").elevateZoom({ gallery: 'gal1', cursor: 'pointer', galleryActiveClass: 'active', imageCrossfade: true, loadingIcon: 'http://www.elevateweb.co.uk/spinner.gif' });
}
//pass the images to Fancybox
$("#ctl00_ContentPlaceHolder1_imgProd").bind("click", function (e) {
    var ez = $('#ctl00_ContentPlaceHolder1_imgProd').data('elevateZoom');
    $.fancybox(ez.getGalleryList());
    return false;
});