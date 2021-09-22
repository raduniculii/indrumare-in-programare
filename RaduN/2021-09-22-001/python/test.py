#Importam toate constantele, cum ar fi codurile tastelor din program si ROWS si COLUMNS
from constants import *
#importam functia startGame din gameStart.py
from gameStart import startGame

#definite doar in test.py, le puteti denumi cum vreti voi si sa faceti si 100 daca vreti
myX = 0
myY = 0

#metoda definita doar aici si o dam ca argument lui "startGame", care o va chema
#cand are treaba, de ex. cand userul apasa tastele definite.
#"startGame", cand o cheama, ii da ca primul argument codul tastei apasate,
#cum a fost definit in constants.py, si in al doilea argument ii da o matrice
#cu 2 dimensiuni, adica o lista de liste, blocks. Ea contine doar True pentru
#patratelele care sunt aprinse si false pentru cele stinse. La inceput toate
# sunt False (stinse); blocks[0][0] e celula din stanga sus, blocks[0][3] e
# celula din stanga de tot (prima coloana) si randul 4 de sus. Tineti minte ca
# la matrici toti indecsii sunt cu 1 mai mici decat in vorbirea uzuala. Incep de
# la 0 si se termina la N-1, unde N era numarul de elemente.
#In cazul nostru avem 0..9 coloane si 0..19 randuri
def keyDownHandler(key, blocks):
    #facem referire la cele definite in afara functiei, nu definim altele
    global myX, myY

    blocks[myX][myY] = False

    if(key == KEY_ARROW_UP):
        myY = max(myY - 1, 0)
    elif(key == KEY_ARROW_RIGHT):
        myX = min(myX + 1, COLUMNS - 1)
    elif(key == KEY_ARROW_DOWN):
        myY = min(myY + 1, ROWS - 1)
    elif(key == KEY_ARROW_LEFT):
        myX = max(myX - 1, 0)
    elif(key == KEY_SPACE):
        print("space")#nothign else yet...

    blocks[myX][myY] = True

#aici chemam startGame si ii zicem sa ne cheme functia noastra "keyDownHandler"
#cand are ceva sa ne comunice
startGame(keyDownHandler)