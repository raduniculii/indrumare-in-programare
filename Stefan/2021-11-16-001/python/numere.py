# import sys

# numar = int(sys.argv[1])

# unu_zece = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
# unsprezece_nouasprezece=["unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]
# douazeci_nouazeci=["douazeci", "treizeci", "patruzeci", "cincizeci", "saizeci", "saptezeci", "optzeci", "nouazeci"]

# if numar < 10 and numar >= 0:
#     print(unu_zece[numar])

# #https://numar-text.calculators.ro/numerele-cardinale-reguli-de-scriere-din-cifre-in-cuvinte-cu-litere.php

# print(numar // 10)
# print(numar // 100)
# print(numar // 1000)

# print((numar // 1 ) % 10)
# print((numar // 10 ) % 10)
# print((numar // 100 ) % 10)
# print((numar // 1000 ) % 10)
# print((numar // 10000 ) % 10)

# print("doisprezece mii trei sute patruzeci si cinci")
# nr = 123
# l = []
# l.append((nr // 1 ) % 10)
# l.append((nr // 10 ) % 10)
# print(len(l))
import sys

numar = int(sys.argv[1])


unu_zece = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
unu_zece_mii_sute = ["zero", "o", "doua", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]
unsprezece_nouasprezece=["unsprezece", "doisprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece"]
douazeci_nouazeci=["zero", "zece", "douazeci", "treizeci", "patruzeci", "cincizeci", "saizeci", "saptezeci", "optzeci", "nouazeci"]
temp_str = ""
if numar == 0: # Daca numarul e 0
    temp_str = "zero " # inistializare temp_str cu zero
# calculul fiecarui digit
primul_digit = numar // 1000
doilea_digit = (numar // 100 ) % 10
treilea_digit = (numar // 10 ) % 10
patrulea_digit = (numar // 1 ) % 10
if  primul_digit >0 and primul_digit <= 1  : 
    temp_str = temp_str + unu_zece_mii_sute[primul_digit] + " mie "
if primul_digit >1 and primul_digit <= 2  : 
    temp_str = temp_str + unu_zece_mii_sute[primul_digit] + " mii "
if primul_digit >2   : 
    temp_str = temp_str + unu_zece[primul_digit] + " mii "   


if doilea_digit > 0 and doilea_digit <=1:
    temp_str = temp_str + unu_zece_mii_sute[doilea_digit] + " suta "
if doilea_digit >1 and doilea_digit <=2:
    temp_str = temp_str + unu_zece_mii_sute[doilea_digit] + " sute " 
if doilea_digit >2 :
    temp_str = temp_str + unu_zece[doilea_digit] + " sute " 

if treilea_digit > 1:
    temp_str = temp_str + douazeci_nouazeci[treilea_digit] + " si "
if treilea_digit == 1:
    temp_str = temp_str + unsprezece_nouasprezece[patrulea_digit] + " "
else:
    if patrulea_digit:
        temp_str = temp_str + unu_zece[patrulea_digit] + " "
if temp_str[-1] == " ": # Daca ultimul digit e spatiu
    temp_str = temp_str[0:-1] # sterge spatiul
print (temp_str)