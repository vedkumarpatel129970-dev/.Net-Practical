document.addEventListener("DOMContentLoaded", () => {
    const alerts = document.querySelectorAll(".auto-dismiss-alert");
    alerts.forEach((alertEl) => {
        setTimeout(() => {
            if (window.bootstrap && window.bootstrap.Alert) {
                const instance = window.bootstrap.Alert.getOrCreateInstance(alertEl);
                instance.close();
            }
        }, 4500);
    });
});
