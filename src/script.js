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

  google.accounts.id.initialize({
    client_id:
      "247608479620-l5ptoru2lrdm2qj93a0lsmtdnibvlohk.apps.googleusercontent.com",
    callback: handleLogin,
  }
)

  // function handleLogin(resp) {
  //   console.log(resp.credential); 
  //   let userObject = jwt_decode(resp.credential);
    
  //   let newUser = {
  //     email: userObject.email,
  //     name: userObject.name,
  //     password: null,
  //     phone: null,
  //     photo: userObject.picture, 
  //     role: {
  //       roleId: 2,
  //       accessFlags: 2,
  //     },
  //   }

  //   fetch('https://localhost:7061/api/User/', {
  //     method: 'POST', 
  //     headers: {
  //       'Content-Type': 'application/json',
  //     },
  //     body: JSON.stringify(newUser),
  //   })
  //   .then(response => {
  //     if (!response.ok) {
  //       throw new Error(`HTTP error! status: ${response.status}`);
  //     }
      
  //     return response.json();
  //   })
  //   .then(data => console.log('Success:', data))
  //   .catch((error) => console.error('Error:', error));

  //   console.log(userObject, userObject.name);
  // }

  function handleLogin(resp) {
    console.log(resp.credential); 
    let userObject = jwt_decode(resp.credential);
    
    let newUser = {
      Email: userObject.email,
      Name: userObject.name,
      Password: null,
      Phone: null,
      Photo: userObject.picture,
      RoleID: null // Assumed role ID, modify as needed
    };

    fetch('https://localhost:7061/api/User', {
      method: 'POST', 
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user),
    })
    .then(response => {
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      return response.json();
    })
    .then(data => console.log('Success:', data))
    .catch((error) => console.error('Error:', error));
}

function postUserData(user) {
  fetch('https://localhost:7061/api/User', {
    method: 'POST', 
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(user),
  })
  .then(response => {
    return response.json();
  })
  .then(data => console.log('Success:', data))
  .catch((error) => console.error('Error:', error));
}

  google.accounts.id.renderButton(
    document.getElementById("auth"),
    { theme: "outline", size: "large" }
  )
