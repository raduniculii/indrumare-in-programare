def adunaLista(lista):
    index = 0
    sum = 0
    while(index < len(lista)):
        sum += lista[index]  # <=> sum = sum + lista[index]
        index += 1 # <=> index = index + 1
    
    return sum

def patrat(nr):
    return nr * nr

def adunaPatrateleDinLista(lista):
    index = 0
    sum = 0
    while(index < len(lista)):
        sum += patrat(lista[index])  # <=> sum = sum + lista[index]
        index += 1 # <=> index = index + 1
    
    return sum

lst = [1, 2, 4]

print(f"Suma numerelor {lst} este {adunaLista(lst)}")
lst.append(12)
print(f"Suma numerelor {lst} este {adunaLista(lst)}")

nrTest = 2
print(f"Patratul lui {nrTest} este: {patrat(nrTest)}")
nrTest = 9
print(f"Patratul lui {nrTest} este: {patrat(nrTest)}")

lst = [1, 2]

print(f"Suma patratelor numerelor {lst} este {adunaPatrateleDinLista(lst)}")
lst.append(4)
print(f"Suma patratelor numerelor {lst} este {adunaPatrateleDinLista(lst)}")


listaNoua = [2, 3, 4, 5, 6, 7, 8] #list(range(2, 8))
print(listaNoua)
listaDePatrate = list(map(lambda x: x * x, listaNoua))

print(listaDePatrate)
print(adunaLista(listaDePatrate))

#lambda element: patrat(element)
#def myAnonymousFunction(element):
#   return patrat(element)
