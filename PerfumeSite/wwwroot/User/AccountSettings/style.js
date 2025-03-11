function showTab(tabId) {
    document.querySelectorAll('.tab').forEach(tab => tab.classList.remove('active'));
    document.getElementById(tabId).classList.add('active');

    document.querySelectorAll('.tab-buttons a').forEach(btn => btn.classList.remove('active-tab'));
    event.target.classList.add('active-tab');
}