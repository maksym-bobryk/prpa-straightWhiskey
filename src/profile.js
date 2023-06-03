let params = {};

let regex = /([^&=]+)=([^&=]*)/g, m;

while (m = regex.exec(location.href)) {
  params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
}

if(Object.keys(params).length > 0) {
  localStorage.setItem('authInfo', JSON.stringify(params));
}

window.history.pushState({}, document.title, '/' + 'profile.html')

let info = JSON.parse(localStorage.getItem('authInfo'));
console.log(JSON.parse(localStorage.getItem('authInfo')));
console.log(info['access_token']);
console.log(info['expires_in']);

fetch('https://www.googleapis.com/oauth2/v2/userinfo', {
  headers: {
    'Authorization': `Bearer ${info ['access_token']}`
  }
})
.then((data) => data.json())
.then((info) => {
  console.log(info)
  if (info.name) {
    document.getElementById('name').innerHTML += info.name
  }
  if (info.email) {
    document.getElementById('email').innerHTML += info.email
  }
})
.catch((error) => {
  console.error('Error:', error);
});