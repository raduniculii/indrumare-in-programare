const readLine = require("./readLine");

var pozitieCurenta = "hol";
var pozitieNoua = "";
var areCheie = "nu";

var primaDataIn_Hol = "da";
var primaDataIn_Baie = "da";
var primaDataIn_Dormitor = "da";
var primaDataIn_Sufragerie = "da";
var primaDataIn_Balcon = "da";

while(pozitieCurenta != "afara"){
    if(pozitieCurenta == "hol"){
        if(primaDataIn_Hol == "da"){
            console.log(`Esti in holul unei case din care trebuie neaparat sa iesi.`);

            primaDataIn_Hol = "nu";
        }
        else {
            console.log(`Esti in hol.`);
        }

        console.log(`Ai urmatoarele optiuni:
    [1] usa de intrare/iesire din apartament
    [2] usa de la baie
    [3] usa de la dormitor
    [4] usa de la sufragerie
Ce alegi(1-4)?`);
    
        pozitieNoua = "";
        while(pozitieNoua == ""){
            pozitieNoua = readLine();

            if(pozitieNoua == "1"){
                if(areCheie == "da"){
                    pozitieCurenta = "afara";
                }
                else {
                    console.log("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
                    console.log("Va trebui sa incerci altceva.");
                }
            }
            else if(pozitieNoua == "2"){
                pozitieCurenta = "baie";
            }
            else if(pozitieNoua == "3"){
                pozitieCurenta = "dormitor";
            }
            else if(pozitieNoua == "4"){
                pozitieCurenta = "sufragerie";
            }
            else {
                console.log("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 4.");
                pozitieNoua = "";
            }
        }
    }
    else if(pozitieCurenta == "baie"){
        if(primaDataIn_Baie == "da"){
            console.log(`Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
`);

            primaDataIn_Baie = "nu";
        }
        else {
            console.log(`Esti in baie si e bezna.`);
        }

        console.log(`Nu ai nici o alta optiune decat sa te intorci in hol.`);
        pozitieCurenta = "hol";
    }
    else if(pozitieCurenta == "dormitor"){
        if(primaDataIn_Dormitor == "da"){
            console.log(`Dormitorul arata sinistru.`);

            primaDataIn_Dormitor = "nu";
        }
        else {
            console.log(`Esti in dormitor.`);
        }

        console.log(`Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?`);
    
        pozitieNoua = "";
        while(pozitieNoua == ""){
            pozitieNoua = readLine();

            if(pozitieNoua == "1"){
                pozitieCurenta = "hol";
            }
            else if(pozitieNoua == "2"){
                pozitieCurenta = "balcon";
            }
            else {
                console.log("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                pozitieNoua = "";
            }
        }
    }
    else if(pozitieCurenta == "sufragerie"){
        if(primaDataIn_Sufragerie == "da"){
            console.log(`Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.`);

            primaDataIn_Sufragerie = "nu";
        }
        else {
            console.log(`Esti in sufragerie.`);
        }

        console.log(`Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?`);
    
        pozitieNoua = "";
        while(pozitieNoua == ""){
            pozitieNoua = readLine();

            if(pozitieNoua == "1"){
                pozitieCurenta = "hol";
            }
            else if(pozitieNoua == "2"){
                pozitieCurenta = "balcon";
            }
            else {
                console.log("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                pozitieNoua = "";
            }
        }
    }
    else if(pozitieCurenta == "balcon"){
        if(primaDataIn_Balcon == "da"){
            console.log(`Din balcon se vede afara. Esti la etajul 12.`);

            primaDataIn_Balcon = "nu";
        }
        else {
            console.log(`Esti in balcon.`);
        }

        if(areCheie == "da"){
            console.log(`Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
Ce alegi(1-2)?`);
        }
        else {
            console.log(`Pe jos se vede o cheie ruginita
Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
    [3] ridica cheia de pe jos
Ce alegi(1-3)?`);
        }
    
        pozitieNoua = "";
        while(pozitieNoua == ""){
            pozitieNoua = readLine();

            if(pozitieNoua == "1"){
                pozitieCurenta = "dormitor";
            }
            else if(pozitieNoua == "2"){
                pozitieCurenta = "sufragerie";
            }
            else if(pozitieNoua == "3" && areCheie != "da"){
                pozitieCurenta = "balcon";
                console.log("Ai luat cheia, acum poti deschide ceva.");
                areCheie = "da";
            }
            else {
                console.log("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                pozitieNoua = "";
            }
        }
    }
}

console.log("Ai reusit sa scapi din apartament, felicitari!");
