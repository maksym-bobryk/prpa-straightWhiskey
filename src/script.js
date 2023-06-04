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

  function handleLogin(resp) {
    console.log(resp.credential); 
    let userObject = jwt_decode(resp.credential);

    localStorage.setItem('userName', userObject.name);
    localStorage.setItem('userEmail', userObject.email);
    localStorage.setItem('userPic', userObject.picture);
    
    window.location.href = './profile.html';

    console.log(userObject, userObject.name);
  }

  

  google.accounts.id.renderButton(
    document.getElementById("auth"),
    { theme: "outline", size: "large" }
  )
