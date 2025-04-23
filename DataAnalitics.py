import json
import os
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np

##  Leer todos los archivos
folder_path = './data'

#Pregunta 1 
#Puntuaciones del libro ordebadas cronologicamente 
orderRatings = []

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
dayLoses = np.zeros(5)#Contamos cuantas veces pierde en cada dia 

#pregunta 4 

averageChoiceTime=[]#Tiempos medios de decision de cada dia ordenados cronologicamente

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
                          orderRatings.append(obj["day"]["order"])
                          averageChoiceTime.append(obj["day"]["time"])
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
                     if("dayLoses" in obj):
                          dayLoses = obj["dayLoses"]

            print("aaargh")          
                