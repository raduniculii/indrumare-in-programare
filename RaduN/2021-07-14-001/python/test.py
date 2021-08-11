import sys

listaDeNume = ["John", "William", "Catherine", "Sam"]

index = 0

del listaDeNume[1]
print(f"Cine e la 1? {listaDeNume[1]}")

while(index < len(listaDeNume)):
    print(listaDeNume[index])
    index = index + 1

sys.exit()

pozitieCurenta = "hol"
pozitieNoua = ""
areCheie = False
primaDataIn_Hol = True
primaDataIn_Baie = True
primaDataIn_Dormitor = True
primaDataIn_Sufragerie = True
primaDataIn_Balcon = True

def afiseazaCevaurile(nume, varsta):
    if(varsta < 18):
        print("Buna " + nume)
        print(f"Inteleg ca ai {varsta} ani")
    else:
        print("Buna " + nume)
        print(f"Inteleg ca ai {varsta} ani, si esti major")

def oriZece(numar):
    return numar * 10

def una():
    return "Ion"

def doua():
    return "Ioaneee"

def trei(adresa):
    return "--" + adresa + "--"

def patru(adresa):
    adresaNoua = "Bucuresti, " + adresa
    print("inainte")
    return adresa
    print("dupa")


def compuneMesaj(cineva, varsta):
    """Aratam un mesaj in functie de varsta persoanei."""
    if varsta < 18:
        return cineva + "el" + " esti minor"
    elif varsta < 60:
        return cineva + " esti in campul muncii"

    return cineva + " esti pensionar"

mesaj = doua() + ", tu stai in " + patru("Brasov, pe 13 Decembrie?")
print(mesaj)

#Ctrl + k, s

cineva = "Gigi"
print(compuneMesaj(cineva, 17))
print(compuneMesaj(cineva, 19))
print(compuneMesaj(cineva, 70))


# print(oriZece(12))
# print(oriZece(1))
# print(oriZece(0))
# print(oriZece(-3))

# numarTest = 7
# print(numarTest)
# numarTest = oriZece(2)
# print(f"aa{numarTest}bb")

# afiseazaCevaurile("Gigi", 12)
# afiseazaCevaurile(nume="Petre", varsta=19)
# afiseazaCevaurile(varsta=36, nume="Maria")

# print(12 + 13)
# print("aa" + "bb")
# print("aa" + str(12))
# print(int("12") + 13)
# print("12" + "13")

sys.exit()

while pozitieCurenta != "afara":
    if pozitieCurenta == "hol":
        if primaDataIn_Hol:
            print(f"""Esti in holul unei case din care trebuie neaparat sa iesi.""")

            primaDataIn_Hol = False
        else :
            print(f"""Esti in hol.""")

        print(f"""Ai urmatoarele optiuni:
    [1] usa de intrare/iesire din apartament
    [2] usa de la baie
    [3] usa de la dormitor
    [4] usa de la sufragerie
Ce alegi(1-4)?""")

        pozitieNoua = ""
        while pozitieNoua == "":
            pozitieNoua = input()

            if pozitieNoua == "1":
                if areCheie:
                    pozitieCurenta = "afara"
                else:
                    print("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...")
                    print("Va trebui sa incerci altceva.")
            elif pozitieNoua == "2":
                pozitieCurenta = "baie"
            elif pozitieNoua == "3":
                pozitieCurenta = "dormitor"
            elif pozitieNoua == "4":
                pozitieCurenta = "sufragerie"
            else:
                print("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 4.")
                pozitieNoua = ""
    elif pozitieCurenta == "baie":
        if primaDataIn_Baie:
            print(f"""Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
""")

            primaDataIn_Baie = False
        else:
            print(f"""Esti in baie si e bezna.""")

        print(f"""Nu ai nici o alta optiune decat sa te intorci in hol.""")
        pozitieCurenta = "hol"
    elif pozitieCurenta == "dormitor":
        if primaDataIn_Dormitor:
            print(f"""Dormitorul arata sinistru.""")

            primaDataIn_Dormitor = False
        else:
            print(f"""Esti in dormitor.""")

        print(f"""Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?""")
    
        pozitieNoua = ""
        while pozitieNoua == "":
            pozitieNoua = input()

            if pozitieNoua == "1":
                pozitieCurenta = "hol"
            elif pozitieNoua == "2":
                pozitieCurenta = "balcon"
            else:
                print("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.")
                pozitieNoua = ""
    elif pozitieCurenta == "sufragerie":
        if primaDataIn_Sufragerie:
            print(f"""Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.""")

            primaDataIn_Sufragerie = False
        else:
            print(f"""Esti in sufragerie.""")

        print(f"""Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?""")
    
        pozitieNoua = ""
        while pozitieNoua == "":
            pozitieNoua = input()

            if pozitieNoua == "1":
                pozitieCurenta = "hol"
            elif pozitieNoua == "2":
                pozitieCurenta = "balcon"
            else:
                print("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.")
                pozitieNoua = ""
    elif pozitieCurenta == "balcon":
        if primaDataIn_Balcon:
            print(f"""Din balcon se vede afara. Esti la etajul 12.""")

            primaDataIn_Balcon = False
        else:
            print(f"""Esti in balcon.""")

        if areCheie:
            print(f"""Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
Ce alegi(1-2)?""")
        else:
            print(f"""Pe jos se vede o cheie ruginita
Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
    [3] ridica cheia de pe jos
Ce alegi(1-3)?""")
    
        pozitieNoua = ""
        while pozitieNoua == "":
            pozitieNoua = input()

            if pozitieNoua == "1":
                pozitieCurenta = "dormitor"
            elif pozitieNoua == "2":
                pozitieCurenta = "sufragerie"
            elif pozitieNoua == "3" and areCheie != True:
                pozitieCurenta = "balcon"
                print("Ai luat cheia, acum poti deschide ceva.");
                areCheie = True
            else:
                print("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.")
                pozitieNoua = ""

print("Ai reusit sa scapi din apartament, felicitari!")
