const readLine = require("./readLine");

var pozitieCurenta = "hol";
var areCheie = false;

var primaDataIn_Hol = true;
var primaDataIn_Baie = true;
var primaDataIn_Dormitor = true;
var primaDataIn_Sufragerie = true;
var primaDataIn_Balcon = true;

function oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuni)
{
    console.log("Ai urmatoarele optiuni:");
    var index = 0;
    while(index < listaDeOptiuni.length)
    {
        console.log("   [" + (index + 1).toString() + "] " + listaDeOptiuni[index]);

        index = index + 1;
    }

    console.log(`Ce alegi (1-${listaDeOptiuni.length})?`);

    var alegereUtilizator = "";
    while(alegereUtilizator == ""){
        alegereUtilizator = +readLine();

        if(isNaN(alegereUtilizator) || alegereUtilizator < 1 || alegereUtilizator > listaDeOptiuni.length || alegereUtilizator % 1 !== 0){
            console.log(`Optiune inexistenta, te rog reintrodu o optiune de la 1 la ${listaDeOptiuni.length}.`);
            alegereUtilizator = "";
        }
    }

    return alegereUtilizator - 1;
}

while(pozitieCurenta != "afara"){
    if(pozitieCurenta == "hol"){
        if(primaDataIn_Hol){
            console.log(`Esti in holul unei case din care trebuie neaparat sa iesi.`);

            primaDataIn_Hol = false;
        }
        else {
            console.log(`Esti in hol.`);
        }

        var raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa de intrare/iesire din apartament"
            , "usa de la baie"
            , "usa de la dormitor"
            , "usa de la sufragerie"
        ]);

        var listaPozitiiUrmatoare = [
            "afara" //0
            , "baie" //1
            , "dormitor" //2
            , "sufragerie" //3
        ];

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
        
        //cum areCheie e boolean (adica true sau false), am inlocuit areCheie != "da" cu (nu areCheie, care in limbaj e !areCheie)
        if(pozitieCurenta == "afara" && !areCheie)
        {
            console.log("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
            console.log("Va trebui sa incerci altceva.");
            pozitieCurenta = "hol";
        }
    }
    else if(pozitieCurenta == "baie"){
        if(primaDataIn_Baie){
            console.log(`Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
`);

            primaDataIn_Baie = false;
        }
        else {
            console.log(`Esti in baie si e bezna.`);
        }

        console.log(`Nu ai nici o alta optiune decat sa te intorci in hol.`);
        pozitieCurenta = "hol";
    }
    else if(pozitieCurenta == "dormitor"){
        if(primaDataIn_Dormitor){
            console.log(`Dormitorul arata sinistru.`);

            primaDataIn_Dormitor = false;
        }
        else {
            console.log(`Esti in dormitor.`);
        }

        var raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa catre hol"
            , "usa catre balcon"
        ]);

        var listaPozitiiUrmatoare = [
            "hol" //0
            , "balcon" //1
        ];

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
    }
    else if(pozitieCurenta == "sufragerie"){
        if(primaDataIn_Sufragerie){
            console.log(`Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.`);

            primaDataIn_Sufragerie = false;
        }
        else {
            console.log(`Esti in sufragerie.`);
        }

        var raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa catre hol"
            , "usa catre balcon"
        ]);

        var listaPozitiiUrmatoare = [
            "hol" //0
            , "balcon" //1
        ];

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
    }
    else if(pozitieCurenta == "balcon"){
        if(primaDataIn_Balcon){
            console.log(`Din balcon se vede afara. Esti la etajul 12.`);

            primaDataIn_Balcon = false;
        }
        else {
            console.log(`Esti in balcon.`);
        }

        var raspunsUtilizator = 0;
        
        if(areCheie){
            raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
                "usa catre dormitor"
                , "usa catre sufragerie"
            ]);
        }
        else {
            raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
                "usa catre dormitor"
                , "usa catre sufragerie"
                , "ridica cheia de pe jos"
            ]);
        }

        var listaPozitiiUrmatoare = [
            "dormitor" //0
            , "sufragerie" //1
            , "balcon" //2
        ];

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];

        if(pozitieCurenta == "balcon"){
            console.log("Ai luat cheia, acum poti deschide ceva.");
            areCheie = true;
        }
    }
}

console.log("Ai reusit sa scapi din apartament, felicitari!");
