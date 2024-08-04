cb = document.getElementById("my-toggle");
cb.addEventListener("click", ToggleExtension);
chrome.storage.local.get(["unimote_enabled"]).then((result) => {
    cb.checked = result.unimote_enabled;
});

function ToggleExtension() {
    chrome.storage.local.set({ unimote_enabled: cb.checked }).then(() => {
    });
}
