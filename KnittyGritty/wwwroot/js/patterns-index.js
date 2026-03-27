
document.querySelectorAll('.img-modal-trigger').forEach(function (el) {
    el.addEventListener('click', function (e) {
        e.preventDefault();
        document.getElementById('modalImage').src = this.dataset.img;
        var modal = new bootstrap.Modal(document.getElementById('imageModal'));
        modal.show();
    });
});
