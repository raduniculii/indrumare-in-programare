import sys

numar = int(sys.argv[1])

listaCifre = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

listaNumere = ["zece", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]

listaZeci = ["douăzeci", "treizeci", "patruzeci", "cincizeci", "șaizeci", "șaptezeci", "optzeci", "nouăzeci"]

listaSute = ["o sută", "două sute", "trei sute","patru sute", "cinci sute", "șase sute", "șapte sute", "opt sute", "nouă sute"]

listaMii = ["o mie", "două mii", "trei mii","patru mii", "cinci mii", "șase mii", "șapte mii", "opt mii", "nouă mii"]

lista = []


def ordinDeMarime(numar):
    index = 1
    while (numar // 10 > 0):
        index += 1
        numar = numar // 10
    return index

if ordinDeMarime(numar) > 5:
    print("Hai ca te intreci cu gluma! Alege un numar cu ordinul de marime cel mult 5.")

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
      
def scriereCifre(numar):
    global lista
    lista = (listaCifre[numar])
    return lista

def scriereZeci(numar):
    global lista
    if (numar // 10 == 1):
        lista = listaNumere[numar % 10]
    elif (numar % 10 == 0):
        lista = listaZeci[(numar // 10) - 2]
    else:
       lista = listaZeci[(numar // 10) - 2] + " si " + listaCifre[numar % 10]
    return lista

def scriereSute(numar):
    global lista
    if (numar % 1000 == 0): #ma ajuta la zeci de mii: ex pentru 12000
        lista = " " 
    elif (((numar % 1000) // 100 == 0) and ((numar % 10000) // 10) != 0): #ma ajuta la zeci de mii: ex pentru 12090
        lista = scriereZeci(numar % 100)
    elif (((numar % 1000) // 100 == 0) and ((numar % 10000) // 10) == 0): #ma ajuta la zeci de mii: ex pentru 12009
        lista = scriereCifre(numar % 10)
    elif (numar % 100 == 0) and (numar % 10 == 0): 
        lista = listaSute[numar//100 - 1]
    elif ((numar // 10) % 10 == 0) and (numar % 10 != 0): 
        lista = listaSute[numar//100 - 1] + " " + listaCifre[numar % 10]
    else:
        lista = listaSute[numar//100 - 1] + " " + scriereZeci(numar % 100)
    return lista

def scriereMii(numar):
    global lista
    if (numar % 1000 == 0) and (numar % 100 == 0) and (numar % 10 == 0): 
        lista = listaMii[numar//1000 - 1]
    elif (((numar // 100)) % 10 == 0) and ((numar // 10) % 10 == 0) and (numar % 10 != 0): 
        lista = listaMii[numar//1000 - 1] + " " + listaCifre[numar % 10]
    elif ((numar //100) % 10 == 0) and ((numar // 10) % 10 != 0):
        lista = listaMii[numar//1000 - 1] + " " + scriereZeci(numar % 100)
    else:
        lista = listaMii[numar//1000 - 1] + " " + scriereSute(numar % 1000)
    return lista

def scriereZeciDeMii(numar):
    global lista
    if (numar // 10000 == 1):
        lista = scriereZeci(numar // 1000) + " mii " + scriereSute(numar % 1000)
   
    elif (numar // 10000 != 1):
        lista = scriereZeci(numar // 1000) + " de mii " + scriereSute(numar % 1000)
    return lista

scriereNumar(numar)