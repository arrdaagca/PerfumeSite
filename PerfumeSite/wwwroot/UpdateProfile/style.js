// Sayfa yüklendiğinde animasyonu başlat
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("updateForm").classList.add("show");
});

// Şifre doğrulama fonksiyonu
function validatePasswords() {
    let newPassword = document.getElementById("newPassword").value;
    let confirmPassword = document.getElementById("confirmPassword").value;

    if (newPassword !== confirmPassword) {
        alert("Yeni şifreler uyuşmuyor!");
        return false;
    }

    return true;
}