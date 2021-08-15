pozitieCurenta = "hol"
pozitieNoua = ""
areCheie = "nu"
primaDataIn_Hol = "da"
primaDataIn_Baie = "da"
primaDataIn_Dormitor = "da"
primaDataIn_Sufragerie = "da"
primaDataIn_Balcon = "da"

while pozitieCurenta != "afara":
    if pozitieCurenta == "hol":
        if primaDataIn_Hol == "da":
            print(f"""Esti in holul unei case din care trebuie neaparat sa iesi.""")

            primaDataIn_Hol = "nu"
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
                if areCheie == "da":
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
        if primaDataIn_Baie == "da":
            print(f"""Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
""")

            primaDataIn_Baie = "nu"
        else:
            print(f"""Esti in baie si e bezna.""")

        print(f"""Nu ai nici o alta optiune decat sa te intorci in hol.""")
        pozitieCurenta = "hol"
    elif pozitieCurenta == "dormitor":
        if primaDataIn_Dormitor == "da":
            print(f"""Dormitorul arata sinistru.""")

            primaDataIn_Dormitor = "nu"
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
        if primaDataIn_Sufragerie == "da":
            print(f"""Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.""")

            primaDataIn_Sufragerie = "nu"
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
        if primaDataIn_Balcon == "da":
            print(f"""Din balcon se vede afara. Esti la etajul 12.""")

            primaDataIn_Balcon = "nu"
        else:
            print(f"""Esti in balcon.""")

        if areCheie == "da":
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
Ce alegi(1-2)?""")
    
        pozitieNoua = ""
        while pozitieNoua == "":
            pozitieNoua = input()

            if pozitieNoua == "1":
                pozitieCurenta = "dormitor"
            elif pozitieNoua == "2":
                pozitieCurenta = "sufragerie"
            elif pozitieNoua == "3" and areCheie != "da":
                pozitieCurenta = "balcon"
                areCheie = "da"
            else:
                print("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.")
                pozitieNoua = ""

print("Ai reusit sa scapi din apartament, felicitari!")
