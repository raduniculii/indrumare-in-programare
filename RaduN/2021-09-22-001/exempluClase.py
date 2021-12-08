class color: #astea sunt "statice", adica le folosesti direct de pe color.XXX
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
       return color.RED + text + color.END

#echivalent cu:
# print("normal " + color.RED + "important" + color.END + " si iar normal")
print("normal " + color.redText("important") + " si iar normal")

class Fractie: #o clasa e un tip de date facuts de noi.
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

print(color.CYAN + "hey" + color.END + " text normal din nou")

fr1 = Fractie(3, 5) # 3/5 ... denumirea oficiala e initializare; fr1 e acum un "obiect" de tipul clasei Fractie
fr2 = Fractie(2, 5) # 2/5

print("am facut fr1 si fr2")

print(fr1.ToString())
print(fr2.ToString())

fr3 = fr1.Aduna(fr2)
print(fr3.ToString())
