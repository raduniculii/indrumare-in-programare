import sys

#citire argument de la consola... e.g: "py numere.py 12345" fara ghilimele
#numar = int(sys.argv[1])

listaCifre = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

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

