console.log(sumStringMultiples("1,2,3,4", "5,6,7"));

function sumStringMultiples(str1, str2) {
  //Check to make sure arguments are strings
  if (typeof str1 !== "string" || typeof str2 !== "string") return;

  //Declare and initialize variables
  let result = 0;
  let i = 0;

  //Put each integer from string arguments into arrays
  const str1Array = str1.split(",");
  const str2Array = str2.split(",");

  //Determine which array has the most values
  const longArray = str1Array.length > str2Array.length ? str1Array : str2Array;
  const shortArray = str1Array.length > str2Array.length ? str2Array : str1Array;

  //Iterate through longer array to sum the multiplication to shorter array
  for (i; i < longArray.length; i++) {
    result += parseInt(longArray[i]) * parseInt(shortArray[i % shortArray.length]);
  }

  return result;
}
