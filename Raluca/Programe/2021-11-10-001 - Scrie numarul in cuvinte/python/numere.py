import sys

numar = int(sys.argv[1])

listaCifre = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

listaNumere = ["zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]

listaZeci = ["douăzeci", "treizeci", "patruzeci", "cincizeci", "șaizeci", "șaptezeci", "optzeci", "nouăzeci"]

listaSute = ["o sută", "două sute", "trei sute","patru sute", "cinci sute", "șase sute", "șapte sute", "opt sute", "nouă sute"]

listaMii = ["o mie", "două mii", "trei mii","patru mii", "cinci mii", "șase mii", "șapte mii", "opt mii", "nouă mii"]

listaMilioane = ["un", "două"]

numarInText = ""


def ordinDeMarime(numar):
    index = 1
    while (numar // 10 > 0):
        index += 1
        numar = numar // 10
    return index

if ordinDeMarime(numar) > 9:
    print("Hai ca te intreci cu gluma! Alege un numar cu ordinul de marime cel mult 9.")

print("Ordinul de marime este: " + str(ordinDeMarime(numar)))
 
def scriereNumar(numar):
    if (ordinDeMarime(numar) == 1): 
       print(scriereCifre(numar))
    
    if (ordinDeMarime(numar) == 2):
        print(scriereZeci(numar))
    
    if (ordinDeMarime(numar) == 3):
        print(scriereSute(numar))
    
    if (ordinDeMarime(numar) == 4):
        print(scriereMii(numar))
    
    if (ordinDeMarime(numar) == 5):
        print(scriereZeciDeMii(numar))
   
    if (ordinDeMarime(numar) == 6):
        print(scriereSuteDeMii(numar))
   
    if (ordinDeMarime(numar) == 7):
        print(scriereMilioane(numar))
    
    if (ordinDeMarime(numar) == 8):
        print(scriereZeciDeMilioane(numar))

    if (ordinDeMarime(numar) == 9):
        print(scriereSuteDeMilioane(numar))
      
def scriereCifre(numar):
    global numarInText
    numarInText = (listaCifre[numar])
    return numarInText

def scriereZeci(numar):
    global numarInText
    if (numar // 10 == 1):
        numarInText = listaNumere[numar % 10]
    elif (numar % 10 == 0):
        numarInText = listaZeci[(numar // 10) - 2]
    else:
       numarInText = listaZeci[(numar // 10) - 2] + " si " + listaCifre[numar % 10]
    return numarInText

def scriereSute(numar):
    global numarInText
    if (numar % 1000 == 0): #ma ajuta la zeci de mii: ex pentru 12000
        numarInText = "" 
    elif (((numar % 1000) // 100 == 0) and ((numar % 10000) // 10) != 0): #ma ajuta la zeci de mii: ex pentru 12090
        numarInText = scriereZeci(numar % 100)
    elif (((numar % 1000) // 100 == 0) and ((numar % 10000) // 10) == 0): #ma ajuta la zeci de mii: ex pentru 12009
        numarInText = scriereCifre(numar % 10)
    elif (numar % 100 == 0) and (numar % 10 == 0): 
        numarInText = listaSute[numar//100 - 1]
    elif ((numar // 10) % 10 == 0) and (numar % 10 != 0): 
        numarInText = listaSute[numar//100 - 1] + " " + listaCifre[numar % 10]
    else:
        numarInText = listaSute[numar//100 - 1] + " " + scriereZeci(numar % 100)
    return numarInText

def scriereMii(numar):
    global numarInText
    if (numar % 1000 == 0) and (numar % 100 == 0) and (numar % 10 == 0): 
        numarInText = listaMii[numar//1000 - 1]
    elif (((numar // 100)) % 10 == 0) and ((numar // 10) % 10 == 0) and (numar % 10 != 0): 
        numarInText = listaMii[numar//1000 - 1] + " " + listaCifre[numar % 10]
    elif ((numar //100) % 10 == 0) and ((numar // 10) % 10 != 0):
        numarInText = listaMii[numar//1000 - 1] + " " + scriereZeci(numar % 100)
    else:
        numarInText = listaMii[numar//1000 - 1] + " " + scriereSute(numar % 1000)
    return numarInText

def scriereZeciDeMii(numar):
    global numarInText
    if (numar // 10000 == 1):
        numarInText = scriereZeci(numar // 1000) + " mii " + scriereSute(numar % 1000)
   
    elif (numar // 10000 != 1):
        numarInText = scriereZeci(numar // 1000) + " de mii " + scriereSute(numar % 1000)
    return numarInText

def scriereSuteDeMii(numar):
    global numarInText
    if ((numar //  1000) % 1000 == 0):
       numarInText = scriereSute(numar % 1000) #ma ajuta la milioane, zeci si sute de milioane: ex pentru 1000000, 10000000, 100000000 (sa nu mai scrie - de mii)
    elif (((numar //  1000) % 10 != 0) and ((numar //  10000) % 10 == 0)) or ((numar //  10000) % 10 == 1): #ma ajuta la milioane, zeci si sute de milioane: ex pentru 12000090 (sa nu mai scrie - de mii)
       numarInText = scriereSute(numar // 1000) + " mii " + scriereSute(numar % 1000)
    else:
        numarInText = scriereSute(numar // 1000) + " de mii " + scriereSute(numar % 1000)
    return numarInText

def scriereMilioane(numar):
    global numarInText
    if ((numar // 1000000) == 1):
        numarInText = "un milion " + scriereSuteDeMii(numar % 1000000)
    elif ((numar // 1000000) == 2):
        numarInText = "două milioane " + scriereSuteDeMii(numar % 1000000)
    else:
        numarInText = scriereCifre(numar // 1000000) + " milioane " + scriereSuteDeMii(numar % 1000000)
    return numarInText

def scriereZeciDeMilioane(numar):
    global numarInText
    if (numar // 10000000 == 1):
        numarInText = scriereZeci(numar // 1000000) + " milioane " + scriereSuteDeMii(numar % 1000000)
    elif (numar // 10000000 != 1):
        numarInText = scriereZeci(numar // 1000000) + " de milioane " + scriereSuteDeMii(numar % 1000000)
    return numarInText    

def scriereSuteDeMilioane(numar):
    global numarInText
    if ((numar // 1000000) % 10 != 0 and (numar // 10000000) % 10 == 0) or ((numar // 10000000) % 10 == 1):
        numarInText = scriereSute(numar // 1000000) + " milioane " + scriereSuteDeMii(numar % 1000000)
    else:
        numarInText = scriereSute(numar // 1000000) + " de milioane " + scriereSuteDeMii(numar % 1000000)
    return numarInText

scriereNumar(numar)