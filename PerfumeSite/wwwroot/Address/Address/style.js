function confirmDelete() {
    if (confirm("Bu adresi silmek istediğinizden emin misiniz?")) {
        document.getElementById("deleteForm").submit();
    }
}