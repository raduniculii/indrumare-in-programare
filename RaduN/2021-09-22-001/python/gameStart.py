#Imports
import pygame, sys
from pygame.locals import *
import random, time
from constants import *

###############################################
###############################################
####                                        ###
####      Asta nu e ca sa il schimbati voi, ###
####    e ca sa va ascunda codul care cred  ###
####    ca v-ar fi dificil deocamdata.      ###
####      Uitati-va si modificati linistiti ###
####    daca vreti, dar "tema" e in test.py ###
####                                        ###
####                                        ###
####                                        ###
####                                        ###
####                                        ###
###############################################
###############################################

def startGame(KeyDownHandler):
    #Initialzing 
    pygame.init()

    #declaram o matrice bidimensionala de 20 x 10
    ScreenBlocks = [[0 for y in range(ROWS)] for x in range(COLUMNS)]

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
    background_on = pygame.image.load("resurse/imagini/ScreenOn.bmp")

    background = background_off

    squareOnImage = pygame.image.load("resurse/imagini/SquareOn.bmp")

    #Create a white screen 
    DISPLAYSURF = pygame.display.set_mode((SCREEN_WIDTH,SCREEN_HEIGHT))
    DISPLAYSURF.blit(background, (0,0))
    pygame.display.set_caption("Game")


    SQUARE_SIZE = 14
    SPACING = 1

    #Adding a new User event 
    INC_SPEED = pygame.USEREVENT + 1
    EVT_MOVE = pygame.USEREVENT + 3
    EVT_SCREEN_ON = pygame.USEREVENT + 4
    EVT_SCREEN_READY = pygame.USEREVENT + 5
    EVT_START_MUSIC_DONE = pygame.USEREVENT + 6
    #pygame.time.set_timer(INC_SPEED, 1000)
    pygame.time.set_timer(EVT_SCREEN_ON, 500, loops=1)
    pygame.time.set_timer(EVT_SCREEN_READY, 1000, loops=1)

    # pygame.mixer.music.load("resurse/sunete/Brick_Game_8_in_1_Song01.mp3")
    # pygame.mixer.music.set_volume(0.05)
    # pygame.mixer.music.play(0, 0.0)
    # pygame.mixer.music.set_endevent(EVT_START_MUSIC_DONE)

    pygame.key.set_repeat(50, 100)
    keyToProcess = KEY_OTHER

    #Game Loop
    while True:
        #Cycles through all events occuring
        
        pressed_keys = pygame.key.get_pressed()
        for event in pygame.event.get():
            if event.type == INC_SPEED:
                SPEED += 0.5
            if event.type == EVT_MOVE:
                pass
            if event.type == EVT_START_MUSIC_DONE:
                print("music done")
            if event.type == EVT_SCREEN_ON:
                print("screen on - background full")
                background = background_full
            if event.type == EVT_SCREEN_READY:
                print("screen ready")
                background = background_on
                pygame.time.set_timer(EVT_MOVE, 200)
            if event.type == KEYDOWN:
                if pressed_keys[K_UP]:
                    keyToProcess = KEY_ARROW_UP
                elif pressed_keys[K_DOWN]:
                    keyToProcess = KEY_ARROW_DOWN
                elif pressed_keys[K_LEFT]:
                    keyToProcess = KEY_ARROW_LEFT
                elif pressed_keys[K_RIGHT]:
                    keyToProcess = KEY_ARROW_RIGHT
                elif pressed_keys[K_SPACE]:
                    keyToProcess = KEY_SPACE
                
                KeyDownHandler(keyToProcess, ScreenBlocks)
                keyToProcess = KEY_OTHER
                
            if event.type == QUIT:
                pygame.quit()
                sys.exit()

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
