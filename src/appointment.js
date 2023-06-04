
  // fetch('https://localhost:7061/api/Service/')
  // .then(response => response.json())
  // .then(data => {
  //   console.log(data);
  //   const select = document.getElementById('services');

  //   for (let i = 0; i <= data.length; i++) {
  //     const option = document.createElement('option');
  //     option.value = data[i].serviceId;
  //     option.text = data[i].name;
  //     console.log(option);
  //     select.appendChild(option);
  //   }
  // })
  // .catch(error => {
  //   console.error(error);
  // });

  fetch('https://localhost:7061/api/Barber/')
  .then(response => response.json())
  .then(data => {
    console.log(data);
    const select = document.getElementById('barbers');

    for (let i = 0; i <= data.length; i++) {
      const option = document.createElement('option');
      option.value = data[i].barberId;
      option.text = data[i].user.name;
      console.log(option);
      select.appendChild(option);
    }
  })


  fetch('https://localhost:7061/api/Service/')
  .then(response => response.json())
  .then(data => {
    const select = document.getElementById('services');

    for (let i = 0; i < data.length; i++) {
      const option = document.createElement('option');
      option.value = data[i].serviceId;
      option.text = data[i].name;
      option.cost = data[i].cost;
      select.appendChild(option);
    }

    select.addEventListener('change', function() {
      const selectedOption = select.options[select.selectedIndex];
      const selectedValue = selectedOption.cost;
      const selectedText = selectedOption.text;
      document.getElementById('selectedService').textContent = `Total:  ${selectedValue}`;
    });
  })
  .catch(error => {
    console.error(error);
  });

let dateInput = document.getElementById("datefield");
dateInput.min = new Date().toISOString().slice(0,new Date().toISOString().lastIndexOf(":"));
