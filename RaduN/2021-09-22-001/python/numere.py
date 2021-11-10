import sys

numar = int(sys.argv[1])

listaCifre = ["zero", "unu", "doi", "trei", "patru", "cinci", "sase", "sapte", "opt", "noua"]

if numar < 10 and numar >= 0:
    print(listaCifre[numar])

#https://numar-text.calculators.ro/numerele-cardinale-reguli-de-scriere-din-cifre-in-cuvinte-cu-litere.php

print(numar // 10)
print(numar // 100)
print(numar // 1000)

print((numar // 1 ) % 10)
print((numar // 10 ) % 10)
print((numar // 100 ) % 10)
print((numar // 1000 ) % 10)
print((numar // 10000 ) % 10)


#print("doisprezece mii trei sute patruzeci si cinci")
