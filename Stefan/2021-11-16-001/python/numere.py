
# #https://numar-text.calculators.ro/numerele-cardinale-reguli-de-scriere-din-cifre-in-cuvinte-cu-litere.php


import sys

# numar = int(sys.argv[1])
numar = int(input('Introduceti numarul: '))


unu_zece = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
unu_zece_mii_sute = ["zero", "o", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
unsprezece_nouasprezece=["zero", "unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]
douazeci_nouazeci=["zero", "zece", "douazeci", "treizeci", "patruzeci", "cincizeci", "saizeci", "saptezeci", "optzeci", "nouazeci"]
temp_str = ""
if numar == 0: # Daca numarul e 0
    temp_str = "zero " # inistializare temp_str cu zero
if numar < 0 or numar > 9999:
    print("Numar invalid. Incercati cu numere intre 0 si 9999")
    exit()

# calculul fiecarui digit
primul_digit = numar // 1000
doilea_digit = (numar // 100 ) % 10
treilea_digit = (numar // 10 ) % 10
patrulea_digit = (numar // 1 ) % 10
if  primul_digit == 1  : 
    temp_str = temp_str + unu_zece_mii_sute[primul_digit] + " mie "
if primul_digit == 2  : 
    temp_str = temp_str + unu_zece_mii_sute[primul_digit] + " mii "
if primul_digit >2   : 
    temp_str = temp_str + unu_zece[primul_digit] + " mii "   


if doilea_digit ==1:
    temp_str = temp_str + unu_zece_mii_sute[doilea_digit] + " suta "
if doilea_digit ==2:
    temp_str = temp_str + unu_zece_mii_sute[doilea_digit] + " sute " 
if doilea_digit >2 :
    temp_str = temp_str + unu_zece[doilea_digit] + " sute " 


if treilea_digit == 1  :
    temp_str = temp_str + unsprezece_nouasprezece[patrulea_digit] + " "
    

if treilea_digit > 1:
    temp_str = temp_str + douazeci_nouazeci[treilea_digit] + " si "


# if patrulea_digit==0:
#     temp_str = temp_str + douazeci_nouazeci[treilea_digit]

# else:
    if patrulea_digit:
        temp_str = temp_str + unu_zece[patrulea_digit] + " "

print ("Numarul " +str(numar) +" scris in cifre este: "  + temp_str)