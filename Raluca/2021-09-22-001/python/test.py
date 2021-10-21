#Importam toate constantele, cum ar fi codurile tastelor din program si ROWS si COLUMNS
from constants import *
#importam functia startGame din gameStart.py
from gameStart import startGame

#definite doar in test.py, le puteti denumi cum vreti voi si sa faceti si 100 daca vreti
# myX = 0
# myY = 0

# #metoda definita doar aici si o dam ca argument lui "startGame", care o va chema
# #cand are treaba, de ex. cand userul apasa tastele definite.
# #"startGame", cand o cheama, ii da ca primul argument codul tastei apasate,
# #cum a fost definit in constants.py, si in al doilea argument ii da o matrice
# #cu 2 dimensiuni, adica o lista de liste, blocks. Ea contine doar True pentru
# #patratelele care sunt aprinse si false pentru cele stinse. La inceput toate
# # sunt False (stinse); blocks[0][0] e celula din stanga sus, blocks[0][3] e
# # celula din stanga de tot (prima coloana) si randul 4 de sus. Tineti minte ca
# # la matrici toti indecsii sunt cu 1 mai mici decat in vorbirea uzuala. Incep de
# # la 0 si se termina la N-1, unde N era numarul de elemente.
# #In cazul nostru avem 0..9 coloane si 0..19 randuri
# def keyDownHandler(key, blocks):
#     #facem referire la cele definite in afara functiei, nu definim altele
#     global myX, myY

#     blocks[myX][myY] = False

#     if(key == KEY_ARROW_UP):
#         myY = max(myY - 1, 0)
#     elif(key == KEY_ARROW_RIGHT):
#         myX = min(myX + 1, COLUMNS - 1)
#     elif(key == KEY_ARROW_DOWN):
#         myY = min(myY + 1, ROWS - 1)
#     elif(key == KEY_ARROW_LEFT):
#         myX = max(myX - 1, 0)
#     elif(key == KEY_SPACE):
#         print("space")#nothign else yet...

#     blocks[myX][myY] = True

wormXCoord = [0,1,2,3]
wormYCoord = [0,1,2,3]

def DrawWorm(IsOn,blocks):
    for i in range(0,len(wormXCoord)):
        x = wormXCoord[i]
        y = wormYCoord[i]
        blocks[x][y] = IsOn

def MoveWorm():
    wormXCoord.pop() 
    wormYCoord.pop()
    wormXCoord.insert(0,wormXCoord[0]) 
    wormYCoord.insert(0,wormYCoord[0]) 

def keyDownHandler(key, blocks):
    
    global wormXCoord, wormYCoord
    
    DrawWorm(False,blocks)

    if(key == KEY_ARROW_UP):
        MoveWorm()
        #wormYCoord[0] = max(wormYCoord[0] - 1, 0)
        wormYCoord[0] = (wormYCoord[0] - 1 + ROWS)%ROWS

    elif(key == KEY_ARROW_RIGHT):
        MoveWorm()
        wormXCoord[0] = min(wormXCoord[0] + 1, COLUMNS - 1)
    elif(key == KEY_ARROW_DOWN):
        MoveWorm()
        #wormYCoord[0] = min(wormYCoord[0] + 1, ROWS - 1)
        wormYCoord[0] = (wormYCoord[0] + 1 + ROWS)%ROWS
    elif(key == KEY_ARROW_LEFT):
        MoveWorm()
        wormXCoord[0] = max(wormXCoord[0] - 1, 0)
    elif(key == KEY_SPACE):
        MoveWorm()
        print("space")#nothign else yet...

    DrawWorm(True,blocks)
       

#aici chemam startGame si ii zicem sa ne cheme functia noastra "keyDownHandler"
#cand are ceva sa ne comunice
startGame(keyDownHandler)