# Functii

Uneori apare nevoia sa folosim un cod identic, sau aproape identic, in mai multe locuri din aplicatie sau program. Pentru aceste situatii putem folosi functiile.

Functiile sunt practic niste blocuri (~bucati) de cod care au un nume. Ele trebuie definite, adica sa anuntam compilatorul sau interpretorul (acel program care transforma textul nostru in cod care poate fi rulat de calculator) ca vom refolosi "aceasta" bucata de cod, "acest" bloc, sub numele de _____.

Pentru numele functiei, apar diferente intre limbaje dar o sa va dau cateva reguli pe care ar fi ok sa le urmati si merg in toate limbajele:
1. Numele incepe cu o litera sau _ (underscore)
2. Numele nu contine spatii
3. Numele contine doar litere, cifre sau _ (underscore - linia de subliniere)
4. In limbajele cu care lucram noi numele de functii si variabile sunt **"case sensitive"**, adica "nume" nu e acelasi lucru cu "Nume" si nici cu "NUME".

Nota: In exemplele de mai jos, in loc de "numeAlesDeNoi" puteti pune un nume ales de voi, doar sa respecte regulile amintite mai sus.

Pentru a defini o functie fara parametri in JavaScript (nu mai ziceti Java ca ala e alt limbaj):
``` javascript
function numeAlesDeNoi(){
    //codul pe care vrem sa il refolosim
}
//iar pentru a executa sau apela functia folosim:
numeAlesDeNoi();
```

Pentru a defini o functie fara parametri in Python
```python
def numeAlesDeNoi():
    #codul pe care vrem sa il refolosim
    #...
    #...
    #...

#Note: In python conteaza indentarea (adica cate spatii sunt de la inceputul liniei pana la comanda.) Observati ca def numeAlesDeNoi(): are o alta indentare decat codul. Codul din functie trebuie sa fie mai indentat (mai inauntru)

#Pentru a executa sau apela functia folosim:
numeAlesDeNoi()
```

Pentru a defini o functie fara parametri in C#, astfel incat sa poata fi chemata din Main, de unde scriem de obicei programul:
```csharp
using System;

namespace demo
{
    class Program
    {
        static void numeAlesDeNoi()
        {
            //codul pe care vrem sa il refolosim
        }

        static void Main(string[] args)
        {
            //codul din main, unde scrieti voi programul
            //...
            //Pentru a executa sau apela functia folosim:
            numeAlesDeNoi();
        }
    }
}
//Note: la C# declaratie de functie vine intre acoladele de la class Program. Fie inainte de Main ca in exemplu, fie dupa. De retinut ca trebuie sa fie in afara acoladelor lui Main.
```

## Functii cu parametri

In unele cazuri avem nevoie ca functiile noastre sa "primeasca" niste valori si apoi sa lucreze cu ele. Pentru aceste cazuri folosim functii cu parametri.

Pentru a defini o functie cu parametri in JavaScript:
``` javascript
//Evident, daca voiam un singur parametru aveam doar ...altNumeAlesDeNoi(numePersoana), iar daca vrem mai multi, tot punem nume3, nume4, ... nume_N; numele parametrilor sunt alese de noi, cu aceleasi reguli de denumire ca si functiile, si le alegem dupa nevoi, sa reflecte cat mai bine ceea ce vor contine
function altNumeAlesDeNoi(numePesoana, varsta){
    //codul pe care vrem sa il refolosim
}
//iar pentru a executa sau apela functia folosim:
altNumeAlesDeNoi("Gigel", 18);
//sau
altNumeAlesDeNoi(numeIntrodus, varstaInAni); //adica putem sa ii trimitem fie valori ca in primul apel, fie valorile din variabile, ca in cel de-al doilea apel
```

Pentru a defini o functie cu parametri in Python
```python
#Evident, daca voiam un singur parametru aveam doar ...altNumeAlesDeNoi(numePersoana), iar daca vrem mai multi, tot punem nume3, nume4, ... nume_N; numele parametrilor sunt alese de noi, cu aceleasi reguli de denumire ca si functiile, si le alegem dupa nevoi, sa reflecte cat mai bine ceea ce vor contine
def altNumeAlesDeNoi(numePesoana, varsta):
    #codul pe care vrem sa il refolosim
    #...

#iar pentru a executa sau apela functia folosim:
altNumeAlesDeNoi("Gigel", 18)
#sau
altNumeAlesDeNoi(numeIntrodus, varstaInAni) #adica putem sa ii trimitem fie valori ca in primul apel, fie valorile din variabile, ca in cel de-al doilea apel
```

Pentru a defini o functie cu parametri in C#, astfel incat sa poata fi chemata din Main, de unde scriem de obicei programul:
```csharp
using System;

namespace demo
{
    class Program
    {
        //Evident, daca voiam un singur parametru aveam doar ...altNumeAlesDeNoi(numePersoana), iar daca vrem mai multi, tot punem nume3, nume4, ... nume_N; numele parametrilor sunt alese de noi, cu aceleasi reguli de denumire ca si functiile, si le alegem dupa nevoi, sa reflecte cat mai bine ceea ce vor contine
        static void altNumeAlesDeNoi(string numePesoana, int varsta){ //observati ca in C# trebuie sa precizam tipul de date pentru fiecare parametru in parte. Ce va contine el? Text/string? Numar intreg? Boolean? etc.
            //codul pe care vrem sa il refolosim
        }

        static void Main(string[] args)
        {
            //codul din main, unde scrieti voi programul
            //...
            //iar pentru a executa sau apela functia folosim:
            altNumeAlesDeNoi("Gigel", 18);
            //sau
            altNumeAlesDeNoi(numeIntrodus, varstaInAni); //adica putem sa ii trimitem fie valori ca in primul apel, fie valorile din variabile, ca in cel de-al doilea apel
        }
    }
}
```

