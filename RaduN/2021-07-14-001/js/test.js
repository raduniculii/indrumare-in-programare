const readLine = require("./readLine");

const IX_NEVALID = -1;

//astea nu mai sunt constante, ca sa le putem schimba ordinea si mai
//stiu eu ce, asa ca folosim litere mici, ca si CONVENTIE (adica mergea
//la fel programul si cu litere mari dar e conventie arhi-cunoscuta ca
//avem constante cu caps lock si variabile normale fara)
var ixHol, ixBaie, ixDormitor, ixSufragerie, ixBalcon, ixAfara, ixCheie;

var primaDataIn = [];
var primulTextPentru = [];
var textulUrmatorPentru = [];
var textOptiunePentru = [];
var listaDeOptiuniPentru = [];

function oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuni)
{
    if(listaDeOptiuni == null || listaDeOptiuni.length == 0) return IX_NEVALID;

    console.log("Ai urmatoarele optiuni:");
    var index = 0;
    while(index < listaDeOptiuni.length)
    {
        console.log("   [" + (index + 1).toString() + "] " + textOptiunePentru[listaDeOptiuni[index]]);

        index = index + 1;
    }

    console.log(`Ce alegi (1-${listaDeOptiuni.length})?`);

    var alegereUtilizator = "";
    while(alegereUtilizator == ""){
        alegereUtilizator = +readLine();//cast/parse catre numar

        //test sa vedem daca e numar si daca e in limitele propuse
        if(isNaN(alegereUtilizator) || alegereUtilizator < 1 || alegereUtilizator > listaDeOptiuni.length || alegereUtilizator % 1 !== 0){
            console.log(`Optiune inexistenta, te rog reintrodu o optiune de la 1 la ${listaDeOptiuni.length}.`);
            alegereUtilizator = "";
        }
    }

    return listaDeOptiuni[alegereUtilizator - 1];
}

function AfiseazaMesajCameraSiActualizeazaPrimaData(indexCamera)
{
    if(primaDataIn[indexCamera]){
        console.log(primulTextPentru[indexCamera]);

        primaDataIn[indexCamera] = false;
    }
    else {
        console.log(textulUrmatorPentru[indexCamera]);
    }
}

function AdaugaOptiune(primulText, textulUrmator, textOptiune)
{
    primaDataIn.push(true);
    primulTextPentru.push(primulText);
    textulUrmatorPentru.push(textulUrmator);
    textOptiunePentru.push(textOptiune);
    
    //punem null aici si o definim unde doar avem nevoie
    listaDeOptiuniPentru.push(null);

    //returnam indexul elementului abia adaugat
    return primaDataIn.length - 1;
}

function ConfigureazaOptiuni()
{
    ixHol = AdaugaOptiune(
        `Esti in holul unei case din care trebuie neaparat sa iesi.`
        , `Esti in hol.`
        , "usa de la hol."
    );

    ixBaie = AdaugaOptiune(
        `Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.`
        , `Esti in baie si e bezna.`
        , "usa de la baie"
    );
    
    ixDormitor = AdaugaOptiune(
        `Dormitorul arata sinistru.`
        , `Esti in dormitor.`
        , "usa de la dormitor."
    );

    ixSufragerie = AdaugaOptiune(
        `Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.`
        , `Esti in sufragerie.`
        , "usa de la sufragerie."
    );

    ixBalcon = AdaugaOptiune(
        `Din balcon se vede afara. Esti la etajul 12.`
        , `Esti in balcon.`
        , "usa de la balcon"
    );

    ixAfara = AdaugaOptiune(
        null
        , null
        , "usa de intrare/iesire din apartament"
    );

    ixCheie = AdaugaOptiune(
        null
        , null
        , "ridica cheia"
    );

    listaDeOptiuniPentru[ixHol] = [ ixAfara, ixBaie, ixDormitor, ixSufragerie ];
    listaDeOptiuniPentru[ixDormitor] = [ ixHol, ixBalcon ];
    listaDeOptiuniPentru[ixSufragerie] = [ ixHol, ixBalcon ];
    listaDeOptiuniPentru[ixBalcon] = [ ixDormitor, ixSufragerie, ixCheie ];
}

//functia facuta de noi
ConfigureazaOptiuni();

var pozitieCurenta = ixHol;
var areCheie = false;
var raspunsUtilizator = IX_NEVALID;

while(pozitieCurenta != ixAfara)
{
    AfiseazaMesajCameraSiActualizeazaPrimaData(pozitieCurenta);
    raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuniPentru[pozitieCurenta]);

    if(pozitieCurenta == ixHol && raspunsUtilizator == ixAfara)
    {
        if(areCheie)
        {
            pozitieCurenta = ixAfara;
        }
        else
        {
            console.log("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
            console.log("Va trebui sa incerci altceva.");
        }
    }
    else if(pozitieCurenta == ixBaie)
    {
        console.log(`Nu ai nici o alta optiune decat sa te intorci in hol.`);
        pozitieCurenta = ixHol;
    }
    else if(raspunsUtilizator == ixCheie)
    {
        console.log("Ai luat cheia, acum poti deschide ceva.");
        areCheie = true;
        
        
        //reatribuim listei de optiuni, o noua lista cu elementele (e) care sunt diferite de ixCheie.
        //Pe romaneste, scoatem din lista de optiuni ixCheie.
        listaDeOptiuniPentru[ixBalcon] = listaDeOptiuniPentru[ixBalcon].filter(e => e != ixCheie);
    }
    else
    {
        pozitieCurenta = raspunsUtilizator;
    }
}

console.log("Ai reusit sa scapi din apartament, felicitari!");
