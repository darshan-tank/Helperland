function popupFuction() {
    var modal = document.getElementById("myModal");
    var modal1 = document.getElementById("myModal1");
    var modal2 = document.getElementById("myModal2");
    console.log(modal);
    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");
    var btn1 = document.getElementById("myBtn1");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
    var span1 = document.getElementsByClassName("close1")[0];
    var span2 = document.getElementById("close2");
    console.log(span2);

    // When the user clicks the button, open the modal 
    btn.onclick = function() {
        modal.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() {
        modal.style.display = "none";
    }

    btn1.onclick = function() {
        console.log("click");
        modal1.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    span1.onclick = function() {
        modal1.style.display = "none";
    }

    span2.onclick = function () {
        console.log("span close");
        modal2.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        } else if (event.target == modal1) {
            modal1.style.display = "none";
        }
    }
}