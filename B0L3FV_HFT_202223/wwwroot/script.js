let goblins = [];
let connection = null;

let goblinIdToUpdate = -1;
getdata();
setupSignalR();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:11828/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on(
        "GoblinCreated", (user, message) => {
            getdata();
        });
    connection.on(
        "GoblinDeleted", (user, message) => {
            getdata();
        });
    connection.on(
        "GoblinUpdated", (user, message) => {
            getdata();
        });

    connection.onclose(async () => {
        await start();
    });

    start();

}

function showupdate(id) {
    
    document.getElementById('goblinNameToUpdate').value = goblins.find(t => t['goblinID'] == id)['goblinName'];
    document.getElementById('goblinWIDToUpdate').value = goblins.find(t => t['goblinID'] == id)['wid'];
    document.getElementById('goblinLevelToUpdate').value = goblins.find(t => t['goblinID'] == id)['level'];
    document.getElementById('goblinMoneyToUpdate').value = goblins.find(t => t['goblinID'] == id)['money'];
    document.getElementById('goblinHeightToUpdate').value = goblins.find(t => t['goblinID'] == id)['height'];
    document.getElementById('updateformdiv').style.display = 'flex';
    goblinIdToUpdate = id;
}


async function getdata()
{
    fetch('http://localhost:11828/goblin').then(x => x.json()).then(y => {
        goblins = y;
        //console.log(goblins);
        display();
    });

}





function display()
{
    document.getElementById('resultareaGoblin').innerHTML += "";
    goblins.forEach(t =>
    {
        
        document.getElementById('resultareaGoblin').innerHTML += 
            '<tr><td>' + t.goblinID + '</td>' +
        '<td>' + t.goblinName + '</td>' + 
        '<td>' + t.wid + '</td>' +
        '<td>' + t.level+'</td>' +
        '<td>' + t.money + '</td>' +
        '<td>' + t.height + '</td>' +
        '<td>' +
        `<button type="button" onclick="removeGoblin(${t.goblinID})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.goblinID})">Update</button>` +
            '</td></tr>';

    })
}

function createGoblin() {
    let name = document.getElementById('goblinname').value;
    fetch('http://localhost:11828/goblin', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { goblinName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
    
}

function updateGoblin() {
    document.getElementById('updateformdiv').style.display ='none';
    let name = document.getElementById('goblinNameToUpdate').value;
    let widup = document.getElementById('goblinWIDToUpdate').value;
    let levelup = document.getElementById('goblinLevelToUpdate').value;
    let moneyup = document.getElementById('goblinMoneyToUpdate').value;
    let heighup = document.getElementById('goblinHeightToUpdate').value;
    fetch('http://localhost:11828/goblin', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { goblinName: name, goblinID: goblinIdToUpdate, wid: widup, level: levelup, money: moneyup, height: heighup })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });

}



function removeGoblin(id) {
    fetch('http://localhost:11828/goblin/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });
}
