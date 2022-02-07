        /* When the user clicks on the button,
        toggle between hiding and showing the dropdown content */
        function myFunction() {
            document.getElementById("myDropdown").classList.toggle("show");
        }

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

//if (TempData["Al"] != null)
//{
  
//    //var name = $("name").val();
//        swal("Saved successfully!"," ", "success");
//}
//function y() {
  
//    swal("Saved successfully!", " ", "success");
//    //swal({
//    //    title: "Deleted!",
//    //    text: "Your row has been deleted.",
//    //    type: "success",
//    //    timer: 3000
//    //})
//};
//$("#btnSave").click(function (e) {
//    swal("Saved successfully!", " ", "success");
//});
//$("#sub").click(function () {
//   // var name = $("#name").val();
//    alert("|name");
//    if (name != null) {
//        swal("Saved successfully!", " ", "success");

//    }
//});
//   if (TempData["Al"] != null)
//{
//    swal("Saved successfully!", " ", "success");

//}