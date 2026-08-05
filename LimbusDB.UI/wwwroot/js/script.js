const toggleBtn = document.querySelector(".toggle-btn");
const toggler = document.querySelector("#icon");

toggleBtn.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");
    toggler.classList.toggle("bx-chevrons-right");
    toggler.classList.toggle("bx-chevrons-left");
})