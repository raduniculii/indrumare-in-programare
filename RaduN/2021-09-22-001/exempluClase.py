class Color: #astea sunt "statice", adica le folosesti direct de pe color.XXX
   PURPLE = '\033[95m'
   CYAN = '\033[96m'
   DARKCYAN = '\033[36m'
   BLUE = '\033[94m'
   GREEN = '\033[92m'
   YELLOW = '\033[93m'
   RED = '\033[91m'
   BOLD = '\033[1m'
   UNDERLINE = '\033[4m'
   END = '\033[0m'

   def redText(text): #tot "statica" pt ca nu e cu self in ea!
       return Color.RED + text + Color.END

#echivalent cu:
# print("normal " + color.RED + "important" + color.END + " si iar normal")
print("normal " + Color.redText("important") + " si iar normal")

class Fractie: #o clasa e un tip de date facuta de noi.
    def __init__(self, num, numit):
        # numarator / numitor
        self.numarator = num
        self.numitor = numit
        print("Constructor " + self.ToString())
    def Aduna(self, fr):
        print("Adun " + self.ToString())
        if self.numitor != fr.numitor:
            raise("numitor diferit")
        return Fractie(self.numarator + fr.numarator, self.numitor)
    def ToString(self):
        return str(self.numarator) + "/" + str(self.numitor)
    def Clone(self):
        return Fractie(self.numarator, self.numitor)

print(Color.CYAN + "hey" + Color.END + " text normal din nou")

fr1 = Fractie(3, 5) # 3/5 ... denumirea oficiala e initializare; fr1 e acum un "obiect" de tipul clasei Fractie
fr2 = Fractie(2, 5) # 2/5

print("am facut fr1 si fr2")

print(fr1.ToString())
print(fr2.ToString())

fr3 = fr1.Aduna(fr2)
print(fr3.ToString())

print("----------------------------")
fr1.numarator = 4
print(fr1.ToString())
fr4 = fr1 #primeste NU VALOAREA ci REFERINTA catre obiectul din fr1
print("fr4 = " + fr4.ToString())
fr1.numarator = 5
print("fr1 = " + fr1.ToString())
print("fr4 = " + fr4.ToString())
fr4.numitor = 2
print("fr1 = " + fr1.ToString())
print("fr4 = " + fr4.ToString())
fr1 = fr2
print("..fr1 = " + fr1.ToString())
print("..fr4 = " + fr4.ToString())
print("----------------------------")

a = 3
print("a = " + str(a))
b = a #var b primeste VALOAREA lui a, pentru ca int e un tip prin valoare, ca si restul de tipuri de baza
print("b = " + str(b))
a = 4 # tipurile prin valoare sun immutable (adica nu pot fi mutate/schimbate)
print("a = " + str(a))
print("b = " + str(b))
#---------------------------------------------------
# 010101010101 memorie 4*1024M=4*1024*1024Kb=4*1024*1024*1024b 00000000 4Gb = 4,294,967,296 - 00000000=1byte
# 8 => 1000 => 4 bytes (32 bits) la adresa de memorie 19238713 sunt variabila A
# a = 25 .... merge la adresa de memorie unde e tinut a, si scrie acolo reprezentarea lui 25
# fr1 .... adresa de memorie [..... toate QQA proprietatile ... ]
# fr4 = fr1 lui fr4 ii da ACEEASI ADRESA pe care o avea fr1
# fr1 = fr2, fr1 primeste adresa lui fr2 si se va uita in memorie la fr2, fr4 a ramas catre adresa pe care o avea
#
# avem 2 fisiere excel in primul avem cheltuielile personale -> personale.xls
# in cel de-al doilea avem cheltuielile de munca -> munca.xls
# create shortcut -> personale.xls -> personale.xls.lnk
# *2 .... personale.xls(2).lnk
# munca.xls... munca.xls.lnk + rename personale.xls.lnk dar tot la munca xls te duce

def DaFractiePutinMaiMare(fr):
    #fr = Fractie(fr.numarator + 1, fr.numitor) #ok
    fr.numarator = fr.numarator + 1 #not OK
    return fr

fr5 = Fractie(7, 10)
print(fr5.ToString())

fr6 = DaFractiePutinMaiMare(fr5.Clone())

print(fr6.ToString())
print(fr5.ToString())
