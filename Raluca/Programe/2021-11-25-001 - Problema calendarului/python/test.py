#o problema interesanta pe care o puteti aborda ar fi sa faceti o functie care primeste o data (ca trei parametri, an [1800-9999], luna [1-12 sau 0-11], si zi [1-31]) 
# si returneaza ziua saptamanii in functie de data, fara sa folositi functiile din python, C# sau JS care stiu ele sa faca direct asta. Pentru asta trebuie sa stiti ca 
# 1 Ianuarie 1800 a fost o Miercuri, si regulile calendarului, care sunt:
# - evident: avem sapte zile ale saptamanii si se repeta cap coada mereu mereu
# - un an normal are 365 de zile, adica 52 de saptamani si o zi. (Nota: asta inseamna ca daca un an incepe Luni, se termina Luni si urmatorul incepe Marti)
# -numerele de zile din lunile unui an normal sunt: ian-31, feb-28, mar-31, apr-30, mai-31, iun-30, iul-31, aug-31, sept-30, oct-31, nov-30, dec-31
#- un an este bisect daca (se imparte la exact 4, dar nu si la 100) SAU (se imparte exact la 400); de ex: 1900 nu e bisect desi se imparte la 4, pentru ca se imparte 
# si la 100. 2000 e bisect pentru ca se imparte la 400. 2100 nu va fi bisect, 2004, 2008, 2012, 2016 si 2020 au fost toti bisecti pentru ca se imparteau exact la 4 si nu si la 100
#
#cu informatiile astea puteti face un program cu care sa calculati ni ce zi a saptamanii pica data si daca cumva nu e valida puteti afisa un mesaj si termina programul


anul = int(input('Introdu anul: '))

if anul < 1800 or anul > 9999:
    print('Alege un an in intervalul 1800 - 9999.')
    

#luna = int(input('Introdu luna: '))
#
#if luna < 1 or luna > 12:
#    print('Alege o luna valida')
#
#ziua = int(input('Introdu ziua: '))
#
#if ziua < 1 or ziua > 31:
#    print('Alege o zi valida')
#
#print(str(ziua) + " " + str(luna) + " " + str(anul))

def anBisect(anul):
    esteBisect = False
    if (anul % 4 == 0 and anul % 100 !=0) or (anul % 400 == 0):
        esteBisect = True
    return esteBisect

if anBisect(anul):
    print('Anul ' + str(anul) + ' este bisect')
else:
    print('Anul ' + str(anul) + ' nu este bisect')

def cateZile(anul):
    nrZile = 0
    i = 1801
    while (i <= anul): 
        if anBisect(i):
            nrZile += 366
            i += 1            
        else:
            nrZile += 365
            i += 1          
    return nrZile

print(cateZile(anul)) 

def data(anul):
   if  cateZile(anul) / 7 == 0:
       print ('miercuri')

data(anul)