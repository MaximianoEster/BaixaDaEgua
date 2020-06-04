import pygame
import random
from pygame import *
import time

pygame.init()

# tela e imagens
tela_w = 1280
tela_h = 720

screen = pygame.display.set_mode((tela_w, tela_h), 0, 32)
pygame.display.set_caption("BAIXA DA ÉGUA")

text11 = pygame.image.load("./tutorial/1_pt.png")
text21 = pygame.image.load("./tutorial/2_pt.png")
text31 = pygame.image.load("./tutorial/3_pt.png")
text41 = pygame.image.load("./tutorial/4_pt.png")
text51 = pygame.image.load("./tutorial/5_pt.png")
text61 = pygame.image.load("./tutorial/6_pt.png")
text1_I1 = pygame.image.load("./tutorial/e_1.png")
text2_I1 = pygame.image.load("./tutorial/e_2.png")
text3_I1 = pygame.image.load("./tutorial/e_3.png")
text4_I1 = pygame.image.load("./tutorial/e_4.png")
text6_I1 = pygame.image.load("./tutorial/e_5.png")

text1 = pygame.transform.scale(text11, (tela_w, tela_h))
text2 = pygame.transform.scale(text21, (tela_w, tela_h))
text3 = pygame.transform.scale(text31, (tela_w, tela_h))
text4 = pygame.transform.scale(text41, (tela_w, tela_h))
text5 = pygame.transform.scale(text51, (tela_w, tela_h))
text6 = pygame.transform.scale(text61, (tela_w, tela_h))
text1_I = pygame.transform.scale(text1_I1, (tela_w, tela_h))
text2_I = pygame.transform.scale(text2_I1, (tela_w, tela_h))
text3_I = pygame.transform.scale(text3_I1, (tela_w, tela_h))
text4_I = pygame.transform.scale(text4_I1, (tela_w, tela_h))
text6_I = pygame.transform.scale(text6_I1, (tela_w, tela_h))

fundo1 = pygame.image.load("./tutorial/fiundo.png")
fundo = pygame.transform.scale(fundo1, (tela_w, tela_h))

tutorial1 = pygame.image.load("./tutorial/sprites_tutorial.png")
tutorial = pygame.transform.scale(tutorial1, ((tela_w*4),(tela_h*2)))

mula = pygame.image.load("Mula.png")
boss_tiro_1 = pygame.image.load("tiro_boss.png")
boss_tiro_2 = pygame.image.load("tiro_boss_1.png")

boss_tiro1 = pygame.transform.scale(boss_tiro_1, (33,62))
boss_tiro2 = pygame.transform.scale(boss_tiro_2, (33,62))

cenario = pygame.image.load('cenario ofcial.jpg')
sprite_sheet = pygame.image.load("sprites_maria.PNG")
esqueleeeto = pygame.image.load("sprites_esqueletos.PNG")
tiro = pygame.image.load('tiro.PNG')
play1 = pygame.image.load('jogar_oficial.PNG')
opcoes = pygame.image.load('configuracoes_oficial.PNG')
cabeca = pygame.image.load('cabeca_maria.PNG')
menu_tela = pygame.image.load('menu.jpg')
portugues = pygame.image.load("BandeiraBR.png")
ingles = pygame.image.load("BandeiraEU.png")
fechando2 = pygame.image.load("sair_oficial.png")
fundo_esc1 = pygame.image.load("fundo_esc.png")

intro1 = pygame.image.load("intro.jpg")
intro = pygame.transform.scale(intro1, (401, 640))

gme_over1 = pygame.image.load("gameover.jpg")
gme_over = pygame.transform.scale(gme_over1, (tela_w, tela_h))

opcoes2 = pygame.transform.scale(opcoes, (int(tela_w/7), int(tela_h/8)))
opcoes3 = pygame.transform.scale(opcoes, (int(tela_w/6.5), int(tela_h/7.5)))

fechando3 = pygame.transform.scale(fechando2, (int(tela_w/10), int(tela_h/8)))
fechando4 = pygame.transform.scale(fechando2, (int(tela_w/9), int(tela_h/7)))

play = pygame.transform.scale(play1, (int(tela_w/9.5), int(tela_h/7.5)))
play2 = pygame.transform.scale(play1, (int(tela_w/9), int(tela_h/7)))

continu1 = pygame.image.load("continue.jpg")
continu = pygame.transform.scale(continu1, (int(tela_w/9), int(tela_h/7)))
continu2 = pygame.transform.scale(continu1, (int(tela_w/8.5), int(tela_h/6.5)))

saindo_menu_1 = pygame.image.load("menu.png")
saindo_menu = pygame.transform.scale(saindo_menu_1, (int(tela_w/9), int(tela_h/7)))
saindo_menu2 = pygame.transform.scale(saindo_menu_1, (int(tela_w/8.5), int(tela_h/6.5)))

again1 = pygame.image.load("joagr_novamente.png")
again = pygame.transform.scale(again1, (int(tela_w/9), int(tela_h/7)))
again2 = pygame.transform.scale(again1, (int(tela_w/8.5), int(tela_h/6.5)))

fechando = pygame.transform.scale(fechando2, (50, 50))
menu_tela_t = pygame.transform.scale(menu_tela, (tela_w,tela_h))
cenario_final = pygame.transform.scale(cenario, (15000, 1600))
portugues2 = pygame.transform.scale(portugues, (240, 150))
ingles2 = pygame.transform.scale(ingles, (240, 150))
fundo_esc = pygame.transform.scale(fundo_esc1, (tela_w, tela_h))

chao1 = pygame.image.load("plat1.PNG")
chao2 = pygame.image.load("plat2.PNG")

plat11 = pygame.image.load("plataforma 1.PNG")
plat21 = pygame.image.load("plataforma 2.PNG")
plat31 = pygame.image.load("plataforma 1.PNG")
plat41 = pygame.image.load("plataforma 2.PNG")

plat1 = pygame.transform.scale(plat11, (370, 68))
plat2 = pygame.transform.scale(plat21, (401, 78))
plat3 = pygame.transform.scale(plat31, (150, 46))
plat4 = pygame.transform.scale(plat41, (502, 98))

t_chao1 = pygame.transform.scale(chao1, (15000, 1017))
cabeca_t = pygame.transform.scale(cabeca, (126, 84))
cabeca_t2 = pygame.transform.scale(cabeca, (101, 68))
cabeca_t3 = pygame.transform.scale(cabeca, (76, 51))
imagem_tiro = pygame.transform.scale(tiro, (5, 5))

som_passos = pygame.mixer.Sound('./SONS/passos_mb.ogg')
som_tiro = pygame.mixer.Sound('./SONS/tiro_mb.ogg')
som_morte_esqueletos = pygame.mixer.Sound('./SONS/latas_quebrando.ogg')
som_jogo = pygame.mixer.Sound('./SONS/musica tema jogo.ogg')
som_menu = pygame.mixer.Sound('./SONS/menu.ogg')
som_tutorial = pygame.mixer.Sound('./SONS/tutorial.ogg')
som_morte = pygame.mixer.Sound('./SONS/risada maligna.ogg')
som_plataforma = pygame.mixer.Sound('./SONS/queda plataforma.ogg')
som_game_over = pygame.mixer.Sound('./SONS/12 Heavens Choir.wav')

# variaveis
CLOCK = pygame.time.Clock()
v = tela_w/2 - 100
state = 0
state_language = 1
agachado = 0
tiro_top = 0
contagem_caindo = tela_h + 200
pause = False
pygame.mouse.set_visible(True)
teste = 0
alt = 0
pula = 0
tiro_baixo = 1
right = 3
left = 0
colidex_direita = 0
colidex_esquerda = 0
colidey = 0
chao = True
pulacorno = 0
pulando = False
maria_emcima = False
atirando = False
pode_atirar = 30
cont_tutorial = 0
som_menu.play(-1)
som_menu.set_volume(.5)
contador_intro = 0
alpha = 0
state = -1
cimao = 0
agacha = 0

