import sys

#citire argument de la consola... e.g: "py numere.py 12345" fara ghilimele
#numar = int(sys.argv[1])

listaCifreMasculin = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
listaCifreNeutru = ["zero", "un", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
listaCifreFeminin = ["zero", "o", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
sprezece = ["zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]
zeci = ["douăzeci", "treizeci", "patruzeci", "cincizeci", "șaizeci", "șaptezeci", "optzeci", "nouăzeci"]
sute = ["o sută", "două sute", "trei sute", "patru sute", "cinci sute", "șase sute", "șapte sute", "opt sute", "nouă sute"]

#dictionare de tip cheie: valoare
genuri = {
      "unitati": "m"
    , "mii": "f"
    , "milioane": "n"
    , "miliarde": "n"
}
singulareOrdine = {
      "unitati": "unitate"
    , "mii": "mie"
    , "milioane": "milion"
    , "miliarde": "miliard"
}

numar = int(sys.argv[1])

arrCuvinteNumar = []

if (numar >= 10**12):
    print("prea mare")
    sys.exit()

# 10**9 = 10 la puterea a noua
UN_MILIARD = 10**9
UN_MILION = 10**6
O_MIE = 10**3

def numarInText(numar):
    #separm numarul in cate 3 cifre de la coada la cap.
    #adica daca avuem 1234567 vom avea 1 in numar si 234567 in numar ramas
    #a.i. apoi vom chema functia cu 234567 care devine 234 si 567, etc.
    numarRamas = 0
    ordin = "unitati"
    if numar >= UN_MILIARD:
        ordin = "miliarde"
        gen = genuri[ordin]
        numarRamas = numar % UN_MILIARD
        numar = numar // UN_MILIARD
    elif numar >= UN_MILION:
        ordin = "milioane"
        gen = genuri[ordin]
        numarRamas = numar % UN_MILION
        numar = numar // UN_MILION
    elif numar >= O_MIE:
        ordin = "mii"
        gen = genuri[ordin]
        numarRamas = numar % O_MIE
        numar = numar // O_MIE
    else:
        ordin = "unitati"
        gen = genuri[ordin]
        numarRamas = 0

    ordinDeAfisat = ordin
    if numar == 1:
        ordinDeAfisat = singulareOrdine[ordin]
    

    if (numar >= 100):
        arrCuvinteNumar.append(sute[(numar // 100) - 1])
        numar = numar % 100

    punemDe = False
    if (numar >= 20):
        arrCuvinteNumar.append(zeci[(numar // 10) - 2])
        numar = numar % 10
        punemDe = True
        if numar != 0:
            arrCuvinteNumar.append("si")

    if (numar >= 10):
        arrCuvinteNumar.append(sprezece[numar % 10])
        numar = numar % 10
    else:
        if len(arrCuvinteNumar) == 0 or numar != 0:
            if(gen == "m"):
                arrCuvinteNumar.append(listaCifreMasculin[numar % 10])
            elif gen == "n":
                arrCuvinteNumar.append(listaCifreNeutru[numar % 10])
            elif gen == "f":
                arrCuvinteNumar.append(listaCifreFeminin[numar % 10])
            else:
                print("scandal")
                sys.exit()
    
    if ordin != "unitati":
        if punemDe:
            arrCuvinteNumar.append("de")
        arrCuvinteNumar.append(ordinDeAfisat)
    
    if numarRamas > 0:
        numarInText(numarRamas)

numarInText(numar)
print(" ".join(arrCuvinteNumar))
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

