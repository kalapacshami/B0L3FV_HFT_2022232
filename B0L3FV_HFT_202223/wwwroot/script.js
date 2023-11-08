let goblins = [];



fetch('http://localhost:11828/goblin').then(x => x.json()).then(y =>
{
    goblins = y;
    console.log(goblins);
    display();
});


function display()
{
    goblins.forEach(t =>
    {
        
        document.getElementById('resultareaGoblin').innerHTML += 
            '<tr><td>' + t.goblinID + '</td>' +
            '<td>' + t.goblinName + '</td><td>' +
            //`<button type="button" onclick="removeGoblin(${t.id})">Delete</button>` +
            //`<button type="button" onclick="updateGoblin(${t.id})">Update</button>` +
            '</td></tr>';

    })
}

function createGoblin() {
    let goblinname = document.getElementById('goblinname').value;
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
    display();
}