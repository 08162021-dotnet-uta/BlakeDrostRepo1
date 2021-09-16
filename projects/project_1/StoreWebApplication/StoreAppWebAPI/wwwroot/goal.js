window.onload = function () {
    //console.log('Something');
    console.log(sessionStorage.getItem('user'));
    let user = JSON.parse(sessionStorage.getItem('user'));
    document.getElementById("place1").innerHTML = `Welcome ${user.fname} ${user.lname}!<br>Please select a store below!<br>`;
    //List the stores as buttons
    fetch("/storelist")
        .then(res => {

        })
    //document.getElementById("place1").innerHTML += `<br>Name: ${user.fname}`;
}