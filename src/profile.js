const name = localStorage.getItem('userName');
const email = localStorage.getItem('userEmail');
const pic = localStorage.getItem('userPic');

document.getElementById('name').textContent = name;
document.getElementById('email').textContent = email;
document.getElementById('image').src = pic;

logout = () => {
  window.open('index.html');
}