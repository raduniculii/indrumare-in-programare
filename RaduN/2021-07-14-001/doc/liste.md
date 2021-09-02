# Liste

Unul dintre tipurile de date cele mai utile e lista. O lista e o variabila care poate tine mai multe valori. In limbajele "strong typed", cum ar fi C#, aceste valori trebuie sa aiba acelasi tip. In limbajele care nu sunt "strong typed", cum ar fi JavaScript si python, aceasta restrictie nu se aplica.

Pentru a lucra cu una din aceste valori, va trebui sa specificam cu a cata vrem sa lucram. Doar ca... in programare lucrurile incep de la zero. Adica daca vrem sa lucram cu prima valoare, vom folosi numarul 0 pentru a semnaliza asta, daca vrem cu cea de-a doua, vom folosi numarul 1, si asa mai departe. Mereu avem N-1. Ultimul element are indexul (asa se cheama "al catalea e") egal cu numarul de elemente din lista minus 1.

In JavaScript:
```javascript
//asa declaram si initializam (adica ii dam valoarea initiala) o lista
var listaDeNume = [];

//asa adaugam 3 valoari in lista
listaDeNume.push("Gigel"); //va avea index-ul 0 pentru ca lista era goala si asta se adauga la sfarsit (primul - 1 = 0)
listaDeNume.push("Miruna"); //va avea index-ul 1 pentru ca lista avea deja un element asta se adauga la sfarsit (a doilea - 2 = 1)
listaDeNume.push("Costel"); //va avea index-ul 2 pentru ca lista avea deja doua elemente asta se adauga la sfarsit (al treilea - 1 = 2)

console.log(listaDeNume[1]); //se afiseaza Miruna

listaDeNume[1] = "Geta";// suprascriem valoarea de la index = 1; adica nu mai eavem Miruna, acum e Geta
console.log(listaDeNume[1]); //se afiseaza Geta

var indexNume = 0;
//atat timp cat indexNume e strict mai mic decat numarul de elemente din lista; Notati ca nu am folosit mai mic sau egal, pentru ca incepe de la zero si ultimul element e listaDeNume.length - 1
while(indexNume < listaDeNume.length){
    console.log(listaDeNume[indexNume]);
    indexNume = indexNume + 1;//crestem indexNume ca sa mergem la urmatorul element
}
//acest while va afisa: Gigel, Geta, Costel, fiecare pe linia lui si fara virgule. Miruna nu mai e in lista, a fost suprascrisa de Geta. (se mai intampla... oricum era o lista ciudata)

//si pentru a scoate un element din lista
listaDeNume.splice(1, 1); //primul argument e index-ul de unde sa inceapa sa stearga, cel de-al doilea zice "cate" elemente sa stearga. Aici am sters-o pe Geta, iar acum lista mai are doar 2 elemente.

console.log(listaDeNume[1]); //se afiseaza Costel, el a fost mutat de pe index-ul 2 pe index-ul 1, pentru ca elementul de la 1 a fost sters. Indecsii raman mereu consecutivi.
```


In python:
```python
#asa declaram si initializam (adica ii dam valoarea initiala) o lista
listaDeNume = []

#asa adaugam 3 valoari in lista
listaDeNume.append("Gigel") #va avea index-ul 0 pentru ca lista era goala si asta se adauga la sfarsit (primul - 1 = 0)
listaDeNume.append("Miruna") #va avea index-ul 1 pentru ca lista avea deja un element asta se adauga la sfarsit (a doilea - 2 = 1)
listaDeNume.append("Costel") #va avea index-ul 2 pentru ca lista avea deja doua elemente asta se adauga la sfarsit (al treilea - 1 = 2)

print(listaDeNume[1]) #se afiseaza Miruna

listaDeNume[1] = "Geta"# suprascriem valoarea de la index = 1; adica nu mai eavem Miruna, acum e Geta
print(listaDeNume[1]) #se afiseaza Geta

indexNume = 0
#atat timp cat indexNume e strict mai mic decat numarul de elemente din lista; Notati ca nu am folosit mai mic sau egal, pentru ca incepe de la zero si ultimul element e listaDeNume.length - 1
while indexNume < len(listaDeNume):
    print(listaDeNume[indexNume])
    indexNume = indexNume + 1#crestem indexNume ca sa mergem la urmatorul element

#acest while va afisa: Gigel, Geta, Costel, fiecare pe linia lui si fara virgule. Miruna nu mai e in lista, a fost suprascrisa de Geta. (se mai intampla... oricum era o lista ciudata)

#si pentru a scoate un element din lista
del listaDeNume[1] #"sterge" elementul al doilea ( - 1 = 1); Aici am sters-o pe Geta, iar acum lista mai are doar 2 elemente.
#merge si `del listaDeNume[startIndex:endIndex]` primul index zice de unde sa inceapa sa stearga, cel de-al doilea pana la unde.

print(listaDeNume[1]) #se afiseaza Costel, el a fost mutat de pe index-ul 2 pe index-ul 1, pentru ca elementul de la 1 a fost sters. Indecsii raman mereu consecutivi.
```

