fetch('https://localhost:44382/api/values')
.then((res)=>res.json())
.then((data)=>setUser(data))
.then(()=>applySelection());


// function setUser(data){
// 	for (var i =  0; i < data.length; i++) {
// 		document.getElementById('userName').innerHTML = 'Имя: '+ data[i].name;
// 		document.getElementById("userSerName").innerHTML ='Фамилия: '+ data[i].serName;
// 		document.getElementById("userEmail").innerHTML = 'Email: '+ data[i].email;
// 		document.getElementById("userNumber").innerHTML = 'Номер заявки: '+ data[i].number;
// 	}

// };
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



//<td>${hero.dateTime}</td>
//<th>Время регистрации</th>



// <h1>Имя: ${hero.name}</h1>		
// 		<h2>Фамилия: ${hero.serName}</h2>
// 		<p>Должность: ${hero.position}</p>
// 		<p>Email: ${hero.email}</p>
// 		<p>Время регистрации: ${hero.dateTime}</p>
// 		<p>Номер заявки: ${hero.number}</p>

// <div class="rt">${setUsers(data)}</div>

// 