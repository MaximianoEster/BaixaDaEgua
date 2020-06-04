import pygame
import random
from pygame import *

pygame.init()

telaw = 1280
telah = 720

x1 = 0
y1 = 0

screen = pygame.display.set_mode((telaw, telah))

mula1 = pygame.image.load("mula.png")
boss_tiro = pygame.image.load("tiro_boss.png")

boss_tiro1 = pygame.transform.scale(boss_tiro, (70, 70))
mula = pygame.transform.scale(mula1, (2000, 1200))

boss = {"pos": [telaw - 400,telah*.517],
        "life": 1000,
        "velX": 20,
        "velY": 0,
        "state": "right_stop",
        "right_stop": [0],
        "left_stop": [19],
        "right_run": [0,0,0,0, 1,1,1,1, 2,2,2,2, 3,3,3,3, 4,4,4,4],
        "left_run": [19,19,19,19 ,18,18,18,18, 17,17,17,17, 16,16,16,16, 15,15,15,15],
        "frame_index": 0,
        }

move = {"pos": [100,500],
        "velX":0,
        "velY": 0,
        "state": "left",
        "left": 0,
        "right": 1,
        "left_stop" :2,
        "right_stop":3
        }

cont_ataque_boss = 0
lista_ataque = []
can_ataque = True
ataque = 0
count = 500
ataque3 = 0
ataqueb3 = False

def get_frame( gId , imagem):
    top = 0
    margin = 0
    space_h = 0
    space_v = 0
    width = 400
    height = 300
    columns = 5
    coluna = gId % columns
    linha = int(gId / columns)
    x = margin + (coluna * (width + space_h))
    y = top + (linha * (height + space_v))
    img = imagem.subsurface(x, y, width, height)
    return img

def anima( obj , imagem):
    global tela
    chave = obj["state"]
    frames = obj[chave]
    obj["frame_index"] += 1
    if obj["frame_index"] >= len(frames) - 1:
        obj["frame_index"] = 0
    gId = frames[obj["frame_index"]]
    sur_frame = get_frame(gId, imagem)
    screen.blit(sur_frame, obj["pos"])

def movimenta(obj):
    obj['x'] = obj['x'] + obj['velX']
    obj['y'] = obj['y'] + obj['velY']

def movimenta2(obj):
    obj['pos'][0] = obj['pos'][0]  + obj['velX']
    obj['pos'][1] = obj['pos'][1]  + obj['velY']

def pintar( scr, obj ):
    scr.blit(obj['imagem'], (obj['x'], obj['y']))

def ataque_boss_1(obj):
    global cont_ataque_boss, telaw, x1
    if obj["life"] > 600:
        if obj["pos"][0] > telaw - 400:
            obj["pos"][0] = telaw - 400
            obj["state"] = "left_stop"
            if cont_ataque_boss > count:
                obj["velX"] = -10
                obj["state"] = "left_run"
                cont_ataque_boss = 0

        elif obj["pos"][0] < 0:
            obj["pos"][0] = 0
            obj["state"] = "right_stop"
            if cont_ataque_boss > count:
                obj["velX"] = 10
                cont_ataque_boss = 0
                obj["state"] = "right_run"

def ataque_boss_2(obj, img, obj2):
    global cont_ataque_boss, lista_ataque, screen, can_ataque, ataque

    x = 0
    y = 70

    if obj["state"] == "right_stop" or obj["state"] == "right_run":
        x = 200
        # lim1 = 350
        # lim2 = telaw

    elif obj["state"] == "left_stop" or obj["state"] == "left_run":
        x = 60
        # lim1 = 0
        # lim2 = telaw - 350

    if obj["life"] <= 600 and obj["life"] > 301 :
        if can_ataque == True and ataque > 85 and ataque < 185:
            bola = {"x": obj["pos"][0] + x , "y": obj["pos"][1] + y, "velY": -1, "velX": 0, "imagem":img}
            bola["velY"] = - (random.randint(15, 25))
            lista_ataque.append(bola)

        if obj["pos"][0] > telaw - 400:
            obj["pos"][0] = telaw - 400
            obj["state"] = "left_stop"
            can_ataque = True
            if cont_ataque_boss > count:
                can_ataque = False
                obj["velX"] = -10
                obj["state"] = "left_run"
                cont_ataque_boss = 0

        elif obj["pos"][0] < 0:
            obj["pos"][0] = 0
            obj["state"] = "right_stop"
            can_ataque = True
            if cont_ataque_boss > count:
                can_ataque = False
                obj["velX"] = 10
                cont_ataque_boss = 0
                obj["state"] = "right_run"

    for bola in lista_ataque:
        pintar(screen, bola)
        if bola["y"] < -(random.randint(1000, 2200)):
            bola["velY"] = random.randint(5, 15)
            bola["x"] = random.randint(5, telaw - 75)
        if bola["y"] >= telah + 100:
            lista_ataque.remove(bola)
    for bola in lista_ataque:
        movimenta(bola)

    for bolo in lista_ataque:
        bolorect = bolo["imagem"].get_rect()
        boloreco = Rect((bolo["x"], bolo["y"]),(bolorect.w, bolorect.h))
        if boloreco.colliderect(obj2):
            lista_ataque.remove(bolo)
            print("Oe")

