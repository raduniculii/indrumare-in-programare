import sys

#citire argument de la consola... e.g: "py numere.py 12345" fara ghilimele
#numar = int(sys.argv[1])

listaCifreMasculin = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
listaCifreNeutru = ["zero", "un", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
listaCifreFeminin = ["zero", "o", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
sprezece = ["zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]
zeci = ["douăzeci", "treizeci", "patruzeci", "cincizeci", "șaizeci", "șaptezeci", "optzeci", "nouăzeci"]
sute = ["o sută", "două sute", "trei sute", "patru sute", "cinci sute", "șase sute", "șapte sute", "opt sute", "nouă sute"]

numar = int(sys.argv[1])

arrNumar = []

if (numar > 999):
    print("prea mare")
    sys.exit()

def myFc(gen, numar):
    if (numar >= 100):
        arrNumar.append(sute[(numar // 100) - 1])
        numar = numar % 100

    if (numar >= 20):
        arrNumar.append(zeci[(numar // 10) - 2])
        numar = numar % 10
        if numar != 0:
            arrNumar.append("si")

    if (numar >= 10):
        arrNumar.append(sprezece[numar % 10])
        numar = numar % 10
    else:
        if(gen == "m"):
            arrNumar.append(listaCifreMasculin[numar % 10])
        elif gen == "n":
            arrNumar.append(listaCifreNeutru[numar % 10])
        elif gen == "f":
            arrNumar.append(listaCifreFeminin[numar % 10])
        else:
            print("scandal")
            sys.exit()

myFc("n", numar)
print(" ".join(arrNumar))
sys.exit()
#https://numar-text.calculators.ro/numerele-cardinale-reguli-de-scriere-din-cifre-in-cuvinte-cu-litere.php
#print("doisprezece mii trei sute patruzeci si cinci")


import os 
# calea catre directorul in care se afla fisierul py
dir_path = os.path.dirname(os.path.realpath(__file__))


#writing files
#deschidem fisierul denumit myTextFile.txt in acelasi fisier cu py-ul nostru
with open(os.path.join(dir_path, 'myTextFile.txt'), 'w') as writer:
    # Write the dog breeds to the file in reversed order
    for i in range(1, 10):
        writer.write(str(i) + "\n")

# Open a file: file
with open(os.path.join(dir_path, 'myTextFile.txt'),mode='r') as file:
    # read all lines at once
    all_of_it = file.read()

    print(all_of_it)

# Open the file a second time
with open(os.path.join(dir_path, 'myTextFile.txt'),mode='r') as file:
    line = file.readline()
    while line != "":
        print("linia:")
        print(line)
        line = file.readline()

