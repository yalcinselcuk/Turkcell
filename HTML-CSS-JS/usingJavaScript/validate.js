function validate() {
    var requiredInputs = document.getElementsByClassName("required"); // class adından koleksiyonu yakaladık ve o ad'a ait değişkeni yakaladık
    //console.log(requiredInputs);
    let isValid = true;
  
    for (let index = 0; index < requiredInputs.length; index++) {
      const element = requiredInputs[index];
      isValid = isRequired(element) && isValid; // burada iki şartı da kontrol ettik
    }
    return isValid;
  }
  
  function isRequired(element) {
    let isAvailable = true;
    let value = element.value;
    if (value === "") {
      let span = element.getAttribute("data-target");
      let message = element.getAttribute("data-message");
  
      element.addEventListener("change", function () { //burada bir şey girilip girilmediğini kontrol ediyoruz
        document.getElementById(span).innerText = ""; // eğer ki input'a değer girildiyse span'daki mesaj silinecek
      });
  
      document.getElementById(span).innerText = message;
      isAvailable = false;
    }
  
    return isAvailable;
  }