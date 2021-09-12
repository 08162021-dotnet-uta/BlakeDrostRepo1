fetch('http://api.icndb.com/jokes/random/5',)
  .then(stuff => stuff.json())
  .then(stuff => {
    console.log(stuff)
    return stuff;
  })
  .then(stuff => {
    const listOfPs = document.getElementsByTagName('p');
    for (let i = 0; i < stuff.value.length; i++) {
      listOfPs[i].innerHTML = `${stuff.value[i].joke}`;
    }
    console.log(this.responseText);
  });