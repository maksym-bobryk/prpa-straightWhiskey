const user = null;
fetch('https://localhost:7061/api/User/')
  .then(response => response.json())
  .then(data => {
    console.log(data);
  })
  .catch(error => {
    user = { ...data[0] };
    console.error(error);
  });

fetch('https://localhost:7061/api/Barber/')
  .then(response => response.json())
  .then(data => {
    console.log(data);
  })
  .catch(error => {
    user = { ...data[0] };
    console.error(error);
  });



  google.accounts.id.initialize({
    client_id:
      "247608479620-l5ptoru2lrdm2qj93a0lsmtdnibvlohk.apps.googleusercontent.com",
    callback: handleLogin,
  }
)

  function handleLogin(resp) {
    console.log(resp.credential); 
    let userObject = jwt_decode(resp.credential);

    localStorage.setItem('userName', userObject.name);
    localStorage.setItem('userEmail', userObject.email);
    localStorage.setItem('userPic', userObject.picture);
    
    // window.location.href = './profile.html';let newUser = {
      let newUser = {
      "Email": userObject.email,
      "Name": userObject.name,
      "Photo": userObject.picture,
      "Role": {
        "RoleId": 1,
        "AccessFlags": 1
      }
    }


    console.log(userObject, userObject.name);

    fetch('https://localhost:7061/api/User', {
      method: 'POST',
      body: JSON.stringify (newUser),
      headers: {
        "Content-type": "application/json; charset=UTF-8"
      }
    })
    .then((response) => response.json())
    .then((json) => console.log(json))
  }

  function hideAuthDiv() {
    console.log(count);
    
      let div = document.getElementById('auth');
      
      if (div) {
          div.style.display = 'none';
      } else {
          console.warn("Element with ID 'auth' could not be found.");
      }
}

  google.accounts.id.renderButton(
    document.getElementById("auth"),
    { theme: "outline", size: "medium" }
  )
