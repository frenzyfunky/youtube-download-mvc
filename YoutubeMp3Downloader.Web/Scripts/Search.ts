document.getElementById("search-input")
    .addEventListener("keyup", (event) => {
        event.preventDefault();
        if (event.keyCode === 13) {
            document.getElementById("search-button").click();
        }
    });