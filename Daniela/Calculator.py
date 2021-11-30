#1. Calculator
#Add
def add(n1, n2):
    return n1 + n2
#Subtract
def subtract(n1, n2):
    return n1 - n2
#Multiply
def multiply(n1, n2):
    return n1 * n2
#Divide
def divide(n1, n2):
    return n1 / n2

#2. Functie cu trei parametri care sa returneze maximul

def maxim(nr1, nr2, nr3):
    numere = input("Scrie 3 numere, te rog. Ex: 2, 5, 9")
    for x in numere:
        if nr1>=nr2&nr3:
            return nr1
        elif nr2>=nr1&nr3:
            return nr2
        else: 
            return nr3
print(maxim())


#3. Functie cu un parametru, care sa returneze patratul argumentului

#4. Functie cu un parametru care sa afiseze pe consola mesajul: 
# "Simon says: " urmat de mesajul pe care l-a primit ca argument la 
# apel.