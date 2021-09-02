import sys
#sys.exit() pentru cand vrem sa terminam programul fortat

IX_NEVALID = -1

#astea nu mai sunt constante, ca sa le putem schimba ordinea si mai
#stiu eu ce, asa ca folosim litere mici, ca si CONVENTIE (adica mergea
#la fel programul si cu litere mari dar e conventie arhi-cunoscuta ca
#avem constante cu caps lock si variabile normale fara)
#Le punem pe toate 0 desi ele nu vor fi 0 ci in functie de indexul adevarat
ixHol = 0
ixBaie = 0
ixDormitor = 0
ixSufragerie = 0
ixBalcon = 0
ixAfara = 0
ixCheie = 0

primaDataIn = []
primulTextPentru = []
textulUrmatorPentru = []
textOptiunePentru = []
listaDeOptiuniPentru = []

def oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuni):
    if listaDeOptiuni == None or len(listaDeOptiuni) == 0: return IX_NEVALID

    print("Ai urmatoarele optiuni:")
    index = 0
    while index < len(listaDeOptiuni):
        print("   [" + str(index + 1) + "] " + textOptiunePentru[listaDeOptiuni[index]])
        index = index + 1

    print(f"Ce alegi (1-{len(listaDeOptiuni)})?")

    #am pus -1 ca nu il vom lasa pe el sa aleaga -1 si asta va fi valoarea noastra nevalida
    alegereUtilizator = -1
    while alegereUtilizator == -1:
        try:
            alegereUtilizator = int(input())
        except ValueError:
            #daca nu a mers transformatea in int, facem alegerea iar -1, desi tot aia ramasese
            alegereUtilizator = -1

        if alegereUtilizator < 1 or alegereUtilizator > len(listaDeOptiuni):
            print(f"Optiune inexistenta, te rog reintrodu o optiune de la 1 la {len(listaDeOptiuni)}.")
            alegereUtilizator = -1

    return listaDeOptiuni[alegereUtilizator - 1]

def AfiseazaMesajCameraSiActualizeazaPrimaData(indexCamera):
    if primaDataIn[indexCamera]:
        print(primulTextPentru[indexCamera])

        primaDataIn[indexCamera] = False
    else:
        print(textulUrmatorPentru[indexCamera])

def AdaugaOptiune(primulText, textulUrmator, textOptiune):
    primaDataIn.append(True)
    primulTextPentru.append(primulText)
    textulUrmatorPentru.append(textulUrmator)
    textOptiunePentru.append(textOptiune)
    
    #punem None aici (e ca null din js sau C#) si o definim unde doar avem nevoie
    listaDeOptiuniPentru.append(None)

    #returnam indexul elementului abia adaugat
    return len(primaDataIn) - 1

def ConfigureazaOptiuni():
    # trebuie sa punem astea ca si global ca sa ne lase se le re-atribuim o valoare
    # Nota: la liste nu am facut asta pentru ca nu le-am re-atribuit lor, ci fie
    # le-am adaugat elemente, fie am reatribuit elementele lor
    global ixHol
    global ixBaie
    global ixDormitor
    global ixSufragerie
    global ixBalcon
    global ixAfara
    global ixCheie

    ixHol = AdaugaOptiune(
        "Esti in holul unei case din care trebuie neaparat sa iesi."
        , "Esti in hol."
        , "usa de la hol."
    )

    ixBaie = AdaugaOptiune(
        """Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric."""
        , "Esti in baie si e bezna."
        , "usa de la baie"
    )
    
    ixDormitor = AdaugaOptiune(
        "Dormitorul arata sinistru."
        , "Esti in dormitor."
        , "usa de la dormitor."
    )

    ixSufragerie = AdaugaOptiune(
        "Sufrageria arata primitor, desi tu nu ai timp sa stai la TV."
        , "Esti in sufragerie."
        , "usa de la sufragerie."
    )

    ixBalcon = AdaugaOptiune(
        "Din balcon se vede afara. Esti la etajul 12."
        , "Esti in balcon."
        , "usa de la balcon"
    )

    ixAfara = AdaugaOptiune(
        None
        , None
        , "usa de intrare/iesire din apartament"
    )

    ixCheie = AdaugaOptiune(
        None
        , None
        , "ridica cheia"
    )

    #lista cu liste
    listaDeOptiuniPentru[ixHol] = [ ixAfara, ixBaie, ixDormitor, ixSufragerie ]
    listaDeOptiuniPentru[ixDormitor] = [ ixHol, ixBalcon ]
    listaDeOptiuniPentru[ixSufragerie] = [ ixHol, ixBalcon ]
    listaDeOptiuniPentru[ixBalcon] = [ ixDormitor, ixSufragerie, ixCheie ]

#functia facuta de noi
ConfigureazaOptiuni()

pozitieCurenta = ixHol
areCheie = False
raspunsUtilizator = IX_NEVALID

while pozitieCurenta != ixAfara:
    AfiseazaMesajCameraSiActualizeazaPrimaData(pozitieCurenta)
    raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuniPentru[pozitieCurenta])

    if pozitieCurenta == ixHol and raspunsUtilizator == ixAfara:
        if areCheie:
            pozitieCurenta = ixAfara
        else:
            print("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...")
            print("Va trebui sa incerci altceva.")
    elif pozitieCurenta == ixBaie:
        print("Nu ai nici o alta optiune decat sa te intorci in hol.")
        pozitieCurenta = ixHol
    elif raspunsUtilizator == ixCheie:
        print("Ai luat cheia, acum poti deschide ceva.")
        areCheie = True
        
        #scoatem din lista de optiuni ixCheie.
        listaDeOptiuniPentru[ixBalcon].remove(ixCheie)
    else:
        pozitieCurenta = raspunsUtilizator

print("Ai reusit sa scapi din apartament, felicitari!")
