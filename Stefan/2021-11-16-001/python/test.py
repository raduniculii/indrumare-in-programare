#Importam toate constantele, cum ar fi codurile tastelor din program si ROWS si COLUMNS
from constants import *
#importam functia startGame din gameStart.py
from gameStart import startGame
import pygame, sys, random
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



wormXCoord = []
wormYCoord = []
dirY = -1 # -1, 0, +1
dirX = 0 # -1, 0, +1
pointX = 0
pointY = 0

randomIndex = 2
def randomX():
    global randomIndex
    if randomIndex < len(wormXCoord) + 2:
        randomIndex +=1
        return wormXCoord [(randomIndex - 1) % len(wormXCoord)] 
    else:
        return random.randint(0, COLUMNS - 1)

def randomY():
    global randomIndex
    if randomIndex < len(wormYCoord) + 2:
        randomIndex +=1
        return wormYCoord [(randomIndex - 1) % len(wormYCoord)]
    else:
        return random.randint(0, ROWS - 1)

def showNewPoint(blocks):
    global pointX, pointY
    blocks[pointX][pointY] = False
    resetPoint = True
    while resetPoint:
        pointX = randomX()
        pointY = randomY()
        resetPoint = False
        for i in range (0,len(wormXCoord)):
            x = wormXCoord[i]
            y = wormYCoord[i]
            if  pointX == x and pointY ==y:
                resetPoint = True

def resetWorm(blocks):
    global wormXCoord, wormYCoord
    wormXCoord = [5,5,5,5]
    wormYCoord = [8,9,10,11]

    showNewPoint(blocks)


def DrawWorm(IsOn,blocks):
    for i in range(0,len(wormXCoord)):
        x = wormXCoord[i]
        y = wormYCoord[i]
        blocks[x][y] = IsOn

def keyDownHandler(key, blocks):
    global dirY, dirX
    
    if(key == KEY_ARROW_UP):
        dirY = -1
        dirX = 0
    elif(key == KEY_ARROW_RIGHT):
        dirY = 0
        dirX = +1
    elif(key == KEY_ARROW_DOWN):
        dirY = +1
        dirX = 0
    elif(key == KEY_ARROW_LEFT):
        dirY = 0
        dirX = -1
    elif(key == KEY_SPACE):
        pass

speed_in_intervals = 25
intervalsSoFar = 0

lifeCount = 3
gameStarted = False

def timerTick(blocks):
    global intervalsSoFar, pointX, pointY, gameStarted
    blocks[pointX][pointY] = True

    if not gameStarted:
        resetWorm(blocks)
        gameStarted = True
    if intervalsSoFar == 0:
        global wormXCoord, wormYCoord
        global dirY, dirX, lifeCount
        newX = wormXCoord[0] + dirX
        newY = wormYCoord[0] + dirY
        
        DrawWorm(False,blocks)

        if not(0 <= newX < COLUMNS and 0 <= newY < ROWS) or (newX == wormXCoord[1] and newY == wormYCoord[1]):
            resetWorm(blocks) 
            lifeCount -= 1   
            dirX = 0
            dirY = -1     

        if lifeCount <= 0:
            sys.exit()

        #remove last block
        wormXCoord.pop() 
        wormYCoord.pop()
        
        #insert a new block at the beginning, using the new position for it based on dirX and dirY
        wormXCoord.insert(0, newX)
        wormYCoord.insert(0, newY)

        DrawWorm(True,blocks)

    intervalsSoFar += 1
    if intervalsSoFar >= speed_in_intervals:
        intervalsSoFar = 0

#aici chemam startGame si ii zicem sa ne cheme functia noastra "keyDownHandler"
#cand are ceva sa ne comunice
startGame(keyDownHandler, timerTick)