let missions = [];
let connection = null;

let missionIdToUpdate = -1;
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
        "MissionCreated", (user, message) => {
            getdata();
        });
    connection.on(
        "MissionDeleted", (user, message) => {
            getdata();
        });
    connection.on(
        "MissionUpdated", (user, message) => {
            getdata();
        });

    connection.onclose(async () => {
        await start();
    });

    start();

}

function showupdate(id) {

    document.getElementById('missionTypeToUpdate').value = missions.find(t => t['missionID'] == id)['mType'];
    document.getElementById('missionDurToUpdate').value = missions.find(t => t['missionID'] == id)['missionDuration'];
    document.getElementById('missionCompToUpdate').value = missions.find(t => t['missionID'] == id)['missionCompleted'];
    document.getElementById('missionLootToUpdate').value = missions.find(t => t['missionID'] == id)['loot'];
    document.getElementById('missionLocToUpdate').value = missions.find(t => t['missionID'] == id)['location'];
    document.getElementById('missionKillToUpdate').value = missions.find(t => t['missionID'] == id)['kills'];
    document.getElementById('missionGobIDToUpdate').value = missions.find(t => t['missionID'] == id)['goblinID'];
    document.getElementById('missionDeathToUpdate').value = missions.find(t => t['missionID'] == id)['deaths'];
    document.getElementById('missionDateToUpdate').value = missions.find(t => t['missionID'] == id)['date'];
    document.getElementById('updateformdiv').style.display = 'flex';
    goblinIdToUpdate = id;
}

async function getdata() {
    fetch('http://localhost:11828/mission').then(x => x.json()).then(y => {
        missions = y;
        //console.log(goblins);
        displayMission();
    });

}
function displayMission() {
    document.getElementById('resultareaMission').innerHTML += "";
    missions.forEach(t => {

        document.getElementById('resultareaMission').innerHTML +=
            '<tr><td>' + t.missionID + '</td>' +
        '<td>' + t.missionDuration + '</td>' +
        '<td>' + t.missionCompleted + '</td>' +
        '<td>' + t.mType + '</td>' +
        '<td>' + t.loot + '</td>' +
        '<td>' + t.location + '</td>' +
        '<td>' + t.kills + '</td>' +
        '<td>' + t.hazard + '</td>' +
        '<td>' + t.goblinID + '</td>' +
        '<td>' + t.deaths + '</td>' +
        '<td>' + t.date + '</td>' +
        '<td>' +
        `<button type="button" onclick="removeMission(${t.missionID})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.missionID})">Update</button>` +
            '</td></tr>';

    })
}
function createMission() {
    let name = document.getElementById('missionname').value;
    let hazardform = document.getElementById('missionhazard').value;
    let locationform = document.getElementById('missionloc').value;
    fetch('http://localhost:11828/mission', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { mType: name, location: locationform, hazard: hazardform })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });

}

function updateMission() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('missionTypeToUpdate').value;
    let durup = document.getElementById('missionDurToUpdate').value;
    let compup = document.getElementById('missionCompToUpdate').value;
    let lootup = document.getElementById('missionLootToUpdate').value;
    let locup = document.getElementById('missionLocToUpdate').value;
    let killup = document.getElementById('missionKillToUpdate').value;
    let gobidup = document.getElementById('missionGobIDToUpdate').value;
    let deathup = document.getElementById('missionDeathToUpdate').value;
    let dateup = document.getElementById('missionDateToUpdate').value;
    fetch('http://localhost:11828/mission', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                mType: name, missionDuration: durup, missonID: missionIdToUpdate, missionCompleted: compup,
                loot: lootup, location: locup, kills: killup, goblinID: gobidup, deaths: deathup, date: dateup
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success: ', data);
            getdata();
        })
        .catch((error) => { console.error('Error: ', error); });

}

function removeMission(id) {
    fetch('http://localhost:11828/mission/' + id, {
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