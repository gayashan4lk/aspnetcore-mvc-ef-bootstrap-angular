//let messageForm = document.getElementById("messageForm");
//console.log(messageForm);
//messageForm.hidden = true;

/*let buyButton = document.getElementById("buyButton");
buyButton.addEventListener("click", () => {
    console.log("proccess buying..")
});*/


let messageForm = $("#messageForm");
messageForm.hide();

let button = $("#buyButton");
button.on("click", () => {
    console.log("Buying process...");
});

let productInfo = $(".product-props li");

// arrow function did not work here.
productInfo.on("click", function () {
    console.log("You clicked on " + $(this).text());
});