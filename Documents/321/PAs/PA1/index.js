let myShops = []

let handleOnLoad = ()=> {
    myShops = JSON.parse(localStorage.getItem('myShops')) || []
    populateTable()

}

let handleAddShop = () => {
    let rating = document.getElementById('rating').value;
    if (rating < 1 || rating > 10) {
        alert("Rating must be between 1 and 10.");
        return; 
    }
    let newShop = {
        shopId: crypto.randomUUID(),
        name: document.getElementById('name').value,
        rating: rating,
        dateEntered: document.getElementById('dateEntered').value
    
}
myShops.push(newShop)
localStorage.setItem('myShops', JSON.stringify(myShops))
populateTable()

}
let handleOnAdd = () => {
let html = `<form onsubmit = "return false;">
  <label for="name">Name:</label><br>
  <input type="text" id="name" name="name"><br>
  <label for="dateEntered">Date Entered:</label><br>
  <input type="text" id="dateEntered" name="dateEntered"><br>
  <label for="rating">Rating:</label><br>
  <input type="number" id="rating" name="rating" min = "1" max = "10">

  <input onclick = "handleAddShop()" class = "btn btn-info" type = "submit" value= "Submit">
</form>`
document.getElementById("app").innerHTML = html
}

function handleFavorited(idx){
    myShops[idx].favorited = !myShops[idx].favorited;
    localStorage.setItem('myShops', JSON.stringify(myShops))
    populateTable();
}

let handleDelete = (idx) => {
   
    myShops.splice(idx, 1)
    localStorage.setItem('myShops', JSON.stringify(myShops))
    populateTable()
}

function handleEdit(idx) {
    let shop = myShops[idx];
    let html = `<form onsubmit="return false;">
        <label for="name">Name:</label><br>
        <input type="text" id="name" name="name" value="${shop.name}"><br>
        <label for="dateEntered">Date Entered:</label><br>
        <input type="text" id="dateEntered" name="dateEntered" value="${shop.dateEntered}"><br>
        <label for="rating">Rating:</label><br>
        <input type="number" id="rating" name="rating" value="${shop.rating}" min = "1" max = "10">
        <input onclick="handleEditUpdate(${idx})" class="btn btn-info" type="submit" value="Save">
    </form>`
    document.getElementById("app").innerHTML = html
}

function handleEditUpdate(idx) {
    let rating = document.getElementById('rating').value;
    if (rating < 1 || rating > 10) {
        alert("Rating must be between 1 and 10.");
        return; 
    }
    let editedShop = {
        name: document.getElementById('name').value,
        rating: rating,
        dateEntered: document.getElementById('dateEntered').value,
        favorited: myShops[idx].favorited
    }
myShops.splice(idx, 1, editedShop)
populateTable()
}
function populateTable(){
myShops.sort((a, b) => b.rating - a.rating);
let html = `<table class = 'table table-striped table-success'>

<tr>
    <th>Rating</th> 
    <th>Name</th> 
    <th>Date Entered</th> 
    <th>Favorited</th> 
    <th>Delete</th>
    <th>Edit</th>
    </tr>
    `
    myShops.forEach((shop,index) => {
        html += `<tr>
    <td>${shop.rating}</td> 
    <td>${shop.name}</td> 
    <td>${shop.dateEntered}</td> 
    <td>${shop.favorited ? "Yes" : "No"} <button onclick="handleFavorited(${index})" class="btn btn-warning">${shop.favorited ? "Unfavorite" : "Favorite"}</button>
    <td><button onclick = "handleDelete(${index})" class = "btn btn-danger">Delete</button></td>
    <td><button onclick = "handleEdit(${index})" class = "btn btn-primary">Edit</button></td>  
    </tr>
    `
    })
    html += '</table>'
    html += '<button class = "btn btn-success" onClick = "handleOnAdd()">Add shop</button><br><br>'
    document.getElementById('app').innerHTML = html
}
