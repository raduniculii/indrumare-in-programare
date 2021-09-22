#Imports
import pygame, sys
from pygame.locals import *
import random, time

def noop(): pass #"no operation" function 

KeyDownHanders = {
    "up": noop
    , "right": noop
    , "down": noop
    , "left": noop
}

ScreenBlocks = []
i = 0
while i < 10:
    ScreenBlocks.append([])
    j = 0
    while j < 20:
        ScreenBlocks[i].append(False)
        j += 1
    
    i += 1;

myX = 1
myY = 1

def TurnOn(col, row):
    ScreenBlocks[col - 1][row - 1] = True

def TurnOff(col, row):
    ScreenBlocks[col - 1][row - 1] = False

def IsOn(col, row):
    return ScreenBlocks[col - 1][row - 1]

def startGame():
    #Initialzing 
    pygame.init()

    #Setting up FPS 
    FPS = 60
    FramePerSec = pygame.time.Clock()

    #Creating colors
    BLUE  = (0, 0, 255)
    RED   = (255, 0, 0)
    GREEN = (0, 255, 0)
    BLACK = (0, 0, 0)
    WHITE = (255, 255, 255)

    #Other Variables for use in the program
    SCREEN_WIDTH = 249
    SCREEN_HEIGHT = 309
    SPEED = 5
    SCORE = 0

    #Setting up Fonts
    font = pygame.font.SysFont("Verdana", 60)
    font_small = pygame.font.SysFont("Verdana", 20)
    game_over = font.render("Game Over", True, BLACK)

    background_off = pygame.image.load("resurse/imagini/ScreenOff.bmp")
    background_full = pygame.image.load("resurse/imagini/ScreenOnLcdOn.bmp")
    background = pygame.image.load("resurse/imagini/ScreenOn.bmp")

    squareOnImage = pygame.image.load("resurse/imagini/SquareOn.bmp")

    #Create a white screen 
    DISPLAYSURF = pygame.display.set_mode((SCREEN_WIDTH,SCREEN_HEIGHT))
    DISPLAYSURF.blit(background, (0,0))
    pygame.display.set_caption("Game")


    SQUARE_SIZE = 14
    SPACING = 1

    #Adding a new User event 
    INC_SPEED = pygame.USEREVENT + 1
    EVT_CHECK_KEY = pygame.USEREVENT + 2
    EVT_MOVE = pygame.USEREVENT + 3
    #pygame.time.set_timer(INC_SPEED, 1000)
    pygame.time.set_timer(EVT_CHECK_KEY, 100)
    pygame.time.set_timer(EVT_MOVE, 700)

    #Game Loop
    while True:
        #Cycles through all events occuring  
        for event in pygame.event.get():
            if event.type == INC_SPEED:
                SPEED += 0.5
                #if SPEED == 10:
                    #pygame.mixer.music.load("Our-Mountain_v003.mp3")#REPLACE
                    #pygame.mixer.music.play(-1,0.0)
            if event.type == EVT_MOVE:
                pass
            if event.type == EVT_CHECK_KEY:
                if pressed_keys[K_UP]:
                    KeyDownHanders["up"]()
                elif pressed_keys[K_DOWN]:
                    KeyDownHanders["down"]()
                elif pressed_keys[K_LEFT]:
                    KeyDownHanders["left"]()
                elif pressed_keys[K_RIGHT]:
                    KeyDownHanders["right"]()
            if event.type == QUIT:
                pygame.quit()
                sys.exit()
        
        pressed_keys = pygame.key.get_pressed()

        if pressed_keys[K_ESCAPE]:
            pygame.quit()
            sys.exit()

        DISPLAYSURF.blit(background, (0,0))
        for colIx, col in enumerate(ScreenBlocks):
            for rowIx, cell in enumerate(col):
                if cell:
                    DISPLAYSURF.blit(squareOnImage, (5 + colIx * (SQUARE_SIZE + SPACING), (5 + rowIx * (SQUARE_SIZE + SPACING))))
            
        pygame.display.update()
        FramePerSec.tick(FPS)
