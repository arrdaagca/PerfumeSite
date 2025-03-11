function confirmDelete() {
    if (confirm("Bu Kartı silmek istediğinizden emin misiniz?")) {
        document.getElementById("deleteForm").submit();
    }
}