# boss variaveis
cont_ataque_boss = 0
lista_ataque = []
can_ataque = True
ataque = 0
count = 300
ataque3 = 0
ataqueb3 = False

# tiros
ciclos = 0
lista_tiros = []
bala = 0
velx = 0
y_tiro = 0

# listas e dicionarios
maria = {"pos": [500, 300],
            "velX": 0,
            "velY": 0,
            "state": "images_state_right_stop",
            "images_state_left_run": [11,11, 10, 10, 9, 9, 9, 8, 8, 7, 7, 6, 6],
            "images_state_left_stop": [19],
            "images_state_right_run": [0, 0, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 5],
            "images_state_right_stop": [18],
            "images_state_tiro_right": [17, 17, 17, 17, 17, 17],
            "images_state_tiro_left": [23, 23, 23, 23, 23, 23],
            "images_state_tiro_right_down": [16, 16, 16, 16, 16, 16],
            "images_state_tiro_left_down": [20, 20, 20, 20, 20, 20],
            "images_state_down_left": [20],
            "images_state_down_right": [16],
            "images_state_down_run_left":[22,22,21,21,20,20],
            "images_state_down_run_right": [14,14,15,15,16,16],
            "images_state_tiro_top": [25, 25, 25, 25, 25, 25],
            "images_state_tiro_baixo": [24, 24, 24, 24, 24, 24],
            "images_state_up_left": [13],
            "images_state_up_right": [12],
            "frame_index": 0,
            "qtd_de_vidas": 3,
            "vida": 0

    }

tutorial_lista = {"pos": [0,0],
                    "state": "andar",
                    "andar": [0,0,0,0,0, 4,4,4,4,4, 5,5,5,5,5],
                    "pular": [0,0,0,0,0, 3,3,3,3,3],
                    "atirar": [0,0,0,0,0, 2,2,2,2,2],
                    "atirar_cima": [0,0,0,0,0, 6,6,6,6,6],
                    "atirar_baixo": [0,0,0,0,0, 7,7,7,7,7],
                    "abaixar": [0,0,0,0,0, 1,1,1,1,1],
                    "frame_index": 0,

                    }

parallax = { "pos":  0,
             "posy": 0,
             "velx": 0,
             "vely": 0

        }

esqueleto = {"pos": [2088 , 170],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "can_morrer":0,
            "frame_index": 0,
            "vida": 100
        }

esqueleto1 = {"pos": [2812, -40],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "can_morrer":0,
            "frame_index": 0,
            "vida": 100
               }

esqueleto2 = {"pos": [3088, -246],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }


