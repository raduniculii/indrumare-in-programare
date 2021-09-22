
listaDeNumere = []

listaDeNumere.append(1)
listaDeNumere.append(2)
listaDeNumere.append(4)


# Ex 1, afiseaza sum,a numerelor
print (listaDeNumere[0] + listaDeNumere[1] + listaDeNumere[2])
# Ex. 2, afiseaza media numerelor
print ((listaDeNumere[0] + listaDeNumere[1] + listaDeNumere[2]) / 4)



#4. Un program care sa zica la ce index avem un anumit nume in lista, sau daca nu e gasit sa afiseze "nu am gasit" si sa planga 10 minute.
nume = []
nume = ["Alina", "Mihai", "Elena", "George"]

index = nume.index("Mihai")
print (f"Mihai este la index {index}")