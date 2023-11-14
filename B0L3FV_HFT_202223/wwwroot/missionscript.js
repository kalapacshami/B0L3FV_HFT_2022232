let missions = [];

fetch('http://localhost:11828/mission').then(x => x.json()).then(y => {
    missions = y;
    console.log(missions);
   /* display();*/
});