esqueleto3 = {"pos": [3158, 210],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto4 = {"pos": [3424, 350],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto5 = {"pos": [5738, 250],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto6 = {"pos": [8050, 6],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto7 = {"pos": [8050, 6],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto8 = {"pos": [8050, 6],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

esqueleto9 = {"pos": [11206, 6],
            "velX": -15,
            "velY": 0,
            "state": "images_state_right_run",
            "images_state_right_run": [0, 1, 2, 3, 4, 5],
            "images_state_left_run": [11, 10, 9, 8, 7, 6],
            "can_morrer":0,
            "morte_left": [12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14],
            "morte_right": [17,17,17,17,17,17,17,16,16,16,16,16,16,16,16,15,15,15,15,15,15,15,15,15,15],
            "frame_index": 0,
            "vida": 100
        }

plataforma = {"pos": [0, 0],
              "velX": 0,
              "velY": 0,
              "caindo": 510,
              "maria_emcima": False

        }

plataforma1 = {"pos": [0, 0],
              "velX": 0,
              "velY": 0,
              "caindo": 900,
              "maria_emcima": False

        }

plataforma3 = {"pos": [0, 0],
              "velX": 0,
              "velY": 0,
              "caindo": 300,
              "maria_emcima": False

        }

plataforma4 = {"pos": [0, 0],
              "velX": 0,
              "velY": 0,
              "caindo": 1100,
              "maria_emcima": False
        }


boss = {"pos": [tela_w - 400,tela_h*.517],
        "vida": 1000,
        "velX": 20,
        "velY": 0,
        "state": "left_stop",
        "right_stop": [9],
        "left_stop": [8],
        "dash_right":[8,8,8,8, 7,7,7,7, 6,6,6,6, 2,2,2,2, 1,1,1,1, 0,0,0,0],
        "dash_right_stop":[0],
        "dash_left":[9,9,9,9 ,10,10,10,10 ,11,11,11,11 ,15,15,15,15 ,16,16,16,16, 17,17,17,17],
        "dash_left_stop":[17],
        "right_run": [10,10,10, 11,11,11, 12,12,12, 13,13,13, 14,14,14],
        "right_run_1": [10, 10, 11, 11, 12, 12, 13, 13, 14, 14],
        "left_run": [7,7,7, 6,6,6, 5,5,5, 4,4,4, 3,3,3],
        "left_run_1": [7, 7, 6, 6, 5, 5, 4, 4, 3, 3],
        "frame_index": 0,
        }

def estado_jogar():
    global state
    state = 6
    som_menu.stop()
    som_tutorial.play(-1)
    som_tutorial.set_volume(.5)

def estado_config():
    global state
    state = 2

def estado_creditos():
    global state
    state = 3

def estado_idioma_portuges():
    global state_language
    state_language = 1

def estado_idioma_ingles():
    global state_language
    state_language = 2

def estado_fechando():
    global state
    state = 0

def saindo():
    global state
    state = 10

def voltando_ao_menu():
    global state
    state = 0
    jogar_denovo()
    som_jogo.stop()
    som_game_over.stop()
    som_menu.play(-1)

def continuar_jogando():
    global state
    state = 1

def jogar_novamente():
    global state
    state = 1
    jogar_denovo()
    som_game_over.stop()
    som_jogo.play(-1)

jogar = {"pos": [tela_w/2 - 110, tela_h/3],
         "funcao": estado_jogar,
         "img": play
         }

config = {"pos": [tela_w/2 - 110, tela_h/2],
          "funcao": estado_config,
          "img": opcoes2
          }

portuges = {"pos": [300, 200],
          "funcao": estado_idioma_portuges,
          "img": portugues2
          }

ingls = {"pos": [600, 200],
          "funcao": estado_idioma_ingles,
          "img": ingles2
          }

close = {"pos": [tela_w - 62, (tela_h* .02)],
          "funcao": estado_fechando,
          "img": fechando
          }

sair = {"pos": [tela_w/2 - 110, tela_h - 100],
          "funcao": saindo,
          "img": fechando3
          }

sair_menu = {"pos": [int(tela_w*.42), int(tela_h*.5)],
          "funcao": voltando_ao_menu,
          "img": saindo_menu
          }

continuar_jogando = {"pos": [int(tela_w*.42), int(tela_h*.7)],
          "funcao": continuar_jogando,
          "img": continu
          }

jogar_nova = {"pos": [int(tela_w * .72), int(tela_h * .7)],
          "funcao": jogar_novamente,
          "img": again
          }

def jogar_denovo():
    global maria, parallax, esqueleto, esqueleto1, esqueleto2, esqueleto3, esqueleto4, \
        esqueleto5, esqueleto6, esqueleto7, esqueleto8, esqueleto9, contagem_caindo

    maria["pos"] = [500, -100]
    maria["qtd_de_vidas"] = 3
    maria["vida"] = 0

    parallax["pos"] = 0
    parallax["posy"] = -280

    contagem_caindo = tela_h + 200

    esqueleto["pos"] = [2088 , 170]
    esqueleto["vida"] = 100
    esqueleto["can_morrer"] = 0

    esqueleto1["pos"] = [2812, -40]
    esqueleto1["vida"] = 100
    esqueleto1["can_morrer"] = 0

    esqueleto2["pos"] = [3088, -246]
    esqueleto2["vida"] = 100
    esqueleto2["can_morrer"] = 0

    esqueleto3["pos"] = [3158, 210]
    esqueleto3["vida"] = 100
    esqueleto3["can_morrer"] = 0

    esqueleto4["pos"] = [3424, 350]
    esqueleto4["vida"] = 100
    esqueleto4["can_morrer"] = 0

    esqueleto5["pos"] = [5738, 250]
    esqueleto5["vida"] = 100
    esqueleto5["can_morrer"] = 0

    esqueleto6["pos"] = [8050, 6]
    esqueleto6["vida"] = 100
    esqueleto6["can_morrer"] = 0

    esqueleto7["pos"] = [8050, 6]
    esqueleto7["vida"] = 100
    esqueleto7["can_morrer"] = 0

    esqueleto8["pos"] = [8050, 6]
    esqueleto8["vida"] = 100
    esqueleto8["can_morrer"] = 0

    esqueleto9["pos"] = [11206, 6]
    esqueleto9["vida"] = 100
    esqueleto9["can_morrer"] = 0

def pintar_options(scr, obj):
    sur_opcao = obj["img"]
    scr.blit(sur_opcao, obj["pos"])

def colisao_menu(obj, e):
    global state
    r1 = obj["img"].get_rect()
    r1.x = obj["pos"][0]
    r1.y = obj["pos"][1]
    if r1.collidepoint(e.pos):
        obj["funcao"]()

def cima_menu(obj, imagem_troca, estdo_normal, y, pos, x1, x2):
    global screen, tela_w, tela_h

    rect = obj["img"].get_rect()
    rect.x = obj["pos"][0]
    rect.y = obj["pos"][1]
    mouse = pygame.mouse.get_pos()
    rect1 = Rect((mouse[0], mouse[1]),(10,10))
    #pygame.draw.rect(screen, (255,255,255), rect1)

    if rect.colliderect(rect1):
        obj["img"] = imagem_troca
        obj["pos"][0] = (tela_w / 2) - x2
        obj["pos"][1] = (tela_h / y)+ pos

    else:
        obj["img"] = estdo_normal
        obj["pos"][0] = (tela_w / 2) - x1
        obj["pos"][1] = (tela_h / y) + pos

def movimenta_paralax(obj):
    global chao, maria, contagem_caindo, tiro_baixo, colidey

    obj["pos"] += obj["velx"]
    obj["posy"] += (obj["vely"])

    if chao == True and colidey == 1:
        obj["vely"] = 0

    if maria["pos"][1] > 110:
        contagem_caindo = -10

    if maria["pos"][1] < 200 and contagem_caindo > 0:
        obj["vely"] = 0
        maria["velY"] = 5

    elif chao == False and contagem_caindo < 0:
        contagem_caindo -= 10
        obj["vely"] += 1

    if obj["pos"] <= 0:
        obj["pos"] = 0
    if obj["pos"] >= 18700:
        obj["pos"] = 18700

    if obj["pos"] == 0:
       maria["pos"][0] += maria["velX"]
    if obj["pos"] < tela_w/2 - 100:
       maria["pos"][0] += maria["velX"]
    if obj["pos"] == 18700:
       maria["pos"][0] += maria["velX"]
    if obj["pos"] < 18700:
        maria["pos"][0] += maria["velX"]

    if colidey == 1:
        obj["vely"] = 0 + pulacorno

def parallax_draw (pos_inicial, img, posx):
    imgW = img.get_width()
    imgH = img.get_height()
    posx %= imgW

    img_rect1 = img.subsurface((posx, 0), (imgW - posx, imgH))
    img_rect2 = img.subsurface((0, 0), (posx, imgH))
    screen.blit(img_rect1, pos_inicial)
    screen.blit(img_rect2, (imgW - posx, pos_inicial[1]))
    return screen

def atualizar_regra_personagem( obj ):
    global atirando, right, left, parallax, v, tiro_baixo, chao, pulacorno, maria_emcima, contagem_caindo

    obj["pos"][1] += (obj["velY"])

    if chao == True:
        obj["velY"] = 0
        tiro_baixo = 0
    elif chao == False:
        obj["velY"] += 1
        pulacorno = 0

    if obj["pos"][1] < -20 and contagem_caindo <= 0:
        maria["velY"] += 1
        parallax["vely"] += 1

    if obj["pos"][0] <= v and parallax["pos"] > v:
        obj["pos"][0] = tela_w/2 - 100
    if obj["pos"][0] >= v and parallax["pos"] < 18700:
        obj["pos"][0] = tela_w/2 - 100

    if obj["pos"][0] > tela_w/2 - 100:
        v = 25000

    if obj["pos"][0] < tela_w/2 - 100:
        v = tela_w/2 - 100

    if obj["pos"][0] >= tela_w - 150:
        obj["pos"][0] = tela_w - 150
        obj["velX"] = 0

    if obj["pos"][0] <= -18:
        obj["pos"][0] = -18
        obj["velX"] = 0

    if chao == False:
        if left >= 1:
            obj["state"] = "images_state_up_left"
        elif right >= 1:
            obj["state"] = "images_state_up_right"

    elif chao == True and atirando == False:
        if right == 1:
            obj["state"] = "images_state_right_run"
        elif right == 2:
            obj["state"] = "images_state_down_run_right"
        elif right == 3:
            obj["state"] = "images_state_right_stop"
        elif right == 4:
            obj["state"] = "images_state_down_right"

        elif left == 1:
            obj["state"] = "images_state_left_run"
        elif left == 2:
            obj["state"] = "images_state_down_run_left"
        elif left == 3:
            obj["state"] = "images_state_left_stop"
        elif left == 4:
            obj["state"] = "images_state_down_left"

        if colidey == 1:
            obj["velY"] = 0 + pulacorno

    if atirando == True:
        if tiro_top == 1:
            obj["state"] = "images_state_tiro_top"

        elif tiro_baixo == 1:
            obj["state"] = "images_state_tiro_baixo"

        elif right == 1:
            obj["state"] = "images_state_right_run"
        elif right == 2:
            obj["state"] = "images_state_down_run_right"
        elif right == 3:
            obj["state"] = "images_state_tiro_right"
        elif right == 4:
            obj["state"] = "images_state_tiro_right_down"

        elif left == 1:
            obj["state"] = "images_state_left_run"
        elif left == 2:
            obj["state"] = "images_state_down_run_left"
        elif left == 3:
            obj["state"] = "images_state_tiro_left"
        elif left == 4:
            obj["state"] = "images_state_tiro_left_down"

def atualizar_regra_personagem_semscroll(obj):
    global atirando, right, left, parallax, v, tiro_baixo, chao, pulacorno, maria_emcima

    obj["pos"][1] += obj["velY"]
    obj["pos"][0] += obj["velX"]
    obj["velY"] += 1

    if obj["pos"][0] >= (tela_w - 150):
        obj["pos"][0] = (tela_w - 150)
        obj["velX"] = 0

    if obj["pos"][0] <= -18:
        obj["pos"][0] = -18
        obj["velX"] = 0

    if obj["pos"][1] >= (tela_h - (tela_h * .27)):
        obj["pos"][1] = (tela_h - (tela_h * .27))
        chao = True
        tiro_baixo = 0

    else:
        chao = False

    if state == 6:
        if obj["pos"][1] >= (tela_h - (tela_h * .47)):
            obj["pos"][1] = (tela_h - (tela_h * .47))
            chao = True
            tiro_baixo = 0

    if chao == False:
        if left >= 1:
            obj["state"] = "images_state_up_left"
        elif right >= 1:
            obj["state"] = "images_state_up_right"

    elif chao == True and atirando == False:
        if right == 1:
            obj["state"] = "images_state_right_run"
        elif right == 2:
            obj["state"] = "images_state_down_run_right"
        elif right == 3:
            obj["state"] = "images_state_right_stop"
        elif right == 4:
            obj["state"] = "images_state_down_right"

        elif left == 1:
            obj["state"] = "images_state_left_run"
        elif left == 2:
            obj["state"] = "images_state_down_run_left"
        elif left == 3:
            obj["state"] = "images_state_left_stop"
        elif left == 4:
            obj["state"] = "images_state_down_left"

    if atirando == True:
        if tiro_top == 1:
            obj["state"] = "images_state_tiro_top"

        elif tiro_baixo == 1:
            obj["state"] = "images_state_tiro_baixo"

        elif right == 1:
            obj["state"] = "images_state_right_run"
        elif right == 2:
            obj["state"] = "images_state_down_run_right"
        elif right == 3:
            obj["state"] = "images_state_tiro_right"
        elif right == 4:
            obj["state"] = "images_state_tiro_right_down"

        elif left == 1:
            obj["state"] = "images_state_left_run"
        elif left == 2:
            obj["state"] = "images_state_down_run_left"
        elif left == 3:
            obj["state"] = "images_state_tiro_left"
        elif left == 4:
            obj["state"] = "images_state_tiro_left_down"

def atualizar_regra_personagem1( obj, pos_y, pos_x_min, pos_x_max ):
    global parallax, maria, chao_esq

    obj["pos"][0] += (obj["velX"])
    obj["pos"][1] += (obj["velY"])

    # if chao_esq == True:
    #     obj["velY"] = 0
    # elif chao_esq == False:
    #     obj["velY"] += 1
    obj["pos"][1] = pos_y - parallax["posy"]

    if obj["pos"][0] >= pos_x_max - parallax["pos"]:
        obj["velX"] = -15
        obj["state"] = "images_state_right_run"

    elif obj["pos"][0] <= pos_x_min - parallax["pos"]:
        obj["velX"] = +15
        obj["state"] = "images_state_left_run"

    if obj["velX"] > 0 and obj["vida"] < 1:
        obj["state"] = "morte_right"

    if obj["velX"] < 0 and obj["vida"] < 1:
        obj["state"] = "morte_left"

    if obj["vida"] < 1:
        obj["can_morrer"] += 5
        obj["velX"] = -parallax["velx"]

def get_frame( gId , imagem, x, y, colunas):
    top = 0
    margin = 0
    space_h = 0
    space_v = 0
    width = x
    height = y
    columns = colunas
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
    sur_frame = get_frame(gId, imagem, 150, 150, 6)
    screen.blit(sur_frame, obj["pos"])


def anima_boss( obj , imagem):
    global tela
    chave = obj["state"]
    frames = obj[chave]
    obj["frame_index"] += 1
    if obj["frame_index"] >= len(frames) - 1:
        obj["frame_index"] = 0
    gId = frames[obj["frame_index"]]
    sur_frame = get_frame(gId, imagem, 250, 250, 9)
    screen.blit(sur_frame, obj["pos"])

def anima_tuto( obj , imagem):
    global tela
    chave = obj["state"]
    frames = obj[chave]
    obj["frame_index"] += 1
    if obj["frame_index"] >= len(frames) - 1:
        obj["frame_index"] = 0
    gId = frames[obj["frame_index"]]
    sur_frame = get_frame(gId, imagem, tela_w, tela_h, 4)
    screen.blit(sur_frame, obj["pos"])

def pintar( scr, obj ):
    scr.blit(obj['imagem'], (obj['x'], obj['y']))

def movimenta(obj):
    obj['x'] = obj['x'] + obj['velX']
    obj['y'] = obj['y'] + obj['velY']

def movimenta_plataforma(obj):
    global parallax, maria_emcima, parallax, maria, caindo

    obj["pos"][1] += (obj["velY"])

    if obj["maria_emcima"] == True:
        obj["caindo"] = obj["caindo"] - 50
        som_plataforma.play()
        som_plataforma.set_volume(.7)
    if obj["caindo"] <= 0:
        obj["velY"] += 2
    if obj["pos"][1] > 1000:
        obj["caindo"] = 1000
        obj["velY"] -= 2
    if obj["pos"][1] < 0:
        obj["pos"][1] = 0
        obj["velY"] = 0

def tiro_tete(x, y, velx, vely, img):
    global bala, maria, y_tiro

    tiro = {'x': maria["pos"][0] + x, 'y': maria["pos"][1] + y , 'velX': velx, 'velY': vely, 'imagem': img}
    lista_tiros.append(tiro)
    bala = 0

def colisa(obj, obj_colide):
    global lista_tiros, state

    for bullet in lista_tiros:
        bulletrect = bullet["imagem"].get_rect()
        bulletRect = Rect([bullet["x"], bullet["y"], bulletrect.w, bulletrect.h])
        if bulletRect.colliderect(obj_colide) and obj["vida"] > 0:
            obj["vida"] -= 35
            lista_tiros.remove(bullet)
            if obj["vida"] <= 0:
                som_morte_esqueletos.play()

        elif (bulletRect.colliderect(c1) or bulletRect.colliderect(c2) or bulletRect.colliderect(c3) or bulletRect.colliderect(c4)
           or bulletRect.colliderect(c5) or bulletRect.colliderect(c6) or bulletRect.colliderect(c7) or bulletRect.colliderect(c8)
           or bulletRect.colliderect(c9) or bulletRect.colliderect(c10) or bulletRect.colliderect(c11) or bulletRect.colliderect(c12)
           or bulletRect.colliderect(p1) or bulletRect.colliderect(p2) or bulletRect.colliderect(p3) or bulletRect.colliderect(p4)
           or bulletRect.colliderect(p5) or bulletRect.colliderect(p6) or bulletRect.colliderect(p7) or bulletRect.colliderect(p8)
           or bulletRect.colliderect(p9) or bulletRect.colliderect(p10) or bulletRect.colliderect(p11) or bulletRect.colliderect(p1b)) and state == 1:
            lista_tiros.remove(bullet)

def teste_colide(y, vely, y_maria):
    global colidey, chao, maria, tiro_baixo, contagem_caindo

    parallax["vely"] = vely
    parallax["posy"] = y
    maria["velY"] = vely
    maria["pos"][1] = y_maria
    colidey = 1
    chao = True
    contagem_caindo = -10

def desenha_atributos_inimigos(obj, px, py, img):
    global state
    if obj["can_morrer"] < 100:
        # rec_teste_life = Rect((obj["pos"][0] + px,obj["pos"][1] + py), (obj["vida"], 10))
        # pygame.draw.rect(screen, (0, 255, 0), rec_teste_life)
        anima(obj, img)

def colide_plataforma_lateral(colisor, velx, paratraz):
    global chao, maria_emcima, colidex_direita, colidex_esquerda, colidey, maria, parallax

    if colisor.colliderect(c1) or colisor.colliderect(c2) or colisor.colliderect(c3) or colisor.colliderect(c4) \
        or colisor.colliderect(c5) or colisor.colliderect(c6) or colisor.colliderect(c7) or colisor.colliderect(c8) \
        or colisor.colliderect(c9) or colisor.colliderect(c10) or colisor.colliderect(c11) or colisor.colliderect(c12) \
        or colisor.colliderect(p1) or colisor.colliderect(p2) or colisor.colliderect(p3) or colisor.colliderect(p4) \
        or colisor.colliderect(p5) or colisor.colliderect(p6) or colisor.colliderect(p7) or colisor.colliderect(p8) \
        or colisor.colliderect(p9) or colisor.colliderect(p10) or colisor.colliderect(p11) or colisor.colliderect(p1b):

        parallax["velx"] = velx
        maria["velX"] = velx
        parallax["pos"] = parallax["pos"] + paratraz
        maria["pos"][0] = maria["pos"][0] + paratraz

    else:
        colidex_direita = 0
        colidex_esquerda = 0
        colidey = 0
        chao = False
        maria_emcima = False

def colisao_com_inimigo(colisor, pos, life_maria):
    global maria, parallax

    if colisor.colliderect(esq_rect1) and esqueleto["vida"] > 1 or colisor.colliderect(esq_rect2) and esqueleto1["vida"] > 1 \
            or colisor.colliderect(esq_rect3) and esqueleto2["vida"] > 1 or colisor.colliderect(esq_rect4) and esqueleto3["vida"] > 1 \
            or colisor.colliderect(esq_rect5) and esqueleto4["vida"] > 1 or colisor.colliderect(esq_rect6) and esqueleto5["vida"] > 1 \
            or colisor.colliderect(esq_rect7) and esqueleto6["vida"] > 1 or colisor.colliderect(esq_rect8) and esqueleto7["vida"] > 1 \
            or colisor.colliderect(esq_rect9) and esqueleto8["vida"] > 1 or colisor.colliderect(esq_rect10) and esqueleto9["vida"] > 1:

        maria["vida"] += life_maria
        parallax["pos"] += pos
        maria["pos"][0] += pos

def ataque_boss_1(obj):
    global cont_ataque_boss, tela_w, x1

    if obj["vida"] > 600:
        if obj["pos"][0] > tela_w - 250:
            obj["pos"][0] = tela_w - 250
            obj["state"] = "left_stop"
            if cont_ataque_boss > count:
                obj["velX"] = -30
                obj["state"] = "left_run"
                cont_ataque_boss = 0
            if cont_ataque_boss > 250:
                obj["state"] = "left_run_1"

        elif obj["pos"][0] < 0:
            obj["pos"][0] = 0
            obj["state"] = "right_stop"
            if cont_ataque_boss > count:
                obj["velX"] = 30
                cont_ataque_boss = 0
                obj["state"] = "right_run"
            if cont_ataque_boss > 250:
                obj["state"] = "right_run_1"

def ataque_boss_2(obj, img, obj2, img2):
    global cont_ataque_boss, lista_ataque, screen, can_ataque, ataque, bulletRect

    x = 0
    y = 70

    if obj["state"] == "right_stop" or obj["state"] == "right_run":
        x = 200

    elif obj["state"] == "left_stop" or obj["state"] == "left_run":
        x = 60

    if obj["vida"] <= 600 and obj["vida"] > 301 :
        if can_ataque == True and ataque > 85 and ataque < 150:
            bola = {"x": obj["pos"][0] + x , "y": obj["pos"][1] + y, "velY": -1, "velX": 0, "imagem":img}
            bola["velY"] = - (random.randint(25, 35))
            lista_ataque.append(bola)

        if obj["pos"][0] > tela_w - 250:
            obj["pos"][0] = tela_w - 250
            obj["state"] = "left_stop"
            can_ataque = True
            if cont_ataque_boss > count:
                can_ataque = False
                obj["velX"] = -12
                obj["state"] = "left_run"
                cont_ataque_boss = 0
            if cont_ataque_boss > 250:
                obj["state"] = "left_run_1"

        elif obj["pos"][0] < 0:
            obj["pos"][0] = 0
            obj["state"] = "right_stop"
            can_ataque = True
            if cont_ataque_boss > count:
                can_ataque = False
                obj["velX"] = 12
                cont_ataque_boss = 0
                obj["state"] = "right_run"
            if cont_ataque_boss > 250:
                obj["state"] = "right_run_1"

    for bullet in lista_tiros:
        bulletrect = bullet["imagem"].get_rect()
        bulletRect = Rect([bullet["x"], bullet["y"], bulletrect.w, bulletrect.h])

    for bola in lista_ataque:
        pintar(screen, bola)
        if bola["y"] < -(random.randint(1000, 2200)):
            bola["imagem"] = img2
            bola["velY"] = random.randint(15, 25)
            bola["x"] = random.randint(5, tela_w - 75)
        if bola["y"] >= tela_h + 100:
            lista_ataque.remove(bola)
    for bola in lista_ataque:
        movimenta(bola)

    for bolo in lista_ataque:
        bolorect = bolo["imagem"].get_rect()
        boloreco = Rect((bolo["x"], bolo["y"]),(bolorect.w, bolorect.h))
        if boloreco.colliderect(obj2) or boloreco.colliderect(bulletRect):
            lista_ataque.remove(bolo)

def ataque_boss_3(obj):
    global cont_ataque_boss, move, ataque3, ataqueb3, telah, telaw, maria

    ataqueb3 = True
    if obj["vida"] <= 300 and cont_ataque_boss > count:
        obj["velX"] = 0
        obj["pos"][1] = tela_h*.05
        obj["pos"][0] = maria["pos"][0]
        if obj["pos"][1] <= tela_h*.15:
            obj["velY"] = 0
        cont_ataque_boss = 0
        ataque3 = 0

        if maria["pos"][0] >= tela_w/2:
            obj["state"] = "dash_right_stop"

        if maria["pos"][0] <= tela_w/2:
            obj["state"] = "dash_left_stop"

    if obj["pos"][1] < (tela_h * .1) and ataque3 > 40:
        obj["velY"] += 100
        if maria["pos"][0] >= tela_w/2:
            obj["state"] = "dash_right"

        if maria["pos"][0] <= tela_w/2:
            obj["state"] = "dash_left"

    if obj["pos"][0] > tela_w - 250:
        obj["pos"][0] = tela_w - 250

    elif obj["pos"][0] < 0:
        obj["pos"][0] = 0

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

def boss_regras(obj):
    global tela_h

    obj["pos"][0] = obj["pos"][0] + obj["velX"]
    obj["pos"][1] = obj["pos"][1] + obj["velY"]

    if  ataqueb3 == False:
        obj["velY"] += 1

    if obj["pos"][1] >= (tela_h - (tela_h * .417)):
        obj["pos"][1] = (tela_h - (tela_h * .417))
        obj["velY"] = 0


while True:
    contador_intro += 10
    CLOCK.tick(35)
    pode_atirar += 1
    pygame.display.update()
    if state == -1:
        if contador_intro > 0 and contador_intro < 1200:
            screen.fill((0,0,0))
            alpha += 10
            intro.set_alpha(alpha)
            screen.blit(intro, (434, 0))
            if alpha >= 1000:
                alpha = 1000
        if contador_intro > 1200 and contador_intro < 2400:
            screen.fill((0, 0, 0))
            alpha -= 10
            intro.set_alpha(alpha)
            screen.blit(intro, (434, 0))
        if contador_intro >= 2400:
            state = 0

    if state == 6:
        pygame.mouse.set_visible(False)
        cont_tutorial += 10
        screen.blit(cenario_final, (0, -350))

        for tiro in lista_tiros:
            pintar(screen, tiro)
            if tiro["x"] > 2000 or tiro["x"] < -2000 :
                lista_tiros.remove(tiro)
            if tiro["y"] > 2000 or tiro["y"] < -2000 :
                lista_tiros.remove(tiro)
        for tiro in lista_tiros:
            movimenta(tiro)

        atualizar_regra_personagem_semscroll(maria)
        anima(maria, sprite_sheet)
        screen.blit(fundo, (0,0))

        anima_tuto(tutorial_lista, tutorial)

        if cont_tutorial > 100 and cont_tutorial < 1600:
            tutorial_lista["state"] = "andar"
            if state_language == 1:
                screen.blit(text1,(0, 0))
            if state_language == 2:
                screen.blit(text1_I,(0, 0))

        if cont_tutorial > 1700 and cont_tutorial < 3200:
            tutorial_lista["state"] = "abaixar"
            if state_language == 1:
                screen.blit(text2,(0, 0))
            if state_language == 2:
                screen.blit(text2_I,(0, 0))

        if cont_tutorial > 3300 and cont_tutorial < 4800:
            tutorial_lista["state"] = "atirar"
            if state_language == 1:
                screen.blit(text3,(0, 0))
            if state_language == 2:
                screen.blit(text3_I,(0, 0))

        if cont_tutorial > 4900 and cont_tutorial < 6400:
            tutorial_lista["state"] = "atirar_baixo"
            if state_language == 1:
                screen.blit(text4,(0, 0))
            if state_language == 2:
                screen.blit(text4_I,(0, 0))

        if cont_tutorial > 6500 and cont_tutorial < 8000:
            tutorial_lista["state"] = "atirar_cima"
            if state_language == 1:
                screen.blit(text5,(0, 0))
            if state_language == 2:
                screen.blit(text4_I(0, 0))

        if cont_tutorial > 8100 and cont_tutorial < 9600:
            tutorial_lista["state"] = "pular"
            if state_language == 1:
                screen.blit(text6, (0, 0))
            if state_language == 2:
                screen.blit(text6_I, (0, 0))

    if state == 1:
        pygame.mouse.set_visible(True)
        movimenta_paralax(parallax)
        screen.fill((0, 155, 255))
        parallax_draw((0, - (parallax["posy"]*-.2) - 500), cenario_final, parallax["pos"]*-.25)
        #parallax_draw((0, - (parallax["posy"]*.3) - 150), nuven_transp, - posx)

        esquerdo = Rect((maria["pos"][0] + 35 , maria["pos"][1] + agacha),(3, (100 - agacha)))
        direito = Rect((maria["pos"][0] + 115, maria["pos"][1] + agacha), (3, (100 - agacha)))
        cima = Rect((maria["pos"][0] + 50, maria["pos"][1] + cimao), (50, 3))
        baixo = Rect((maria["pos"][0] + 60, maria["pos"][1] + 150),(30, 3))
        ret = Rect((- parallax["pos"] + 1000, - parallax["posy"] + 360), (250, 30))
        c_boss = Rect((- parallax["pos"] + 19500, - parallax["posy"] - 220), (100, 500))
        rect_boss = pygame.draw.rect(screen, (0, 0, 0), c_boss)

        if rect_boss.colliderect(direito) or rect_boss.colliderect(esquerdo) or rect_boss.colliderect(baixo) or rect_boss.colliderect(cima):
            state = 15

        c1 = Rect((- parallax["pos"], -(parallax["posy"]) + 500), (1342, 274))
        #colide = pygame.draw.rect(screen, (255, 255, 255), c1)

        c2 = Rect((- parallax["pos"] + 1580, - parallax["posy"] + 500), (366, 274))
        colide2 = pygame.draw.rect(screen, (255, 255, 255), c2)

        c3 = Rect((- parallax["pos"] + 3008, - parallax["posy"] - 96), (150, 940))
        c4 = Rect((- parallax["pos"] + 3158, - parallax["posy"] + 360), (266, 484))
        c5 = Rect((- parallax["pos"] + 3424, - parallax["posy"] + 500), (1200, 296))
        # colide3 = pygame.draw.rect(screen, (255, 255, 255), c3)
        # colide4 = pygame.draw.rect(screen, (255, 255, 255), c4)
        # colide5 = pygame.draw.rect(screen, (255, 255, 255), c5)

        c_teste = Rect((- parallax["pos"] + 4600, - parallax["posy"] + 483), (1150, 296))
        # czera = pygame.draw.rect(screen, (255, 255, 255), c_teste)

        c6 = Rect((- parallax["pos"] + 5738, - parallax["posy"] + 500), (1414 , 296))
        # colide6 = pygame.draw.rect(screen, (255, 255, 255), c6)

        c7 = Rect((- parallax["pos"] + 11736, - parallax["posy"] + 500), (2570, 288))
        # colide7 = pygame.draw.rect(screen, (255, 255, 255), c7)

        c8 = Rect((- parallax["pos"] + 17200, - parallax["posy"] + 500), (1190, 296))
        c9 = Rect((- parallax["pos"] + 18400, - parallax["posy"] + 224), (254, 566))
        c10 = Rect((- parallax["pos"] + 18650, - parallax["posy"] + 32), (170, 768))
        c11 = Rect((- parallax["pos"] + 18820, - parallax["posy"] + 94), (266, 696))
        c12 = Rect((- parallax["pos"] + 19100, - parallax["posy"] - 64), (1272, 854))
        # colide8 = pygame.draw.rect(screen, (255, 255, 255), c8)
        # colide9 = pygame.draw.rect(screen, (255, 255, 255), c9)
        # colide10 = pygame.draw.rect(screen, (255, 255, 255), c10)
        # colide11 = pygame.draw.rect(screen, (255, 255, 255), c11)
        # colide12 = pygame.draw.rect(screen, (255, 255, 255), c12)


        p1 = Rect((- parallax["pos"] + 2188, - parallax["posy"] + 320), (624, 162))
        p1b = Rect((- parallax["pos"] + 2078, - parallax["posy"] + 400), (100, 70))
        # plat1 = pygame.draw.rect(screen, (255, 255, 255), p1)
        # plat1b = pygame.draw.rect(screen, (255, 255, 255), p1b)

        p2 = Rect((- parallax["pos"] + 2812, - parallax["posy"] + 110), (126, 112))
        # plat2 = pygame.draw.rect(screen, (255, 255, 255), p2)

        p3 = Rect((- parallax["pos"] + 7238, - parallax["posy"] + 230), (220, 100))
        p3b = Rect((- parallax["pos"] + 7258, - parallax["posy"] + 330), (180, 70))
        # plat3 = pygame.draw.rect(screen, (255, 255, 255), p3)
        # plat4 = pygame.draw.rect(screen, (255, 255, 255), p3b)

        p4 = Rect((- parallax["pos"] + 7658, - parallax["posy"] + 50), (210, 190))
        # plat5 = pygame.draw.rect(screen, (255, 255, 255), p4)

        p5 = Rect((- parallax["pos"] + 8050, - parallax["posy"] + 156), (2486, 170))
        # plat6 = pygame.draw.rect(screen, (255, 255, 255), p5)

        p6 = Rect((- parallax["pos"] + 10758, - parallax["posy"] - 4), (278, 222))
        # plat7 = pygame.draw.rect(screen, (255, 255, 255), p6)

        p7 = Rect((- parallax["pos"] + 11206, - parallax["posy"] + 156), (450, 182))
        # plat8 = pygame.draw.rect(screen, (255, 255, 255), p7)

        p8 = Rect((- parallax["pos"] + 14372, - parallax["posy"] + 260), (170, 200))
        # plat9 = pygame.draw.rect(screen, (255, 255, 255), p8)

        p9 = Rect((-parallax["pos"] + 14730, - parallax["posy"] + 160 + plataforma["pos"][1]), (370, 68))
        #plat10 = pygame.draw.rect(screen, (255, 255, 255), p9)
        screen.blit(plat1, ((-parallax["pos"] + 14730, - parallax["posy"] + 150 + plataforma["pos"][1])))

        plattt = Rect((-parallax["pos"] + 15400, - parallax["posy"] + 160 + plataforma1["pos"][1]), (401, 78))
        #plad2 = pygame.draw.rect(screen, (255, 255, 255), plattt)
        screen.blit(plat2, ((-parallax["pos"] + 15400, - parallax["posy"] + 150 + plataforma1["pos"][1])))

        p10 = Rect((- parallax["pos"] + 15892, - parallax["posy"] + 400), (166, 126))
        #plat11 = pygame.draw.rect(screen, (255, 255, 255), p10)

        p11 = Rect((- parallax["pos"] + 16250, - parallax["posy"] + 160 + plataforma3["pos"][1]), (150, 46))
        #plat12 = pygame.draw.rect(screen, (255, 255, 255), p11)
        screen.blit(plat3, ((-parallax["pos"] + 16250, - parallax["posy"] + 150 + plataforma3["pos"][1])))

        platttt = Rect((- parallax["pos"] + 16500, - parallax["posy"] + 160 + plataforma4["pos"][1]), (502, 98))
        #plad = pygame.draw.rect(screen, (255, 255, 255), platttt)
        screen.blit(plat4, ((-parallax["pos"] + 16500, - parallax["posy"] + 150 + plataforma4["pos"][1])))

        screen.blit(chao1, ((- parallax["pos"] , -(parallax["posy"]) - 250)))
        screen.blit(chao2, ((- parallax["pos"] + 10000 , -(parallax["posy"]) - 250)))

        movimenta_plataforma(plataforma)
        movimenta_plataforma(plataforma1)
        movimenta_plataforma(plataforma3)
        movimenta_plataforma(plataforma4)

        life_bar = pygame.draw.rect(screen, (0, 255, 0),((130, 20),(300 - maria["vida"], 30)))

        if maria["qtd_de_vidas"] >= 1:
            screen.blit(cabeca_t, (0,0))
        if maria["qtd_de_vidas"] >= 2:
            screen.blit(cabeca_t2, (0,80))
        if maria["qtd_de_vidas"] == 3:
            screen.blit(cabeca_t3, (0,140))

        e = pygame.draw.rect(screen, (255, 255, 255), esquerdo)
        d = pygame.draw.rect(screen, (255, 255, 255), direito)
        c = pygame.draw.rect(screen, (255, 255, 255), cima)
        b = pygame.draw.rect(screen, (255, 255, 255), baixo)

        if esqueleto["can_morrer"] < 100:
            esq_rect1 = Rect((esqueleto["pos"][0], esqueleto["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto, 170, 2188, 2688)

        if esqueleto1["can_morrer"] < 100:
            esq_rect2 = Rect((esqueleto1["pos"][0], esqueleto1["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto1, -40, 2712, 2812)

        if esqueleto2["can_morrer"] < 100:
            esq_rect3 = Rect((esqueleto2["pos"][0], esqueleto2["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto2, -246, 2958, 3058)

        if esqueleto3["can_morrer"] < 100:
            esq_rect4 = Rect((esqueleto3["pos"][0], esqueleto3["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto3, 210, 3198, 3298)

        if esqueleto4["can_morrer"] < 100:
            esq_rect5 = Rect((esqueleto4["pos"][0], esqueleto4["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto4, 350, 3500, 4200)

        if esqueleto5["can_morrer"] < 100:
            esq_rect6 = Rect((esqueleto5["pos"][0], esqueleto5["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto5, 350, 5850, 6250)

        if esqueleto6["can_morrer"] < 100:
            esq_rect7 = Rect((esqueleto6["pos"][0], esqueleto6["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto6, 6, 8050, 9050)

        if esqueleto7["can_morrer"] < 100:
            esq_rect8 = Rect((esqueleto7["pos"][0], esqueleto7["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto7, 6, 9050, 10050)

        if esqueleto8["can_morrer"] < 100:
            esq_rect9 = Rect((esqueleto8["pos"][0], esqueleto8["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto8, 6, 9850, 10350)

        if esqueleto9["can_morrer"] < 100:
            esq_rect10 = Rect((esqueleto9["pos"][0], esqueleto9["pos"][1]), (100, 150))
            atualizar_regra_personagem1(esqueleto9, 6, 11200, 11600)

        colisa(esqueleto, esq_rect1)
        colisa(esqueleto1, esq_rect2)
        colisa(esqueleto2, esq_rect3)
        colisa(esqueleto3, esq_rect4)
        colisa(esqueleto4, esq_rect5)
        colisa(esqueleto5, esq_rect6)
        colisa(esqueleto6, esq_rect7)
        colisa(esqueleto7, esq_rect8)
        colisa(esqueleto8, esq_rect9)
        colisa(esqueleto9, esq_rect10)

        desenha_atributos_inimigos(esqueleto, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto1, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto2, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto3, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto4, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto5, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto6, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto7, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto8, + 20, - 30, esqueleeeto)
        desenha_atributos_inimigos(esqueleto9, + 20, - 30, esqueleeeto)

        for tiro in lista_tiros:
            pintar(screen, tiro)
            if tiro["x"] > tela_w-150 or tiro["x"] < -tela_w+150 :
                lista_tiros.remove(tiro)
            if tiro["y"] > tela_h-150 or tiro["y"] < -tela_h+150 :
                lista_tiros.remove(tiro)

        for tiro in lista_tiros:
            movimenta(tiro)

        colisao_com_inimigo(esquerdo, 5, 5)
        colisao_com_inimigo(direito, -5, 5)
        colisao_com_inimigo(cima,     0, 5)
        colisao_com_inimigo(baixo,    0, 5)

        colide_plataforma_lateral(esquerdo, 0, +3)
        colide_plataforma_lateral(direito, 0, -3)

        if baixo.colliderect(c_teste):
            teste_colide(30, 0, 314)

        elif baixo.colliderect(c1):
            teste_colide(28, 0, 328)

        elif baixo.colliderect(c2):
            teste_colide(28, 0, 328)

        elif baixo.colliderect(c3):
            teste_colide(-270, 0, 30)

        elif baixo.colliderect(c4):
            teste_colide(-49, 0, 271)

        elif baixo.colliderect(c5):
            teste_colide(30, 0, 330)

        elif baixo.colliderect(c6):
            teste_colide(30, 0, 330)

        elif baixo.colliderect(c7):
            teste_colide(30, 0, 330)

        elif baixo.colliderect(c8):
            teste_colide(28, 0, 328)

        elif baixo.colliderect(c9):
            teste_colide(-116, 0, 197)

        elif baixo.colliderect(c10):
            teste_colide(-226, 0, 107)

        elif baixo.colliderect(c11):
            teste_colide(-190, 0, 143)

        elif baixo.colliderect(c12):
            teste_colide(-274, 0, 69)

        elif baixo.colliderect(p1):
            teste_colide(-60, 0, 240)

        elif baixo.colliderect(p1b):
            teste_colide(-28, 0, 289)

        elif baixo.colliderect(p2):
            teste_colide(-165, 0, 125)

        elif baixo.colliderect(p3):
            teste_colide(-102, 0, 182)

        elif baixo.colliderect(p4):
            teste_colide(-199, 0, 108)

        elif baixo.colliderect(p5):
            teste_colide(-169, 0, 185)

        elif baixo.colliderect(p6):
            teste_colide(-250, 0, 102)

        elif baixo.colliderect(p7):
            teste_colide(-177, 0, 200)

        elif baixo.colliderect(p8):
            teste_colide(-90, 0, 210)

        elif baixo.colliderect(p9):
            teste_colide(-140, 0, 160)
            plataforma["maria_emcima"] = True

        elif baixo.colliderect(p10):
            teste_colide(-30, 0, 278)

        elif baixo.colliderect(p11):
            teste_colide(-140, 0, 160)
            plataforma3["maria_emcima"] = True

        elif baixo.colliderect(platttt):
            teste_colide(-140, 0, 160)
            plataforma4["maria_emcima"] = True

        elif baixo.colliderect(plattt):
            teste_colide(-140, 0, 160)
            plataforma1["maria_emcima"] = True

        else:
            plataforma["maria_emcima"] = False
            plataforma1["maria_emcima"] = False
            plataforma3["maria_emcima"] = False
            plataforma4["maria_emcima"] = False

        if maria["pos"][1] > 1000 and maria["qtd_de_vidas"] > 0:
            maria["qtd_de_vidas"] -= 1
            maria["pos"][1] = -100
            parallax["posy"] = -280
            maria["vida"] = 0
            contagem_caindo = tela_h + 200
            som_morte.play()

        if maria["vida"] > 305 and maria["qtd_de_vidas"] > 0:
            maria["qtd_de_vidas"] -= 1
            maria["pos"][1] = -100
            parallax["posy"] = -280
            maria["vida"] = 0
            contagem_caindo = tela_h + 200
            som_morte.play()

        if maria["qtd_de_vidas"] <= 0:
            state = 5

    if state == 5 and maria["qtd_de_vidas"] <= 0:
        screen.blit(gme_over, (0, 0))
        som_game_over.play()
        som_jogo.stop()
        pintar_options(screen, jogar_nova)
        pintar_options(screen, sair_menu)
        cima_menu(jogar_nova, again2, again, 2, (tela_h * .25), -300, -305)
        cima_menu(sair_menu, saindo_menu2, saindo_menu, 2, (tela_h * .25), 450, 455)

    if state == 1:
        anima(maria, sprite_sheet)
        atualizar_regra_personagem(maria)

    elif state == 2:
        screen.fill((0,0,0))
        pintar_options(screen, portuges)
        pintar_options(screen, ingls)
        pintar_options(screen, close)

    elif state == 0:
        screen.blit(menu_tela_t, ((0, 0)))
        pintar_options(screen, jogar)
        pintar_options(screen, config)
        pintar_options(screen, sair)
        cima_menu(jogar, play2, play, 2, (tela_h * -.19), 55, 60)
        cima_menu(config, opcoes3, opcoes2, 2, (tela_h * -.055), 80, 85)
        cima_menu(sair, fechando4, fechando3, 2, (tela_h * .075), 47, 52)

    elif state == 10:
        exit()

    if state == 15:
        cont_ataque_boss += 1
        screen.fill((0,0,0))
        rect_boss_1 = Rect((boss["pos"][0], boss["pos"][1]),(250, 250))
        persona = Rect((maria["pos"][0], maria["pos"][1]),(100, 150))

        if boss["vida"] < 600:
            ataque += 1
            if ataque > 300:
                ataque = 0

        if boss["vida"] < 300:
            count = 100
            ataque3 += 1

        for tiro in lista_tiros:
            pintar(screen, tiro)
            if tiro["x"] > 1500 or tiro["x"] < -1500 :
                lista_tiros.remove(tiro)
            if tiro["y"] > 1500 or tiro["y"] < -1500 :
                lista_tiros.remove(tiro)

        for tiro in lista_tiros:
            movimenta(tiro)

        anima_boss(boss, mula)
        boss_regras(boss)
        ataque_boss_1(boss)
        ataque_boss_2(boss, boss_tiro1, persona, boss_tiro2)
        ataque_boss_3(boss)
        atualizar_regra_personagem_semscroll(maria)
        anima(maria, sprite_sheet)
        colisa(boss, rect_boss_1)

    elif state == 55:
        pintar_options(screen, sair_menu)
        pintar_options(screen, continuar_jogando)
        cima_menu(sair_menu, saindo_menu2, saindo_menu, 2, (tela_h * -.05), 100, 105)
        cima_menu(continuar_jogando, continu2, continu, 2, (tela_h * .15), 100, 105)

    # Pintar
    for e in pygame.event.get():
        if e.type == pygame.QUIT:
            exit()

        #teclas apertadas
        if e.type == pygame.KEYDOWN:
            if e.key == pygame.K_LALT:
                alt = 1
            if alt == 1 and e.key == pygame.K_F4:
                exit()

            if e.key == K_ESCAPE and state == 1:
                state = 55
                screen.blit(fundo_esc, (0, 0))

            elif e.key == K_ESCAPE and state == 55:
                state = 1

            if e.key == pygame.K_RIGHT and not state == 55:
                maria["state"] = "images_state_right_run"
                parallax["velx"] = 10
                maria["velX"] = 10
                right = 1
                left = 0
                if chao == True:
                    som_passos.play(-1)
                    som_passos.set_volume(.4)
                if agachado == 1:
                    maria["state"] = "images_state_down_run_right"
                    right = 2
                    left = 0
                if colidex_direita == 1:
                    parallax["velx_d"] = 0
                    maria["velX"] = 0
                if state == 6 or state == 15:
                    maria["velX"] = 15

            if e.key == pygame.K_LEFT and not state == 55:
                maria["state"] = "images_state_left_run"
                parallax["velx"] = -10
                maria["velX"] = -5
                right = 0
                left = 1
                som_passos.play(-1)
                som_passos.set_volume(.4)
                if agachado == 1:
                    maria["state"] = "images_state_down_run_left"
                    right = 0
                    left = 2
                if colidex_esquerda == 1:
                    parallax["velx"] = 0
                    maria["velX"] = 0
                if state == 6 or state == 15:
                    maria["velX"] = -15

            if e.key == pygame.K_SPACE and chao == True and not state == 55:
                parallax["vely"] = -15
                maria["velY"] = -15
                pula = 1
                pulacorno = -15
                pulando = True
                if state == 15:
                    maria["velY"] = -25
                if state == 6:
                    maria["velY"] = -18

            if e.key == K_p and chao == True and state == 6 :
                state = 1
                maria["pos"] = [500, -100]
                parallax["posy"] = -280
                som_jogo.play(-1)
                som_tutorial.stop()
                som_jogo.set_volume(.5)

            if e.key == pygame.K_UP and not state == 55:
                tiro_top = 1

            if e.key == pygame.K_DOWN and not state == 55:
                cimao = 30
                agacha = 30
                agachado = 1
                tiro_baixo = 1

                if maria["state"] == "images_state_right_run":
                    right = 2
                    left = 0

                elif maria["state"] == "images_state_right_stop":
                    right = 4
                    left = 0

                elif maria["state"] == "images_state_left_run":
                    right = 0
                    left = 2
                elif maria["state"] == "images_state_left_stop":
                    right = 0
                    left = 4

            if e.key == pygame.K_x and pode_atirar >= 8 and not state == 55:
                pode_atirar = 0
                som_tiro.play()
                som_tiro.set_volume(.5)
                atirando = True
                if tiro_top == 1:
                    tiro_tete(75, 0, 0, -50, imagem_tiro)

                elif tiro_baixo == 1:
                    tiro_tete(75, 75, 0, 50, imagem_tiro)

                elif right == 1:
                    tiro_tete(135, 68, 50, 0, imagem_tiro)
                elif right == 2:
                    tiro_tete(135, 79, 50, 0, imagem_tiro)
                elif right == 3:
                    tiro_tete(135, 50, 50, 0, imagem_tiro)
                elif right == 4:
                    tiro_tete(135, 79, 50, 0, imagem_tiro)

                elif left == 1:
                    tiro_tete(5, 68, -50, 0, imagem_tiro)
                elif left == 2:
                    tiro_tete(5, 78, -50, 0, imagem_tiro)
                elif left == 3:
                    tiro_tete(5, 50, -50, 0, imagem_tiro)
                elif left == 4:
                    tiro_tete(5, 78, -50, 0, imagem_tiro)

            if e.key == K_e:
                print(parallax["posy"])

            if e.key == K_q:
                print(maria["pos"][1])

        #teclas soltas
        if e.type == pygame.KEYUP:
            if e.key == pygame.K_LALT:
                alt = 0

            if e.key == pygame.K_RIGHT:
                maria["state"] = "images_state_right_stop"
                parallax["velx"] = 0
                maria["velX"] = 0
                right = 3
                left = 0
                som_passos.stop()
                if agachado == 1:
                    maria["state"] = "images_state_down_right"
                    right = 4
                    left = 0

            if e.key == pygame.K_LEFT:
                maria["state"] = "images_state_left_stop"
                parallax["velx"] = 0
                maria["velX"] = 0
                right = 0
                left = 3
                som_passos.stop()
                if agachado == 1:
                    maria["state"] = "images_state_down_left"
                    right = 0
                    left = 4

            if e.key == pygame.K_DOWN:
                cimao = 0
                agacha = 0
                agachado = 0
                tiro_baixo = 0
                if right == 2:
                    right = 1
                    left = 0
                elif right == 4:
                    right = 3
                    left = 0

                elif left == 2:
                    right = 0
                    left = 1
                elif left == 4:
                    right = 0
                    left = 3

            if e.key == pygame.K_UP:
                tiro_top = 0
                if right == 1 or right == 2:
                    maria["state"] = "images_state_right_run"
                elif right == 3 or right == 4:
                    maria["state"] = "images_state_right_stop"

                elif left == 1 or left == 2:
                    maria["state"] = "images_state_left_run"
                elif left == 3 or left == 4:
                    maria["state"] = "images_state_left_stop"

            # if e.key == pygame.K_SPACE:
            #     pulacorno = 0

            if e.key == K_x:
                atirando = False

        if e.type == MOUSEBUTTONDOWN:
            if state == 0:
                colisao_menu(jogar, e)
                colisao_menu(config, e)
                colisao_menu(sair, e)
            if state == 2:
                colisao_menu(ingls, e)
                colisao_menu(portuges, e)
                colisao_menu(close, e)
            if state == 55:
                colisao_menu(sair_menu, e)
                colisao_menu(continuar_jogando, e)
            if state == 5:
                colisao_menu(sair_menu, e)
                colisao_menu(jogar_nova, e)