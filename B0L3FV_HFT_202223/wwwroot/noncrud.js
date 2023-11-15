let toolsmission = []
let toolsgoblin = []

fetch('http://localhost:11828/tool/AVGMission').then(x => x.json()).then(y => {
    toolsmission = y;
    console.log(toolsmission);
    displayMissionNonCrud();
});

fetch('http://localhost:11828/tool/AVGGoblin').then(x => x.json()).then(y => {
    toolsgoblin = y;
    console.log(toolsgoblin);
    displayGoblinNonCrud();
});

function displayMissionNonCrud() {
    document.getElementById('resultareanoncrudmission').innerHTML += "";
    toolsmission.forEach(t => {

        document.getElementById('resultareanoncrudmission').innerHTML +=
            '<tr><td>' + t.type + '</td>' +
            '<td>' + t.avg_loot + '</td>' +
        '<td>' + t.avg_level + '</td>' +
        '<td>' + t.avg_Height + '</td>' +
        '<td>' + t.avg_Hazard + '</td>' +
              '</td></tr>';

    })
}

function displayGoblinNonCrud() {
    document.getElementById('resultareanoncrudgoblin').innerHTML += "";
    toolsgoblin.forEach(t => {

        document.getElementById('resultareanoncrudgoblin').innerHTML +=
            '<tr><td>' + t.name + '</td>' +
            '<td>' + t.loot + '</td>' +
            '<td>' + t.kill + '</td>' +
            '<td>' + t.death + '</td>' +
            '<td>' + t.duration + '</td>' +
            //'<td>' +
            '</td></tr>';

    })
}