## Functii cu return

In multe cazuri, functiile noastre calculeaza ceva, sau obtin prin diferite mijloace o anumita valoare, si am vrea sa obtinem acel rezultat. Pentru aceste cazuri folosim cuvantul cheie **return** din interiorul functiei.

De retinut! Cand functia executa comanda return, se opreste si nu mai executa nimic altceva din corpul functiei, revine la locul de unde a fost apelata functia cu valoarea "returnata".

Note: Cand lucrati cu alte persoane, trebuie sa vedeti care e conduita pe proiectul respectiv. Sunt proiecte unde s-a stabilit sa nu se foloseasca mai multe "return-uri" in aceeasi functie, pe motiv ca ar putea ingreuna citirea functiei.

Eu va voi arata un exemplu cu doua return-uri, ca sa va pot ilustra cum functioneaza.

In JavaScript:
```javascript
function ceCopilConduce(primulNume, primaVarsta, alDoileaNume, aDouaVarsta){
    if(primaVarsta >= aDouaVarsta) return primulNume;

    //aici puteam folosi si else, dar pentru ca in primul if avem return si pentru ca functia "iese" cand da de return, putem sa nu mai punem else. E o practica cu care de multe ori putem valida repede mai multe lucruri la inceputul unei functii si sa nu ajungem sa facem degeaba if in if in if in else in etc...
    //Codul se traduce cam asa: Daca prima varsta e mai mare sau egala cu cea de-a doua, primul copil e seful, daca nu, mergi mai departe in functie. Apoi: daca ajungi aici, al doilea copil e seful.
    return alDoileaNume;
}

//pentru apel
var numeSef = ceCopilConduce("Gigel", 9, "Miruna", 10);
//evident ca apelul putea facut si cu variabile in loc de valorile literale "Gigel", 9, "Miruna", 10; Si tot evident puteau fi mixte.
```

In Python:
```python
def ceCopilConduce(primulNume, primaVarsta, alDoileaNume, aDouaVarsta):
    if primaVarsta >= aDouaVarsta: return primulNume

    #aici puteam folosi si else, dar pentru ca in primul if avem return si pentru ca functia "iese" cand da de return, putem sa nu mai punem else. E o practica cu care de multe ori putem valida repede mai multe lucruri la inceputul unei functii si sa nu ajungem sa facem degeaba if in if in if in else in etc...
    #Codul se traduce cam asa: Daca prima varsta e mai mare sau egala cu cea de-a doua, primul copil e seful, daca nu, mergi mai departe in functie. Apoi: daca ajungi aici, al doilea copil e seful.
    return alDoileaNume

#pentru apel
numeSef = ceCopilConduce("Gigel", 9, "Miruna", 10)
#evident ca apelul putea facut si cu variabile in loc de valorile literale "Gigel", 9, "Miruna", 10; Si tot evident puteau fi mixte.
```

In C#:
```csharp
using System;

namespace demo
{
    class Program
    {
        //NOTA! numai avem "static void" ci "static string", pentru ca returnam un string iar C#-ul vrea sa stie exact cu ce tipuri de date lucram (denumirea acestei forme specifice de OCD este: "strongly typed language").
        static string ceCopilConduce(string primulNume, int primaVarsta, string alDoileaNume, int aDouaVarsta){
            if(primaVarsta >= aDouaVarsta) return primulNume;

            //aici puteam folosi si else, dar pentru ca in primul if avem return si pentru ca functia "iese" cand da de return, putem sa nu mai punem else. E o practica cu care de multe ori putem valida repede mai multe lucruri la inceputul unei functii si sa nu ajungem sa facem degeaba if in if in if in else in etc...
            //Codul se traduce cam asa: Daca prima varsta e mai mare sau egala cu cea de-a doua, primul copil e seful, daca nu, mergi mai departe in functie. Apoi: daca ajungi aici, al doilea copil e seful.
            return alDoileaNume;
        }

        static void Main(string[] args)
        {
            //codul din main, unde scrieti voi programul
            //...
            //pentru apel
            string numeSef = ceCopilConduce("Gigel", 9, "Miruna", 10);
            //evident ca apelul putea facut si cu variabile in loc de valorile literale "Gigel", 9, "Miruna", 10; Si tot evident puteau fi mixte.
        }
    }
}
```


## Exercitii cu functii

1. Faceti o functie care sa aiba 2 parametri si sa returneze rezultatul adunarii lor. Puteti repeta pentru alte operatii.
2. Faceti o functie cu trei parametri si care sa returneze pe cel mai mare dintre ei. De ex: maximulMeu(2, 5, 3) va returna 5, pentru ca acesta e cel mai mare numar dintre cele 3; maximulMeu(3, 3, 1) va returna 3 (oricare, doar 3)
3. Faceti o functie cu un parametru, care sa returneze patratul argumentului (numarul "trimis" catrea ea la apel) Hint: patratul poate fi obtinut inmultind numarul cu el insusi.
4. Faceti o functie cu un parametru care sa afiseze pe consola mesajul: "Simon says: " urmat de mesajul pe care l-a primit ca argument la apel.

Daca mai aveti si alte exercitii simple cu functii, puneti pe grup.

Daca sunt greseli prin cod (ca nu l-am testat), va rog sa-mi dati de stie si il corectez repede.