def ataque_boss_3(obj):
    global cont_ataque_boss, move, ataque3, ataqueb3, telah, telaw

    ataqueb3 = True
    if obj["life"] <= 300 and cont_ataque_boss > count:
        obj["velX"] = 0
        obj["pos"][1] = telah*.05
        obj["pos"][0] = move["pos"][0] - 150
        if obj["pos"][1] <= telah*.15:
            obj["velY"] = 0
        cont_ataque_boss = 0
        ataque3 = 0
        telaw += 5

        if move["pos"][0] >= telah/2:
            obj["state"] = "right_stop"

        if move["pos"][0] <= telah/2:
            obj["state"] = "left_stop"

    # if obj["life"] <= 300 and cont_ataque_boss > count:
    #     obj["velY"] -= 1
    #     if move["pos"][0] >= telaw/2:
    #         obj["velX"] = 1
    #     elif move["pos"][0] <= telaw/2:
    #         obj["velX"] = -1
    #     if obj["pos"][1] <= telah*.15:
    #         obj["velY"] = 0
    #         obj["velX"] = 0
    #     if cont_ataque_boss < count:
    #         obj["velX"] = 0

    if obj["pos"][1] < (telah * .1) and ataque3 > 100:
        obj["velY"] += 10

def boss_regras(obj):
    global telah

    move["velY"] += 1
    obj["pos"][0] = obj["pos"][0] + obj["velX"]
    obj["pos"][1] = obj["pos"][1] + obj["velY"]

    if  ataqueb3 == False:
        obj["velY"] += 1

    if obj["pos"][1] >= (telah - (telah * .517)):
        obj["pos"][1] = (telah - (telah * .517))
        obj["velY"] = 0

    if move["pos"][1] >= (telah - (telah * .317)):
        move["pos"][1] = (telah - (telah * .317))
        move["velY"] = 0

cor = (0,0,0)
touch = False
teste_ra = 0

while True:
    cont_ataque_boss += 1
    boss["life"] -= .2
    screen.fill(cor)
    reco = pygame.draw.rect(screen, (255,255,255), ((boss["pos"][0], boss["pos"][1]), (400,300)))
    tela = pygame.draw.rect(screen, (255,0,0), ((x1, y1),(1280, 720)))

    if boss["life"] < 600:
        ataque += 1
        if ataque > 500:
            ataque = 0
            can_ataque = True

    if boss["life"] < 300:
        count = 300
        ataque3 += 1

    movimenta2(move)
    c1 = pygame.draw.rect(screen, (0,0,0), ((move["pos"][0], move["pos"][1]),(150,150)))

    anima(boss, mula)
    boss_regras(boss)
    ataque_boss_1(boss)
    ataque_boss_2(boss, boss_tiro1, c1)
    ataque_boss_3(boss)

    for e in pygame.event.get():
        if e.type == QUIT:
            exit()

        if e.type == KEYDOWN:
            if e.key == K_RIGHT:
                move["velX"] = 5
                move["state"] = "right"
            if e.key == K_LEFT:
                move["velX"] = -5
                move["state"] = "left"
            if e.key == K_SPACE:
                move["velY"] = -30

        if e.type == KEYUP:
            if e.key == K_RIGHT:
                move["velX"] = 0
                move["state"] = "right_stop"
            if e.key == K_LEFT:
                move["velX"] = 0
                move["state"] = "left_stop"