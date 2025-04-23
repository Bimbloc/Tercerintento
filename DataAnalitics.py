import json
import os
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np

##  Leer todos los archivos
folder_path = './data'

#Pregunta 1 
#Puntuaciones del libro ordebadas cronologicamente 
orderRatings = np.zeros(6)
#pregnta 2

#lista ordenada cronoligamente de decisiones correctas o erroneas
playerChoices =[] #[Y,N,Y,Y,N]
#jugement 1 == cielo 
#sinner 1 == cielo
#jugement != sinner es un acierto
correctGuessFavor = np.zeros(30) ##30 enteros , contamos cuantos acierto s Hay asociados a cada favor
correctGuessSin =np.zeros(30)#30 enteros , contamos cuantos aciertos Hay asociados a cada pecado
wrongGuessFavors =np.zeros(30)#30 enteros , contamos cuantos fallos Hay asociados a cada favor
wrongGuessSins =np.zeros(30)##30 enteros , contamos cuantos fallos Hay asociados a cada pecado

#pregunta 3
dayLoses = np.zeros(6)#Contamos cuantas veces pierde en cada dia 
lastDay = 0
#pregunta 4 

averageChoiceTime=[]#Tiempos medios de decision de cada dia ordenados cronologicamente
averageChoiceTime = np.zeros(6)

#pregunta 5

characterSentences = [np.zeros(6),np.zeros(6),np.zeros(6),np.zeros(6)]#Frases de cada tio de personaje 
characterTypes = np.zeros(4)
#pregunta 6
#Sumamos apariciones en aciertos y en fallos 
totalFavorApearance = np.zeros(30)
totalSinAppearance = np.zeros(30)
    
for file_name in os.listdir(folder_path):
        
        if file_name.endswith('.json'):  # Process only JSON files
            file_path = os.path.join(folder_path, file_name)

            print(f"Processing file: {file_name}")

            # Leer Contenidos de cada archivo
            with open(file_path, 'r') as file:
                data = json.load(file)
                
                for obj in data : 
                     if("day") in obj :
                          orderRatings[obj["day"]["number"]-1] += obj["day"]["order"]
                          averageChoiceTime[obj["day"]["number"]-1] += obj["day"]["time"]
                          lastDay = obj["day"]["number"]-1
                     if("character") in obj :
                          playerChoices.append(obj["character"]["judgement"])     
                          if(obj["character"]["sinner"]== obj["character"]["judgement"]): # acierto
                             for f in obj["character"]["favores"]:
                                correctGuessFavor[f]+=1
                                totalFavorApearance[f] +=1
                             for p in obj["character"]["pecados"]:
                                correctGuessSin[p]+=1
                                totalSinAppearance[p] +=1 
                             characterSentences[obj["character"]["type"]][obj["character"]["sentence"]] +=1  
                             characterTypes[obj["character"]["type"]]+=1
                             totalSinAppearance[obj["character"]["pecados"]] +=1                                          
                          else:
                               for f in obj["character"]["favores"]:
                                wrongGuessFavors[f]+=1
                                totalFavorApearance[f] +=1
                               for p in obj["character"]["pecados"]:
                                 wrongGuessSins[p]+=1
                                 totalSinAppearance[p] +=1
                     if ("final" in obj):
                        if (obj["final"]["final"] == 4):
                           dayLoses[lastDay] += 1

#Con los datos de cada partida obtenemos graficas
plt.title("Niveles de Orden")
days = list(range(1,len(orderRatings)+1))
plt.xticks(days)
plt.bar(days,orderRatings)
plt.show()

numvars = np.arange(0,30)
plt.title("Pecados Aciertos")
plt.xticks(numvars)
plt.bar(numvars,correctGuessSin)
plt.show()
plt.title("Pecados Fallos")
plt.xticks(numvars)
plt.bar(numvars,wrongGuessSins)
plt.show()
plt.title("Favores Aciertos")
plt.xticks(numvars)
plt.bar(numvars,correctGuessFavor)
plt.show()
plt.title("Favores Fallos")
plt.xticks(numvars)
plt.bar(numvars,wrongGuessFavors)
plt.show()

plt.title("Derrotas por dia")
plt.xticks(np.arange( 1,len(dayLoses)+1))
plt.bar(np.arange(1,len(dayLoses)+1),dayLoses)
plt.show()

plt.title("Tiempo por dia")
plt.xticks(days)
plt.bar(days,averageChoiceTime)
plt.show()

plt.title("Personajes por tipo")
plt.xticks(np.arange(0,len(characterTypes)))
plt.bar(np.arange(0,len(characterTypes)),characterTypes)
plt.show()

charCounter = 0
for char in characterSentences:
      plt.title("Frases Tipo " + str(charCounter))
      plt.xticks(np.arange(0,len(char)))
      plt.bar(np.arange(0,len(char)),char)
      plt.show()
      charCounter+=1

plt.title("Favores totales")
plt.xticks(numvars)
plt.bar(numvars,totalFavorApearance)
plt.show()

plt.title("Pecados Total")
plt.xticks(numvars)
plt.bar(numvars,totalSinAppearance)
plt.show()    
                  
                