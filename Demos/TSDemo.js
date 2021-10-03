//Take two objects that have string arrays
//Alternately print out their strings
function AlternatingStrings(ob1, ob2) {
  //Find the smaller arrays
  let smallArray = Math.min(ob1.stuff.length, ob2.stuff.length);
  let fullString = '';
  for (let i = 0; i < smallArray; i++) {
    fullString += `${ob1.stuff[i]} ${ob2.stuff[i]} `;
  }
  return fullString;
}
let thing1 = { stuff: ["This", "a", "cool", "demo"], bigNum: 123456789012345612373456n, curDate: new Date() };
let thing2 = { stuff: ["is", "really", "typescript", "."], numStuff: 444, conditional: true };
let resultString = AlternatingStrings(thing1, thing2);
console.log(resultString);
//export {};
//This is a really cool typescript demo.
