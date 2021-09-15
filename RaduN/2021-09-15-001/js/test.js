const readLine = require("./readLine");

function adunaLista(lista){
    var index = 0;
    var sum = 0;
    while(index < lista.length){
        sum += lista[index];  // echivalent cu sum = sum + lista[index];
        index++; // echivalent cu index += 1 echivalent cu index = index + 1;
    }
    
    return sum;
}

function patrat(nr){
    return nr * nr;
}

function adunaPatrateleDinLista(lista){
    var index = 0;
    var sum = 0;
    while(index < lista.length){
        sum += patrat(lista[index]); // echivalent cu sum = sum + lista[index]
        index++; // echivalent cu index += 1 echivalent cu index = index + 1
    }
    
    return sum;
}

var lst = [1, 2, 4];

console.log(`Suma numerelor ${lst} este ${adunaLista(lst)}`);
lst.push(12);
console.log(`Suma numerelor ${lst} este ${adunaLista(lst)}`);

var nrTest = 2;
console.log(`Patratul lui ${nrTest} este: ${patrat(nrTest)}`);
nrTest = 9;
console.log(`Patratul lui ${nrTest} este: ${patrat(nrTest)}`);

lst = [1, 2];

console.log(`Suma patratelor numerelor ${lst} este ${adunaPatrateleDinLista(lst)}`);
lst.push(4);
console.log(`Suma patratelor numerelor ${lst} este ${adunaPatrateleDinLista(lst)}`);


var listaNoua = [2, 3, 4, 5, 6, 7, 8];
console.log(listaNoua);
var listaDePatrate = listaNoua.map((x) => x * x); //mergea si cu listaNoua.map(patrat), adica doar voia o functie care sa primeasca un numar si sa returneze ceva. (x) => x*x e un lambda care face asta in JS

console.log(listaDePatrate);
console.log(adunaLista(listaDePatrate));

console.log(adunaLista(listaNoua.map(patrat)));


//(x) => x*x sau (x) => patrat(x) e tot una cu 
//function myAnonymousFunction(element){
//   return patrat(element);
//}
