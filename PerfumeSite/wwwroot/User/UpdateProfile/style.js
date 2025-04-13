
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("updateForm").classList.add("show");
});


function validatePasswords() {
    let newPassword = document.getElementById("newPassword").value;
    let confirmPassword = document.getElementById("confirmPassword").value;

    if (newPassword !== confirmPassword) {
        alert("Yeni şifreler uyuşmuyor!");
        return false;
    }

    return true;
}