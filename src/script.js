console.log('Hello');

fetch('https://127.0.0.1:7061/api/User/Get')
.then(function(response) {
  return response.json();
})
.then(function(data) {
  console.log(data);
})
.catch(function(error) {
  console.error('Error:', error);
});