

fetch('https://localhost:7061/api/User/')
  .then(response => response.json())
  .then(data => {
    console.log(data);
  })
  .catch(error => {
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
    console.log(userObject);
  }

  google.accounts.id.renderButton(
    document.getElementById("auth"),
    { theme: "outline", size: "large" }
  )

  // function signIn() {
  //   let oath2Endpoint = 'https://accounts.google.com/o/oauth2/v2/auth';

  //   let form = document.createElement('form');
  //   form.setAttribute('method', 'GET');
  //   form.setAttribute('action', oath2Endpoint);

  //   let params = {
  //     'client_id': '247608479620-l5ptoru2lrdm2qj93a0lsmtdnibvlohk.apps.googleusercontent.com',
  //     'redirect_uri': 'http://127.0.0.1:5500/src/profile.html',
  //     'response_type': 'token',
  //     'scope':'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/youtube.readonly',
  //     'include_granted_scopes': 'true',
  //     'state': 'pass-through-value',
  //   }

  //   for (let p in params) {
  //     let input = document.createElement('input');
  //     input.setAttribute('type', 'hidden');
  //     input.setAttribute('name', p);
  //     input.setAttribute('value', params[p]);
  //     form.appendChild(input);
  //   }

  //   document.body.appendChild(form);

  //   form.submit()
  // }

  