In C#:
```csharp
//sus de tot, langa using System; sa mai aveti o linie cu:
//using System.Collections.Generic;

//asa declaram si initializam (adica ii dam valoarea initiala) o lista
List<string> listaDeNume = new List<string>();
//subliniat cu rosu daca nu ati facut ce scrie in comentariul de inceput de exemplu

//asa adaugam 3 valoari in lista
listaDeNume.Add("Gigel"); //va avea index-ul 0 pentru ca lista era goala si asta se adauga la sfarsit (primul - 1 = 0)
listaDeNume.Add("Miruna"); //va avea index-ul 1 pentru ca lista avea deja un element asta se adauga la sfarsit (a doilea - 2 = 1)
listaDeNume.Add("Costel"); //va avea index-ul 2 pentru ca lista avea deja doua elemente asta se adauga la sfarsit (al treilea - 1 = 2)

Console.WriteLine(listaDeNume[1]); //se afiseaza Miruna

listaDeNume[1] = "Geta";// suprascriem valoarea de la index = 1; adica nu mai eavem Miruna, acum e Geta
Console.WriteLine(listaDeNume[1]); //se afiseaza Geta

int indexNume = 0;
//atat timp cat indexNume e strict mai mic decat numarul de elemente din lista; Notati ca nu am folosit mai mic sau egal, pentru ca incepe de la zero si ultimul element e listaDeNume.length - 1
while(indexNume < listaDeNume.Count){
    Console.WriteLine(listaDeNume[indexNume]);
    indexNume = indexNume + 1;//crestem indexNume ca sa mergem la urmatorul element
}
//acest while va afisa: Gigel, Geta, Costel, fiecare pe linia lui si fara virgule. Miruna nu mai e in lista, a fost suprascrisa de Geta. (se mai intampla... oricum era o lista ciudata)

//si pentru a scoate un element din lista
listaDeNume.RemoveAt(1); //index-ul de unde sa inceapa stearga. Aici am sters-o pe Geta, iar acum lista mai are doar 2 elemente.
//C# stie si `listaDeNume.RemoveRange(index, count);` care zice de unde sa stearga si cate

Console.WriteLine(listaDeNume[1]); //se afiseaza Costel, el a fost mutat de pe index-ul 2 pe index-ul 1, pentru ca elementul de la 1 a fost sters. Indecsii raman mereu consecutivi.
```

## Exercitii

1. Un program care sa afiseze suma numerelor dintr-o lista
2. Un program care sa calculeze media numerelor din lista (pt c# folositi double in loc de int pentru medie, astfel incat sa va calculeze si valori cu virgula, nu doar intregi)
3. Un program care sa gaseasca cel mai mic (sau mare) numar dintr-o lista de numere
4. Un program care sa zica la ce index avem un anumit nume in lista, sau daca nu e gasit sa afiseze "nu am gasit" si sa planga 10 minute.
5. Un program care sa afiseze valoarile unei liste in ordine inversa
6. Un program care e despre a fi pozitiv. Sa "curete" lista de numere negative, sa lea stearga si sa lase doar ce e pozitiv. ATENTIE, vor aparea niste probleme aici, faceti teste si cu o lista care are mai multe numere negative unul langa altul si vedeti de ce nu va merge din prima... poate puneti writeline sau console log sau print si vedeti de ce nu merge cum ati crezut.
7. Un program care sa inverseze valorile dintr-o lista, nu doar sa le afiseze invers ca la punctul 5, adica daca are [1, 2, 3, 4, 5] sa aiba la sfarsit 5 la indexul 0, 4 la 1, ... si 1 la indexul 4 (ultimul).
8. Un program care sa sorteze o lista (adica sa aseze valorile in ordine crescatoare) fara sa va folositi de functiile de sort pe care le au deja limbajele de programare. Asta ca sa faceti muschi pentru manipulat liste. S-ar putea sa va fie foarte greu.


Ca de obicei, daca mi-au scapat greseli si nu merge vre-un exemplu, scrieti pe grup.