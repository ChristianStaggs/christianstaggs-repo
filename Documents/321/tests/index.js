let myBooks = []
let book = {
    bookId: crypto.randomUUID(),
    authorName: 'Brandon',
    pageCount: 1300,
    title: "mistborn",
    deleted: false

}
myBooks.push(book)


function handleOnLoad(){
myBooks = JSON.parse(localStorage.getItem('myBooks')) || []
renderTable()
}

let handleOnAdd = () => {
    let newBook = {
        
            author: document.getElementById('authorName').value,
            title: document.getElementById('title').value,
            pageCount: document.getElementById('pageCount').value,
        
    }
    myBooks.push(newBook)
    localStorage.setItem('myBooks', JSON.stringify(myBooks))
    renderTable()
    
    }
function handleDelete(bookId){
for (let i = 0; i<myBooks.length; i++){
    if (myBooks[i].bookId === bookId){
        myBooks[i].deleted === true
    }
}
renderTable()
}
function renderTable(){
    let html = `
    <table>
  <tr>
    <th>Title</th>
    <th>Author Name</th>
    <th>Page Count</th>
  </tr>
  `
  myBooks.forEach((book) => {
  if(book.deleted == false){
    html += `<tr>
    <td>${book.title}</td>
    <td>${book.authorName}</td>
    <td>${book.pageCount}</td>
       <td><button onclick= "handleDelete('${book.bookId}')">Delete</button></td>
  </tr>
  <tr>
   `}
  })
  html += '</table>'
  document.getElementById('app').innerHTML = html
}