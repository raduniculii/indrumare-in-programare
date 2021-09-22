#Imports
import pygame, sys
from pygame.locals import *
import random, time
from gameStart import *


TurnOn(myX, myY)

def upKeyFc():
    global myX, myY
    TurnOff(myX, myY)
    myY = max(myY - 1, 1)
    TurnOn(myX, myY)

def downKeyFc():
    global myX, myY
    TurnOff(myX, myY)
    myY = min(myY + 1, 20)
    TurnOn(myX, myY)

def leftKeyFc():
    global myX, myY
    TurnOff(myX, myY)
    myX = max(myX - 1, 1)
    TurnOn(myX, myY)

def rightKeyFc():
    global myX, myY
    TurnOff(myX, myY)
    myX = min(myX + 1, 10)
    TurnOn(myX, myY)


KeyDownHanders["up"] = upKeyFc
KeyDownHanders["right"] = rightKeyFc
KeyDownHanders["down"] = downKeyFc
KeyDownHanders["left"] = leftKeyFc

startGame()