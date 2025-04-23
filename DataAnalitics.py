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
#sinner 1 == infierno 
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

characterTypes = [np.zeros(6),np.zeros(6),np.zeros(6),np.zeros(6)]#Frases de cada tio de personaje 

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
                          orderRatings.append(obj["day"]["orden"])
                          averageChoiceTime.append(obj["day"]["time"])
                     if("character") in obj :
                          playerChoices.append(obj["character"]["judgement"])     
                          if(obj["character"]["sinner"]!= obj["character"]["judgement"]): # acierto
                             correctGuessFavor.append()
                             correctGuessSin.append()
                             characterTypes[obj["character"]["type"]][obj["character"]["sentence"]] +=1  
                             totalFavorApearance[obj["character"]["favores"]] +=1
                             totalSinAppearance[obj["character"]["pecados"]] +=1                                          
                          else:
                               wrongGuessFavors.append()
                               wrongGuessSins.append()
                     if("dayLoses" in obj):
                          dayLoses = obj["dayLoses"]

                       
                