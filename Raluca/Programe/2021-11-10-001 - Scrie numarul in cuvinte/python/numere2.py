import sys

numar = int(sys.argv[1])

listaCifre = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

listaNumere = ["zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]

listaZeci = ["douăzeci", "treizeci", "patruzecici", "cincizecici", "șaizeci", "șaptezecici", "optzeci", "nouăzeci"]

listaSpeciala = ["zero", "o", "două", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

listaNumar = []

lista = []

def ordinDeMarime(numar):
    index = 1
    while (numar // 10 > 0):
        index += 1
        numar = numar // 10
    return index

if ordinDeMarime(numar) > 6:
    print("Hai ca te intreci cu gluma! Alege un numar mai mic.")

print("Ordinul de marime este: " + str(ordinDeMarime(numar)))

def scriereNumar(numar):
    global lista
    index = 0
    numarVar = numar
    while index < ordinDeMarime(numar):
        listaNumar.append(listaCifre[numarVar % 10])
        index += 1
        numarVar = numarVar // 10 
    sortareListaNumar(listaNumar)
    print(listaNumar)  

      
def sortareListaNumar(listaNumar):
    lungimeLista = (len(listaNumar) - 1)
    index = 0 
    varindex = listaNumar[0]
    while (index < (len(listaNumar)/2)) and len(listaNumar) > 1:
        listaNumar[index] = listaNumar[lungimeLista]
        listaNumar[lungimeLista] = varindex
        lungimeLista -= 1
        index += 1
        varindex = listaNumar[index]

scriereNumar(numar)



#elif numar < 10 and numar >= 0:
 #       print(listaCifre[numar])


#https://numar-text.calculators.ro/numerele-cardinale-reguli-de-scriere-din-cifre-in-cuvinte-cu-litere.php

#print(numar // 10)
#print(numar // 100)
#print(numar // 1000)
#
#print((numar // 1 ) % 10)
#print((numar // 10 ) % 10)
#print((numar // 100 ) % 10)
#print((numar // 1000 ) % 10)
#print((numar // 10000 ) % 10)

#print("doisprezece mii trei sute patruzeci si cinci")
#nr = 123
#l = []
#l.append((nr // 1 ) % 10)
#l.append((nr // 10 ) % 10)
#print(len(l))