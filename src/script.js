fetch('https://localhost:7061/api/User/')
  .then(response => response.json())
  .then(data => {
    console.log(data);
  })
  .catch(error => {
    console.error(error);
  });

  function signIn() {
    let oath2Endpoint = 'https://accounts.google.com/o/oauth2/v2/auth';

    let form = document.createElement('form');
    form.setAttribute('method', 'GET');
    form.setAttribute('action', oath2Endpoint);

    let params = {
      'client_id': '114623133917-1gnbg8urd7v3u13gi2s5pp391ph3b653.apps.googleusercontent.com',
      'redirect_uri': 'http://127.0.0.1:5500/src/index.html',
      'response_type': 'token',
      'scope':'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/youtube.readonly',
      'include_granted_scopes': 'true',
      'state': 'pass-through-value',
    }

    for (let p in params) {
      let input = document.createElement('input');
      input.setAttribute('type', 'hidden');
      input.setAttribute('name', p);
      input.setAttribute('value', params[p]);
      form.appendChild(input);
    }

    document.body.appendChild(form);

    form.submit()
  }