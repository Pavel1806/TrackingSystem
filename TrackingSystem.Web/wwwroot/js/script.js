
function myFunction() {

    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// $(function () {
//     const str = document.querySelectorAll('table tr');
    
//     const input = document.querySelector('.edit');
//     {
//         str.forEach(item => {
//             item.addEventListener('click', (e) => {
//                 str.forEach(el => { el.classList.remove('selected'); });
//                 item.classList.add('selected')
//             })
//         })

//         input.addEventListener('click', (evt) => {
//             const table = document.querySelector('table');
//             const values = [];
//             table.querySelectorAll('tr').forEach((tr) => {
//                 if (tr.classList.contains('selected')) {
//                     values.push(tr.children[1].textContent.trim());
//                 }
//             });
//             sendToServer(values);
//         });
//         //var r = window.location.href;
//         function sendToServer(values) {
//             console.log(values[0]);
//             var body = "title=" + values[0];
//             document.location = "/edit/index?" + body;
//         }
//     }

// });



// $(function () {
//     const str = document.querySelectorAll('table tr');
//     const input = document.querySelector('.delete');

//         //applySelection();

//         input.addEventListener('click', (evt) => {
//             const table = document.querySelector('table');
//             const values = [];
//             table.querySelectorAll('tr').forEach((tr) => {
//                 if (tr.classList.contains('selected')) {
//                     values.push(tr.children[4].textContent.trim());
//                 }
//             });
//             const id = values[0];
//             console.log(id);
//             console.log('https://localhost:44382/api/Values/'+ id);
//              userDelete(id);
//             //sendToServer(values);
//         });

       
// });

const input = document.querySelector('.delete');
input.addEventListener('click', getByIdDelete);

function getByIdDelete(){
     const str = document.querySelectorAll('table tr');
    const input = document.querySelector('.delete');

        //applySelection();
            const table = document.querySelector('table');
            const values = [];
            table.querySelectorAll('tr').forEach((tr) => {
                if (tr.classList.contains('selected')) {
                    values.push(tr.children[4].textContent.trim());
                }
            });
            const id = values[0];
            console.log(id);
            
            userDelete(id);
            //window.localhost.reload();

            //sendToServer(values);
}


async function userDelete(id){
//console.log(id);
    await fetch('https://localhost:44382/api/values/'+ id, {
              method: 'DELETE'
              // headers: {'content-type': 'application/json'},
              //body: JSON.stringify({id: values[0]})
            }).then(() => {console.log('removed');
                }).then(()=>getAll()).then(()=>window.location.reload()).catch(err => {console.error(err)});
            // .then(res => res.text()) // OR res.json()
            // .then(res => console.log(res))
        
}





function applySelection() {
    const str = document.querySelectorAll('table tr');
      str.forEach(item => {
                item.addEventListener('click', (e) => {
                    str.forEach(el => { el.classList.remove('selected'); });
                    item.classList.add('selected')
                })
            })
}

function getAll(){
    fetch('https://localhost:44382/api/values')
.then((res)=>res.json())
.then((data)=>setUser(data));

var table=document.body.children[0].children[2].children[0].children[0].children[0];
function setUser(data) {
    table.insertAdjacentHTML('afterend',`
            ${setUsers(data)}   
        `);
}

function setUsers(data) {
    return data.map(
        hero=>`
                    <tr >
                        <td class="name">
                            ${hero.name}
                        </td>
                        <td class="serName">
                            ${hero.serName}
                        </td>
                        <td class="position">
                            ${hero.position}
                        </td>
                        <td class="email">
                            ${hero.email}
                        </td>
                        <td class="number">
                            ${hero.number}
                        </td>
                        <td >
                            ${hero.dateTime}
                        </td>
                    </tr>
        `
        ).join(' ');
}
}

//



$(document).ready(function () {

    function addRemoveClass(theRows) {
    }
    var rows = $("table#myTable tr:not(:first-child)");
    addRemoveClass(rows);

    $(".selectDepartment").on("change", function () {
        var selected = this.value;
        if (selected != "All") {
            rows.filter("[position=" + selected + "]").show();
            rows.not("[position=" + selected + "]").hide();
            var visibleRows = rows.filter("[position=" + selected + "]");
            addRemoveClass(visibleRows);
        } else {
            rows.show();
            addRemoveClass(rows);
        }
    });
});


const form = document.getElementById('form');
form.addEventListener('submit', getFormValue);

  function getFormValue(event) {
    event.preventDefault();
    const name = form.querySelector('[name="name"]'), 
    sername = form.querySelector('[name="sername"]'),
    post = form.querySelector('[name="post"]'), 
    email = form.querySelector('[name="email"]')
    //number = form.querySelector('[name="number"]');
    const data = {
      name: name.value,
      serName: sername.value,
      position: post.value,
      email: email.value,
   };
   console.log(data);
   metodPost(data);
}

function metodPost(data){
//console.log(id);
 
const jsonPost = JSON.stringify(data);
    fetch('https://localhost:44382/api/values', {
              method: 'POST',
              headers: {
                          'Content-Type': 'application/json;charset=utf-8'
                       },
              body: jsonPost
            }).then(() => {console.log('removed');
                }).then(()=>getAll()).then(()=>window.location.reload()).catch(err => {console.error(err)});
            // .then(res => res.text()) // OR res.json()
            // .then(res => console.log(res))
        console.log(jsonPost);
}


//.then(()=>window.location.reload()).


// myTable.addEventListener('submit', getFormValue);

//   function getFormValue(event) {
//     event.preventDefault();
    
//    console.log(data);
//    metodPost(data);
// }


const myTable = document.getElementById('myTable');
const popupLink = document.querySelector('.popup_link');
popupLink.addEventListener('click', getByIdEdit);

function getByIdEdit(){
     const str = document.querySelectorAll('table tr');

            const table = document.querySelector('table');
            const values = [];
            table.querySelectorAll('tr').forEach((tr) => {
                if (tr.classList.contains('selected')) {

                    values.push(tr.children[0].textContent.trim(), 
                                tr.children[1].textContent.trim(),
                                tr.children[2].textContent.trim(),
                                tr.children[3].textContent.trim(),
                                tr.children[4].textContent.trim()
                                );
                }
            });
            openPopup(values);

}


function openPopup(values){
    const popupName = popupLink.getAttribute('href').replace('#', '');
    const currentPopup = document.getElementById(popupName);
    popupOpen(currentPopup);
    //e.preventDefault();
    //console.log(values[1])
    document.getElementById('popupName').value = values[0];
    document.getElementById("popupSerName").value =values[1];
    document.getElementById("popupEmail").value = values[3];
    document.getElementById("popupNumber").value = values[4];
    document.getElementById("popupPost").value = values[2];
}

function popupOpen(currentPopup){
    currentPopup.classList.add('open');
}



const popup_form = document.getElementById('popup_form');
popup_form.addEventListener('submit', getFormValuePopup);

  function getFormValuePopup(event) {
    event.preventDefault();
    const name = popup_form.querySelector('[name="name"]'), 
    sername = popup_form.querySelector('[name="sername"]'),
    post = popup_form.querySelector('[name="post"]'), 
    email = popup_form.querySelector('[name="email"]'),
    number = popup_form.querySelector('[name="number"]');
    const data = {
      number: number.value,
      name: name.value,
      serName: sername.value,
      position: post.value,
      email: email.value,
   };
   console.log(data);
   metodPut(data);

}

function metodPut(data){
//console.log(id);
 
const jsonPost = JSON.stringify(data);
    fetch('https://localhost:44382/api/values', {
              method: 'PUT',
              headers: {
                          'Content-Type': 'application/json;charset=utf-8'
                       },
              body: jsonPost
            }).then(() => {console.log('removed');
                }).then(()=>getAll()).then(()=>window.location.reload()).catch(err => {console.error(err)});
            // .then(res => res.text()) // OR res.json()
            // .then(res => console.log(res))
        console.log(jsonPost);
}


const closePopup = document.querySelector('.popup_close');

closePopup.addEventListener('click', function(e){
    
    Popupclose(closePopup.closest('.popup'));
    e.preventDefault();

});

function Popupclose(closePopup){
    closePopup.classList.remove('open');

}