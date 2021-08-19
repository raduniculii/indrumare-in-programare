import sys
#sys.exit() pentru cand vrem sa terminam programul fortat

pozitieCurenta = "hol"
areCheie = False

primaDataIn_Hol = True
primaDataIn_Baie = True
primaDataIn_Dormitor = True
primaDataIn_Sufragerie = True
primaDataIn_Balcon = True

def oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuni):
    print("Ai urmatoarele optiuni:")
    index = 0
    while index < len(listaDeOptiuni):
        print("   [" + str(index + 1) + "] " + listaDeOptiuni[index])
        index = index + 1

    print(f"Ce alegi (1-{len(listaDeOptiuni)})?")

    #am pus -1 ca nu il vom lasa pe el sa aleaga -1 si asta va fi valoarea noastra nevalida
    alegereUtilizator = -1
    while alegereUtilizator == -1:
        try:
            alegereUtilizator = int(input())
        except:
            #daca nu a mers transformatea in int, facem alegerea iar -1, desi tot aia ramasese
            alegereUtilizator = -1

        if alegereUtilizator < 1 or alegereUtilizator > len(listaDeOptiuni):
            print(f"Optiune inexistenta, te rog reintrodu o optiune de la 1 la {len(listaDeOptiuni)}.")
            alegereUtilizator = -1

    return alegereUtilizator - 1

while pozitieCurenta != "afara":
    if pozitieCurenta == "hol":
        if primaDataIn_Hol:
            print(f"Esti in holul unei case din care trebuie neaparat sa iesi.")

            primaDataIn_Hol = False
        else:
            print(f"Esti in hol.")

        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa de intrare/iesire din apartament"
            , "usa de la baie"
            , "usa de la dormitor"
            , "usa de la sufragerie"
        ])

        listaPozitiiUrmatoare = [
            "afara" #0
            , "baie" #1
            , "dormitor" #2
            , "sufragerie" #3
        ]

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator]
        
        #cum areCheie e boolean (adica True sau False), am inlocuit areCheie != "da" cu (nu areCheie, care in limbaj e not areCheie)
        if pozitieCurenta == "afara" and (not areCheie):
            print("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...")
            print("Va trebui sa incerci altceva.")
            pozitieCurenta = "hol"
    elif pozitieCurenta == "baie":
        if primaDataIn_Baie:
            #in python, putem avea string-uri cu 3 seturi de ghilimele, acestea ne permit sa avem randuri multiple
            print(f"""Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
""")

            primaDataIn_Baie = False
        else:
            print(f"Esti in baie si e bezna.")

        print(f"Nu ai nici o alta optiune decat sa te intorci in hol.")
        pozitieCurenta = "hol"
    elif pozitieCurenta == "dormitor":
        if primaDataIn_Dormitor:
            print(f"Dormitorul arata sinistru.")

            primaDataIn_Dormitor = False
        else:
            print(f"Esti in dormitor.")

        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa catre hol"
            , "usa catre balcon"
        ])

        listaPozitiiUrmatoare = [
            "hol" #0
            , "balcon" #1
        ]

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator]
    elif pozitieCurenta == "sufragerie":
        if primaDataIn_Sufragerie:
            print(f"Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.")

            primaDataIn_Sufragerie = False
        else:
            print(f"Esti in sufragerie.")

        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
            "usa catre hol"
            , "usa catre balcon"
        ])

        listaPozitiiUrmatoare = [
            "hol" #0
            , "balcon" #1
        ]

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator]
    elif pozitieCurenta == "balcon":
        if primaDataIn_Balcon:
            print(f"Din balcon se vede afara. Esti la etajul 12.")

            primaDataIn_Balcon = False
        else:
            print(f"Esti in balcon.")

        raspunsUtilizator = 0
        
        if areCheie:
            raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
                "usa catre dormitor"
                , "usa catre sufragerie"
            ])
        else:
            raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid([
                "usa catre dormitor"
                , "usa catre sufragerie"
                , "ridica cheia de pe jos"
            ])

        listaPozitiiUrmatoare = [
            "dormitor" #0
            , "sufragerie" #1
            , "balcon" #2
        ]

        pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator]

        if pozitieCurenta == "balcon":
            print("Ai luat cheia, acum poti deschide ceva.")
            areCheie = True

print("Ai reusit sa scapi din apartament, felicitari!")
