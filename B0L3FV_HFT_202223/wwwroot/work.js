let works = [];

let connection = null;
let workIdToUpdate = -1;
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
        "WorkCreated", (user, message) => {
            getdata();
        });
    connection.on(
        "WorkDeleted", (user, message) => {
            getdata();
        });
    connection.on(
        "WorkUpdated", (user, message) => {
            getdata();
        });

    connection.onclose(async () => {
        await start();
    });

    start();

}
function showupdate(id) {

    document.getElementById('workNameToUpdate').value = works.find(t => t['wid'] == id)['wName'];
    document.getElementById('workMinMoneyToUpdate').value = works.find(t => t['wid'] == id)['min_Money'];
    document.getElementById('workMaxMoneyToUpdate').value = works.find(t => t['wid'] == id)['max_Money'];
    document.getElementById('workHazardToUpdate').value = works.find(t => t['wid'] == id)['hazardLevel'];
    document.getElementById('updateformdiv').style.display = 'flex';
    workIdToUpdate = id;
}

async function getdata() {
    fetch('http://localhost:11828/work').then(x => x.json()).then(y => {
        works = y;
       /* console.log(works);*/
        display();
    });

};

function display() {
    document.getElementById('resultareaWork').innerHTML += "";
    works.forEach(t => {

        document.getElementById('resultareaWork').innerHTML +=
            '<tr><td>' + t.wid + '</td>' +
        '<td>' + t.wName + '</td>' +
        '<td>' + t.min_Money + '</td>' +
        '<td>' + t.max_Money + '</td>' +
        '<td>' + t.hazardLevel + '</td>' +
        '<td>' +
        `<button type="button" onclick="removeWork(${t.wid})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.wid})">Update</button>` +
            '</td></tr>';

    })
}

function createWork() {
    let name = document.getElementById('workname').value;
    fetch('http://localhost:11828/work', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { wName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });

}

function updateGoblin() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('workNameToUpdate').value;
    let minmoneyup = document.getElementById('workMinMoneyToUpdate').value;
    let maxmoneyup = document.getElementById('workMaxMoneyToUpdate').value;
    let hazardup = document.getElementById('workHazardToUpdate').value;
    fetch('http://localhost:11828/work', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { wName: name, wid: workIdToUpdate, min_Money: minmoneyup, max_Money: maxmoneyup, hazardLevel: moneyhazardup })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });

}

function removeWork(id) {
    fetch('http://localhost:11828/work/' + id, {
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