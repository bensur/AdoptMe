var slider = document.getElementById("helper-salary");
var output = document.getElementById("helper-salary-value");
output.innerHTML = slider.value; // Display the default slider value
// Update the current slider value (each time you drag the slider handle)
slider.oninput = function () {
    output.innerHTML = this.value;
}