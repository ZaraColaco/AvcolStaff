
function onNameChange()//when a name is entered
{
    var firstName = $('#Staff_FirstName').val();// stores the value of first name in a variable
    var lastName = $('#Staff_LastName').val();//stores the value of the last name in a variable

    if (firstName !== "" && lastName !== "")//not nulls
    {
        var TeacherCode = $('#Staff_TeacherCode').val(firstName.substring(0, 1).toUpperCase() + lastName.substring(0, 2).toUpperCase());
        //sets the value of the teacher code in the staff class. Takes the start of the first name string up to the first character and adds it to the first 2 charcters of the last name and then makes them upper case
    }

}

