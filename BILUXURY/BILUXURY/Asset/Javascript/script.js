/* <!-- Created By CodingNepal --> */
const slidePage = document.querySelector(".slide-page");
const nextBtnFirst = document.querySelector(".firstNext");
const prevBtnSec = document.querySelector(".prev-1");
const nextBtnSec = document.querySelector(".next-1");
const prevBtnThird = document.querySelector(".prev-2");
const nextBtnThird = document.querySelector(".next-2");
const prevBtnFourth = document.querySelector(".prev-3");
const submitBtn = document.querySelector(".submit");
const progressText = document.querySelectorAll(".step p");
const progressCheck = document.querySelectorAll(".step .check");
const bullet = document.querySelectorAll(".step .bullet");
let current = 1;
const a = document.forms["myForm"];

nextBtnFirst.addEventListener("click", function (event) {
    event.preventDefault();
    if (a["name"].value == "") {
        document.getElementById("validate-name").innerHTML = "Không được để trống!";
    } else {
        document.getElementById("validate-name").style.display = "none";
        slidePage.style.marginLeft = "-25%";
        bullet[current - 1].classList.add("active");
        progressCheck[current - 1].classList.add("active");
        progressText[current - 1].classList.add("active");
        current += 1;
    }
});
nextBtnSec.addEventListener("click", function (event) {
    event.preventDefault();
    if (a["diachi"].value == "") {
        document.getElementById("validate-diachi").innerHTML = "Không được để trống!";
    } else if (a["phone"].value == "")
    {
        document.getElementById("validate-phone").innerHTML = "Không được để trống!";
    } else
    {
        document.getElementById("validate-diachi").style.display = "none";
        document.getElementById("validate-phone").style.display = "none";
        slidePage.style.marginLeft = "-50%";
        bullet[current - 1].classList.add("active");
        progressCheck[current - 1].classList.add("active");
        progressText[current - 1].classList.add("active");
        current += 1;
    }
});
nextBtnThird.addEventListener("click", function (event) {
    event.preventDefault();
    if (a["ngaysinh"].value == "2020-01-01") {
        document.getElementById("validate-date").innerHTML = "Chọn ngày sinh của bạn!";
    } else {
        document.getElementById("validate-date").style.display = "none";
        slidePage.style.marginLeft = "-75%";
        bullet[current - 1].classList.add("active");
        progressCheck[current - 1].classList.add("active");
        progressText[current - 1].classList.add("active");
        current += 1
    }
});
submitBtn.addEventListener("click", function () {
    //if (a["email"].value == "") {
    //    document.getElementById("validate-email").innerHTML = "Không được để trống!";
    //}
    //if (a["pass"].value == "") {
    //    document.getElementById("validate-pass").innerHTML = "Không được để trống!";
    //}
    if (a["pass"].value != "" && a["email"].value != "") {

        setTimeout(function () {
            alert("Bạn đã đăng ký thành công");
            //location.reload();
        }, 800);
    }
});

prevBtnSec.addEventListener("click", function (event) {
    event.preventDefault();
    slidePage.style.marginLeft = "0%";
    bullet[current - 2].classList.remove("active");
    progressCheck[current - 2].classList.remove("active");
    progressText[current - 2].classList.remove("active");
    current -= 1;
});
prevBtnThird.addEventListener("click", function (event) {
    event.preventDefault();
    slidePage.style.marginLeft = "-25%";
    bullet[current - 2].classList.remove("active");
    progressCheck[current - 2].classList.remove("active");
    progressText[current - 2].classList.remove("active");
    current -= 1;
});
prevBtnFourth.addEventListener("click", function (event) {
    event.preventDefault();
    slidePage.style.marginLeft = "-50%";
    bullet[current - 2].classList.remove("active");
    progressCheck[current - 2].classList.remove("active");
    progressText[current - 2].classList.remove("active");
    current -= 1;
});